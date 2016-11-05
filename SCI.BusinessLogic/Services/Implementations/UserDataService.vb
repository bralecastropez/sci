Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SCI.BusinessObjects.Models
Imports SCI.Infrastructure.Helpers

Namespace SCI.BusinessLogic.Services
    Public Class UserDataService
        Implements IUserDataService

        Public Function GetUserByUserName(ByVal UserName As String) As Usuario Implements IUserDataService.GetUserByUserName
            Dim Resultado As New Usuario
            Try
                Resultado = (From u In DataContext.DBEntities.Usuario Where u.Nick = UserName).FirstOrDefault
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
            Return Resultado
        End Function

        Private Function VerifyUserAndPassword(ByVal UserName As String, ByVal Password As String) As Boolean
            Dim Resultado = False
            Try
                Dim usuario As Usuario = (From u In DataContext.DBEntities.Usuario Where u.Nick = UserName And u.Pass = Password).FirstOrDefault
                If Not usuario.Nick Is Nothing Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Catch ex As Exception
                Resultado = False
                'Throw New Exception(ex.Message, ex.InnerException)
            End Try
            Return Resultado
        End Function

        Public Function Login(ByVal UserName As String, ByVal LoginPassword As String) As Boolean Implements IUserDataService.Login
            Dim errMsg As String = String.Empty
            Dim user As Usuario = Nothing

            Dim sUserName As String = Trim(UserName)
            Dim sLoginPassword As String = Trim(LoginPassword)
            Dim principal As IPrincipal

            Try
                user = GetUserByUserName(sUserName)
                If user Is Nothing Then
                    errMsg += "El nombre de usuario no es valido. Por favor Intente de Nuevo"
                    Throw New Exception(errMsg)
                End If
                If VerifyUserAndPassword(sUserName, CryptoHelper.ObtenerPassword(sLoginPassword)) Then
                    Dim nombreUsuario As String = user.Nick

                    Dim roleList As New List(Of String)
                    Dim sRoleList() As String = Nothing
                    Dim roles = (From r In DataContext.DBEntities.Rol
                                 Join u In DataContext.DBEntities.Usuario
                                 On r.IdRol Equals u.IdRol
                                 Where u.Nick = sUserName
                                 Select r)

                    If roles Is Nothing Then
                        errMsg += "Este usuario no tiene roles asignados. Por favor intente de nuevo"
                        Throw New Exception(errMsg)
                    End If

                    Dim i As Integer = 0

                    For Each r In roles
                        roleList.Add(r.IdRol)
                        i += 1
                    Next

                    Dim idRole As Integer = CInt(roleList(0).ToString)

                    Dim modules = (From r In DataContext.DBEntities.Rol
                                   Where r.IdRol = idRole
                                   Select r.Modulo)

                    Dim moduleList As New List(Of String)

                    For Each modu In modules
                        For Each m In modu
                            MsgBox(m.Descripcion)
                            moduleList.Add(m.Descripcion)
                        Next
                    Next

                    Dim moduleStringArray() As String = moduleList.ToArray

                    Dim identity As New IdentityBusinessObject(user.Nick, "Custom")
                    principal = New PrincipleBusinessObject(identity, roleList)
                    LoggedInUser.GetInstance.UserLogged = user
                    'Throw New Exception(errMsg)
                Else
                    Dim identity As New IdentityBusinessObject("", "")
                    principal = New PrincipleBusinessObject(identity, Nothing)
                    errMsg += "Contraseña incorrecta. Por favor intente de nuevo"
                    Throw New Exception(errMsg)
                End If
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

    End Class
End Namespace


Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Data.Entity
Imports SCI.BusinessObjects.Models
Imports SCI.Infrastructure.Helpers

Namespace SCI.BusinessLogic.Services
    Public Class UsuarioDataService
        Implements IUsuarioDataService

        Public Function GetUserByUserName(ByVal UserName As String) As Usuario Implements IUsuarioDataService.GetUserByUserName
            Dim Resultado As Usuario = Nothing
            Try
                Dim Usuario As Usuario = (From u In DataContext.DBEntities.Usuario Where u.Nick = UserName).FirstOrDefault
                Resultado.IdUsuario = Usuario.IdUsuario
                Resultado.IdEmpleado = Usuario.IdEmpleado
                Resultado.IdRol = Usuario.IdRol
                Resultado.Nick = Usuario.Nick
                Resultado.Pass = Usuario.Pass
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
            Return Resultado
        End Function

        Private Function VerifyUserAndPassword(ByVal UserName As String, ByVal Password As String) As Boolean
            Dim Resultado = False
            Try
                Dim usuario = (From u In DataContext.DBEntities.Usuario Where u.Nick = UserName And u.Pass = Password).FirstOrDefault
                Resultado = True
            Catch ex As Exception
                Resultado = False
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
            Return Resultado
        End Function

        Public Function Login(ByVal UserName As String, ByVal LoginPassword As String) As Boolean Implements IUsuarioDataService.Login
            Dim errMsg As String = String.Empty
            Dim user As Usuario = Nothing

            Dim sUserName As String = Trim(UserName)
            Dim sLoginPassword As String = CryptoHelper.ObtenerPassword(Trim(LoginPassword))
            Dim principal As IPrincipal

            Try
                user = GetUserByUserName(sUserName)
                If user Is Nothing Then
                    errMsg += "El nombre de usuario no es valido. Por favor Intente de Nuevo"
                    Throw New Exception(errMsg)
                Else
                    If VerifyUserAndPassword(sUserName, sLoginPassword) Then

                        '    Dim roleList As New List(Of String)
                        '    Dim sRoleList() As String = Nothing
                        '    Dim roles = (From r In DataContext.DBEntities.Rol
                        '                 Join u In DataContext.DBEntities.Usuario
                        '                 On r.IdRol Equals u.IdRol
                        '                 Where u.Nick = sUserName
                        '                 Select r)

                        '    If roles Is Nothing Then
                        '        errMsg += "Este usuario no tiene roles asignados. Por favor intente de nuevo"
                        '        MsgBox(errMsg)
                        '        Throw New Exception(errMsg)
                        '    End If

                        '    Dim i As Integer = 0

                        '    For Each r In sRoleList
                        '        roleList.Add(r)
                        '        i += 1
                        '    Next

                        '    Dim idRole As Integer = CInt(roleList(0).ToString)

                        '    Dim modules = (From r In DataContext.DBEntities.Rol
                        '                   Where r.IdRol = idRole
                        '                   Select r.Modulo)

                        '    Dim moduleList As New List(Of String)

                        '    For Each modu In modules
                        '        For Each m In modu
                        '            moduleList.Add(m.Descripcion)
                        '        Next
                        '    Next

                        '    Dim moduleStringArray() As String = moduleList.ToArray

                        '    Dim identity As New IdentityBusinessObject(user.Nick, "Custom")
                        '    principal = New PrincipleBusinessObject(identity, roleList)
                    Else
                        Dim identity As New IdentityBusinessObject("", "")
                        principal = New PrincipleBusinessObject(identity, Nothing)
                        errMsg += "Contraseña incorrecta. Por favor intente de nuevo"
                        MsgBox(errMsg)
                        Throw New Exception(errMsg)
                    End If
                    Return True
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
                Return False
            End Try
        End Function

    End Class
End Namespace


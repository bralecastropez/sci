Imports System.Text.RegularExpressions
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessObjects.Validators
    Public Class ModelValidator
#Region "Fields"
        Private Shared _Instance As ModelValidator
#End Region
#Region "Properties"
        Public Shared Function GetInstance() As ModelValidator
            If IsNothing(_Instance) Then
                _Instance = New ModelValidator
            End If
            Return _Instance
        End Function
#End Region
#Region "Constructors"
        Private Sub New()
        End Sub
#End Region
#Region "Functions"
        Public Function ValidateEmail(ByVal Email As String) As Boolean
            Dim Result As Boolean = False
            Try
                If Not String.IsNullOrWhiteSpace(Email) Then
                    If Regex.IsMatch(Email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
                        Result = True
                    End If
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error en 'ValidateEmail'")
            End Try
            Return Result
        End Function
        Public Function ValidateEmpty(ByVal Field As String) As Boolean
            Dim Result As Boolean = False
            Try
                If Not Field.Trim("") = "" Then
                    Result = True
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error en 'ValidateEmail'")
            End Try
            Return Result
        End Function
        Public Function ValidateNit(ByVal Nit As String) As Boolean
            Dim Result As Boolean = False
            Try
                If Not String.IsNullOrWhiteSpace(Nit) Then
                    '
                    Dim pos As Integer = Nit.IndexOf("-")
                    Dim Correlativo As String = Nit.Substring(0, pos)
                    Dim DigitoVerificador As String = Nit.Substring(pos + 1)
                    Dim Factor As Integer = Correlativo.Length + 1
                    Dim Suma As Integer = 0
                    Dim Valor As Integer = 0

                    For x As Integer = 0 To Nit.IndexOf("-") - 1
                        Valor = CInt(Nit.Substring(x, 1))
                        Suma = Suma + (Valor * Factor)
                        Factor = Factor - 1
                    Next

                    Dim xMOd11 As Double
                    xMOd11 = (11 - (Suma Mod 11)) Mod 11
                    Dim s As String = Str(xMOd11)

                    If (xMOd11 = 10 And DigitoVerificador = "K") Or (s.Trim = DigitoVerificador) Then
                        Result = True
                    Else
                        Result = False
                    End If
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error en 'ValidateEmail'")
            End Try
            Return Result
        End Function
#End Region
    End Class
End Namespace

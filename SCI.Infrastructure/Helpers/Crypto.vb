Imports System.Text
Imports System.Security.Cryptography
Imports SCI.Infrastructure.Util

Namespace SCI.Infrastructure.Helpers
    Public Class CryptoHelper
#Region "Functions"
        Public Shared Function GeneratePassword(ByVal StrPass As String) As String
            Dim Result As String = ""
            Try
                Dim md5 As New MD5CryptoServiceProvider
                Dim bytValue() As Byte
                Dim bytHash() As Byte
                Dim i As Integer

                bytValue = Encoding.UTF8.GetBytes(StrPass)

                bytHash = md5.ComputeHash(bytValue)
                md5.Clear()

                For i = 0 To bytHash.Length - 1
                    Result &= bytHash(i).ToString("x").PadLeft(2, "0")
                Next
            Catch ex As Exception
                SCILog.Instance.Control(ex, "Crytpo", "Error al Generar Contraseña")
            End Try
            Return Result
        End Function
        Public Shared Function EncryptPassword(ByVal Password As String) As String
            Dim Result As String = ""
            Try
                Result = StrReverse(GeneratePassword(Password))
            Catch ex As Exception
                SCILog.Instance.Control(ex, "Crytpo", "Error al Encriptar Contraseña")
            End Try
            Return Result
        End Function
        Public Shared Function GetPassword(ByVal Password As String) As String
            Dim Result As String = ""
            Try
                Result = EncryptPassword(Password)
            Catch ex As Exception
                SCILog.Instance.Control(ex, "Crytpo", "Error al Obtener la Contraseña")
            End Try
            Return Result
        End Function
        Public Shared Function Verify(ByVal User As String, ByVal Pass As String)
            Return True
        End Function
#End Region
    End Class
End Namespace


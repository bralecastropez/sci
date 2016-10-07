Imports System
Imports System.Text
Imports System.Security.Cryptography

Namespace SCI.Infrastructure.Helpers
    Public Class CryptoHelper
        Public Shared Function GenerarPassword(ByVal StrPass As String) As String
            Dim Resultado As String = ""
            Try
                Dim md5 As New MD5CryptoServiceProvider
                Dim bytValue() As Byte
                Dim bytHash() As Byte
                Dim i As Integer

                bytValue = Encoding.UTF8.GetBytes(StrPass)

                bytHash = md5.ComputeHash(bytValue)
                md5.Clear()

                For i = 0 To bytHash.Length - 1
                    Resultado &= bytHash(i).ToString("x").PadLeft(2, "0")
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Resultado
        End Function

        Public Shared Function EncriptarPassword(ByVal Password As String) As String
            Dim Resultado As String = ""
            Try
                Resultado = StrReverse(GenerarPassword(Password))
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Resultado
        End Function

        Public Shared Function ObtenerPassword(ByVal Password As String) As String
            Dim Resultado As String = ""
            Try
                Resultado = EncriptarPassword(Password)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Return Resultado
        End Function

        Public Shared Function Verify(ByVal User As String, ByVal Pass As String)
            Return True
        End Function
    End Class
End Namespace


Imports System.Globalization
Imports System.Windows.Controls
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessObjects.Validators
    Public Class NitValidationRule
        Inherits ValidationRule

        Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult
            Dim Result As ValidationResult
            Try
                If String.IsNullOrWhiteSpace(value.ToString) Then
                    Result = New ValidationResult(False, "Este campo es requerido")
                Else
                    If ValidarNit(value.ToString) Then
                        Result = ValidationResult.ValidResult
                    Else
                        Result = New ValidationResult(False, "Este nit es invalido")
                    End If
                End If
            Catch ex As Exception
                Result = New ValidationResult(False, "Este campo es requerido")
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al validar campo")
            End Try
            Return Result
        End Function

        Public Function ValidarNit(ByVal Nit As String) As Boolean
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
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace

Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Controls
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessObjects.Validators
    Public Class EmailValidationRule
        Inherits ValidationRule

        Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult
            Dim Result As ValidationResult
            Try
                If String.IsNullOrWhiteSpace(value.ToString) Then
                    Result = New ValidationResult(False, "Este campo es requerido")
                Else
                    If Regex.IsMatch(value.ToString, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
                        Result = ValidationResult.ValidResult
                    Else
                        Result = New ValidationResult(False, "Este correo electrónico ingresado es invalido")
                    End If
                End If
            Catch ex As Exception
                Result = New ValidationResult(False, "Este campo es requerido")
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al validar campo")
            End Try
            Return Result
        End Function
    End Class
End Namespace
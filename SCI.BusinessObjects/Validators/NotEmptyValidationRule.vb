Imports System.Globalization
Imports System.Windows.Controls
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessObjects.Validators
    Public Class NotEmptyValidationRule
        Inherits ValidationRule

        Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult
            Dim Result As ValidationResult
            Try
                If Not String.IsNullOrEmpty(value.ToString) Then
                    If value.ToString.Trim(" ").Replace(" ", "") = "" Then
                        Result = New ValidationResult(False, "Este campo es requerido")
                    Else
                        Result = ValidationResult.ValidResult
                    End If
                Else
                    Result = New ValidationResult(False, "Este campo es requerido")
                End If
            Catch ex As Exception
                Result = New ValidationResult(False, "Este campo es requerido")
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al validar campo")
            End Try
            Return Result
        End Function
    End Class
End Namespace
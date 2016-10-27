Namespace SCI.BusinessLogic.Services
    Public Class EmployeeDataService
        Implements IEmployeeDataService

        Public Function GetEmployees() As List(Of Empleado) Implements IEmployeeDataService.GetEmployees
            Dim Resultado As List(Of Empleado) = Nothing
            Try
                Resultado = DataContext.DBEntities.Empleado.ToList
            Catch ex As Exception
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Listar")
            End Try
            Return Resultado
        End Function
    End Class
End Namespace

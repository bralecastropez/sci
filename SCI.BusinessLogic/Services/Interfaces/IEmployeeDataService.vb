Namespace SCI.BusinessLogic.Services
    Public Interface IEmployeeDataService

        Function GetEmployees() As List(Of Empleado)
        Function AddEmployee(ByVal Employee As Empleado)
        Function EditEmployee(ByVal Employee As Empleado)
        Function DeleteEmployee(ByVal Employee As Empleado)
        Function SearchEmployee(ByVal Data As String) As List(Of Empleado)

    End Interface
End Namespace

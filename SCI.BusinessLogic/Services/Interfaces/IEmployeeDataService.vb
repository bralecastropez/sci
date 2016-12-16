Namespace SCI.BusinessLogic.Services
    Public Interface IEmployeeDataService

        Function GetEmployees() As List(Of Employee)
        Function AddEmployee(ByVal Employee As Employee) As Boolean
        Function EditEmployee(ByVal Employee As Employee) As Boolean
        Function DeleteEmployee(ByVal Employee As Employee) As Boolean
        Function SearchEmployee(ByVal Data As String) As List(Of Employee)

    End Interface
End Namespace

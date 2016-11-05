Namespace SCI.BusinessLogic.Services
    Public Interface ICustomerDataService
        Function Add(ByVal Cliente As Cliente) As Boolean
        Function Edit(ByVal Cliente As Cliente) As Boolean
        Function Delete(ByVal Cliente As Cliente) As Boolean
        Function GetCustomers() As List(Of Cliente)
        Function Search(ByVal Valor As String) As List(Of Cliente)
    End Interface
End Namespace

Namespace SCI.BusinessLogic.Services
    Public Interface ICustomerDataService
        Function AddCustomer(ByVal Customer As Customer) As Boolean
        Function EditCustomer(ByVal Customer As Customer) As Boolean
        Function DeleteCustomer(ByVal Customer As Customer) As Boolean
        Function GetCustomers() As List(Of Customer)
        Function SearchCustomer(ByVal Data As String) As List(Of Customer)
    End Interface
End Namespace
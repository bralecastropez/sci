Namespace SCI.BusinessLogic.Services
    Public Interface IProviderDataService
        Function GetProviders() As List(Of Provider)
        Function AddProvider(ByVal Provider As Provider) As Boolean
        Function EditProvider(ByVal Provider As Provider) As Boolean
        Function DeleteProvider(ByVal Provider As Provider) As Boolean
        Function SearchProvider(ByVal Data As String) As List(Of Provider)
    End Interface
End Namespace
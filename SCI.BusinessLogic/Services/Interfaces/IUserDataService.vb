Namespace SCI.BusinessLogic.Services
    Public Interface IUserDataService
        Function GetUserByUserName(ByVal UserName As String) As Reader
        Function Login(ByVal UserName As String, ByVal LoginPassword As String) As Boolean

    End Interface
End Namespace


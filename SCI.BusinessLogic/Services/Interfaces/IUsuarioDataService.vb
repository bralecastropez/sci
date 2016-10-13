Namespace SCI.BusinessLogic.Services
    Public Interface IUsuarioDataService
        Function GetUserByUserName(ByVal UserName As String) As Usuario
        Function Login(ByVal UserName As String, ByVal LoginPassword As String) As Boolean

    End Interface
End Namespace


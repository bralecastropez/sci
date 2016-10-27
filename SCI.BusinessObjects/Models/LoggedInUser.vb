Namespace SCI.BusinessObjects.Models
    Public Class LoggedInUser
        Private Shared _instance As LoggedInUser = Nothing
        Private Shared _userLogged As Usuario
        Public Shared Property UserLogged() As Usuario
            Get
                Return _userLogged
            End Get
            Set(ByVal value As Usuario)
                _userLogged = value
            End Set
        End Property
        Public Sub New()

        End Sub

        Public Shared Function GetInstance() As LoggedInUser
            If _instance Is Nothing Then
                _instance = New LoggedInUser
            End If
            Return _instance
        End Function

    End Class
End Namespace

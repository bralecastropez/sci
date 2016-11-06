Imports System.Security.Principal
Namespace SCI.BusinessObjects.Models
    Public Class PrincipleBusinessObject
        Implements IPrincipal
#Region "Fields"
        Private _roles As New List(Of String)()
        Private _identity As IdentityBusinessObject
#End Region
#Region "Properties"
        Public Property Roles() As List(Of String)
            Get
                Return _roles
            End Get
            Set(ByVal value As List(Of String))
                _roles = value
            End Set
        End Property

        Public Sub New(ByVal identity As IdentityBusinessObject, ByVal roles As List(Of String))
            _identity = identity
            _roles = roles
        End Sub

        Public ReadOnly Property Identity() As IIdentity Implements IPrincipal.Identity
            Get
                Return _identity
            End Get
        End Property

        Public Function IsInRole(ByVal role As String) As Boolean Implements IPrincipal.IsInRole
            Return Roles.Contains(role)
        End Function
#End Region
    End Class
End Namespace
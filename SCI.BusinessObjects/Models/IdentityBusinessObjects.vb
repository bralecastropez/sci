Imports System.Security.Principal

Namespace SCI.BusinessObjects.Models

    Public Class IdentityBusinessObject
        Implements IIdentity
#Region "Fields"
        Private _nombreUsuario As String = String.Empty
        Private _authType As String = String.Empty
        Private _isAuth As Boolean = False
#End Region
#Region "Properties"
        Public Sub New(ByVal userName As String, ByVal authenticationType As String)
            _nombreUsuario = userName
            _authType = authenticationType
        End Sub

        Public ReadOnly Property UserName() As Integer
            Get
                Return _nombreUsuario
            End Get
        End Property
#End Region
#Region "IIdentity Members"

        Public ReadOnly Property AuthenticationType() As String Implements IIdentity.AuthenticationType
            Get
                Return _authType
            End Get
        End Property

        Public ReadOnly Property IsAuthenticated() As Boolean Implements IIdentity.IsAuthenticated
            Get
                Return _isAuth
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements IIdentity.Name
            Get
                Return _nombreUsuario
            End Get
        End Property
#End Region
    End Class

End Namespace

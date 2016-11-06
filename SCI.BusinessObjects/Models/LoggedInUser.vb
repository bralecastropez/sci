﻿Namespace SCI.BusinessObjects.Models
    Public Class LoggedInUser
#Region "Fields"
        Private Shared _instance As LoggedInUser = Nothing
        Private Shared _userLogged As Usuario
        Private Shared _isAuth As Boolean = False
        Private Shared _modules As List(Of Modulo)
#End Region
#Region "Properties"
        Public Shared Property UserLogged() As Usuario
            Get
                Return _userLogged
            End Get
            Set(ByVal value As Usuario)
                _userLogged = value
            End Set
        End Property
        Public Property IsAuth As Boolean
            Get
                Return _isAuth
            End Get
            Set(value As Boolean)
                _isAuth = value
            End Set
        End Property
        Public Property Modulos As List(Of Modulo)
            Get
                Return _modules
            End Get
            Set(value As List(Of Modulo))
                _modules = value
            End Set
        End Property
#End Region
#Region "Methods"
        Public Shared Function GetInstance() As LoggedInUser
            If _instance Is Nothing Then
                _instance = New LoggedInUser
            End If
            Return _instance
        End Function
#End Region
#Region "Constructors"
        Private Sub New()

        End Sub
        Public Sub New(ByVal Auth As Boolean, ByVal User As Usuario, ByVal Modules As List(Of Modulo))
            IsAuth = Auth
            UserLogged = User
            Modulos = Modules
        End Sub
#End Region
    End Class
End Namespace
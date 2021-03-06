﻿Namespace SCI.BusinessObjects.Models
    Public Class LogonConfig
#Region "Fields"
        Private Shared _Instance As LogonConfig = Nothing
        Private Shared _userLogged As Reader
        Private Shared _isAuth As Boolean = False
        Private Shared _modules As List(Of [Module])
        Private Shared _headerTitle As String
#End Region
#Region "Properties"
        Public Shared Property UserLogged() As Reader
            Get
                Return _userLogged
            End Get
            Set(ByVal value As Reader)
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
        Public Property Modulos As List(Of [Module])
            Get
                Return _modules
            End Get
            Set(value As List(Of [Module]))
                _modules = value
            End Set
        End Property
        Public Property HeaderTitle As String
            Get
                Return _headerTitle
            End Get
            Set(value As String)
                _headerTitle = value
            End Set
        End Property
#End Region
#Region "Methods"
        Public Shared Function Instance() As LogonConfig
            If _Instance Is Nothing Then
                _Instance = New LogonConfig
            End If
            Return _Instance
        End Function
#End Region
#Region "Constructors"
        Private Sub New()

        End Sub
        Public Sub New(ByVal Auth As Boolean, ByVal User As Reader, ByVal Modules As List(Of [Module]))
            IsAuth = Auth
            UserLogged = User
            Modulos = Modules
        End Sub
#End Region
    End Class
End Namespace

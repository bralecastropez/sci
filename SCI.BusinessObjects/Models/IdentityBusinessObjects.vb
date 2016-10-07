Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Principal

Namespace SCI.BusinessObjects.Models

    Public Class IdentityBusinessObject
        Implements IIdentity

        Private _nombreUsuario As String = String.Empty
        Private _authType As String = String.Empty
        Private _isAuth As Boolean = False

        Public Sub New(ByVal userName As String, ByVal authenticationType As String)
            _nombreUsuario = userName
            _authType = authenticationType
        End Sub

        Public ReadOnly Property UserName() As Integer
            Get
                Return Me._nombreUsuario
            End Get
        End Property

#Region "IIdentity Members"

        Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
            Get
                Return _authType
            End Get
        End Property

        Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
            Get
                Return _isAuth
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
            Get
                Return _nombreUsuario
            End Get
        End Property

#End Region
    End Class

End Namespace

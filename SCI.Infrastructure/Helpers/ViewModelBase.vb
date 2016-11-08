Imports System.ComponentModel

Namespace SCI.Infrastructure.Helpers
    Public Class ViewModelBase
        Implements INotifyPropertyChanged
#Region "Fields"
        Private _myServiceLocator As New ServiceLocator
        Private _privateThrowOnInvalidPropertyName As Boolean
        Private _privateDisplayName As String
#End Region
#Region "Properties"
        Protected Overridable Property ThrowOnInvalidPropertyName() As Boolean
            Get
                Return _privateThrowOnInvalidPropertyName
            End Get
            Set(ByVal value As Boolean)
                _privateThrowOnInvalidPropertyName = value
            End Set
        End Property
        Public Overridable Property DisplayName() As String
            Get
                Return _privateDisplayName
            End Get

            Protected Set(ByVal value As String)
                _privateDisplayName = value
            End Set
        End Property
#End Region
#Region "Methods"
        <Conditional("DEBUG"), DebuggerStepThrough()>
        Public Sub VerifyPropertyName(ByVal propertyName As String)
            ' Verify that the property name matches a real,
            ' public, instance property on this object.
            If TypeDescriptor.GetProperties(Me)(propertyName) Is Nothing Then
                Dim msg As String = "Invalid property name: " & propertyName

                If Me.ThrowOnInvalidPropertyName Then
                    Throw New Exception(msg)
                Else
                    Debug.Fail(msg)
                End If
            End If
        End Sub
#End Region
#Region "Functions"
        Public Function ServiceLocator() As ServiceLocator
            Return Me._myServiceLocator
        End Function

        Public Function GetService(Of T)() As T
            Return _myServiceLocator.GetService(Of T)()
        End Function
#End Region
#Region "Events"
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
#End Region
#Region "Contructors"
        Protected Sub OnPropertyChanged(ByVal strPropertyName As String)
            If Me.PropertyChangedEvent IsNot Nothing Then
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(strPropertyName))
            End If
        End Sub
#End Region
    End Class
End Namespace

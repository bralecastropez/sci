Imports SCI.Infrastructure.Helpers

Namespace SCI.BusinessObjects.Domain
    Public Class ItemMenu
        Inherits ViewModelBase
#Region "Fields"
        Private _Name As String
        Private _Content As Object
#End Region
#Region "Properties"
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
                OnPropertyChanged("Name")
            End Set
        End Property
        Public Property Content As Object
            Get
                Return _Content
            End Get
            Set(ByVal value As Object)
                _Content = value
                OnPropertyChanged("Content")
            End Set
        End Property
#End Region
#Region "Constructors"
        Sub New(ByVal Name As String, ByVal Content As Object)
            Me.Name = Name
            Me.Content = Content
        End Sub

#End Region
    End Class

End Namespace
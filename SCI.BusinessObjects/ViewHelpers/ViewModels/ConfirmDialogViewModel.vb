Imports SCI.Infrastructure.Helpers

Namespace SCI.BusinessObjects.ViewHelpers.ViewModels
    Public Class ConfirmDialogViewModel
        Inherits ViewModelBase
#Region "Fields"
        Private _Title As String
        Private _Content As String
        Private _ButtonContent As String
#End Region
#Region "Properties"
        Public Property ButtonContent() As String
            Get
                Return _ButtonContent
            End Get
            Set(ByVal value As String)
                _ButtonContent = value
            End Set
        End Property
        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property
        Public Property Content() As String
            Get
                Return _Content
            End Get
            Set(ByVal value As String)
                _Content = value
            End Set
        End Property
#End Region
#Region "Contructors"
        Sub New(ByVal Title As String, ByVal Content As String, ByVal ButtonContent As String)
            Me.Title = Title
            Me.Content = Content
            Me.ButtonContent = ButtonContent
        End Sub
#End Region
    End Class
End Namespace

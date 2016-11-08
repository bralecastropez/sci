Imports SCI.BusinessObjects.ViewHelpers.ViewModels

Namespace SCI.BusinessObjects.ViewHelpers.Views
    Public Class ConfirmDialogView
        Sub New(ByVal Title As String, ByVal Content As String, ByVal ButtonContent As String)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New ConfirmDialogViewModel(Title, Content, ButtonContent)
        End Sub
    End Class
End Namespace
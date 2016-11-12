Imports SCI.Modules.Category.ViewModels
Imports System.Windows.Controls

Namespace SCI.Modules.Category.Views
    Public Class CategoryView

        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New CategoryViewModel
        End Sub

        Private Sub SearchBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

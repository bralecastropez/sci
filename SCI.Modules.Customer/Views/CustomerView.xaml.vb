Imports System.Windows.Controls
Imports SCI.Modules.Customer.ViewModels

Namespace SCI.Modules.Customer.Views
    Public Class CustomerView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New CustomerViewModel
        End Sub
        Private Sub SearchBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

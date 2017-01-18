Imports SCI.Modules.Inventory.ViewModels
Imports System.Windows.Controls

Namespace SCI.Modules.Inventory.Views
    Public Class InventoryView

        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New InventoryViewModel
        End Sub

        Private Sub SearchBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

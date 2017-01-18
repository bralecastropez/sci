Imports SCI.Modules.Inventory.ViewModels

Namespace SCI.Modules.Inventory.Views
    Public Class CrudInventoryView
        Sub New(ByVal ViewModel As InventoryViewModel)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = ViewModel
            ViewModel.PrintDialog = DialogHost
        End Sub

    End Class
End Namespace

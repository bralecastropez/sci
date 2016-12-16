Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.BranchOffice.ViewModels

Namespace SCI.Modules.BranchOffice.Views
    Public Class CrudBranchOfficeView
        Dim DViewModel As BranchOfficeViewModel
        Sub New(ByVal ViewModel As BranchOfficeViewModel)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = ViewModel
            DViewModel = ViewModel
            DViewModel.PrintDialog = DialogHost
        End Sub

        Private Sub DialogHost_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles DialogHost.Loaded
            DViewModel.PrintDialog = DialogHost
        End Sub
    End Class
End Namespace

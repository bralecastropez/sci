Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Provider.ViewModels

Namespace SCI.Modules.Provider.Views
    Public Class CrudProviderView
        Dim DViewModel As ProviderViewModel
        Sub New(ByVal ViewModel As ProviderViewModel)

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

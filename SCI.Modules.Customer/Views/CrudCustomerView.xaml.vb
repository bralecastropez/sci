Imports SCI.Modules.Customer.ViewModels

Namespace SCI.Modules.Customer.Views
    Public Class CrudCustomerView
        Dim _ViewModel As CustomerViewModel
        Sub New(ByVal ViewModel As CustomerViewModel)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = ViewModel
            _ViewModel = ViewModel
        End Sub

        Private Sub DialogHost_Loaded(sender As Object, e As System.Windows.RoutedEventArgs) Handles DialogHost.Loaded
            _ViewModel.PrintDialog = DialogHost
        End Sub
    End Class
End Namespace

Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Employee.ViewModels

Namespace SCI.Modules.Employee.Views
    Public Class CrudEmployeeView
        Dim DViewModel As EmployeeViewModel
        Sub New(ByVal ViewModel As EmployeeViewModel)

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

Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Employee.ViewModels

Namespace SCI.Modules.Employee.Views
    Public Class CrudEmployeeView
        Sub New(ByVal ViewModel As EmployeeViewModel)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = ViewModel
        End Sub
    End Class
End Namespace

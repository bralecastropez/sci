Imports SCI.Modules.Dashboard.ViewModels

Namespace SCI.Modules.Dashboard.Views
    Public Class DashboardView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New DashboardViewModel
        End Sub
    End Class
End Namespace

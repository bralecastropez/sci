Imports SCI.Modules.Employee.ViewModels

Namespace SCI.Modules.Employee.Views
    Public Class EmployeeView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New EmployeeViewModel()
        End Sub
        Private Sub SearchBox_TextChanged(sender As Object, e As System.Windows.Controls.TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

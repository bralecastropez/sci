Imports System.Windows.Controls
Imports SCI.Modules.BranchOffice.ViewModels

Namespace SCI.Modules.BranchOffice.Views
    Public Class BranchOfficeView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New BranchOfficeViewModel()
        End Sub
        Private Sub SearchBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

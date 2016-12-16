Imports System.Windows.Controls
Imports SCI.Modules.Provider.ViewModels

Namespace SCI.Modules.Provider.Views
    Public Class ProviderView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New ProviderViewModel()
        End Sub
        Private Sub SearchBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles SearchBox.TextChanged
            SearchButton.Command.Execute(SearchBox.Text)
        End Sub
    End Class
End Namespace

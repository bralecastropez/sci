Imports SCI.Modules.Category.ViewModels

Namespace SCI.Modules.Category.Views
    Public Class CategoryView

        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New CategoryViewModel
        End Sub

    End Class
End Namespace

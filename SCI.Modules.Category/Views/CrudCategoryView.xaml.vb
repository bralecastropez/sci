Imports SCI.Modules.Category.ViewModels

Namespace SCI.Modules.Category.Views
    Public Class CrudCategoryView
        Sub New(ByVal ViewModel As CategoryViewModel)

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = ViewModel
        End Sub
    End Class
End Namespace

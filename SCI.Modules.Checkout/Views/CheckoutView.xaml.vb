Imports SCI.Modules.Checkout.ViewModels

Namespace SCI.Modules.Checkout.Views
    Public Class CheckoutView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New CheckoutViewModel()
        End Sub
    End Class
End Namespace
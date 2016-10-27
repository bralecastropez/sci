Imports SCI.Modules.UserLogin.ViewModels

Namespace SCI.Modules.UserLogin.Views
    Public Class UserLoginView
        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.DataContext = New UserLoginViewModel()
        End Sub
    End Class
End Namespace


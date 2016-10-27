Imports MahApps.Metro.Controls
Imports SCI.Modules.UserLogin.Views

Namespace SCI.WPF.Shell

    Class MainWindow
        Inherits MetroWindow

        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

            Dim Contenido As New UserLoginView
            Contenido.HorizontalAlignment = HorizontalAlignment.Center
            Contenido.VerticalAlignment = VerticalAlignment.Center
            Content = Contenido

        End Sub
    End Class

End Namespace

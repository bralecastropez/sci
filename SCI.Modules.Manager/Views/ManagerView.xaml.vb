Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Media
Imports SCI.Modules.Manager.ViewModels

Namespace SCI.Modules.Manager.Views
    Public Class ManagerView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New ManagerViewModel
        End Sub

        Private Sub UIElement_OnPreviewMouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
            Dim dependencyObject = TryCast(Mouse.Captured, DependencyObject)
            While dependencyObject IsNot Nothing
                If TypeOf dependencyObject Is ScrollBar Then
                    Return
                End If
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject)
            End While

            MenuToggleButton.IsChecked = False
        End Sub

    End Class
End Namespace

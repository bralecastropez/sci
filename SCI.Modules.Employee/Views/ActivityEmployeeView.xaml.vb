Imports System.Windows.Controls
Imports SCI.Modules.Employee.ViewModels
Namespace SCI.Modules.Employee.Views
    Public Class ActivityEmployeeView
        Sub New()

            ' Esta llamada es exigida por el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            DataContext = New ActivityEmployeeViewModel
        End Sub

        Public Shared Widening Operator CType(v As ActivityEmployeeView) As TabItem
            Throw New NotImplementedException()
        End Operator
    End Class
End Namespace
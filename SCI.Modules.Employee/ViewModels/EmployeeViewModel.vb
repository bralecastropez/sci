Imports SCI.BusinessLogic.Services
Imports SCI.Infrastructure.Helpers

Namespace SCI.Modules.Employee.ViewModels
    Public Class EmployeeViewModel
        Inherits GuiViewBase
        Private _ListadoDeEmpleados As List(Of Empleado)
        Private _employeeAccess As IEmployeeDataService
        Public Property ListadoDeEmpleados() As List(Of Empleado)
            Get
                Return _ListadoDeEmpleados
            End Get
            Set(ByVal value As List(Of Empleado))
                _ListadoDeEmpleados = value
                OnPropertyChanged("ListadoDeEmpleados")
            End Set
        End Property

        Sub New()
            ServiceLocator.RegisterService(Of IEmployeeDataService)(New EmployeeDataService)
            _employeeAccess = GetService(Of IEmployeeDataService)()
            ListadoDeEmpleados = _employeeAccess.GetEmployees
        End Sub
    End Class
End Namespace
Imports SCI.BusinessLogic.Services
Imports SCI.Infrastructure.Helpers

Namespace SCI.Modules.Employee.ViewModels
    Public Class EmployeeViewModel
        Inherits GuiViewBase
        Private _EmployeeList As List(Of Empleado)
        Private _employeeAccess As IEmployeeDataService
        Public Property EmployeeList() As List(Of Empleado)
            Get
                Return _EmployeeList
            End Get
            Set(ByVal value As List(Of Empleado))
                _EmployeeList = value
                OnPropertyChanged("EmployeeList")
            End Set
        End Property

        Sub New()
            ServiceLocator.RegisterService(Of IEmployeeDataService)(New EmployeeDataService)
            _employeeAccess = GetService(Of IEmployeeDataService)()
            EmployeeList = _employeeAccess.GetEmployees
        End Sub
    End Class
End Namespace
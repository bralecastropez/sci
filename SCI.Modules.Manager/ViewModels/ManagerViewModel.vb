Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Domain
Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Category.Views
Imports SCI.Modules.Dashboard.Views
Imports SCI.Modules.Employee.Views
Imports SCI.Modules.Customer.Views
Imports SCI.Modules.Provider.Views
Imports SCI.Modules.BranchOffice.Views

Namespace SCI.Modules.Manager.ViewModels
    Public Class ManagerViewModel
        Inherits GuiViewBase

#Region "Propiedades"
        Private _ModulesList As List(Of ItemMenu)
        Private _SelectedModule As Integer = 0
        Private _userAccess As IUserDataService
#End Region
#Region "Metodos"
        Public Property SelectedModule As Integer
            Get
                Return _SelectedModule
            End Get
            Set(value As Integer)
                _SelectedModule = value
                OnPropertyChanged("SelectedModule")
                HeaderTitle = " " & ModulesList.Item(SelectedModule).Name & " "
            End Set
        End Property
        Public Property ModulesList As List(Of ItemMenu)
            Get
                Return _ModulesList
            End Get
            Set(ByVal value As List(Of ItemMenu))
                _ModulesList = value
                OnPropertyChanged("ModulesList")
            End Set
        End Property
#End Region
#Region "Constructores"
        Sub New()
            ModulesList = New List(Of ItemMenu)
            ModulesList.Add(New ItemMenu("Inicio", New DashboardView))
            ModulesList.Add(New ItemMenu("Empleados", New EmployeeView))
            ModulesList.Add(New ItemMenu("Categorias", New CategoryView))
            ModulesList.Add(New ItemMenu("Clientes", New CustomerView))
            ModulesList.Add(New ItemMenu("Proveedores", New ProviderView))
            ModulesList.Add(New ItemMenu("Sucursales", New BranchOfficeView))
            ServiceLocator.RegisterService(Of IUserDataService)(New UserDataService)
            _userAccess = GetService(Of IUserDataService)()
            HeaderTitle = "Bienvenido " & UserLogged.Employee.Name & " - Dashboard"
        End Sub

        Public Overrides Sub CleanFields()
            Throw New NotImplementedException()
        End Sub
        Public Overrides Sub LoadFields()
            Throw New NotImplementedException()
        End Sub
#End Region

    End Class
End Namespace

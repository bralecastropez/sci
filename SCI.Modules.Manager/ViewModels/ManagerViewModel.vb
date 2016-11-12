Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Models
Imports SCI.BusinessObjects.Domain
Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Category.Views
Imports SCI.Modules.Dashboard.Views
Imports SCI.Modules.Employee.Views

Namespace SCI.Modules.Manager.ViewModels
    Public Class ManagerViewModel
        Inherits GuiViewBase

#Region "Propiedades"
        Private _ModulesList As List(Of ItemMenu)
        Private _SelectedModule As Integer = 0
        Private _userAccess As IUserDataService
        Private _ListadoDeModulos As List(Of ItemMenu)
        Private _ModuloSeleccionado As Integer = 0

#End Region
#Region "Metodos"
        Public Property ModuloSeleccionado As Integer
            Get
                Return _ModuloSeleccionado
            End Get
            Set(value As Integer)
                _ModuloSeleccionado = value
                OnPropertyChanged("ModuloSeleccionado")

                Select Case ModuloSeleccionado
                    Case 0
                        HeaderTitle = "Bienvenido " & UserLogged.Empleado.Nombre & " - Dashboard"
                    Case 1
                        HeaderTitle = "Bienvenido " & UserLogged.Empleado.Nombre & " - Empleados"
                    Case 2
                        HeaderTitle = "Bienvenido " & UserLogged.Empleado.Nombre & " - Categorias"
                End Select
            End Set
        End Property
        Public Property ListadoDeModulos As List(Of ItemMenu)
            Get
                Return _ListadoDeModulos
            End Get
            Set(ByVal value As List(Of ItemMenu))
                _ListadoDeModulos = value
                OnPropertyChanged("ListadoDeModulos")
            End Set
        End Property
#End Region
#Region "Constructores"
        Sub New()
            ListadoDeModulos = New List(Of ItemMenu)
            ListadoDeModulos.Add(New ItemMenu("Inicio", New DashboardView))
            ListadoDeModulos.Add(New ItemMenu("Empleados", New EmployeeView))
            ListadoDeModulos.Add(New ItemMenu("Categorias", New CategoryView))
            ServiceLocator.RegisterService(Of IUserDataService)(New UserDataService)
            _userAccess = GetService(Of IUserDataService)()
            HeaderTitle = "Bienvenido " & UserLogged.Empleado.Nombre & " - Dashboard"
        End Sub

        Public Overrides Sub CleanFields()
            Throw New NotImplementedException()
        End Sub
#End Region

    End Class
End Namespace

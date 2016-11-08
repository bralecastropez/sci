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
        Private _ListadoDeModulos As List(Of ItemMenu)
        Private _TituloTopbar As String
        Private _ModuloSeleccionado As Integer
        Private _userAccess As IUserDataService
#End Region
#Region "Metodos"
        Public Property ModuloSeleccionado As Integer
            Get
                Return _ModuloSeleccionado
            End Get
            Set(value As Integer)
                _ModuloSeleccionado = value
                OnPropertyChanged("ModuloSeleccionado")
            End Set
        End Property
        Public Property TituloTopbar() As String
            Get
                Return _TituloTopbar
            End Get
            Set(ByVal value As String)
                _TituloTopbar = value
                OnPropertyChanged("TituloTopbar")
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
            ModuloSeleccionado = 2
            TituloTopbar = "Bienvenido " & LoggedInUser.GetInstance.UserLogged.Empleado.Nombre
        End Sub
#End Region

    End Class
End Namespace

Imports System.Windows.Controls
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Models
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Employee.Views

Namespace SCI.Modules.Employee.ViewModels
    Public Class EmployeeViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _EmployeesList As List(Of Empleado)
        Private _GendersList As List(Of String)
        Private _SelectedEmployee As Empleado
        Private _Nombre As String
        Private _Apellido As String
        Private _Correo As String
        Private _Telefono As String
        Private _Genero As String
        Private _Direccion As String
        Private _Comentario As String
        Private _Dpi As String
        Private _EmployeeAccess As IEmployeeDataService
#End Region
#Region "Properties"
        Public Property EmployeeAccess As IEmployeeDataService
            Get
                Return _EmployeeAccess
            End Get
            Set(value As IEmployeeDataService)
                _EmployeeAccess = value
            End Set
        End Property
        Public Property GendersList As List(Of String)
            Get
                Return _GendersList
            End Get
            Set(value As List(Of String))
                _GendersList = value
                OnPropertyChanged("GendersList")
            End Set
        End Property
        Public Property EmployeesList() As List(Of Empleado)
            Get
                Return _EmployeesList
            End Get
            Set(ByVal value As List(Of Empleado))
                _EmployeesList = value
                OnPropertyChanged("EmployeesList")
            End Set
        End Property
        Public Property SelectedEmployee As Empleado
            Get
                Return _SelectedEmployee
            End Get
            Set(value As Empleado)
                _SelectedEmployee = value
                OnPropertyChanged("SelectedEmployee")
            End Set
        End Property
        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set(value As String)
                _Nombre = value
                OnPropertyChanged("Nombre")
            End Set
        End Property
        Public Property Apellido As String
            Get
                Return _Apellido
            End Get
            Set(value As String)
                _Apellido = value
                OnPropertyChanged("Apellido")
            End Set
        End Property
        Public Property Correo As String
            Get
                Return _Correo
            End Get
            Set(value As String)
                _Correo = value
                OnPropertyChanged("Correo")
            End Set
        End Property
        Public Property Telefono As String
            Get
                Return _Telefono
            End Get
            Set(value As String)
                _Telefono = value
                OnPropertyChanged("Telefono")
            End Set
        End Property
        Public Property Genero As String
            Get
                Return _Genero
            End Get
            Set(value As String)
                _Genero = value
                OnPropertyChanged("Genero")
            End Set
        End Property
        Public Property Direccion As String
            Get
                Return _Direccion
            End Get
            Set(value As String)
                _Direccion = value
                OnPropertyChanged("Direccion")
            End Set
        End Property
        Public Property Comentario As String
            Get
                Return _Comentario
            End Get
            Set(value As String)
                _Comentario = value
                OnPropertyChanged("Comentario")
            End Set
        End Property
        Public Property Dpi As String
            Get
                Return _Dpi
            End Get
            Set(value As String)
                _Dpi = value
                OnPropertyChanged("Dpi")
            End Set
        End Property
#End Region
#Region "Contructors"
        Sub New()
            ModuleTitle = "Empleado"
            HeaderTitle = UserLogged.Empleado.Nombre & " - Empleado"

            ServiceLocator.RegisterService(Of IEmployeeDataService)(New EmployeeDataService)
            EmployeeAccess = GetService(Of IEmployeeDataService)()

            EmployeesList = EmployeeAccess.GetEmployees

            AddCommand = New RelayCommand(AddressOf AddEmployeeExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditEmployeeExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteEmployeeExecute)
            DetailCommand = New RelayCommand(AddressOf DetailEmployeeExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptEmployeeExecute, AddressOf CanAcceptExecute)
            SearchCommand = New RelayCommand(AddressOf SearchEmployee)

            GendersList = New List(Of String)
            GendersList.Add("Masculino")
            GendersList.Add("Femenino")
        End Sub
#End Region
#Region "Methods"
        Private Sub AcceptEmployeeExecute()
            If MaintanceType.Add = Maintance Then
                SelectedEmployee = New Empleado
            End If
            SelectedEmployee.Nombre = Nombre
            SelectedEmployee.Apellido = Apellido
            SelectedEmployee.Correo = Correo
            SelectedEmployee.Telefono = Telefono
            SelectedEmployee.Genero = Genero
            SelectedEmployee.Direccion = Direccion
            SelectedEmployee.Comentario = Comentario
            SelectedEmployee.Dpi = Dpi
            Select Case Maintance
                Case MaintanceType.Add
                    If EmployeeAccess.AddEmployee(SelectedEmployee) Then
                        SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el empleado", "Aceptar")
                        ShowSecondDialog = True
                    End If
                Case MaintanceType.Edit
                    If EmployeeAccess.EditEmployee(SelectedEmployee) Then
                        SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el empleado", "Aceptar")
                        ShowSecondDialog = True
                    End If
                Case MaintanceType.Delete
                    If EmployeeAccess.DeleteEmployee(SelectedEmployee) Then
                        SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el empleado", "", "Aceptar")
                        ShowSecondDialog = True
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(New CrudEmployeeView(Me), "Window Printing.")
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Sub EditEmployeeExecute()
            LoadFields()
            EditExecute(New CrudEmployeeView(Me))
        End Sub

        Public Sub DeleteEmployeeExecute()
            LoadFields()
            DeleteExecute(New CrudEmployeeView(Me))
        End Sub
        Public Sub DetailEmployeeExecute()
            LoadFields()
            DetailExecute(New CrudEmployeeView(Me))
        End Sub
        Public Sub AddEmployeeExecute()
            CleanFields()
            AddExecute(New CrudEmployeeView(Me))
        End Sub
        Public Overloads Sub CancelExecute()
            ShowFirstDialog = False
            CleanFields()
        End Sub
        Public Sub LoadFields()
            Nombre = SelectedEmployee.Nombre
            Apellido = SelectedEmployee.Apellido
            Telefono = SelectedEmployee.Telefono
            Correo = SelectedEmployee.Correo
            Direccion = SelectedEmployee.Direccion
            Comentario = SelectedEmployee.Comentario
            Dpi = SelectedEmployee.Dpi
            Genero = SelectedEmployee.Genero
        End Sub
        Public Overrides Sub CleanFields()
            Nombre = ""
            Apellido = ""
            Telefono = ""
            Correo = ""
            Direccion = ""
            Comentario = ""
            Dpi = ""
            Genero = ""
            EmployeesList = EmployeeAccess.GetEmployees
        End Sub
        Public Sub SearchEmployee(ByVal Data As String)
            EmployeesList = EmployeeAccess.SearchEmployee(Data)
        End Sub
#End Region

    End Class
End Namespace
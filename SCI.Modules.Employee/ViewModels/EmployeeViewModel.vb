Imports System.Windows
Imports System.Windows.Controls
Imports Dragablz
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Validators
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.Infrastructure.Helpers
Imports SCI.Infrastructure.Util
Imports SCI.Modules.Employee.Views

Namespace SCI.Modules.Employee.ViewModels
    Public Class EmployeeViewModel
        Inherits GuiViewBase
        Implements IInterTabClient

#Region "Fields"
        Private _EmployeesList As List(Of Global.Employee)
        Private _GendersList As List(Of String)
        Private _SelectedEmployee As Global.Employee
        Private _SelectedTab As String
        Private _Name As String
        Private _LastName As String
        Private _Email As String
        Private _Phone As String
        Private _Gender As String
        Private _Direction As String
        Private _Comment As String
        Private _Dpi As String
        Private _BirthDate As Date
        Private _EmployeeAccess As IEmployeeDataService

        Private _ActivityEmployeeView As Object

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
        Public Property EmployeesList() As List(Of Global.Employee)
            Get
                Return _EmployeesList
            End Get
            Set(ByVal value As List(Of Global.Employee))
                _EmployeesList = value
                OnPropertyChanged("EmployeesList")
            End Set
        End Property
        Public Property SelectedEmployee As Global.Employee
            Get
                Return _SelectedEmployee
            End Get
            Set(value As Global.Employee)
                _SelectedEmployee = value
                OnPropertyChanged("SelectedEmployee")
            End Set
        End Property
        Public Property SelectedTab As String
            Get
                Return _SelectedTab
            End Get
            Set(value As String)
                _SelectedTab = value
                OnPropertyChanged("SelectedTab")
                If _SelectedTab = 2 Then
                    'ActivityEmployeeView = New ActivityEmployeeView
                    SnackbarMessage = SelectedTab
                    ShowSnackbar = True
                End If
            End Set
        End Property
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
                OnPropertyChanged("Name")
            End Set
        End Property
        Public Property LastName As String
            Get
                Return _LastName
            End Get
            Set(value As String)
                _LastName = value
                OnPropertyChanged("LastName")
            End Set
        End Property
        Public Property Email As String
            Get
                Return _Email
            End Get
            Set(value As String)
                _Email = value
                OnPropertyChanged("Email")
            End Set
        End Property
        Public Property Phone As String
            Get
                Return _Phone
            End Get
            Set(value As String)
                _Phone = value
                OnPropertyChanged("Phone")
            End Set
        End Property
        Public Property Gender As String
            Get
                Return _Gender
            End Get
            Set(value As String)
                _Gender = value
                OnPropertyChanged("Gender")
            End Set
        End Property
        Public Property Direction As String
            Get
                Return _Direction
            End Get
            Set(value As String)
                _Direction = value
                OnPropertyChanged("Direction")
            End Set
        End Property
        Public Property Comment As String
            Get
                Return _Comment
            End Get
            Set(value As String)
                _Comment = value
                OnPropertyChanged("Comment")
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
        Public Property BirthDate As Date
            Get
                Return _BirthDate
            End Get
            Set(value As Date)
                _BirthDate = value
                OnPropertyChanged("BirthDate")
            End Set
        End Property

        Private Property ActivityEmployeeView As Object
            Get
                Return _ActivityEmployeeView

            End Get
            Set(value As Object)
                _ActivityEmployeeView = value
                OnPropertyChanged("ActivityEmployeeView")
            End Set
        End Property
#End Region
#Region "Contructors"
        Sub New()
            ModuleTitle = "Empleado"
            HeaderTitle = UserLogged.Employee.Name & " - Empleado"

            ServiceLocator.RegisterService(Of IEmployeeDataService)(New EmployeeDataService)
            EmployeeAccess = GetService(Of IEmployeeDataService)()

            EmployeesList = EmployeeAccess.GetEmployees

            AddCommand = New RelayCommand(AddressOf AddEmployeeExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditEmployeeExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteEmployeeExecute)
            DetailCommand = New RelayCommand(AddressOf DetailEmployeeExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptEmployeeExecute, AddressOf CanAcceptEmployeeExecute)
            SearchCommand = New RelayCommand(AddressOf SearchEmployee)
            BackCommand = New RelayCommand(AddressOf BackExecute)

            ActivityEmployeeView = New ActivityEmployeeView

            GendersList = New List(Of String)
            GendersList.Add("Masculino")
            GendersList.Add("Femenino")
        End Sub
#End Region
#Region "Functions"
        Private Function CanAcceptEmployeeExecute() As Boolean
            Dim Result As Boolean = False
            Try
                If ModelValidator.Instance.ValidateEmail(Email) Then
                    If ModelValidator.Instance.ValidateEmpty(Name) AndAlso
                            ModelValidator.Instance.ValidateEmpty(LastName) AndAlso
                            ModelValidator.Instance.ValidateEmpty(Phone) AndAlso
                            ModelValidator.Instance.ValidateEmpty(Direction) Then
                        Result = True
                    End If
                End If
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType].ToString, "Error en 'CanAddCustomerExecute'")
            End Try
            Return Result
        End Function
#End Region
#Region "Methods"
        Private Sub AcceptEmployeeExecute()
            If MaintanceType.Add = Maintance Then
                SelectedEmployee = New Global.Employee
            End If
            SelectedEmployee.Name = Name
            SelectedEmployee.LastName = LastName
            SelectedEmployee.Email = Email
            SelectedEmployee.Phone = Phone
            SelectedEmployee.Gender = Gender
            SelectedEmployee.Direction = Direction
            SelectedEmployee.Comment = Comment
            SelectedEmployee.Dpi = Dpi
            SelectedEmployee.BirthDate = BirthDate
            Select Case Maintance
                Case MaintanceType.Add
                    If EmployeeAccess.AddEmployee(SelectedEmployee) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente el empleado", "Aceptar")
                        SCIActivity.Instance.Register("Employee", "Agrego un empleado", UserLogged.Nick, "Function", "Add")

                    End If
                Case MaintanceType.Edit
                    If EmployeeAccess.EditEmployee(SelectedEmployee) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente el empleado", "Aceptar")
                        SCIActivity.Instance.Register("Employee", "Actualizo un empleado", UserLogged.Nick, "Function", "Update")
                    End If
                Case MaintanceType.Delete
                    If EmployeeAccess.DeleteEmployee(SelectedEmployee) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el empleado", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente la categoria", "Aceptar")
                        SCIActivity.Instance.Register("Employee", "Elimino un empleado", UserLogged.Nick, "Function", "Delete")
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(PrintDialog, "Window Printing.")
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
        Public Overrides Sub LoadFields()
            Name = SelectedEmployee.Name
            LastName = SelectedEmployee.LastName
            Email = SelectedEmployee.Email
            Phone = SelectedEmployee.Phone
            Gender = SelectedEmployee.Gender
            Direction = SelectedEmployee.Direction
            Comment = SelectedEmployee.Comment
            Dpi = SelectedEmployee.Dpi
            BirthDate = SelectedEmployee.BirthDate
        End Sub
        Public Overrides Sub CleanFields()
            Name = ""
            LastName = ""
            Email = ""
            Phone = ""
            Gender = ""
            Direction = ""
            Comment = ""
            Dpi = ""
            BirthDate = Date.Now
            EmployeesList = EmployeeAccess.GetEmployees
        End Sub
        Public Sub SearchEmployee(ByVal Data As String)
            EmployeesList = EmployeeAccess.SearchEmployee(Data)
        End Sub

#End Region
        Public Function GetNewHost(interTabClient As IInterTabClient, partition As Object, source As TabablzControl) As INewTabHost(Of Window) Implements IInterTabClient.GetNewHost
            Try
                Return Nothing
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType].Name, "GetNewHost")
            End Try

        End Function

        Public Function TabEmptiedHandler(tabControl As TabablzControl, window As Window) As TabEmptiedResponse Implements IInterTabClient.TabEmptiedHandler
            Throw New NotImplementedException()
        End Function

    End Class
End Namespace
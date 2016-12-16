Imports System.Windows.Controls
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.BusinessObjects.Validators
Imports SCI.Infrastructure.Helpers
Imports SCI.Modules.Customer.Views
Imports SCI.Infrastructure.Util

Namespace SCI.Modules.Customer.ViewModels
    Public Class CustomerViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _CustomersList As List(Of Global.Customer)
        Private _SelectedCustomer As Global.Customer
        Private _CustomerAccess As ICustomerDataService
        Private _CustomerCode As String
        Private _Name As String
        Private _LastName As String
        Private _Email As String
        Private _Phone As String
        Private _Direction As String
        Private _Nit As String
        Private _Dpi As String
#End Region
#Region "Properties"
        Public Property CustomerCode As String
            Get
                Return _CustomerCode
            End Get
            Set(value As String)
                _CustomerCode = value
                OnPropertyChanged("CustomerCode")
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
        Public Property Direction As String
            Get
                Return _Direction
            End Get
            Set(value As String)
                _Direction = value
                OnPropertyChanged("Direction")
            End Set
        End Property
        Public Property Nit As String
            Get
                Return _Nit
            End Get
            Set(value As String)
                _Nit = value
                OnPropertyChanged("Nit")
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
        Public Property CustomersList As List(Of Global.Customer)
            Get
                Return _CustomersList
            End Get
            Set(value As List(Of Global.Customer))
                _CustomersList = value
                OnPropertyChanged("CustomersList")
            End Set
        End Property
        Public Property SelectedCustomer As Global.Customer
            Get
                Return _SelectedCustomer
            End Get
            Set(value As Global.Customer)
                _SelectedCustomer = value
                OnPropertyChanged("SelectedCustomer")
            End Set
        End Property
        Public Property CustomerAccess As ICustomerDataService
            Get
                Return _CustomerAccess
            End Get
            Set(value As ICustomerDataService)
                _CustomerAccess = value
            End Set
        End Property
#End Region
#Region "Constructors"
        Sub New()
            ModuleTitle = "Cliente"
            ServiceLocator.RegisterService(Of ICustomerDataService)(New CustomerDataService)
            _CustomerAccess = GetService(Of ICustomerDataService)()
            CustomersList = _CustomerAccess.GetCustomers
            HeaderTitle = UserLogged.Employee.Name & " - Cliente"

            AddCommand = New RelayCommand(AddressOf AddCustomerExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditCustomerExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteCustomerExecute)
            DetailCommand = New RelayCommand(AddressOf DetailCustomerExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptCustomerExecute, AddressOf CanAcceptCustomerExecute)
            SearchCommand = New RelayCommand(AddressOf SearchCustomer)
            BackCommand = New RelayCommand(AddressOf BackCustomer)
        End Sub
#End Region
#Region "Methods"
        Private Function CanAcceptCustomerExecute() As Boolean
            Dim Result As Boolean = False
            Try
                If ModelValidator.GetInstance.ValidateEmail(Email) Then
                    If ModelValidator.GetInstance.ValidateNit(Nit) Then
                        If ModelValidator.GetInstance.ValidateEmpty(Name) AndAlso
                                ModelValidator.GetInstance.ValidateEmpty(LastName) AndAlso
                                ModelValidator.GetInstance.ValidateEmpty(Phone) AndAlso
                                ModelValidator.GetInstance.ValidateEmpty(Direction) Then
                            Result = True
                        End If
                    End If
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType].ToString, "Error en 'CanAddCustomerExecute'")
            End Try
            Return Result
        End Function
        Private Sub AcceptCustomerExecute()
            If MaintanceType.Add = Maintance Then
                SelectedCustomer = New Global.Customer
            End If
            SelectedCustomer.Name = Name
            SelectedCustomer.LastName = LastName
            SelectedCustomer.Email = Email
            SelectedCustomer.Phone = Phone
            SelectedCustomer.Nit = Nit
            SelectedCustomer.Dpi = Dpi
            SelectedCustomer.Direction = Direction
            SelectedCustomer.CustomerCode = CustomerCode
            Select Case Maintance
                Case MaintanceType.Add
                    If CustomerAccess.AddCustomer(SelectedCustomer) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el cliente", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente el cliente", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If CustomerAccess.EditCustomer(SelectedCustomer) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el cliente", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente el cliente", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If CustomerAccess.DeleteCustomer(SelectedCustomer) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el cliente", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente el cliente", "Aceptar")
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(PrintDialog, "Window Printing.")
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Sub EditCustomerExecute()
            LoadFields()
            EditExecute(New CrudCustomerView(Me))
        End Sub

        Public Sub DeleteCustomerExecute()
            LoadFields()
            DeleteExecute(New CrudCustomerView(Me))
        End Sub
        Public Sub DetailCustomerExecute()
            LoadFields()
            DetailExecute(New CrudCustomerView(Me))
        End Sub
        Public Sub AddCustomerExecute()
            CleanFields()
            AddExecute(New CrudCustomerView(Me))
        End Sub
        Public Overloads Sub CancelExecute()
            ShowFirstDialog = False
            CleanFields()
        End Sub
        Public Overrides Sub LoadFields()
            Name = SelectedCustomer.Name
            LastName = SelectedCustomer.LastName
            Phone = SelectedCustomer.Phone
            Email = SelectedCustomer.Email
            Direction = SelectedCustomer.Direction
            Nit = SelectedCustomer.Nit
            Dpi = SelectedCustomer.Dpi
            CustomerCode = SelectedCustomer.CustomerCode
        End Sub
        Public Overrides Sub CleanFields()
            Name = ""
            LastName = ""
            Phone = ""
            Email = ""
            Direction = ""
            Nit = ""
            Dpi = ""
            CustomerCode = ""
            CustomersList = CustomerAccess.GetCustomers
        End Sub
        Public Sub SearchCustomer(ByVal Data As String)
            CustomersList = CustomerAccess.SearchCustomer(Data)
        End Sub
        Public Sub BackCustomer()
            ShowFirstDialog = False
        End Sub
#End Region
    End Class
End Namespace

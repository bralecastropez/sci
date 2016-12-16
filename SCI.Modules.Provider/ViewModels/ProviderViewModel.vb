Imports System.Windows.Controls
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Validators
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.Infrastructure.Helpers
Imports SCI.Infrastructure.Util
Imports SCI.Modules.Provider.Views

Namespace SCI.Modules.Provider.ViewModels
    Public Class ProviderViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _ProvidersList As List(Of Global.Provider)
        Private _SelectedProvider As Global.Provider
        Private _ProviderAccess As IProviderDataService
        Private _ProviderCode As String
        Private _BusinessName As String
        Private _PrincipalAddress As String
        Private _Direction As String
        Private _Phone As String
        Private _Pbx As String
        Private _Email As String
        Private _Nit As String
        Private _WebPage As String
        Private _Explanation As String
#End Region
#Region "Properties"
        Public Property ProviderCode As String
            Get
                Return _ProviderCode
            End Get
            Set(value As String)
                _ProviderCode = value
                OnPropertyChanged("ProviderCode")
            End Set
        End Property
        Public Property BusinessName As String
            Get
                Return _BusinessName
            End Get
            Set(value As String)
                _BusinessName = value
                OnPropertyChanged("BusinessName")
            End Set
        End Property
        Public Property PrincipalAddress As String
            Get
                Return _PrincipalAddress
            End Get
            Set(value As String)
                _PrincipalAddress = value
                OnPropertyChanged("PrincipalAddress")
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
        Public Property Phone As String
            Get
                Return _Phone
            End Get
            Set(value As String)
                _Phone = value
                OnPropertyChanged("Phone")
            End Set
        End Property
        Public Property Pbx As String
            Get
                Return _Pbx
            End Get
            Set(value As String)
                _Pbx = value
                OnPropertyChanged("Pbx")
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
        Public Property Nit As String
            Get
                Return _Nit
            End Get
            Set(value As String)
                _Nit = value
                OnPropertyChanged("Nit")
            End Set
        End Property
        Public Property WebPage As String
            Get
                Return _WebPage
            End Get
            Set(value As String)
                _WebPage = value
                OnPropertyChanged("WebPage")
            End Set
        End Property
        Public Property Explanation As String
            Get
                Return _Explanation
            End Get
            Set(value As String)
                _Explanation = value
                OnPropertyChanged("Explanation")
            End Set
        End Property
        Public Property ProviderAccess As IProviderDataService
            Get
                Return _ProviderAccess
            End Get
            Set(value As IProviderDataService)
                _ProviderAccess = value
            End Set
        End Property
        Public Property ProvidersList() As List(Of Global.Provider)
            Get
                Return _ProvidersList
            End Get
            Set(ByVal value As List(Of Global.Provider))
                _ProvidersList = value
                OnPropertyChanged("ProvidersList")
            End Set
        End Property
        Public Property SelectedProvider As Global.Provider
            Get
                Return _SelectedProvider
            End Get
            Set(value As Global.Provider)
                _SelectedProvider = value
                OnPropertyChanged("SelectedProvider")
            End Set
        End Property
#End Region
#Region "Contructors"
        Sub New()
            ModuleTitle = "Proveedor"
            HeaderTitle = UserLogged.Employee.Name & " - Proveedor"

            ServiceLocator.RegisterService(Of IProviderDataService)(New ProviderDataService)
            ProviderAccess = GetService(Of IProviderDataService)()

            ProvidersList = ProviderAccess.GetProviders

            AddCommand = New RelayCommand(AddressOf AddProviderExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditProviderExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteProviderExecute)
            DetailCommand = New RelayCommand(AddressOf DetailProviderExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptProviderExecute, AddressOf CanAcceptExecute)
            SearchCommand = New RelayCommand(AddressOf SearchProvider)
            BackCommand = New RelayCommand(AddressOf BackExecute)

        End Sub
#End Region
#Region "Functions"
        Private Function CanAcceptCustomerExecute() As Boolean
            Dim Result As Boolean = False
            Try
                If ModelValidator.GetInstance.ValidateEmail(Email) Then
                    If ModelValidator.GetInstance.ValidateNit(Nit) Then
                        If ModelValidator.GetInstance.ValidateEmpty(BusinessName) AndAlso
                                ModelValidator.GetInstance.ValidateEmpty(PrincipalAddress) AndAlso
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
#End Region
#Region "Methods"
        Private Sub AcceptProviderExecute()
            If MaintanceType.Add = Maintance Then
                SelectedProvider = New Global.Provider
            End If
            SelectedProvider.ProviderCode = ProviderCode
            SelectedProvider.BusinessName = BusinessName
            SelectedProvider.PrincipalAddress = PrincipalAddress
            SelectedProvider.Direction = Direction
            SelectedProvider.Phone = Phone
            SelectedProvider.Pbx = Pbx
            SelectedProvider.Email = Email
            SelectedProvider.Nit = Nit
            SelectedProvider.WebPage = WebPage
            SelectedProvider.Explanation = Explanation
            Select Case Maintance
                Case MaintanceType.Add
                    If ProviderAccess.AddProvider(SelectedProvider) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente el proveedor", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If ProviderAccess.EditProvider(SelectedProvider) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente el proveedor", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If ProviderAccess.DeleteProvider(SelectedProvider) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el empleado", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente el proveedor", "Aceptar")
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(PrintDialog, "Window Printing.")
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Sub EditProviderExecute()
            LoadFields()
            EditExecute(New CrudProviderView(Me))
        End Sub

        Public Sub DeleteProviderExecute()
            LoadFields()
            DeleteExecute(New CrudProviderView(Me))
        End Sub
        Public Sub DetailProviderExecute()
            LoadFields()
            DetailExecute(New CrudProviderView(Me))
        End Sub
        Public Sub AddProviderExecute()
            CleanFields()
            AddExecute(New CrudProviderView(Me))
        End Sub
        Public Overloads Sub CancelExecute()
            ShowFirstDialog = False
            CleanFields()
        End Sub
        Public Overrides Sub LoadFields()
            ProviderCode = SelectedProvider.ProviderCode
            BusinessName = SelectedProvider.BusinessName
            PrincipalAddress = SelectedProvider.PrincipalAddress
            Direction = SelectedProvider.Direction
            Phone = SelectedProvider.Phone
            Pbx = SelectedProvider.Pbx
            Email = SelectedProvider.Email
            Nit = SelectedProvider.Nit
            WebPage = SelectedProvider.WebPage
            Explanation = SelectedProvider.Explanation
        End Sub
        Public Overrides Sub CleanFields()
            ProviderCode = ""
            BusinessName = ""
            PrincipalAddress = ""
            Direction = ""
            Phone = ""
            Pbx = ""
            Email = ""
            Nit = ""
            WebPage = ""
            Explanation = ""
            ProvidersList = ProviderAccess.GetProviders
        End Sub
        Public Sub SearchProvider(ByVal Data As String)
            ProvidersList = ProviderAccess.SearchProvider(Data)
        End Sub
#End Region

    End Class
End Namespace
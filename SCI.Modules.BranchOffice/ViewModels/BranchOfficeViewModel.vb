Imports System.Windows.Controls
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Validators
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.Infrastructure.Helpers
Imports SCI.Infrastructure.Util
Imports SCI.Modules.BranchOffice.Views

Namespace SCI.Modules.BranchOffice.ViewModels
    Public Class BranchOfficeViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _BranchOfficesList As List(Of Global.BranchOffice)
        Private _SelectedBranchOffice As Global.BranchOffice
        Private _BranchOfficeAccess As IBranchOfficeDataService
        Private _Name As String
        Private _Direction As String
        Private _Phone As String
#End Region
#Region "Properties"
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
                OnPropertyChanged("Name")
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
        Public Property BranchOfficeAccess As IBranchOfficeDataService
            Get
                Return _BranchOfficeAccess
            End Get
            Set(value As IBranchOfficeDataService)
                _BranchOfficeAccess = value
            End Set
        End Property
        Public Property BranchOfficesList() As List(Of Global.BranchOffice)
            Get
                Return _BranchOfficesList
            End Get
            Set(ByVal value As List(Of Global.BranchOffice))
                _BranchOfficesList = value
                OnPropertyChanged("BranchOfficesList")
            End Set
        End Property
        Public Property SelectedBranchOffice As Global.BranchOffice
            Get
                Return _SelectedBranchOffice
            End Get
            Set(value As Global.BranchOffice)
                _SelectedBranchOffice = value
                OnPropertyChanged("SelectedBranchOffice")
            End Set
        End Property
#End Region
#Region "Contructors"
        Sub New()
            ModuleTitle = "Proveedor"
            HeaderTitle = UserLogged.Employee.Name & " - Proveedor"

            ServiceLocator.RegisterService(Of IBranchOfficeDataService)(New BranchOfficeDataService)
            BranchOfficeAccess = GetService(Of IBranchOfficeDataService)()

            BranchOfficesList = BranchOfficeAccess.GetBranchOffices

            AddCommand = New RelayCommand(AddressOf AddBranchOfficeExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditBranchOfficeExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteBranchOfficeExecute)
            DetailCommand = New RelayCommand(AddressOf DetailBranchOfficeExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptBranchOfficeExecute, AddressOf CanAcceptExecute)
            SearchCommand = New RelayCommand(AddressOf SearchBranchOffice)
            BackCommand = New RelayCommand(AddressOf BackExecute)

        End Sub
#End Region
#Region "Functions"
        Private Function CanAcceptCustomerExecute() As Boolean
            Dim Result As Boolean = False
            Try

                If ModelValidator.GetInstance.ValidateEmpty(Name) AndAlso
                    ModelValidator.GetInstance.ValidateEmpty(Phone) AndAlso
                    ModelValidator.GetInstance.ValidateEmpty(Direction) Then
                    Result = True
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType].ToString, "Error en 'CanAddCustomerExecute'")
            End Try
            Return Result
        End Function
#End Region
#Region "Methods"
        Private Sub AcceptBranchOfficeExecute()
            If MaintanceType.Add = Maintance Then
                SelectedBranchOffice = New Global.BranchOffice
            End If
            SelectedBranchOffice.Name = Name
            SelectedBranchOffice.Direction = Direction
            SelectedBranchOffice.Phone = Phone
            Select Case Maintance
                Case MaintanceType.Add
                    If BranchOfficeAccess.AddBranchOffice(SelectedBranchOffice) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente la sucursal", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If BranchOfficeAccess.EditBranchOffice(SelectedBranchOffice) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente la sucursal", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If BranchOfficeAccess.DeleteBranchOffice(SelectedBranchOffice) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el empleado", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente la sucursal", "Aceptar")
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(PrintDialog, "Window Printing.")
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Sub EditBranchOfficeExecute()
            LoadFields()
            EditExecute(New CrudBranchOfficeView(Me))
        End Sub

        Public Sub DeleteBranchOfficeExecute()
            LoadFields()
            DeleteExecute(New CrudBranchOfficeView(Me))
        End Sub
        Public Sub DetailBranchOfficeExecute()
            LoadFields()
            DetailExecute(New CrudBranchOfficeView(Me))
        End Sub
        Public Sub AddBranchOfficeExecute()
            CleanFields()
            AddExecute(New CrudBranchOfficeView(Me))
        End Sub
        Public Overloads Sub CancelExecute()
            ShowFirstDialog = False
            CleanFields()
        End Sub
        Public Overrides Sub LoadFields()
            Name = SelectedBranchOffice.Name
            Direction = SelectedBranchOffice.Direction
            Phone = SelectedBranchOffice.Phone
        End Sub
        Public Overrides Sub CleanFields()
            Name = ""
            Direction = ""
            Phone = ""
            BranchOfficesList = BranchOfficeAccess.GetBranchOffices
        End Sub
        Public Sub SearchBranchOffice(ByVal Data As String)
            BranchOfficesList = BranchOfficeAccess.SearchBranchOffice(Data)
        End Sub
#End Region

    End Class
End Namespace
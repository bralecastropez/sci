Imports SCI.Infrastructure.Helpers
Imports SCI.BusinessLogic.Services
Imports SCI.Modules.Inventory.Views
'Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.BusinessObjects.Validators
Imports System.Windows.Input

Namespace SCI.Modules.Inventory.ViewModels
    Public Class InventoryViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _InventoryAccess As IInventoryDataService
        Private _ReadersList As List(Of Global.Reader)
        Private _InventoriesList As List(Of Global.Inventory)
        Private _SelectedInventory As Global.Inventory
        Private _TypesList As List(Of String)
        Private _Reader As Global.Reader
        Private _Title As String
        Private _InventoryDate As Date
        Private _InventoryState As Boolean
        Private _InventoryType As String
        Private _Entries As Integer
        Private _Departures As Integer
        'Detal Inventory
        Private _SelectedDetailInventory As Global.Product_Inventory
        Private _DetailInventoryList As List(Of Global.Product_Inventory)
        Private _ProductsList As List(Of Global.Product)
        Private _Product As Global.Product
        Private _RegisterType As String
        Private _Amount As Integer
#End Region
#Region "Properties"
        Public Property SelectedInventory As Global.Inventory
            Get
                Return _SelectedInventory
            End Get
            Set(value As Global.Inventory)
                _SelectedInventory = value
                OnPropertyChanged("SelectedInventory")
                DetailInventoryList = InventoryAccess.GetDetailInventory(value)
                CleanMaintanceDetailFields()
            End Set
        End Property
        Public Property TypesList As List(Of String)
            Get
                Return _TypesList
            End Get
            Set(value As List(Of String))
                _TypesList = value
                OnPropertyChanged("TypesList")
            End Set
        End Property
        Public Property InventoriesList() As List(Of Global.Inventory)
            Get
                Return _InventoriesList
            End Get
            Set(ByVal value As List(Of Global.Inventory))
                _InventoriesList = value
                OnPropertyChanged("InventoriesList")
            End Set
        End Property
        Public Property ReadersList As List(Of Reader)
            Get
                Return _ReadersList
            End Get
            Set(value As List(Of Reader))
                _ReadersList = value
                OnPropertyChanged("ReadersList")
            End Set
        End Property
        Public Property InventoryAccess As IInventoryDataService
            Get
                Return _InventoryAccess
            End Get
            Set(value As IInventoryDataService)
                _InventoryAccess = value
            End Set
        End Property

        Public Property Reader As Global.Reader
            Get
                Return _Reader
            End Get
            Set(value As Global.Reader)
                _Reader = value
                OnPropertyChanged("Reader")
            End Set
        End Property
        Public Property Title As String
            Get
                Return _Title
            End Get
            Set(value As String)
                _Title = value
                OnPropertyChanged("Title")
            End Set
        End Property
        Public Property InventoryDate As Date
            Get
                Return _InventoryDate
            End Get
            Set(value As Date)
                _InventoryDate = value
                OnPropertyChanged("InventoryDate")
            End Set
        End Property
        Public Property InventoryState As Boolean
            Get
                Return _InventoryState
            End Get
            Set(value As Boolean)
                _InventoryState = value
                OnPropertyChanged("InventoryState")
            End Set
        End Property
        Public Property InventoryType As String
            Get
                Return _InventoryType
            End Get
            Set(value As String)
                _InventoryType = value
                OnPropertyChanged("InventoryType")
            End Set
        End Property
        Public Property Entries As Integer
            Get
                Return _Entries
            End Get
            Set(value As Integer)
                _Entries = value
                OnPropertyChanged("Entries")
            End Set
        End Property
        Public Property Departures As Integer
            Get
                Return _Departures
            End Get
            Set(value As Integer)
                _Departures = value
                OnPropertyChanged("Departures")
            End Set
        End Property
        Public Property DetailInventoryList As List(Of Global.Product_Inventory)
            Get
                Return _DetailInventoryList
            End Get
            Set(value As List(Of Global.Product_Inventory))
                _DetailInventoryList = value
                OnPropertyChanged("DetailInventoryList")
            End Set
        End Property
        Public Property SelectedDetailInventory As Global.Product_Inventory
            Get
                Return _SelectedDetailInventory
            End Get
            Set(value As Global.Product_Inventory)
                _SelectedDetailInventory = value
                OnPropertyChanged("SelectedDetailInventory")
            End Set
        End Property
        Public Property ProductsList As List(Of Global.Product)
            Get
                Return _ProductsList
            End Get
            Set(value As List(Of Global.Product))
                _ProductsList = value
                OnPropertyChanged("ProductsList")
            End Set
        End Property
        Public Property Product As Global.Product
            Get
                Return _Product
            End Get
            Set(value As Global.Product)
                _Product = value
                OnPropertyChanged("Product")
            End Set
        End Property
        Public Property Amount As Integer
            Get
                Return _Amount
            End Get
            Set(value As Integer)
                _Amount = value
                OnPropertyChanged("Amount")
            End Set
        End Property
        Public Property RegisterType As String
            Get
                Return _RegisterType
            End Get
            Set(value As String)
                _RegisterType = value
                OnPropertyChanged("RegisterType")
            End Set
        End Property
        Public Property ParameterCommand As ICommand
#End Region
#Region "Methods"
        Public Overloads Sub CleanMaintanceDetailFields()
            Product = New Global.Product
            Amount = 0
            RegisterType = ""
            DetailInventoryList = InventoryAccess.GetDetailInventory(SelectedInventory)
        End Sub
        Public Overrides Sub CleanFields()
            Reader = New Global.Reader
            Title = ""
            InventoryDate = DateTime.Now
            InventoryState = False
            InventoryType = "Compras"
            Entries = 0
            Departures = 0
            InventoriesList = InventoryAccess.GetInventories
        End Sub
        Public Overloads Sub LoadMaintanceDetailFields()
            Product = SelectedDetailInventory.Product
            Amount = SelectedDetailInventory.Amount
            RegisterType = SelectedDetailInventory.RegisterType
        End Sub
        Public Overrides Sub LoadFields()
            Reader = SelectedInventory.Reader
            Title = SelectedInventory.Title
            InventoryDate = SelectedInventory.InventoryDate
            InventoryState = SelectedInventory.InventoryState
            InventoryType = SelectedInventory.InventoryType
            Entries = SelectedInventory.Entries
            Departures = SelectedInventory.Departures
        End Sub
        Public Sub AddInventoryExecute()
            SelectedInventory = New Global.Inventory
            CleanFields()
            AddExecute(New CrudInventoryView(Me))
        End Sub
        Public Sub EditMaintanceDetailInventoryExecute()
            LoadMaintanceDetailFields()
            EditMaintanceDetailExecute(Nothing)
        End Sub
        Public Sub EditInventoryExecute()
            LoadFields()
            EditExecute(New CrudInventoryView(Me))
        End Sub
        Public Sub DeleteMaintanceDetailInventoryExecute()
            LoadFields()
            DeleteMaintanceDetailExecute(Nothing)
        End Sub
        Public Sub DeleteInventoryExecute()
            LoadFields()
            DeleteExecute(New CrudInventoryView(Me))
        End Sub
        Public Sub CancelMaintanceDetailInventoryExecute()
            CleanMaintanceDetailFields()
        End Sub
        Public Sub CancelInventoryExecute()
            CleanFields()
            CancelExecute()
        End Sub
        Public Sub AcceptMaintanceDetailInventoryExecute()
            If MaintanceDetail = MaintanceDetailType.Add Then
                SelectedDetailInventory = New Global.Product_Inventory
            End If

            SelectedDetailInventory.Inventory = SelectedInventory
            SelectedDetailInventory.Product = Product
            SelectedDetailInventory.RegisterType = RegisterType
            SelectedDetailInventory.Amount = Amount

            Select Case MaintanceDetail
                Case MaintanceDetailType.Add
                    If InventoryAccess.AddDetailInventory(SelectedDetailInventory) Then
                        ShowSnackbarMessage("Se agregó correctamente el producto", "Aceptar")
                    End If
                Case MaintanceDetailType.Edit
                    If InventoryAccess.EditDetailInventory(SelectedDetailInventory) Then
                        ShowSnackbarMessage("Se actualizó correctamente el producto", "Aceptar")
                    End If
                Case MaintanceDetailType.Delete
                    If InventoryAccess.DeleteDetailInventory(SelectedDetailInventory) Then
                        ShowSnackbarMessage("Se eliminó correctamente el producto", "Aceptar")
                    End If
            End Select

            CleanMaintanceDetailFields()
            AcceptMaintanceDetailExecute()
            AddMaintanceDetailExecute(Nothing)
        End Sub
        Public Sub AcceptInventoryExecute()
            If Maintance = MaintanceType.Add Then
                SelectedInventory = New Global.Inventory
            End If
            SelectedInventory.Reader = Reader
            SelectedInventory.Title = Title
            SelectedInventory.InventoryDate = InventoryDate
            SelectedInventory.InventoryState = InventoryState
            SelectedInventory.InventoryType = InventoryType
            SelectedInventory.Entries = Entries
            SelectedInventory.Departures = Departures

            Select Case Maintance
                Case MaintanceType.Add
                    If InventoryAccess.AddInventory(SelectedInventory) Then
                        ShowSnackbarMessage("Se agregó correctamente el inventario", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If InventoryAccess.EditInventory(SelectedInventory) Then
                        ShowSnackbarMessage("Se actualizó correctamente el inventario", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If InventoryAccess.DeleteInventory(SelectedInventory) Then
                        ShowSnackbarMessage("Se eliminó correctamente el inventario", "Aceptar")
                    End If
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Function CanAcceptInventoryExecute() As Boolean
            Return ModelValidator.GetInstance.ValidateEmpty(Title)
        End Function
        Public Function CanAcceptMaintanceDetailInventoryExecute() As Boolean
            If ModelValidator.GetInstance.ValidateNumber(Amount) _
                AndAlso Not Product Is Nothing _
                AndAlso ModelValidator.GetInstance.ValidateEmpty(RegisterType) Then
                Return True
            End If
            Return false
        End Function
        Public Sub SearchMaintanceDetailInventory(ByVal Data As String)
            DetailInventoryList = InventoryAccess.SearchDetailInventory(SelectedInventory, Data)
        End Sub
        Public Sub SearchInventory(ByVal Data As String)
            InventoriesList = InventoryAccess.SearchInventory(Data)
        End Sub
        Public Sub BackInventory()
            ShowFirstDialog = False
        End Sub
#End Region
#Region "Constructors"
        Sub New()
            MyBase.New()
            ModuleTitle = "Inventario"
            ServiceLocator.RegisterService(Of IInventoryDataService)(New InventoryDataService)
            InventoryAccess = GetService(Of IInventoryDataService)()
            InventoriesList = InventoryAccess.GetInventories
            ReadersList = InventoryAccess.GetReaders
            ProductsList = InventoryAccess.GetProducts

            TypesList = New List(Of String)
            TypesList.Add("Ventas")
            TypesList.Add("Compras")

            AddCommand = New RelayCommand(AddressOf AddInventoryExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditInventoryExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteInventoryExecute)

            AddMaintanceDetailExecute(Nothing)

            SearchCommand = New RelayCommand(AddressOf SearchInventory)
            BackCommand = New RelayCommand(AddressOf BackInventory)
            CancelCommand = New RelayCommand(AddressOf CancelInventoryExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptInventoryExecute, AddressOf CanAcceptInventoryExecute)

            EditMaintanceDetailCommand = New RelayCommand(AddressOf EditMaintanceDetailInventoryExecute)
            DeleteMaintanceDetailCommand = New RelayCommand(AddressOf DeleteMaintanceDetailInventoryExecute)

            CancelMaintanceDetailCommand = New RelayCommand(AddressOf CancelMaintanceDetailInventoryExecute)
            AcceptMaintanceDetailCommand = New RelayCommand(AddressOf AcceptMaintanceDetailInventoryExecute, AddressOf CanAcceptMaintanceDetailInventoryExecute)
        End Sub
#End Region

    End Class
End Namespace

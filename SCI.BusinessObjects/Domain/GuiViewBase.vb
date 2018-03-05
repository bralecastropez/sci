Imports System.Windows.Input
Imports SCI.BusinessObjects.Models

Namespace SCI.Infrastructure.Helpers
    Public MustInherit Class GuiViewBase
        Inherits ViewModelBase
#Region "Login"
        'USER
        Public Property UserLogged As Reader = LogonConfig.Instance.UserLogged
#End Region
#Region "Fields"
        'Dialogs
        Private _ShowFirstDialog As Boolean
        Private _ShowSecondDialog As Boolean
        Private _ShowThirdDialog As Boolean
        Private _FirstDialogContent As Object
        Private _SecondDialogContent As Object
        Private _ThirdDialogContent As Object
        'Components
        Private _HeaderTitle As String
        Private _ModuleTitle As String
        Private _MaintanceTitle As String
        Private _CancelButtonTitle As String
        Private _ExecuteButtonTitle As String
        Private _Maintance As MaintanceType
        Private _EnableEdit As Boolean
        Private _VisibleDelete As String
        'Components Detail 
        Private _MaintanceDetail As MaintanceDetailType
        Private _HeaderMaintanceDetailTitle As String
        Private _MaintanceDetailTitle As String
        Private _CancelMaintanceDetailButtonTitle As String
        Private _ExecuteMaintanceDetailButtonTitle As String
        Private _EnableMaintanceDetailEdit As Boolean
        Private _VisibleMaintanceDetailDelete As String
        'Snackbar
        Private _ShowSnackbar As Boolean
        Private _SnackbarMessage As String
        Private _SnackbarActionContent As String
        'Maintances
        Enum MaintanceType
            Add
            Edit
            Delete
            Detail
            Print
        End Enum
        Enum MaintanceDetailType
            Add
            Edit
            Delete
            Detail
            Print
        End Enum
#End Region
#Region "Properties"
        Public Property ShowFirstDialog As Boolean
            Get
                Return _ShowFirstDialog
            End Get
            Set(value As Boolean)
                _ShowFirstDialog = value
                OnPropertyChanged("ShowFirstDialog")
            End Set
        End Property
        Public Property ShowSecondDialog As Boolean
            Get
                Return _ShowSecondDialog
            End Get
            Set(value As Boolean)
                _ShowSecondDialog = value
                OnPropertyChanged("ShowSecondDialog")
            End Set
        End Property
        Public Property ShowThirdDialog As Boolean
            Get
                Return _ShowThirdDialog
            End Get
            Set(value As Boolean)
                _ShowThirdDialog = value
                OnPropertyChanged("ShowThirdDialog")
            End Set
        End Property
        Public Property FirstDialogContent As Object
            Get
                Return _FirstDialogContent
            End Get
            Set(value As Object)
                _FirstDialogContent = value
                OnPropertyChanged("FirstDialogContent")
            End Set
        End Property
        Public Property SecondDialogContent As Object
            Get
                Return _SecondDialogContent
            End Get
            Set(value As Object)
                _SecondDialogContent = value
                OnPropertyChanged("SecondDialogContent")
            End Set
        End Property
        Public Property ThirdDialogContent As Object
            Get
                Return _ThirdDialogContent
            End Get
            Set(value As Object)
                _ThirdDialogContent = value
                OnPropertyChanged("ThirdDialogContent")
            End Set
        End Property
        Public Property HeaderTitle As String
            Get
                Return _HeaderTitle
            End Get
            Set(value As String)
                _HeaderTitle = value
                OnPropertyChanged("HeaderTitle")
            End Set
        End Property
        Public Property ModuleTitle As String
            Get
                Return _ModuleTitle
            End Get
            Set(value As String)
                _ModuleTitle = value
                OnPropertyChanged("ModuleTitle")
            End Set
        End Property
        Public Property MaintanceTitle As String
            Get
                Return _MaintanceTitle
            End Get
            Set(value As String)
                _MaintanceTitle = value
                OnPropertyChanged("MaintanceTitle")
            End Set
        End Property
        Public Property CancelButtonTitle As String
            Get
                Return _CancelButtonTitle
            End Get
            Set(value As String)
                _CancelButtonTitle = value
                OnPropertyChanged("CancelButtonTitle")
            End Set
        End Property
        Public Property ExecuteButtonTitle As String
            Get
                Return _ExecuteButtonTitle
            End Get
            Set(value As String)
                _ExecuteButtonTitle = value
                OnPropertyChanged("ExecuteButtonTitle")
            End Set
        End Property
        Public Property EnableEdit As Boolean
            Get
                Return _EnableEdit
            End Get
            Set(value As Boolean)
                _EnableEdit = value
                OnPropertyChanged("EnableEdit")
            End Set
        End Property
        Public Property VisibleDelete As String
            Get
                Return _VisibleDelete
            End Get
            Set(value As String)
                _VisibleDelete = value
                OnPropertyChanged("VisibleDelete")
            End Set
        End Property
        Public Property Maintance As MaintanceType
            Get
                Return _Maintance
            End Get
            Set(value As MaintanceType)
                _Maintance = value
            End Set
        End Property
        Public Property MaintanceDetail As MaintanceDetailType
            Get
                Return _MaintanceDetail
            End Get
            Set(value As MaintanceDetailType)
                _MaintanceDetail = value
            End Set
        End Property
        Public Property HeaderMaintanceDetailTitle As String
            Get
                Return _HeaderMaintanceDetailTitle
            End Get
            Set(value As String)
                _HeaderMaintanceDetailTitle = value
                OnPropertyChanged("HeaderMaintanceDetailTitle")
            End Set
        End Property
        Public Property MaintanceDetailTitle As String
            Get
                Return _MaintanceDetailTitle
            End Get
            Set(value As String)
                _MaintanceDetailTitle = value
                OnPropertyChanged("MaintanceDetailTitle")
            End Set
        End Property
        Public Property CancelMaintanceDetailButtonTitle As String
            Get
                Return _CancelMaintanceDetailButtonTitle
            End Get
            Set(value As String)
                _CancelMaintanceDetailButtonTitle = value
                OnPropertyChanged("CancelMaintanceDetailButtonTitle")
            End Set
        End Property
        Public Property ExecuteMaintanceDetailButtonTitle As String
            Get
                Return _ExecuteMaintanceDetailButtonTitle
            End Get
            Set(value As String)
                _ExecuteMaintanceDetailButtonTitle = value
                OnPropertyChanged("ExecuteMaintanceDetailButtonTitle")
            End Set
        End Property
        Public Property EnableMaintanceDetailEdit As Boolean
            Get
                Return _EnableMaintanceDetailEdit
            End Get
            Set(value As Boolean)
                _EnableMaintanceDetailEdit = value
                OnPropertyChanged("EnableMaintanceDetailEdit")
            End Set
        End Property
        Public Property VisibleMaintanceDetailDelete As String
            Get
                Return _VisibleMaintanceDetailDelete
            End Get
            Set(value As String)
                _VisibleMaintanceDetailDelete = value
                OnPropertyChanged("VisibleMaintanceDetailDelete")
            End Set
        End Property
        Public Property SnackbarMessage As String
            Get
                Return _SnackbarMessage
            End Get
            Set(value As String)
                _SnackbarMessage = value
                OnPropertyChanged("SnackbarMessage")
            End Set
        End Property
        Public Property ShowSnackbar As Boolean
            Get
                Return _ShowSnackbar
            End Get
            Set(value As Boolean)
                _ShowSnackbar = value
                OnPropertyChanged("ShowSnackbar")
            End Set
        End Property
        Public Property SnackbarActionContent As String
            Get
                Return _SnackbarActionContent
            End Get
            Set(value As String)
                _SnackbarActionContent = value
                OnPropertyChanged("SnackbarActionContent")
            End Set
        End Property
        'Dialog
        Public Shared Property PrintDialog As Object
        'Events
        Public Property AddCommand As ICommand
        Public Property EditCommand As ICommand
        Public Property DeleteCommand As ICommand
        Public Property DetailCommand As ICommand
        Public Property CancelCommand As ICommand
        Public Property AcceptCommand As ICommand
        Public Property SearchCommand As ICommand
        Public Property BackCommand As ICommand
        'Details
        Public Property AddMaintanceDetailCommand As ICommand
        Public Property EditMaintanceDetailCommand As ICommand
        Public Property DeleteMaintanceDetailCommand As ICommand
        Public Property DetailMaintanceDetailCommand As ICommand
        Public Property CancelMaintanceDetailCommand As ICommand
        Public Property AcceptMaintanceDetailCommand As ICommand
        Public Property SearchMaintanceDetailCommand As ICommand
        Public Property BackMaintanceDetailCommand As ICommand
        'Notifications
        Public Property SnackbarActionCommand As ICommand
#End Region
#Region "Constructors"
        Sub New()
            MyBase.New()
            SnackbarActionCommand = New RelayCommand(AddressOf ParameterCommandExecute)
        End Sub
#End Region
#Region "Methods"
        Public MustOverride Sub CleanFields()
        Public MustOverride Sub LoadFields()
        Public Sub CleanMaintanceDetailFields()

        End Sub
        Public Sub LoadMaintanceDetailFields()

        End Sub
        Public Sub AddExecute(ByVal Content As Object)
            MaintanceTitle = "Agregar " & ModuleTitle
            FirstDialogContent = Content
            Maintance = MaintanceType.Add
            CancelButtonTitle = "Cancelar"
            ExecuteButtonTitle = "Agregar"
            VisibleDelete = "Hidden"
            EnableEdit = True
            ShowFirstDialog = True
        End Sub
        Public Sub EditExecute(ByVal Content As Object)
            MaintanceTitle = "Editar " & ModuleTitle
            FirstDialogContent = Content
            Maintance = MaintanceType.Edit
            CancelButtonTitle = "Cancelar"
            ExecuteButtonTitle = "Editar"
            VisibleDelete = "Hidden"
            EnableEdit = True
            ShowFirstDialog = True
        End Sub
        Public Sub DeleteExecute(ByVal Content As Object)
            MaintanceTitle = "Eliminar " & ModuleTitle
            FirstDialogContent = Content
            Maintance = MaintanceType.Delete
            CancelButtonTitle = "No"
            ExecuteButtonTitle = "Si"
            VisibleDelete = "Visible"
            EnableEdit = False
            ShowFirstDialog = True
        End Sub
        Public Sub DetailExecute(ByVal Content As Object)
            MaintanceTitle = "Detalle " & ModuleTitle
            FirstDialogContent = Content
            Maintance = MaintanceType.Detail
            CancelButtonTitle = "Aceptar"
            ExecuteButtonTitle = "Imprimir"
            VisibleDelete = "Hidden"
            EnableEdit = False
            ShowFirstDialog = True
        End Sub
        Public Sub AcceptExecute()
            CancelExecute()
        End Sub
        Public Sub CancelExecute()
            ShowFirstDialog = False
        End Sub
        Public Sub BackExecute()
            ShowFirstDialog = False
        End Sub
        Public Sub AddMaintanceDetailExecute(ByVal Content As Object)
            MaintanceDetailTitle = "Agregar Producto"
            FirstDialogContent = Content
            MaintanceDetail = MaintanceDetailType.Add
            CancelMaintanceDetailButtonTitle = "Cancelar"
            ExecuteMaintanceDetailButtonTitle = "Agregar"
            VisibleMaintanceDetailDelete = "Collapsed"
            EnableMaintanceDetailEdit = True
            'ShowFirstDialog = True
        End Sub
        Public Sub EditMaintanceDetailExecute(ByVal Content As Object)
            MaintanceDetailTitle = "Editar"
            FirstDialogContent = Content
            MaintanceDetail = MaintanceDetailType.Edit
            CancelMaintanceDetailButtonTitle = "Cancelar"
            ExecuteMaintanceDetailButtonTitle = "Editar"
            VisibleMaintanceDetailDelete = "Hidden"
            EnableMaintanceDetailEdit = True
            'ShowFirstDialog = True
        End Sub
        Public Sub DeleteMaintanceDetailExecute(ByVal Content As Object)
            MaintanceDetailTitle = "Eliminar "
            FirstDialogContent = Content
            MaintanceDetail = MaintanceDetailType.Delete
            CancelMaintanceDetailButtonTitle = "No"
            ExecuteMaintanceDetailButtonTitle = "Si"
            VisibleMaintanceDetailDelete = "Visible"
            EnableMaintanceDetailEdit = False
            'ShowFirstDialog = True
        End Sub
        Public Sub DetailMaintanceDetailExecute(ByVal Content As Object)
            MaintanceTitle = "Detalle " & ModuleTitle
            FirstDialogContent = Content
            Maintance = MaintanceType.Detail
            CancelButtonTitle = "Aceptar"
            ExecuteButtonTitle = "Imprimir"
            VisibleDelete = "Hidden"
            EnableEdit = False
            ShowFirstDialog = True
        End Sub
        Public Sub AcceptMaintanceDetailExecute()
            CancelMaintanceDetailExecute()
        End Sub
        Public Sub CancelMaintanceDetailExecute()
            ShowFirstDialog = False
        End Sub
        Public Sub BackMaintanceDetailExecute()
            ShowFirstDialog = False
        End Sub
        'Notifications
        Public Sub ParameterCommandExecute()
            ShowSnackbar = False
        End Sub
        Public Sub ShowSnackbarMessage(ByVal Message As String, ByVal ActionContent As String)
            SnackbarMessage = Message
            SnackbarActionContent = ActionContent
            ShowSnackbar = True
        End Sub
#End Region
#Region "Functions"
        Public Function CanAddExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanEditExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanDeleteExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanCancelExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanAcceptExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanBackExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanAddMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanEditMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanDeleteMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanCancelMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanAcceptMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanDetailMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
        Public Function CanBackMaintanceDetailExecute(ByVal param As Object) As Boolean
            Return True
        End Function
#End Region
    End Class
End Namespace

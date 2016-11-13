Imports System.Windows.Input
Imports SCI.BusinessObjects.Models

Namespace SCI.Infrastructure.Helpers
    Public MustInherit Class GuiViewBase
        Inherits ViewModelBase
#Region "Login"
        'USER
        Public Property UserLogged As Usuario = LogonConfig.GetInstance.UserLogged
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
        Private _MaintanceDetail As MaintanceDetailType
        Private _EnableEdit As Boolean
        Private _VisibleDelete As String
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
        'Events
        Public Property AddCommand As ICommand
        Public Property EditCommand As ICommand
        Public Property DeleteCommand As ICommand
        Public Property DetailCommand As ICommand
        Public Property CancelCommand As ICommand
        Public Property AcceptCommand As ICommand
        Public Property SearchCommand As ICommand
#End Region
#Region "Constructors"
        Sub New()
            MyBase.New()
        End Sub
#End Region
#Region "Methods"
        Public MustOverride Sub CleanFields()
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
#End Region
    End Class
End Namespace

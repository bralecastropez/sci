Imports SCI.Infrastructure.Helpers
Imports SCI.BusinessLogic.Services
Imports SCI.Modules.Category.Views
'Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.BusinessObjects.Validators
Imports System.Windows.Input

Namespace SCI.Modules.Category.ViewModels
    Public Class CategoryViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _CategoryAccess As ICategoryDataService
        Private _CategoriesList As List(Of Global.Category)
        Private _SelectedCategory As Global.Category
        Private _Name As String
        Private _Explanation As String
#End Region
#Region "Properties"
        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
                OnPropertyChanged("Name")
            End Set
        End Property
        Public Property Explanation As String
            Get
                Return _Explanation
            End Get
            Set(ByVal value As String)
                _Explanation = value
                OnPropertyChanged("Explanation")
            End Set
        End Property
        Public Property SelectedCategory As Global.Category
            Get
                Return _SelectedCategory
            End Get
            Set(value As Global.Category)
                _SelectedCategory = value
                OnPropertyChanged("SelectedCategory")
            End Set
        End Property
        Public Property CategoriesList() As List(Of Global.Category)
            Get
                Return _CategoriesList
            End Get
            Set(ByVal value As List(Of Global.Category))
                _CategoriesList = value
                OnPropertyChanged("CategoriesList")
            End Set
        End Property
        Public Property CategoryAccess As ICategoryDataService
            Get
                Return _CategoryAccess
            End Get
            Set(value As ICategoryDataService)
                _CategoryAccess = value
            End Set
        End Property
        Public Property ParameterCommand As ICommand
#End Region
#Region "Methods"
        Public Overrides Sub CleanFields()
            Name = ""
            Explanation = ""
            CategoriesList = CategoryAccess.GetCategories
        End Sub
        Public Overrides Sub LoadFields()
            Name = SelectedCategory.Name
            Explanation = SelectedCategory.Explanation
        End Sub
        Public Sub AddCategoryExecute()
            AddExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub EditCategoryExecute()
            LoadFields()
            EditExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub DeleteCategoryExecute()
            LoadFields()
            DeleteExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub CancelCategoryExecute()
            CleanFields()
            CancelExecute()
        End Sub
        Public Sub AcceptCategoryExecute()
            If Maintance = MaintanceType.Add Then
                SelectedCategory = New Global.Category
            End If
            SelectedCategory.Name = Name
            SelectedCategory.Explanation = Explanation
            Select Case Maintance
                Case MaintanceType.Add
                    If CategoryAccess.AddCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente la categoria", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente la categoria", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If CategoryAccess.EditCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente la categoria", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente la categoria", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If CategoryAccess.DeleteCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente la categoria", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente la categoria", "Aceptar")
                    End If
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Function CanAcceptCategoryExecute() As Boolean
            Return ModelValidator.GetInstance.ValidateEmpty(Name)
        End Function
        Public Sub SearchCategory(ByVal Data As String)
            CategoriesList = CategoryAccess.SearchCategory(Data)
        End Sub
        Public Sub BackCategory()
            ShowFirstDialog = False
        End Sub
#End Region
#Region "Constructors"
        Sub New()
            MyBase.New()
            ModuleTitle = "Categoria"
            ServiceLocator.RegisterService(Of ICategoryDataService)(New CategoryDataService)
            CategoryAccess = GetService(Of ICategoryDataService)()
            CategoriesList = CategoryAccess.GetCategories

            AddCommand = New RelayCommand(AddressOf AddCategoryExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditCategoryExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteCategoryExecute)

            SearchCommand = New RelayCommand(AddressOf SearchCategory)
            BackCommand = New RelayCommand(AddressOf BackCategory)
            CancelCommand = New RelayCommand(AddressOf CancelCategoryExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptCategoryExecute, AddressOf CanAcceptCategoryExecute)
        End Sub
#End Region

    End Class
End Namespace

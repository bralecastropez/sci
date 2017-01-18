Imports System.Windows.Controls
Imports SCI.BusinessLogic.Services
Imports SCI.BusinessObjects.Validators
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.Infrastructure.Helpers
Imports SCI.Infrastructure.Util
Imports SCI.Modules.Category.Views

Namespace SCI.Modules.Category.ViewModels
    Public Class CategoryViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _CategoriesList As List(Of Global.Category)
        Private _SelectedCategory As Global.Category
        Private _CategoryAccess As ICategoryDataService
        Private _Name As String
        Private _Explanation As String
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
        Public Property Explanation As String
            Get
                Return _Explanation
            End Get
            Set(value As String)
                _Explanation = value
                OnPropertyChanged("Explanation")
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
        Public Property CategoriesList() As List(Of Global.Category)
            Get
                Return _CategoriesList
            End Get
            Set(ByVal value As List(Of Global.Category))
                _CategoriesList = value
                OnPropertyChanged("CategoriesList")
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
#End Region
#Region "Contructors"
        Sub New()
            ModuleTitle = "Categoria"
            HeaderTitle = UserLogged.Employee.Name & " - Categoria"

            ServiceLocator.RegisterService(Of ICategoryDataService)(New CategoryDataService)
            CategoryAccess = GetService(Of ICategoryDataService)()

            CategoriesList = CategoryAccess.GetCategories

            AddCommand = New RelayCommand(AddressOf AddCategoryExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditCategoryExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteCategoryExecute)
            DetailCommand = New RelayCommand(AddressOf DetailCategoryExecute)

            CancelCommand = New RelayCommand(AddressOf CancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptCategoryExecute, AddressOf CanAcceptCategoryExecute)
            SearchCommand = New RelayCommand(AddressOf SearchCategory)
            BackCommand = New RelayCommand(AddressOf BackExecute)

        End Sub
#End Region
#Region "Functions"
        Private Function CanAcceptCategoryExecute() As Boolean
            Dim Result As Boolean = False
            Try
                If ModelValidator.GetInstance.ValidateEmpty(Name) Then
                    Result = True
                End If
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType].ToString, "Error en 'CanAddCategoryExecute'")
            End Try
            Return Result
        End Function
#End Region
#Region "Methods"
        Private Sub AcceptCategoryExecute()
            If MaintanceType.Add = Maintance Then
                SelectedCategory = New Global.Category
            End If
            SelectedCategory.Name = Name
            SelectedCategory.Explanation = Explanation
            Select Case Maintance
                Case MaintanceType.Add
                    If CategoryAccess.AddCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se agregó correctamente la categoria", "Aceptar")
                    End If
                Case MaintanceType.Edit
                    If CategoryAccess.EditCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente el empleado", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se actualizó correctamente la categoria", "Aceptar")
                    End If
                Case MaintanceType.Delete
                    If CategoryAccess.DeleteCategory(SelectedCategory) Then
                        'SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente el empleado", "", "Aceptar")
                        'ShowSecondDialog = True
                        ShowSnackbarMessage("Se eliminó correctamente la categoria", "Aceptar")
                    End If
                Case MaintanceType.Detail
                    Dim printDlg As New PrintDialog
                    printDlg.PrintVisual(PrintDialog, "Window Printing.")
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Sub EditCategoryExecute()
            LoadFields()
            EditExecute(New CrudCategoryView(Me))
        End Sub

        Public Sub DeleteCategoryExecute()
            LoadFields()
            DeleteExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub DetailCategoryExecute()
            LoadFields()
            DetailExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub AddCategoryExecute()
            CleanFields()
            AddExecute(New CrudCategoryView(Me))
        End Sub
        Public Overloads Sub CancelExecute()
            ShowFirstDialog = False
            CleanFields()
        End Sub
        Public Overrides Sub LoadFields()
            Name = SelectedCategory.Name
            Explanation = SelectedCategory.Explanation
        End Sub
        Public Overrides Sub CleanFields()
            Name = ""
            Explanation = ""
            CategoriesList = CategoryAccess.GetCategories
        End Sub
        Public Sub SearchCategory(ByVal Data As String)
            CategoriesList = CategoryAccess.SearchCategory(Data)
        End Sub
#End Region

    End Class
End Namespace
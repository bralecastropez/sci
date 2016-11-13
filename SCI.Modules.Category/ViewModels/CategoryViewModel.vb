Imports SCI.Infrastructure.Helpers
Imports SCI.BusinessLogic.Services
Imports SCI.Modules.Category.Views
Imports System.Windows.Input
Imports SCI.BusinessObjects.ViewHelpers.Views
Imports SCI.BusinessObjects.Domain

Namespace SCI.Modules.Category.ViewModels
    Public Class CategoryViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _CategoryAccess As ICategoryDataService
        Private _CategoriesList As List(Of Categoria)
        Private _SelectedCategory As Categoria
        Private _Nombre As String
        Private _Descripcion As String
#End Region
#Region "Properties"
        Public Property Descripcion As String
            Get
                Return _Descripcion
            End Get
            Set(ByVal value As String)
                _Descripcion = value
                OnPropertyChanged("Descripcion")
            End Set
        End Property
        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set(ByVal value As String)
                _Nombre = value
                OnPropertyChanged("Nombre")
            End Set
        End Property
        Public Property SelectedCategory As Categoria
            Get
                Return _SelectedCategory
            End Get
            Set(value As Categoria)
                _SelectedCategory = value
                OnPropertyChanged("SelectedCategory")
            End Set
        End Property
        Public Property CategoriesList() As List(Of Categoria)
            Get
                Return _CategoriesList
            End Get
            Set(ByVal value As List(Of Categoria))
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
#End Region
#Region "Methods"
        Public Overrides Sub CleanFields()
            Nombre = ""
            Descripcion = ""
            CategoriesList = CategoryAccess.GetCategories
        End Sub
        Public Sub AddCategoryExecute()
            AddExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub EditCategoryExecute()
            Nombre = SelectedCategory.Nombre
            Descripcion = SelectedCategory.Descripcion
            EditExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub DeleteCategoryExecute()
            Nombre = SelectedCategory.Nombre
            Descripcion = SelectedCategory.Descripcion
            DeleteExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub CancelCategoryExecute()
            CleanFields()
            CancelExecute()
        End Sub
        Public Sub AcceptCategoryExecute()
            If Maintance = MaintanceType.Add Then
                SelectedCategory = New Categoria
            End If
            SelectedCategory.Nombre = Nombre
            SelectedCategory.Descripcion = Descripcion
            Select Case Maintance
                Case MaintanceType.Add
                    If CategoryAccess.AddCategory(SelectedCategory) Then
                        SecondDialogContent = New ConfirmDialogView("Éxito", "Se agregó correctamente la categoria", "Aceptar")
                        ShowSecondDialog = True
                    End If
                Case MaintanceType.Edit
                    If CategoryAccess.EditCategory(SelectedCategory) Then
                        SecondDialogContent = New ConfirmDialogView("", "Se actualizó correctamente la categoria", "Aceptar")
                        ShowSecondDialog = True
                    End If
                Case MaintanceType.Delete
                    If CategoryAccess.DeleteCategory(SelectedCategory) Then
                        SecondDialogContent = New ConfirmDialogView("Se eliminó correctamente la categoria", "", "Aceptar")
                        ShowSecondDialog = True
                    End If
            End Select
            CleanFields()
            AcceptExecute()
        End Sub
        Public Function CanAcceptCategoryExecute() As Boolean
            'Return (Not String.IsNullOrWhiteSpace(Nombre))
            If String.IsNullOrWhiteSpace(Nombre) Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Sub SearchCategory(ByVal Data As String)
            CategoriesList = CategoryAccess.SearchCategory(Data)
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
            CancelCommand = New RelayCommand(AddressOf CancelCategoryExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptCategoryExecute, AddressOf CanAcceptCategoryExecute)

        End Sub
#End Region

    End Class
End Namespace

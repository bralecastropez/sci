Imports SCI.Infrastructure.Helpers
Imports SCI.BusinessLogic.Services
Imports SCI.Modules.Category.Views
Imports System.Windows.Input
Imports SCI.BusinessObjects.ViewHelpers.Views

Namespace SCI.Modules.Category.ViewModels
    Public Class CategoryViewModel
        Inherits GuiViewBase

#Region "Campos"
        Private _ListadoDeCategorias As List(Of Categoria)
        Private _categoryAccess As ICategoryDataService
        'Categoria
        Private _CategoriaSeleccionada As Categoria
        Private _Nombre As String
        Private _Descripcion As String
#End Region
#Region "Propiedades"
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
        Public Property CategoriaSeleccionada As Categoria
            Get
                Return _CategoriaSeleccionada
            End Get
            Set(value As Categoria)
                _CategoriaSeleccionada = value
                OnPropertyChanged("CategoriaSeleccionada")
            End Set
        End Property
        Public Property ListadoDeCategorias() As List(Of Categoria)
            Get
                Return _ListadoDeCategorias
            End Get
            Set(ByVal value As List(Of Categoria))
                _ListadoDeCategorias = value
                OnPropertyChanged("ListadoDeCategorias")
            End Set
        End Property
        Public Property SearchCommand As ICommand
#End Region
#Region "Metodos"
        Public Sub AddCategoryExecute()
            AddExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub EditCategoryExecute()
            Nombre = CategoriaSeleccionada.Nombre
            Descripcion = CategoriaSeleccionada.Descripcion
            EditExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub DeleteCategoryExecute()
            Nombre = CategoriaSeleccionada.Nombre
            Descripcion = CategoriaSeleccionada.Descripcion
            DeleteExecute(New CrudCategoryView(Me))
        End Sub
        Public Sub CancelCategoryExecute()
            Nombre = ""
            Descripcion = ""
            ListadoDeCategorias = _categoryAccess.GetCategories
            CancelExecute()
        End Sub
        Public Sub AcceptCategoryExecute()
            Select Case Mantenimiento
                Case TipoMantenimiento.Agregar
                    Dim NuevaCategoria As New Categoria
                    NuevaCategoria.Descripcion = Descripcion
                    NuevaCategoria.Nombre = Nombre
                    _categoryAccess.AddCategory(NuevaCategoria)
                    ContenidoSegundoDialogo = New ConfirmDialogView("Éxito", "Se agregó correctamente la categoria", "Aceptar")
                    MostrarSegundoDialogo = True
                Case TipoMantenimiento.Editar
                    CategoriaSeleccionada.Nombre = Nombre
                    CategoriaSeleccionada.Descripcion = Descripcion
                    _categoryAccess.EditCategory(CategoriaSeleccionada)
                    ContenidoSegundoDialogo = New ConfirmDialogView("Éxito", "Se actualizó correctamente la categoria", "Aceptar")
                    MostrarSegundoDialogo = True
                Case TipoMantenimiento.Eliminar
                    CategoriaSeleccionada.Nombre = Nombre
                    CategoriaSeleccionada.Descripcion = Descripcion
                    _categoryAccess.DeleteCategory(CategoriaSeleccionada)
                    ContenidoSegundoDialogo = New ConfirmDialogView("Éxito", "Se eliminó correctamente la categoria", "Aceptar")
                    MostrarSegundoDialogo = True
            End Select
            Nombre = ""
            Descripcion = ""
            ListadoDeCategorias = _categoryAccess.GetCategories
            AcceptExecute()
        End Sub
        Public Function CanAcceptCategoryExecute() As Boolean
            Return (Not String.IsNullOrEmpty(Nombre))
        End Function

        Public Sub Buscar(ByVal Obj As Object)

        End Sub
#End Region
#Region "Constructores"
        Sub New()
            MyBase.New()
            TituloModulo = "Categoria"
            ServiceLocator.RegisterService(Of ICategoryDataService)(New CategoryDataService)
            _categoryAccess = GetService(Of ICategoryDataService)()
            ListadoDeCategorias = _categoryAccess.GetCategories

            'SearchCommand = New AnotherCommandImplementation(Buscar)

            AddCommand = New RelayCommand(AddressOf AddCategoryExecute, AddressOf CanAddExecute)
            EditCommand = New RelayCommand(AddressOf EditCategoryExecute, AddressOf CanEditExecute)
            DeleteCommand = New RelayCommand(AddressOf DeleteCategoryExecute, AddressOf CanDeleteExecute)
            CancelCommand = New RelayCommand(AddressOf CancelCategoryExecute, AddressOf CanCancelExecute)
            AcceptCommand = New RelayCommand(AddressOf AcceptCategoryExecute, AddressOf CanAcceptCategoryExecute)
        End Sub
#End Region

    End Class
End Namespace

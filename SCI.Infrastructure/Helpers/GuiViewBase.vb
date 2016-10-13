Imports System.Windows.Input

Namespace SCI.Infrastructure.Helpers
    Public Class GuiViewBase
        Inherits ViewModelBase

#Region "Campos"
        'Dialogos
        Private _MostrarPrimerDialogo As Boolean
        Private _MostrarSegundoDialogo As Boolean
        Private _ContenidoPrimerDialogo
        Private _ContenidoSegundoDialogo
        'Componentes
        Private _TituloModulo As String
        Private _TituloCrud As String
        Private _TituloBotonCancelar As String
        Private _TituloBotonEjecutar As String
        Private _Mantenimiento As TipoMantenimiento
        Private _MantenimientoCrud As TipoMantenimientoDetalle
        Private _Habilitado As Boolean
        Private _VisibleEliminar As String
        'Mantenimientos
        Enum TipoMantenimiento
            Agregar
            Eliminar
            Editar
            Imprimir
        End Enum
        Enum TipoMantenimientoDetalle
            Agregar
            Eliminar
            Editar
            Imprimir
        End Enum
#End Region

#Region "Propiedades"
        Public Property TituloModulo As String
            Get
                Return _TituloModulo
            End Get
            Set(value As String)
                _TituloModulo = value
            End Set
        End Property
        Public Property TituloCrud As String
            Get
                Return _TituloCrud
            End Get
            Set(value As String)
                _TituloCrud = value
                OnPropertyChanged("TituloCrud")
            End Set
        End Property
        Public Property TituloBotonCancelar As String
            Get
                Return _TituloBotonCancelar
            End Get
            Set(value As String)
                _TituloBotonCancelar = value
                OnPropertyChanged("TituloBotonCancelar")
            End Set
        End Property
        Public Property TituloBotonEjecutar As String
            Get
                Return _TituloBotonEjecutar
            End Get
            Set(value As String)
                _TituloBotonEjecutar = value
                OnPropertyChanged("TituloBotonEjecutar")
            End Set
        End Property
        Public Property Mantenimiento As TipoMantenimiento
            Get
                Return _Mantenimiento
            End Get
            Set(value As TipoMantenimiento)
                _Mantenimiento = value
            End Set
        End Property
        Public Property MantenimientoCrud As TipoMantenimientoDetalle
            Get
                Return _MantenimientoCrud
            End Get
            Set(value As TipoMantenimientoDetalle)
                _MantenimientoCrud = value
            End Set
        End Property
        Public Property Habilitado As Boolean
            Get
                Return _Habilitado
            End Get
            Set(value As Boolean)
                _Habilitado = value
                OnPropertyChanged("Habilitado")
            End Set
        End Property
        Public Property MostrarPrimerDialogo As Boolean
            Get
                Return _MostrarPrimerDialogo
            End Get
            Set(value As Boolean)
                _MostrarPrimerDialogo = value
                OnPropertyChanged("MostrarPrimerDialogo")
            End Set
        End Property
        Public Property ContenidoPrimerDialogo
            Get
                Return _ContenidoPrimerDialogo
            End Get
            Set(value)
                _ContenidoPrimerDialogo = value
                OnPropertyChanged("ContenidoPrimerDialogo")
            End Set
        End Property
        Public Property MostrarSegundoDialogo As Boolean
            Get
                Return _MostrarSegundoDialogo
            End Get
            Set(value As Boolean)
                _MostrarSegundoDialogo = value
                OnPropertyChanged("MostrarSegundoDialogo")
            End Set
        End Property
        Public Property ContenidoSegundoDialogo
            Get
                Return _ContenidoSegundoDialogo
            End Get
            Set(value)
                _ContenidoSegundoDialogo = value
                OnPropertyChanged("ContenidoSegundoDialogo")
            End Set
        End Property
        Public Property VisibleEliminar As String
            Get
                Return _VisibleEliminar
            End Get
            Set(ByVal value As String)
                _VisibleEliminar = value
                OnPropertyChanged("VisibleEliminar")
            End Set
        End Property
        'Eventos
        Public Property AddCommand As ICommand
        Public Property EditCommand As ICommand
        Public Property DeleteCommand As ICommand
        Public Property CancelCommand As ICommand
        Public Property AcceptCommand As ICommand
#End Region

#Region "Constructores"
        Sub New()
            MyBase.New()
        End Sub
#End Region

#Region "Metodos"
#Region "Comandos"
        Public Sub AddExecute(ByVal Contenido As Object)
            MostrarPrimerDialogo = True
            TituloCrud = "Agregar " & TituloModulo
            ContenidoPrimerDialogo = Contenido
            Mantenimiento = TipoMantenimiento.Agregar
            TituloBotonCancelar = "Cancelar"
            TituloBotonEjecutar = "Agregar"
            VisibleEliminar = "Hidden"
            Habilitado = True
        End Sub
        Public Sub EditExecute(ByVal Contenido As Object)
            MostrarPrimerDialogo = True
            TituloCrud = "Editar " & TituloModulo
            ContenidoPrimerDialogo = Contenido
            Mantenimiento = TipoMantenimiento.Editar
            TituloBotonCancelar = "Cancelar"
            TituloBotonEjecutar = "Editar"
            VisibleEliminar = "Hidden"
            Habilitado = True
        End Sub
        Public Sub DeleteExecute(ByVal Contenido As Object)
            MostrarPrimerDialogo = True
            TituloCrud = "Eliminar " & TituloModulo
            ContenidoPrimerDialogo = Contenido
            Mantenimiento = TipoMantenimiento.Eliminar
            TituloBotonCancelar = "No"
            TituloBotonEjecutar = "Si"
            VisibleEliminar = "Visible"
            Habilitado = False
        End Sub
        Public Sub AcceptExecute()
            CancelExecute()
        End Sub
        Public Sub CancelExecute()
            MostrarPrimerDialogo = False
        End Sub
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
#End Region
#End Region
    End Class
End Namespace

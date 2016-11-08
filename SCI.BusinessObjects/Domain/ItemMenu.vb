Imports SCI.Infrastructure.Helpers

Namespace SCI.BusinessObjects.Domain
    Public Class ItemMenu
        Inherits ViewModelBase

#Region "Campos"
        Private _Nombre As String
        Private _Contenido As Object
#End Region

#Region "Propiedades"
        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set(ByVal value As String)
                _Nombre = value
                OnPropertyChanged("Nombre")
            End Set
        End Property
        Public Property Contenido As Object
            Get
                Return _Contenido
            End Get
            Set(ByVal value As Object)
                _Contenido = value
                OnPropertyChanged("Contenido")
            End Set
        End Property
#End Region
#Region "Constructores"
        Sub New(ByVal Nombre As String, ByVal Contenido As Object)
            Me.Nombre = Nombre
            Me.Contenido = Contenido
        End Sub

#End Region
    End Class

End Namespace
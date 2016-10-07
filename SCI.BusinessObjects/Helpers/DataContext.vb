Imports SCI.BusinessObjects.Models
Imports System.Data.Metadata.Edm
Imports System.Reflection
Imports System.IO
Imports System.Xml
Imports System.Data.Mapping

Public Class DataContext

    Private Shared _DBEntities As DbInventarioEntities
    Public Shared Property DBEntities() As DbInventarioEntities
        Get
            If _DBEntities Is Nothing Then
                _DBEntities = New DbInventarioEntities()
            End If
            Return _DBEntities
        End Get
        Set(value As DbInventarioEntities)
            _DBEntities = value
        End Set
    End Property

End Class

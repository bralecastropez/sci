'------------------------------------------------------------------------------
' <auto-generated>
'    Este código se generó a partir de una plantilla.
'
'    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Inventario
    Public Property IdInventario As Integer
    Public Property IdUsuario As Integer
    Public Property Fecha As Date
    Public Property Estado As Boolean
    Public Property Tipo As String
    Public Property Entradas As Nullable(Of Integer)
    Public Property Salidas As Nullable(Of Integer)

    Public Overridable Property Usuario As Usuario
    Public Overridable Property Producto_Inventario As ICollection(Of Producto_Inventario) = New HashSet(Of Producto_Inventario)

End Class
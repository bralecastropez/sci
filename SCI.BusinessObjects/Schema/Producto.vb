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

Partial Public Class Producto
    Public Property IdProducto As Integer
    Public Property IdCategoria As Integer
    Public Property CodigoProducto As String
    Public Property Nombre As String
    Public Property Descripcion As String
    Public Property Imagen As String
    Public Property PrecioCompra As Nullable(Of Decimal)
    Public Property PrecioUnitario As Decimal
    Public Property PrecioDocena As Nullable(Of Decimal)
    Public Property PrecioMayor As Nullable(Of Decimal)

    Public Overridable Property Categoria As Categoria
    Public Overridable Property Producto_Factura As ICollection(Of Producto_Factura) = New HashSet(Of Producto_Factura)
    Public Overridable Property Producto_Compra As ICollection(Of Producto_Compra) = New HashSet(Of Producto_Compra)
    Public Overridable Property Producto_Inventario As ICollection(Of Producto_Inventario) = New HashSet(Of Producto_Inventario)

End Class
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

Partial Public Class Pedido
    Public Property IdPedido As Integer
    Public Property IdCliente As Integer
    Public Property IdCaja As Integer
    Public Property CodigoPedido As String
    Public Property FechaPedido As Nullable(Of Date)
    Public Property FechaEntrega As Date
    Public Property Estado As Integer
    Public Property Total As Integer

    Public Overridable Property Caja As Caja
    Public Overridable Property Cliente As Cliente
    Public Overridable Property Venta As ICollection(Of Venta) = New HashSet(Of Venta)

End Class

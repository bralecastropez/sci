'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Inventory
    Public Property InventoryId As Integer
    Public Property ReaderId As Integer
    Public Property Title As String
    Public Property InventaryDate As Date
    Public Property InventoryState As Nullable(Of Boolean)
    Public Property InventoryType As String
    Public Property Entries As Nullable(Of Integer)
    Public Property Departures As Nullable(Of Integer)

    Public Overridable Property Reader As Reader
    Public Overridable Property Product_Inventory As ICollection(Of Product_Inventory) = New HashSet(Of Product_Inventory)

End Class
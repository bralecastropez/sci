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

Partial Public Class Product_Inventory
    Public Property ProductId As Integer
    Public Property InventoryId As Integer
    Public Property Amount As Nullable(Of Integer)
    Public Property RegisterType As String

    Public Overridable Property Inventory As Inventory
    Public Overridable Property Product As Product

End Class
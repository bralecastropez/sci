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

Partial Public Class Product
    Public Property ProductId As Integer
    Public Property CategoryId As Integer
    Public Property ProductCode As String
    Public Property Name As String
    Public Property Explanation As String
    Public Property ImageSrc As String
    Public Property PurchasePrice As Nullable(Of Decimal)
    Public Property UnitPrice As Decimal
    Public Property PricePerDozen As Nullable(Of Decimal)
    Public Property WholesalePrice As Nullable(Of Decimal)
    Public Property AddedDate As Nullable(Of Date)
    Public Property Tag As String
    Public Property Review As String
    Public Property AditionalInformation As String
    Public Property Help As String
    Public Property CreationDate As Nullable(Of Date)
    Public Property ModificationDate As Nullable(Of Date)

    Public Overridable Property Category As Category
    Public Overridable Property Product_Sale As ICollection(Of Product_Sale) = New HashSet(Of Product_Sale)
    Public Overridable Property Product_Inventory As ICollection(Of Product_Inventory) = New HashSet(Of Product_Inventory)
    Public Overridable Property Product_Purchase As ICollection(Of Product_Purchase) = New HashSet(Of Product_Purchase)

    Public Overrides Function ToString() As String
        Return Name
    End Function


End Class

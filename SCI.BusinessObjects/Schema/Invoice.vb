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

Partial Public Class Invoice
    Public Property InvoiceId As Integer
    Public Property CustomerId As Integer
    Public Property CheckoutId As Integer
    Public Property InvoiceCode As String
    Public Property Serial As String
    Public Property InvoiceDate As Nullable(Of Date)
    Public Property Explanation As String
    Public Property Total As Nullable(Of Decimal)

    Public Overridable Property Checkout As Checkout
    Public Overridable Property Customer As Customer

End Class

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

Partial Public Class Category
    Public Property CategoryId As Integer
    Public Property Name As String
    Public Property Explanation As String
    Public Property CreationDate As Nullable(Of Date)
    Public Property ModificationDate As Nullable(Of Date)

    Public Overridable Property Product As ICollection(Of Product) = New HashSet(Of Product)

End Class

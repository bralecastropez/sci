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

Partial Public Class Empresa
    Public Property IdEmpresa As Integer
    Public Property Nombre As String
    Public Property Licencia As String
    Public Property Pass As String
    Public Property Clave As String
    Public Property Sucursales As Integer
    Public Property Estado As Boolean
    Public Property Direccion As String
    Public Property Telefono As String
    Public Property Correo As String

    Public Overridable Property Equipo As ICollection(Of Equipo) = New HashSet(Of Equipo)
    Public Overridable Property Reporte As ICollection(Of Reporte) = New HashSet(Of Reporte)
    Public Overridable Property Sucursal As ICollection(Of Sucursal) = New HashSet(Of Sucursal)

End Class

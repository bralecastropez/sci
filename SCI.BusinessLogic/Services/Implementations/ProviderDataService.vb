Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util
Namespace SCI.BusinessLogic.Services
    Public Class ProviderDataService
        Implements IProviderDataService

        Public Function AddProvider(Provider As Provider) As Boolean Implements IProviderDataService.AddProvider
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Provider.Add(Provider)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Insertar Proveedor")
            End Try
            Return Resultado
        End Function

        Public Function DeleteProvider(Provider As Provider) As Boolean Implements IProviderDataService.DeleteProvider
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Provider.Remove(Provider)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Eliminar Proveedor")
            End Try
            Return Resultado
        End Function

        Public Function EditProvider(Provider As Provider) As Boolean Implements IProviderDataService.EditProvider
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(Provider).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Editar Proveedor")
            End Try
            Return Resultado
        End Function

        Public Function GetProviders() As List(Of Provider) Implements IProviderDataService.GetProviders
            Dim Resultado As List(Of Provider) = New List(Of Provider)
            Try
                Resultado = DataContext.DBEntities.Provider.ToList
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Listar Proveedores")
            End Try
            Return Resultado
        End Function

        Public Function SearchProvider(Data As String) As List(Of Provider) Implements IProviderDataService.SearchProvider
            Dim Result As ICollection(Of Provider) = New List(Of Provider)
            Try
                For Each _Provider In GetProviders()
                    Dim _Type As Type = _Provider.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(_Provider, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(_Provider)
                            Exit For
                        End If
                    Next
                Next
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Buscar Proveedor")
            End Try
            Return Result
        End Function
    End Class
End Namespace

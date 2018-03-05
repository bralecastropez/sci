Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util
Namespace SCI.BusinessLogic.Services
    Public Class InventoryDataService
        Implements IInventoryDataService

        Public Function AddDetailInventory(Product_Inventory As Product_Inventory) As Boolean Implements IInventoryDataService.AddDetailInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Product_Inventory.Add(Product_Inventory)
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Insertar Detalle Inventario")
            End Try
            Return Result
        End Function

        Public Function AddInventory(Inventory As Inventory) As Boolean Implements IInventoryDataService.AddInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Inventory.Add(Inventory)
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Insertar Inventario")
            End Try
            Return Result
        End Function

        Public Function DeleteDetailInventory(Product_Inventory As Product_Inventory) As Boolean Implements IInventoryDataService.DeleteDetailInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Product_Inventory.Remove(Product_Inventory)
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Eliminar Detalle Inventario")
            End Try
            Return Result
        End Function

        Public Function DeleteInventory(Inventory As Inventory) As Boolean Implements IInventoryDataService.DeleteInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Product_Inventory.RemoveRange(GetDetailInventory(Inventory))
                DataContext.DBEntities.Inventory.Remove(Inventory)
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Eliminar Inventario")
            End Try
            Return Result
        End Function

        Public Function EditDetailInventory(Product_Inventory As Product_Inventory) As Boolean Implements IInventoryDataService.EditDetailInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Entry(Product_Inventory).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Editar Detalle Inventario")
            End Try
            Return Result
        End Function

        Public Function EditInventory(Inventory As Inventory) As Boolean Implements IInventoryDataService.EditInventory
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Entry(Inventory).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch Ex As Exception
                Result = False
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Editar Inventario")
            End Try
            Return Result
        End Function

        Public Function GetDetailInventory(Inventory As Inventory) As List(Of Product_Inventory) Implements IInventoryDataService.GetDetailInventory
            Dim Result As List(Of Product_Inventory) = New List(Of Product_Inventory)
            Try
                Result = (From Detail In DataContext.DBEntities.Product_Inventory.ToList
                          Where Detail.InventoryId = Inventory.InventoryId).ToList
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Listar Inventarios")
            End Try
            Return Result
        End Function

        Public Function GetInventories() As List(Of Inventory) Implements IInventoryDataService.GetInventories
            Dim Result As List(Of Inventory) = New List(Of Inventory)
            Try
                Result = DataContext.DBEntities.Inventory.ToList
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Listar Inventarios")
            End Try
            Return Result
        End Function

        Public Function GetProducts() As List(Of Product) Implements IInventoryDataService.GetProducts
            Dim Result As List(Of Product) = New List(Of Product)
            Try
                Result = DataContext.DBEntities.Product.ToList
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Listar Productos")
            End Try
            Return Result
        End Function

        Public Function GetReaders() As List(Of Reader) Implements IInventoryDataService.GetReaders
            Dim Result As List(Of Reader) = New List(Of Reader)
            Try
                Result = DataContext.DBEntities.Reader.ToList
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Listar Usuarios")
            End Try
            Return Result
        End Function

        Public Function SearchDetailInventory(Inventory As Inventory, Data As String) As List(Of Product_Inventory) Implements IInventoryDataService.SearchDetailInventory
            Dim Result As ICollection(Of Product_Inventory) = New List(Of Product_Inventory)
            Try
                For Each _Inventory In GetDetailInventory(Inventory)
                    Dim _Type As Type = _Inventory.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(_Inventory, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(_Inventory)
                            Exit For
                        End If
                    Next
                Next
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Buscar Detalle Inventarios")
            End Try
            Return Result
        End Function

        Public Function SearchInventory(Data As String) As List(Of Inventory) Implements IInventoryDataService.SearchInventory
            Dim Result As ICollection(Of Inventory) = New List(Of Inventory)
            Data = Trim(Data)
            Data = Data.ToLower
            If Not String.IsNullOrEmpty(Data) = True Or Not String.IsNullOrWhiteSpace(Data) = True Then
                Try
                    For Each _Inventory In GetInventories()
                        Dim _Type As Type = _Inventory.GetType()
                        Dim _Properties() As PropertyInfo = _Type.GetProperties()
                        For Each _Property As PropertyInfo In _Properties
                            If (_Property.GetValue(_Inventory, Nothing).ToString.ToLower.Trim.Contains(Data)) Then
                                Result.Add(_Inventory)
                                Exit For
                            End If
                        Next
                    Next
                Catch Ex As Exception
                    SCILog.Instance.Control(Ex, [GetType]().ToString, "Error al Buscar Inventarios")
                End Try
            End If
            Return Result
        End Function
    End Class
End Namespace

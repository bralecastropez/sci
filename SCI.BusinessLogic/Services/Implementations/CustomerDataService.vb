Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessLogic.Services
    Public Class CustomerDataService
        Implements ICustomerDataService

        Public Function AddCustomer(Customer As Customer) As Boolean Implements ICustomerDataService.AddCustomer
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Customer.Add(Customer)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Result = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Insertar Customer")
            End Try
            Return Result
        End Function

        Public Function DeleteCustomer(Customer As Customer) As Boolean Implements ICustomerDataService.DeleteCustomer
            Dim Result As Boolean = True
            Try
                DataContext.DBEntities.Customer.Remove(Customer)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Result = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Eliminar Customer")
            End Try
            Return Result
        End Function

        Public Function Edit(Customer As Customer) As Boolean Implements ICustomerDataService.EditCustomer
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(Customer).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Editar Customer")
            End Try
            Return Resultado
        End Function

        Public Function GetCustomers() As List(Of Customer) Implements ICustomerDataService.GetCustomers
            Dim Result As List(Of Customer) = New List(Of Customer)
            Try
                Result = DataContext.DBEntities.Customer.ToList
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Listar Clientes")
            End Try
            Return Result
        End Function

        Public Function SearchCustomer(Data As String) As List(Of Customer) Implements ICustomerDataService.SearchCustomer
            Dim Result As List(Of Customer) = New List(Of Customer)
            Try
                For Each _Customer In GetCustomers()
                    Dim _Type As Type = _Customer.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(_Customer, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(_Customer)
                            Exit For
                        End If
                    Next
                Next
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Buscar Customer")
            End Try
            Return Result
        End Function
    End Class
End Namespace

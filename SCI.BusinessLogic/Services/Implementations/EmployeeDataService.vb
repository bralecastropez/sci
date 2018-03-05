Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessLogic.Services
    Public Class EmployeeDataService
        Implements IEmployeeDataService

        Public Function AddEmployee(Employee As Employee) As Boolean Implements IEmployeeDataService.AddEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Employee.Add(Employee)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Insertar Employee")
            End Try
            Return Resultado
        End Function

        Public Function DeleteEmployee(Employee As Employee) As Boolean Implements IEmployeeDataService.DeleteEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Employee.Remove(Employee)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Eliminar Employee")
            End Try
            Return Resultado
        End Function

        Public Function EditEmployee(Employee As Employee) As Boolean Implements IEmployeeDataService.EditEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(Employee).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Editar Empleado")
            End Try
            Return Resultado
        End Function

        Public Function GetEmployees() As List(Of Employee) Implements IEmployeeDataService.GetEmployees
            Dim Resultado As List(Of Employee) = New List(Of Employee)
            Try
                Resultado = DataContext.DBEntities.Employee.ToList
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Listar Empleados")
            End Try
            Return Resultado
        End Function

        Public Function SearchEmployee(Data As String) As List(Of Employee) Implements IEmployeeDataService.SearchEmployee
            Dim Result As ICollection(Of Employee) = New List(Of Employee)
            Try
                For Each Employee In GetEmployees()
                    Dim _Type As Type = Employee.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(Employee, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(Employee)
                            Exit For
                        End If
                    Next
                Next
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Buscar Employee")
            End Try
            Return Result
        End Function
    End Class
End Namespace

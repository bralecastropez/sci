Imports System.Data.Entity
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessLogic.Services
    Public Class EmployeeDataService
        Implements IEmployeeDataService

        Public Function AddEmployee(Employee As Empleado) As Object Implements IEmployeeDataService.AddEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Empleado.Add(Employee)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Insertar Empleado")
            End Try
            Return Resultado
        End Function

        Public Function DeleteEmployee(Employee As Empleado) As Object Implements IEmployeeDataService.DeleteEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Empleado.Remove(Employee)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Eliminar Empleado")
            End Try
            Return Resultado
        End Function

        Public Function EditEmployee(Employee As Empleado) As Object Implements IEmployeeDataService.EditEmployee
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(Employee).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Editar Empleado")
            End Try
            Return Resultado
        End Function

        Public Function GetEmployees() As List(Of Empleado) Implements IEmployeeDataService.GetEmployees
            Dim Resultado As List(Of Empleado) = New List(Of Empleado)
            Try
                Resultado = DataContext.DBEntities.Empleado.ToList
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Listar Empleados")
            End Try
            Return Resultado
        End Function

        Public Function SearchEmployee(Data As String) As List(Of Empleado) Implements IEmployeeDataService.SearchEmployee
            Dim Resultado As List(Of Empleado) = New List(Of Empleado)
            Try
                Resultado = (From em In DataContext.DBEntities.Empleado.ToList Where em.Nombre.ToLower.Contains(Data.ToLower)).ToList
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Buscar Empleado")
            End Try
            Return Resultado
        End Function
    End Class
End Namespace

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
                Dim EmployeeToDelete As Empleado = (From emp In DataContext.DBEntities.Empleado
                                                    Where emp.IdEmpleado = Employee.IdEmpleado
                                                    Select emp).SingleOrDefault()
                DataContext.DBEntities.Empleado.Remove(EmployeeToDelete)
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
                Dim EmployeeToEdit As Empleado = (From emp In DataContext.DBEntities.Empleado
                                                  Where emp.IdEmpleado = Employee.IdEmpleado
                                                  Select emp).SingleOrDefault()

                EmployeeToEdit.Nombre = Employee.Nombre
                EmployeeToEdit.Apellido = Employee.Apellido
                EmployeeToEdit.Comentario = Employee.Comentario
                EmployeeToEdit.Correo = Employee.Correo
                EmployeeToEdit.Direccion = Employee.Direccion
                EmployeeToEdit.Dpi = Employee.Dpi
                EmployeeToEdit.Genero = Employee.Genero
                EmployeeToEdit.Telefono = Employee.Telefono
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
                Dim Busqueda1 = (From em In DataContext.DBEntities.Empleado.ToList
                                 Where em.Nombre.Contains(Data))
                Resultado = DataContext.DBEntities.Empleado.ToList
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Buscar Empleado")
            End Try
            Return Resultado
        End Function
    End Class
End Namespace

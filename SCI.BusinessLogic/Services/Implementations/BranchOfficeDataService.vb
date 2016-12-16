Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util
Namespace SCI.BusinessLogic.Services
    Public Class BranchOfficeDataService
        Implements IBranchOfficeDataService

        Public Function AddBranchOffice(BranchOffice As BranchOffice) As Boolean Implements IBranchOfficeDataService.AddBranchOffice
            Dim Resultado As Boolean = True
            Try
                BranchOffice.Company = DataContext.DBEntities.Company.ToList.FirstOrDefault
                DataContext.DBEntities.BranchOffice.Add(BranchOffice)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Insertar Caja")
            End Try
            Return Resultado
        End Function

        Public Function DeleteBranchOffice(BranchOffice As BranchOffice) As Boolean Implements IBranchOfficeDataService.DeleteBranchOffice
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.BranchOffice.Remove(BranchOffice)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Eliminar Caja")
            End Try
            Return Resultado
        End Function

        Public Function EditBranchOffice(BranchOffice As BranchOffice) As Boolean Implements IBranchOfficeDataService.EditBranchOffice
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(BranchOffice).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Editar Caja")
            End Try
            Return Resultado
        End Function

        Public Function GetBranchOffices() As List(Of BranchOffice) Implements IBranchOfficeDataService.GetBranchOffices
            Dim Resultado As List(Of BranchOffice) = New List(Of BranchOffice)
            Try
                Resultado = DataContext.DBEntities.BranchOffice.ToList
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Listar Caja")
            End Try
            Return Resultado
        End Function

        Public Function SearchBranchOffice(Data As String) As List(Of BranchOffice) Implements IBranchOfficeDataService.SearchBranchOffice
            Dim Result As ICollection(Of BranchOffice) = New List(Of BranchOffice)
            Try
                For Each _BranchOffice In GetBranchOffices()
                    Dim _Type As Type = _BranchOffice.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(_BranchOffice, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(_BranchOffice)
                            Exit For
                        End If
                    Next
                Next
            Catch ex As Exception
                SCILog.GetInstance.Control(ex, [GetType]().ToString, "Error al Buscar Caja")
            End Try
            Return Result
        End Function
    End Class
End Namespace

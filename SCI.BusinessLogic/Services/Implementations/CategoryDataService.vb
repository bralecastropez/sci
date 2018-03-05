Imports System.Data.Entity
Imports System.Reflection
Imports SCI.Infrastructure.Util
Namespace SCI.BusinessLogic.Services
    Public Class CategoryDataService
        Implements ICategoryDataService

        Public Function AddCategory(Category As Category) As Boolean Implements ICategoryDataService.AddCategory
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Category.Add(Category)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Insertar Category")
            End Try
            Return Resultado
        End Function

        Public Function DeleteCategory(Category As Category) As Boolean Implements ICategoryDataService.DeleteCategory
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Category.Remove(Category)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Eliminar Category")
            End Try
            Return Resultado
        End Function

        Public Function EditCategory(Category As Category) As Boolean Implements ICategoryDataService.EditCategory
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Entry(Category).State = EntityState.Modified
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Editar Category")
            End Try
            Return Resultado
        End Function

        Public Function GetCategories() As List(Of Category) Implements ICategoryDataService.GetCategories
            Dim Resultado As List(Of Category) = New List(Of Category)
            Try
                Resultado = DataContext.DBEntities.Category.ToList
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Listar Categorias")
            End Try
            Return Resultado
        End Function

        Public Function SearchCategory(Data As String) As List(Of Category) Implements ICategoryDataService.SearchCategory
            Dim Result As ICollection(Of Category) = New List(Of Category)
            Try
                For Each _Category In GetCategories()
                    Dim _Type As Type = _Category.GetType()
                    Dim _Properties() As PropertyInfo = _Type.GetProperties()
                    For Each _Property As PropertyInfo In _Properties
                        If (_Property.GetValue(_Category, Nothing).ToString.ToLower.Trim.Contains(Data.ToLower)) Then
                            Result.Add(_Category)
                            Exit For
                        End If
                    Next
                Next
            Catch ex As Exception
                SCILog.Instance.Control(ex, [GetType]().ToString, "Error al Buscar Category")
            End Try
            Return Result
        End Function
    End Class
End Namespace

﻿Imports SCI.BusinessLogic.Util
Namespace SCI.BusinessLogic.Services
    Public Class CategoryDataService
        Implements ICategoryDataService

        Public Function AddCategory(Category As Categoria) As Boolean Implements ICategoryDataService.AddCategory
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Categoria.Add(Category)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instancia.Control(ex, [GetType]().ToString, "Error al Insertar Categoria")
            End Try
            Return Resultado
        End Function

        Public Function DeleteCategory(Category As Categoria) As Boolean Implements ICategoryDataService.DeleteCategory
            Dim Resultado As Boolean = True
            Try
                Dim CategoriaEliminar As Categoria = (From cat In DataContext.DBEntities.Categoria
                                                      Where cat.IdCategoria = Category.IdCategoria
                                                      Select cat).SingleOrDefault()
                DataContext.DBEntities.Categoria.Remove(CategoriaEliminar)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instancia.Control(ex, [GetType]().ToString, "Error al Eliminar Categoria")
            End Try
            Return Resultado
        End Function

        Public Function EditCategory(Category As Categoria) As Boolean Implements ICategoryDataService.EditCategory
            Dim Resultado As Boolean = True
            Try
                Dim CategoriaEditar As Categoria = (From cat In DataContext.DBEntities.Categoria
                                                    Where cat.IdCategoria = Category.IdCategoria
                                                    Select cat).SingleOrDefault()
                CategoriaEditar.Nombre = Category.Nombre
                CategoriaEditar.Descripcion = Category.Descripcion
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                SCILog.Instancia.Control(ex, [GetType]().ToString, "Error al Editar Categoria")
            End Try
            Return Resultado
        End Function

        Public Function GetCategories() As List(Of Categoria) Implements ICategoryDataService.GetCategories
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Resultado = DataContext.DBEntities.Categoria.ToList
            Catch ex As Exception
                SCILog.Instancia.Control(ex, [GetType]().ToString, "Error al Listar Categorias")
            End Try
            Return Resultado
        End Function

        Public Function SearchCategory(Data As String) As List(Of Categoria) Implements ICategoryDataService.SearchCategory
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Dim query1 = (From c In DataContext.DBEntities.Categoria
                              Where c.Nombre.Contains(Data)
                              Select c).ToList
                Dim query2 = (From c In DataContext.DBEntities.Categoria
                              Where c.Descripcion.Contains(Data)
                              Select c).ToList
                If IsNumeric(Data) Then
                    Dim Valor1 As Integer = (Integer.Parse(Data))
                    Dim query = (From c In DataContext.DBEntities.Categoria
                                 Where c.IdCategoria = Valor1
                                 Select c).ToList
                    If query.Count > 0 Then
                        Resultado = query
                    ElseIf query1.Count > 0 Then
                        Resultado = query1
                    ElseIf query2.Count > 0 Then
                        Resultado = query2
                    End If
                Else
                    If query1.Count > 0 Then
                        Resultado = query1
                    ElseIf query2.Count > 0 Then
                        Resultado = query2
                    End If
                End If
            Catch ex As Exception
                SCILog.Instancia.Control(ex, [GetType]().ToString, "Error al Buscar Categoria")
            End Try
            Return Resultado
        End Function
    End Class
End Namespace

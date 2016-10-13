Imports SCI.BusinessObjects.Models
Imports SCI.Infrastructure.Helpers
Namespace SCI.BusinessLogic.Services
    Public Class CategoryDataService
        Implements ICategoryDataService

        Public Function Buscar(Valor As String) As List(Of Categoria) Implements ICategoryDataService.Buscar
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Dim query1 = (From c In DataContext.DBEntities.Categoria
                              Where c.Nombre.Contains(Valor)
                              Select c).ToList
                Dim query2 = (From c In DataContext.DBEntities.Categoria
                              Where c.Descripcion.Contains(Valor)
                              Select c).ToList
                If IsNumeric(Valor) Then
                    Dim Valor1 As Integer = (Integer.Parse(Valor))
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
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Buscar")
            End Try
            Return Resultado
        End Function

        Public Function BuscarPorDescripcion(Valor As String) As List(Of Categoria) Implements ICategoryDataService.BuscarPorDescripcion
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Resultado = (From c In DataContext.DBEntities.Categoria
                             Where c.Descripcion.Contains(Valor)
                             Select c).ToList
            Catch ex As Exception
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Buscar por Descripcion")
            End Try
            Return Resultado
        End Function

        Public Function BuscarPorId(Valor As String) As List(Of Categoria) Implements ICategoryDataService.BuscarPorId
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Dim Valor1 As Integer = (Integer.Parse(Valor))
                Resultado = (From c In DataContext.DBEntities.Categoria
                             Where c.IdCategoria = Valor1
                             Select c).ToList
            Catch ex As Exception
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Buscar por Id")
            End Try
            Return Resultado
        End Function

        Public Function BuscarPorNombre(Valor As String) As List(Of Categoria) Implements ICategoryDataService.BuscarPorNombre
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Resultado = (From c In DataContext.DBEntities.Categoria
                             Where c.Nombre.Contains(Valor)
                             Select c).ToList
            Catch ex As Exception
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Buscar por NOmbre")
            End Try
            Return Resultado
        End Function

        Public Function Editar(Categoria As Categoria) As Boolean Implements ICategoryDataService.Editar
            Dim Resultado As Boolean = True
            Try
                Dim CategoriaEditar As Categoria = (From cat In DataContext.DBEntities.Categoria
                                                    Where cat.IdCategoria = Categoria.IdCategoria
                                                    Select cat).SingleOrDefault()
                CategoriaEditar.Nombre = Categoria.Nombre
                CategoriaEditar.Descripcion = Categoria.Descripcion
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Editar")
            End Try
            Return Resultado
        End Function

        Public Function Eliminar(Categoria As Categoria) As Boolean Implements ICategoryDataService.Eliminar
            Dim Resultado As Boolean = True
            Try
                Dim CategoriaEliminar As Categoria = (From cat In DataContext.DBEntities.Categoria
                                                      Where cat.IdCategoria = Categoria.IdCategoria
                                                      Select cat).SingleOrDefault()
                DataContext.DBEntities.Categoria.Remove(CategoriaEliminar)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Eliminar")
            End Try
            Return Resultado
        End Function

        Public Function Insertar(Categoria As Categoria) As Boolean Implements ICategoryDataService.Insertar
            Dim Resultado As Boolean = True
            Try
                DataContext.DBEntities.Categoria.Add(Categoria)
                DataContext.DBEntities.SaveChanges()
            Catch ex As Exception
                Resultado = False
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Insertar")
            End Try
            Return Resultado
        End Function

        Public Function Listar() As List(Of Categoria) Implements ICategoryDataService.Listar
            Dim Resultado As List(Of Categoria) = Nothing
            Try
                Resultado = DataContext.DBEntities.Categoria.ToList
            Catch ex As Exception
                'SistemaInventarioLog.Instancia.Control(ex, Me.GetType().ToString, "Error al Listar")
            End Try
            Return Resultado
        End Function
    End Class
End Namespace

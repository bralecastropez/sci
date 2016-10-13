Namespace SCI.BusinessLogic.Services
    Public Interface ICategoryDataService
        Function Insertar(ByVal Categoria As Categoria) As Boolean
        Function Editar(ByVal Categoria As Categoria) As Boolean
        Function Eliminar(ByVal Categoria As Categoria) As Boolean
        Function Listar() As List(Of Categoria)
        Function Buscar(ByVal Valor As String) As List(Of Categoria)
        Function BuscarPorId(ByVal Valor As String) As List(Of Categoria)
        Function BuscarPorNombre(ByVal Valor As String) As List(Of Categoria)
        Function BuscarPorDescripcion(ByVal Valor As String) As List(Of Categoria)
    End Interface
End Namespace

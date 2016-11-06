Namespace SCI.BusinessLogic.Services
    Public Interface ICategoryDataService

        Function GetCategories() As List(Of Categoria)
        Function AddCategory(ByVal Category As Categoria) As Boolean
        Function EditCategory(ByVal Category As Categoria) As Boolean
        Function DeleteCategory(ByVal Category As Categoria) As Boolean
        Function SearchCategory(ByVal Data As String) As List(Of Categoria)

    End Interface
End Namespace

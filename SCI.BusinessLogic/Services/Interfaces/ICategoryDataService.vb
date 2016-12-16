Namespace SCI.BusinessLogic.Services
    Public Interface ICategoryDataService

        Function GetCategories() As List(Of Category)
        Function AddCategory(ByVal Category As Category) As Boolean
        Function EditCategory(ByVal Category As Category) As Boolean
        Function DeleteCategory(ByVal Category As Category) As Boolean
        Function SearchCategory(ByVal Data As String) As List(Of Category)

    End Interface
End Namespace

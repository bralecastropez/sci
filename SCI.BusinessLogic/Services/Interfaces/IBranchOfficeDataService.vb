Namespace SCI.BusinessLogic.Services
    Public Interface IBranchOfficeDataService
        Function GetBranchOffices() As List(Of BranchOffice)
        Function AddBranchOffice(ByVal BranchOffice As BranchOffice) As Boolean
        Function EditBranchOffice(ByVal BranchOffice As BranchOffice) As Boolean
        Function DeleteBranchOffice(ByVal BranchOffice As BranchOffice) As Boolean
        Function SearchBranchOffice(ByVal Data As String) As List(Of BranchOffice)
    End Interface
End Namespace
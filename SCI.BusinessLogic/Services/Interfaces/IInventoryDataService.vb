
Namespace SCI.BusinessLogic.Services
    Public Interface IInventoryDataService
        Function AddInventory(ByVal Inventory As Inventory) As Boolean
        Function EditInventory(ByVal Inventory As Inventory) As Boolean
        Function DeleteInventory(ByVal Inventory As Inventory) As Boolean
        Function GetInventories() As List(Of Inventory)
        Function GetReaders() As List(Of Reader)
        Function SearchInventory(ByVal Data As String) As List(Of Inventory)

        Function GetDetailInventory(ByVal Inventory As Inventory) As List(Of Product_Inventory)
        Function AddDetailInventory(ByVal Product_Inventory As Product_Inventory) As Boolean
        Function EditDetailInventory(ByVal Product_Inventory As Product_Inventory) As Boolean
        Function DeleteDetailInventory(ByVal Product_Inventory As Product_Inventory) As Boolean
        Function SearchDetailInventory(ByVal Inventory As Inventory, ByVal Data As String) As List(Of Product_Inventory)
        Function GetProducts() As List(Of Product)
    End Interface
End Namespace
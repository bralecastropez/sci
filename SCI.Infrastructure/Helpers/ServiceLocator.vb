Namespace SCI.Infrastructure.Helpers
    Public Class ServiceLocator
        Implements IServiceProvider
#Region "Fields"
        Private _services As New Dictionary(Of Type, Object)()
#End Region
#Region "Functions"
        Public Function GetService(Of T)() As T
            Return CType(GetService(GetType(T)), T)
        End Function
        Public Function RegisterService(Of T)(ByVal service As T, ByVal overwriteIfExists As Boolean) As Boolean
            SyncLock _services
                If Not _services.ContainsKey(GetType(T)) Then
                    _services.Add(GetType(T), service)
                    Return True
                ElseIf overwriteIfExists Then
                    _services(GetType(T)) = service
                    Return True
                End If
            End SyncLock
            Return False
        End Function
        Public Function RegisterService(Of T)(ByVal service As T) As Boolean
            Return RegisterService(Of T)(service, True)
        End Function
        Public Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService
            SyncLock _services
                If _services.ContainsKey(serviceType) Then
                    Return _services(serviceType)
                End If
            End SyncLock
            Return Nothing
        End Function
#End Region
    End Class
End Namespace


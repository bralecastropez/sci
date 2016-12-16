Public Class DataContext

    Private Shared _DBEntities As InventarioDemoEntities
    Public Shared Property DBEntities() As InventarioDemoEntities
        Get
            If _DBEntities Is Nothing Then
                _DBEntities = New InventarioDemoEntities()
            End If
            Return _DBEntities
        End Get
        Set(value As InventarioDemoEntities)
            _DBEntities = value
        End Set
    End Property

End Class

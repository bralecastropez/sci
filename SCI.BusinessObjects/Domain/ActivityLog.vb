Namespace SCI.BusinessObjects
    Public Class ActivityLog
#Region "Fields"
        Private _ModuleName As String
        Private _ActivityUser As String
        Private _ActivityDate As String
        Private _ActivityType As String
        Private _ActivityAction As String
        Private _ActivityDescription As String
#End Region
#Region "Properties"
        Public Property ModuleName As String
            Get
                Return _ModuleName
            End Get
            Set(value As String)
                _ModuleName = value
            End Set
        End Property
        Public Property ActivityUser As String
            Get
                Return _ActivityUser
            End Get
            Set(value As String)
                _ActivityUser = value
            End Set
        End Property
        Public Property ActivityDate As String
            Get
                Return _ActivityDate
            End Get
            Set(value As String)
                _ActivityDate = value
            End Set
        End Property
        Public Property ActivityType As String
            Get
                Return _ActivityType
            End Get
            Set(value As String)
                _ActivityType = value
            End Set
        End Property
        Public Property ActivityAction As String
            Get
                Return _ActivityAction
            End Get
            Set(value As String)
                _ActivityAction = value
            End Set
        End Property
        Public Property ActivityDescription As String
            Get
                Return _ActivityDescription
            End Get
            Set(value As String)
                _ActivityDescription = value
            End Set
        End Property
#End Region
#Region "Constructors"
        Public Sub New()

        End Sub
        Public Sub New(ByVal ModuleName As String, ByVal ActivityUser As String, ByVal ActivityDate As String, ByVal ActivityType As String, ByVal ActivityAction As String, ByVal ActivityDescription As String)
            Me.ModuleName = ModuleName
            Me.ActivityUser = ActivityUser
            Me.ActivityDate = ActivityDate
            Me.ActivityType = ActivityType
            Me.ActivityAction = ActivityAction
            Me.ActivityDescription = ActivityDescription
        End Sub
#End Region
    End Class
End Namespace
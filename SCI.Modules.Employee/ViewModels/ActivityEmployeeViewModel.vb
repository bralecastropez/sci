Imports SCI.BusinessObjects
Imports SCI.BusinessObjects.Helpers
Imports SCI.Infrastructure.Helpers

Namespace SCI.Modules.Employee.ViewModels
    Public Class ActivityEmployeeViewModel
        Inherits ViewModelBase
#Region "Fields"
        Private _EmployeeActivityListToday As List(Of ActivityLog)
        Private _EmployeeActivityListYesterday As List(Of ActivityLog)
        Private _EmployeeActivityListAll As List(Of ActivityLog)
        Private _SelectedActivity As ActivityLog
#End Region
#Region "Properties"
        Public Property EmployeeActivityListToday As List(Of ActivityLog)
            Get
                Return _EmployeeActivityListToday
            End Get
            Set(value As List(Of ActivityLog))
                _EmployeeActivityListToday = value
                OnPropertyChanged("EmployeeActivityListToday")
            End Set
        End Property
        Public Property EmployeeActivityListAll As List(Of ActivityLog)
            Get
                Return _EmployeeActivityListAll
            End Get
            Set(value As List(Of ActivityLog))
                _EmployeeActivityListAll = value
                OnPropertyChanged("_EmployeeActivityListAll")
            End Set
        End Property
        Public Property SelectedActivity As ActivityLog
            Get
                Return _SelectedActivity
            End Get
            Set(value As ActivityLog)
                _SelectedActivity = value
                OnPropertyChanged("SelectedActivity")
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub UpdateActivities()
            EmployeeActivityListToday = XmlHelper.Instance.GetListOfActivities("Employee")
        End Sub

#End Region
#Region "Functions"

#End Region
#Region "Constructors"
        Public Sub New()
            EmployeeActivityListToday = XmlHelper.Instance.GetListOfActivities("Employee")
            EmployeeActivityListAll = XmlHelper.Instance.GetListOfActivities("Employee")
        End Sub
#End Region
    End Class
End Namespace
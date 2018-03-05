Imports System.Globalization
Imports System.Xml
Imports SCI.Infrastructure.Util

Namespace SCI.BusinessObjects.Helpers
    Public Class XmlHelper
#Region "Fields"
        Private _ActivityList As List(Of ActivityLog)
        Private Shared _Instance As XmlHelper = Nothing
#End Region
#Region "Properties"
        Public Property ActivityList As List(Of ActivityLog)
            Get
                Return _ActivityList
            End Get
            Set(value As List(Of ActivityLog))
                _ActivityList = value
            End Set
        End Property
#End Region
#Region "Functions"
        Public Shared Function Instance() As XmlHelper
            If IsNothing(_Instance) Then
                _Instance = New XmlHelper
            End If
            Return _Instance
        End Function
        Public Function VerifyModules(ByVal ModuleName As String, ByVal ModuleDate As DateTime) As String
            Dim Result As String = ""
            Try
                'Dim LogDate As DateTime = DateTime.Now
                Dim LogDate As DateTime = ModuleDate
                Dim LogFolderPath As String = AppDomain.CurrentDomain.BaseDirectory
                Dim LogFileName As String = "/App/Activity/SCI-Activity-" & LogDate.Year & "-" & LogDate.Month & "-" & LogDate.Day
                Dim RoutePath As String = LogFolderPath & "/" & LogFileName
                If Not IO.Directory.Exists(LogFolderPath & "/App/Activity") Then
                    IO.Directory.CreateDirectory(LogFolderPath & "/App/Activity")
                End If
                If Not IO.Directory.Exists(RoutePath) Then
                    IO.Directory.CreateDirectory(RoutePath)
                End If
                Return RoutePath & "/" & ModuleName & ".xml"
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString, "Error al Verificar Modulos")
            End Try
            Return Result
        End Function
        Public Function GetListOfActivities(ByVal ModuleName As String) As List(Of ActivityLog)
            Dim Result As List(Of ActivityLog) = New List(Of ActivityLog)
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(VerifyModules(ModuleName, Now))
                Dim Nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/" & ModuleName & "/Activity")
                For Each Node As XmlNode In Nodes
                    Dim ElementActivity As New ActivityLog
                    ElementActivity.ActivityUser = Node.SelectSingleNode("User").InnerText
                    ElementActivity.ActivityDescription = Node.SelectSingleNode("Description").InnerText
                    ElementActivity.ActivityAction = Node.SelectSingleNode("Action").InnerText
                    ElementActivity.ActivityDate = Node.SelectSingleNode("Date").InnerText
                    ElementActivity.ActivityType = Node.SelectSingleNode("Type").InnerText
                    ElementActivity.ModuleName = ModuleName
                    Result.Add(ElementActivity)
                Next
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString(), "Error al Obtener Listado de Actividades")
            End Try
            Return Result
        End Function
        Public Function GetListOfActivitiesByDate(ByVal ModuleName As String, ByVal ModuleDate As DateTime) As List(Of ActivityLog)
            Dim Result As List(Of ActivityLog) = New List(Of ActivityLog)
            Try
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(VerifyModules(ModuleName, ModuleDate))
                Dim Nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/" & ModuleName & "/Activity")
                For Each Node As XmlNode In Nodes
                    Dim ElementActivity As New ActivityLog
                    ElementActivity.ActivityUser = Node.SelectSingleNode("User").InnerText
                    ElementActivity.ActivityDescription = Node.SelectSingleNode("Description").InnerText
                    ElementActivity.ActivityAction = Node.SelectSingleNode("Action").InnerText
                    ElementActivity.ActivityDate = Node.SelectSingleNode("Date").InnerText
                    ElementActivity.ActivityType = Node.SelectSingleNode("Type").InnerText
                    ElementActivity.ModuleName = ModuleName
                    Result.Add(ElementActivity)
                Next
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString(), "Error al Obtener Listado de Actividades")
            End Try
            Return Result
        End Function
        Private Function GetDateFromString(ByVal ParseDate As String) As DateTime
            Dim Result As New DateTime
            Try
                Dim ge As New GregorianCalendar
                Dim ca As Calendar
                Dim d As Date
                Dim dt As DateTime

            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString(), "Error al Obtener Fecha")
            End Try
            Return Result
        End Function
#End Region
#Region "Methods"
#End Region
#Region "Constructors"

#End Region
    End Class
End Namespace
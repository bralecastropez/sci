Imports System.Xml
Namespace SCI.Infrastructure.Util
    Public Class SCIActivity
#Region "Fields"
        Public Shared _Instance As SCIActivity = Nothing
#End Region
#Region "Properties"
        Public Shared Function Instance() As SCIActivity
            If IsNothing(_Instance) Then
                _Instance = New SCIActivity
            End If
            Return _Instance
        End Function
#End Region
#Region "Functions"
        Public Function VerifyModules(ByVal ModuleName As String) As String
            Dim Result As String = ""
            Try
                Dim LogDate As DateTime = DateTime.Now
                Dim LogFolderPath As String = AppDomain.CurrentDomain.BaseDirectory
                Dim LogFileName As String = "/App/Activity/SCI-Activity-" & LogDate.Year & "-" & LogDate.Month & "-" & LogDate.Day
                Dim RoutePath As String = LogFolderPath & "/" & LogFileName
                If Not IO.Directory.Exists(LogFolderPath & "/App/Activity") Then
                    IO.Directory.CreateDirectory(LogFolderPath & "/App/Activity")
                End If
                If Not IO.Directory.Exists(RoutePath) Then
                    IO.Directory.CreateDirectory(RoutePath)
                End If
                Dim Path As String = RoutePath & "/" & ModuleName & ".xml"

                If Not IO.File.Exists(Path) Then
                    Dim XmlModule As New XmlTextWriter(Path, System.Text.Encoding.UTF8)
                    XmlModule.WriteStartDocument(True)
                    XmlModule.Formatting = Formatting.Indented
                    XmlModule.Indentation = 2
                    XmlModule.WriteStartElement(ModuleName)
                    XmlModule.WriteEndElement()
                    XmlModule.WriteEndDocument()
                    XmlModule.Close()
                End If
                Return Path
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString, "Error al Verificar Modulos")
            End Try
            Return Result
        End Function
#End Region
#Region "Methods"
        Public Sub Register(ByVal ActivityModule As String, ActivityDescription As String, ByVal ActivityUser As String, ByVal ActivityType As String, ByVal ActivityAction As String)
            Try
                Dim XmlFile As New XmlDocument
                Dim Parent, Child As XmlNode

                XmlFile.Load(VerifyModules(ActivityModule))

                Parent = XmlFile.FirstChild
                Parent = Parent.OwnerDocument

                Child = XmlFile.CreateElement("Activity")
                XmlFile.DocumentElement.AppendChild(Child)

                CreateActivity("User", ActivityUser, Child, Parent)
                CreateActivity("Date", DateTime.Now, Child, Parent)
                CreateActivity("Type", ActivityType, Child, Parent)
                CreateActivity("Description", ActivityDescription, Child, Parent)
                CreateActivity("Action", ActivityAction, Child, Parent)

                XmlFile.Save(VerifyModules(ActivityModule))
            Catch Ex As Exception
                SCILog.Instance.Control(Ex, [GetType].ToString, "Error al Registrar Actividad")
            End Try
        End Sub

        Public Sub CreateActivity(ByVal Title As String, ByVal Value As String, ByVal Activity As XmlNode, ByVal Parent As XmlDocument)
            Dim Node As XmlNode
            Node = Parent.CreateElement(Title)
            Node.InnerText = Value
            Activity.AppendChild(Node)
        End Sub
#End Region
#Region "Contructors"
        Public Sub New()

        End Sub
#End Region
    End Class
End Namespace
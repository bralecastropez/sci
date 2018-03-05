Namespace SCI.Infrastructure.Util
    Public Class SCILog
#Region "Fields"
        Public Shared _Instance As SCILog = Nothing
#End Region
#Region "Methods"
        Public Shared Function Instance() As SCILog
            If IsNothing(_Instance) Then
                _Instance = New SCILog
            End If
            Return _Instance
        End Function
        Private Sub LogFile(ByVal ExceptionName As String, ByVal EventName As String, ByVal ControlName As String, ByVal LineNumber As String, ByVal ClassName As String)
            Try
                Dim LogDate As DateTime = DateTime.Now
                Dim LogFolderPath As String = AppDomain.CurrentDomain.BaseDirectory
                Dim LogFileName As String = "/App/Log/SCI-Log-" & LogDate.Year & "-" & LogDate.Month & "-" & LogDate.Day
                Dim RoutePath As String = LogFolderPath & LogFileName
                'If Not IO.Directory.Exists(LogFolderPath & "/App/Log") Then
                '    IO.Directory.CreateDirectory(LogFolderPath & "/App/Log")
                'End If
                If Not IO.Directory.Exists(RoutePath) Then
                    IO.Directory.CreateDirectory(RoutePath)
                End If
                Dim Path As String = RoutePath & "/" & "SistemaInventario-debug-log.txt"

                If Not IO.File.Exists(Path) Then
                    Using FileSystem As New IO.FileStream(Path, IO.FileMode.CreateNew), File As New IO.StreamWriter(FileSystem)
                        File.WriteLine(" ------------------------------>  Error  <------------------------------------- ")
                        File.WriteLine(" Fecha: " & LogDate)
                        File.WriteLine(" Nombre de la Excepcion: " & ExceptionName)
                        File.WriteLine(" Nombre del Evento: " & EventName)
                        File.WriteLine(LineNumber)
                        File.WriteLine(" Nombre de la Clase: " & ClassName)
                        File.WriteLine(" ------------------------------> Fin del Error <------------------------------------- ")
                        File.Close()
                    End Using
                Else
                    Using FileSystem As New IO.FileStream(Path, IO.FileMode.Append), File As New IO.StreamWriter(FileSystem)
                        File.WriteLine(" ------------------------------>  Error  <------------------------------------- ")
                        File.WriteLine(" Fecha: " & LogDate)
                        File.WriteLine(" Nombre de la Excepcion: " & ExceptionName)
                        File.WriteLine(" Nombre del Evento: " & EventName)
                        File.WriteLine(LineNumber)
                        File.WriteLine(" Nombre de la Clase: " & ClassName)
                        File.WriteLine(" ------------------------------> Fin del Error <------------------------------------- ")
                        File.Close()
                    End Using
                End If
            Catch Ex As Exception
                'MsgBox("Error en el Log ---> " & Ex.Message)
                Control(Ex, [GetType].ToString, "Log")
            End Try
        End Sub

        Private Function GetLine(ByVal Exception As Exception) As String
            Dim LineNumber As String = ""
            Try
                Dim ErrorLine() As String = Exception.ToString.Split(".vb:línea ")
                For i As Integer = 0 To (ErrorLine.Length - 1)
                    If ErrorLine(i).ToString.Contains("vb:línea ") Then
                        LineNumber = " Número de Línea: " & ErrorLine(i).Replace("vb:línea ", "")
                    End If
                Next
            Catch Ex As Exception
                MsgBox("Error en el Log --- NoLinea ---> " & Ex.Message)
            End Try
            Return LineNumber
        End Function

        Public Sub Control(ByVal Exception As Exception, ByVal ClassName As String, ByVal ReferenceMethod As String)
            Try
                LogFile(Exception.Message, Exception.ToString, ReferenceMethod, GetLine(Exception), ClassName)
            Catch ex As Exception
                MsgBox("Error en el Control ---> " & ex.Message)
            End Try
        End Sub
#End Region
#Region "Contructors"
        Private Sub New()

        End Sub
#End Region
    End Class

End Namespace
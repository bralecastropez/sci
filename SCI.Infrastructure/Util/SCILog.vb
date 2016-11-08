Namespace SCI.Infrastructure.Util
    Public Class SCILog
#Region "Fields"
        Public Shared _Instance As SCILog = Nothing
#End Region
#Region "Methods"
        Public Shared Function GetInstance() As SCILog
            If IsNothing(_Instance) Then
                _Instance = New SCILog
            End If
            Return _Instance
        End Function
        Private Sub ArchivoLog(ByVal NombreExcepcion As String, ByVal NombreEvento As String, ByVal NombreControl As String, ByVal NumeroDeLinea As String, ByVal NombreClase As String)
            Try
                'Dim Archivo As New System.IO.StreamWriter("C:\\SistemaInventario-debug-log.txt")
                Dim Path As String = "sci-debug-log.txt"
                'Dim Archivo As New System.IO.StreamWriter("SistemaInventario-debug-log.txt")

                If Not IO.File.Exists(Path) Then
                    Using FileSystem As New IO.FileStream(Path, IO.FileMode.CreateNew), Archivo As New IO.StreamWriter(FileSystem)
                        Archivo.WriteLine(" ------------------------------>  Error <------------------------------------- ")
                        Archivo.WriteLine("Fecha: " & DateTime.Now)
                        Archivo.WriteLine("Nombre de la Excepcion: " & NombreExcepcion)
                        Archivo.WriteLine("Nombre del Evento: " & NombreEvento)
                        Dim Linea() As String = NombreEvento.Split(".vb:línea ")
                        Archivo.WriteLine("Número de Línea: " & Linea(24).Replace("vb:línea ", ""))
                        Archivo.WriteLine("Nombre de la Clase: " & NombreClase)
                        Archivo.WriteLine(" ----------------------------------------------------------------------------- ")
                        Archivo.Close()
                    End Using
                Else
                    Using FileSystem As New IO.FileStream(Path, IO.FileMode.Append), Archivo As New IO.StreamWriter(FileSystem)
                        Archivo.WriteLine(" ------------------------------>  Error <------------------------------------- ")
                        Archivo.WriteLine("Fecha: " & DateTime.Now)
                        Archivo.WriteLine("Nombre de la Excepcion: " & NombreExcepcion)
                        Archivo.WriteLine("Nombre del Evento: " & NombreEvento)
                        Dim Linea() As String = NombreEvento.Split(".vb:línea ")
                        Archivo.WriteLine("Número de Línea: " & Linea(24).Replace("vb:línea ", ""))
                        Archivo.WriteLine("Nombre de la Clase: " & NombreClase)
                        Archivo.WriteLine(" ----------------------------------------------------------------------------- ")
                        Archivo.Close()
                    End Using
                End If

            Catch ex As Exception
                MsgBox("Error en el Log ---> " & ex.Message)
            End Try
        End Sub

        Private Function Linea(ByVal Excepcion As Exception) As String
            Dim NoLinea As String = ""
            Try
                NoLinea = Convert.ToInt32(Excepcion.InnerException)
            Catch ex As Exception
                MsgBox("Error en el Log --- NoLinea ---> " & ex.Message)
            End Try
            Return NoLinea
        End Function

        Public Sub Control(ByVal Excepcion As Exception, ByVal Nombre As String, ByVal MetodoReferencia As String)
            Try
                ArchivoLog(Excepcion.Message, Excepcion.ToString, MetodoReferencia, Linea(Excepcion), Nombre)
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
Imports System.Xml
Public Class ReadApp

    Public Function GetAppValue(ByVal KeyName As String) As String

        Dim xmlReader As XmlTextReader

        Try
            xmlReader = New XmlTextReader("E:\BackUp\Docs\DocumentosEjemplos\.Net\Visual Studio 2005\Drag & Drop\TreeViewDragDrop\PresentationLayer\App.config")
            While (xmlReader.Read)
                Select Case xmlReader.NodeType
                    Case XmlNodeType.Element
                        If xmlReader.HasAttributes Then
                            If xmlReader.MoveToFirstAttribute = True Then
                                If UCase(KeyName) = UCase(xmlReader.Value) Then
                                    If xmlReader.MoveToNextAttribute = True Then
                                        Return xmlReader.Value
                                        Exit Function
                                    End If
                                End If
                            End If
                        End If

                    Case XmlNodeType.Text

                End Select
            End While
            If Not xmlReader Is Nothing Then
                xmlReader.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

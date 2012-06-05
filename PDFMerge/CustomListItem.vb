Structure CustomListItem
    Dim FileName As String
    Dim FullPath As String
    Sub New(ByVal file As String, ByVal path As String)
        FileName = file
        FullPath = path
    End Sub
    Public Overrides Function ToString() As String
        Return FileName
    End Function
End Structure
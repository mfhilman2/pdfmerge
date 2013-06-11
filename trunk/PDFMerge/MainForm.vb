Imports System.IO

Imports iTextSharp.text.pdf
Public Class MainForm
    Dim Files As List(Of String)

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click

        Dim ofd As New OpenFileDialog
        ofd.Filter = "PDF Files (*.PDF)|*.PDF"
        ofd.Multiselect = True
        If (ofd.ShowDialog() <> Windows.Forms.DialogResult.OK) Then Return

        For Each file As String In ofd.FileNames
            Files = ofd.FileNames.ToList()
            Dim index As Integer = Me.FileList.Items.Add(New CustomListItem(System.IO.Path.GetFileName(file), file))
            Me.FileList.SetItemChecked(index, True)
        Next
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.FileList.Items.Count > 0 Then
            For i As Integer = 0 To Me.FileList.Items.Count - 1
                Me.FileList.SetItemChecked(i, Me.CheckBox1.Checked)
            Next
        End If
    End Sub
    Private Sub FileList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileList.SelectedIndexChanged
        If FileList.SelectedIndex > -1 Then
            'Dim img As Image = Image.FromFile(DirectCast(FileList.SelectedItem, CustomListItem).FullPath)
            'If Not img Is Nothing Then
            '    Me.picPreview.Image = img.GetThumbnailImage(60, 60, Nothing, New IntPtr())
            '    Me.lblheight.Text = String.Format("{0} x {1}", img.Height, img.Width)
            'End If
            'img.Dispose()
        End If
    End Sub
    Private Sub cmdConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConvert.Click

        If Me.FileList.CheckedItems.Count = 0 Then
            MessageBox.Show("Please select PNG files to convert.")
            Return
        End If

        Try

            lblProgress.Text = ""
            pbar.Value = 0

            Dim fsd As New SaveFileDialog
            fsd.Filter = "PDF Files (*.PDF)|*.PDF"
            If fsd.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                Return
            End If

            Dim total As Integer = Me.FileList.CheckedItems.Count
            pbar.Maximum = total
            Application.DoEvents()

            Files.Clear()

            For Each item As CustomListItem In Me.FileList.CheckedItems
                Files.Add(item.FullPath)
            Next

            CombineMultiplePDFs(Files, fsd.FileName)



            lblProgress.Text = "Writing to PDF file"
            lblProgress.Refresh()
            Threading.Thread.Sleep(10)


            lblProgress.Text = "Completed ..."
            Threading.Thread.Sleep(10)

            'If MessageBox.Show("Do you want to open the generated PDF file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            '    System.Diagnostics.Process.Start(fsd.FileName)
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CombineMultiplePDFs(ByVal fileNames As List(Of String), ByVal outFile As String)
        Dim pageOffset As Integer = 0
        Dim master As New ArrayList()
        Dim f As Integer = 0

        Dim document As iTextSharp.text.Document = Nothing
        Dim writer As PdfCopy = Nothing
        While f < fileNames.Count
            ' we create a reader for a certain document


            pbar.Value = f
            pbar.Refresh()
            lblProgress.Text = String.Format("Processing {0} of {1}", f, fileNames.Count)
            Application.DoEvents()


            Dim reader As New PdfReader(fileNames(f))
            reader.ConsolidateNamedDestinations()
            ' we retrieve the total number of pages
            Dim n As Integer = reader.NumberOfPages
            Dim bookmarks As ArrayList = SimpleBookmark.GetBookmark(reader)
            If bookmarks IsNot Nothing Then
                If pageOffset <> 0 Then
                    SimpleBookmark.ShiftPageNumbers(bookmarks, pageOffset, Nothing)
                End If
                master.AddRange(bookmarks)
            End If
            pageOffset += n

            If f = 0 Then
                ' step 1: creation of a document-object
                document = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
                ' step 2: we create a writer that listens to the document
                writer = New PdfCopy(document, New FileStream(outFile, FileMode.Create))
                ' step 3: we open the document
                document.Open()
            End If
            ' step 4: we add content
            Dim i As Integer = 0
            While i < n
                i += 1
                If writer IsNot Nothing Then
                    Dim page As PdfImportedPage = writer.GetImportedPage(reader, i)
                    writer.AddPage(page)
                End If
            End While
            Dim form As PRAcroForm = reader.AcroForm
            If form IsNot Nothing AndAlso writer IsNot Nothing Then
                writer.CopyAcroForm(reader)
            End If
            f += 1
        End While
        pbar.Value = pbar.Maximum
        If master.Count > 0 AndAlso writer IsNot Nothing Then
            writer.Outlines = master
        End If
        ' step 5: we close the document
        If document IsNot Nothing Then
            document.Close()
        End If
    End Sub

End Class

Imports System.IO
Imports org.apache.pdfbox.PDFMerger
Imports org.apache.pdfbox.util
Imports java.io.File
Imports java.io.FileInputStream
Imports java.io.IOException
Imports java.io.InputStream
Imports java.io.OutputStream
Imports java.util.ArrayList
Imports java.util.Vector
Imports org.apache.pdfbox.cos.COSArray
Imports org.apache.pdfbox.cos.COSDictionary
Imports org.apache.pdfbox.cos.COSInteger
Imports org.apache.pdfbox.cos.COSName
Imports org.apache.pdfbox.cos.COSNumber
Imports org.apache.pdfbox.cos.COSStream
Imports org.apache.pdfbox.exceptions.COSVisitorException
Imports org.apache.pdfbox.pdmodel.PDDocumentCatalog
Imports org.apache.pdfbox.pdmodel.PDDocumentInformation
Imports org.apache.pdfbox.pdmodel.PDDocumentNameDictionary
Imports org.apache.pdfbox.pdmodel.common.COSArrayList
Imports org.apache.pdfbox.pdmodel.common.PDStream
Imports org.apache.pdfbox.pdmodel.interactive.documentnavigation.outline.PDDocumentOutline
Imports org.apache.pdfbox.pdmodel.interactive.documentnavigation.outline.PDOutlineItem
Imports org.apache.pdfbox.pdmodel.interactive.form.PDAcroForm
Imports org.apache.pdfbox.pdmodel.interactive.form.PDField
Imports org.apache.pdfbox.pdmodel.interactive.form.PDFieldFactory
Public Class MainForm
    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "PDF Files (*.PDF)|*.PDF"
        ofd.Multiselect = True
        If (ofd.ShowDialog() <> Windows.Forms.DialogResult.OK) Then Return

        For Each file As String In ofd.FileNames
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

       
            Dim merger As PDFMergerUtility = New PDFMergerUtility()
            Dim count As Integer
            For Each item As CustomListItem In Me.FileList.CheckedItems

                merger.addSource(item.FullPath)

                count += 1
                pbar.Value = count
                pbar.Refresh()
                lblProgress.Text = String.Format("Processing {0} of {1}", count, total)
                Application.DoEvents()
            Next


            lblProgress.Text = "Writing to PDF file"
            lblProgress.Refresh()
            Threading.Thread.Sleep(10)

            merger.setDestinationFileName(fsd.FileName)
            merger.mergeDocuments()


            lblProgress.Text = "Completed ..."
            Threading.Thread.Sleep(10)

            'If MessageBox.Show("Do you want to open the generated PDF file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            '    System.Diagnostics.Process.Start(fsd.FileName)
            'End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    
End Class

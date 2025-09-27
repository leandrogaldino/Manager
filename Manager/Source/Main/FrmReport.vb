Imports System.IO
Imports ControlLibrary
Public Class FrmReport
    Private _Result As ReportResult
    Public Sub New(Result As ReportResult)
        InitializeComponent()
        _Result = Result
    End Sub
    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        AddHandler Parent.FindForm.Resize, AddressOf FrmMain_ResizeEnd
        If _Result IsNot Nothing Then
            PdfDocumentViewer.Load(_Result.FilePath & ".pdf")
            LblDocumentPage.Text = " De " & PdfDocumentViewer.PageCount
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim Index As Integer
        Dim Page As TabPage
        If Not Control.ModifierKeys = Keys.Shift Then
            Index = FrmMain.TcWindows.SelectedIndex
            Page = FrmMain.TcWindows.SelectedTab
            FrmMain.TcWindows.TabPages.Remove(Page)
            Page.Dispose()
            If Index > 0 Then
                FrmMain.TcWindows.SelectTab(Index - 1)
            End If
        Else
            For Each Page In FrmMain.TcWindows.TabPages
                FrmMain.TcWindows.TabPages.Remove(Page)
                Page.Dispose()
            Next Page
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub FrmMain_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Parent.FindForm IsNot Nothing Then
            Height = Parent.FindForm.Height - 196
            Width = Parent.FindForm.Width - 24
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SfdDocument.Title = "Salvar Relatório"
        SfdDocument.Filter = "Arquivo PDF (*.pdf*)|*.pdf|Planilha do Excel (*.xlsx*)|*.xlsx"
        SfdDocument.FileName = _Result.ReportName
        If SfdDocument.ShowDialog = DialogResult.OK Then
            Try
                If Path.GetExtension(SfdDocument.FileName) = ".pdf" Then
                    File.Copy(_Result.FilePath & ".pdf", SfdDocument.FileName, True)
                Else
                    File.Copy(_Result.FilePath & ".xlsx", SfdDocument.FileName, True)
                End If
            Catch ex As IOException
                CMessageBox.Show("Não foi possível salvar, o arquivo está sendo usado por outro processo.", CMessageBoxType.Warning)
            End Try
        End If
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Using Dialog As New PrintDialog
            Dialog.Document = PdfDocumentViewer.PrintDocument
            If Dialog.ShowDialog() = DialogResult.OK Then
                Dialog.Document.Print()
            End If
        End Using
    End Sub
    Private Sub DisplayRectangleChanged()
        TxtCurrentPage.Text = PdfDocumentViewer.CurrentPageIndex + 1
    End Sub
    Private Sub TxtCurrentPage_TextChanged(sender As Object, e As EventArgs) Handles TxtCurrentPage.TextChanged
        If PdfDocumentViewer.IsDocumentLoaded Then
            If Not String.IsNullOrEmpty(TxtCurrentPage.Text) Then
                If TxtCurrentPage.Text = "0" Then
                    TxtCurrentPage.Text = "1"
                    TxtCurrentPage.Select(TxtCurrentPage.TextLength, 0)
                    PdfDocumentViewer.GoToPageAtIndex(1)
                Else
                    If PdfDocumentViewer.PageCount >= TxtCurrentPage.Text Then
                        PdfDocumentViewer.GoToPageAtIndex(TxtCurrentPage.Text)
                    ElseIf TxtCurrentPage.Text > PdfDocumentViewer.CurrentPageIndex Then
                        TxtCurrentPage.Text = PdfDocumentViewer.PageCount
                        TxtCurrentPage.Select(TxtCurrentPage.TextLength, 0)
                        PdfDocumentViewer.GoToPageAtIndex(PdfDocumentViewer.PageCount)
                    Else
                        PdfDocumentViewer.GoToPageAtIndex(1)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TxtCurrentPage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCurrentPage.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub BtnZoomOut_Click(sender As Object, e As EventArgs) Handles BtnZoomOut.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage - 10)
    End Sub
    Private Sub BtnZoomIn_Click(sender As Object, e As EventArgs) Handles BtnZoomIn.Click
        PdfDocumentViewer.ZoomTo(PdfDocumentViewer.ZoomPercentage + 10)
    End Sub
    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles BtnEmail.Click
        Using Form As New FrmEmail(_Result.Attachments)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub PdfDocumentViewer_CurrentPageChanged(sender As Object, args As EventArgs)
        TxtCurrentPage.Text = PdfDocumentViewer.CurrentPageIndex
    End Sub
End Class
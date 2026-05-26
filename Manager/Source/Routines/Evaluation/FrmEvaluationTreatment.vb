Imports System.Runtime.InteropServices
Imports ControlLibrary
Public Class FrmEvaluationTreatment
    Private _Evaluation As Evaluation
    Private _LargeImageList As New ImageList()
    Private Const LVM_FIRST As Integer = &H1000
    Private Const LVM_SETICONSPACING As Integer = LVM_FIRST + 53
    Public Sub New(Evaluation As Evaluation)
        InitializeComponent()
        _Evaluation = Evaluation
    End Sub
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbxCode.SelectedIndex = 0
        LvPictures.View = View.LargeIcon
        LvPictures.CheckBoxes = True
        LvPictures.MultiSelect = True
        LvPictures.ShowItemToolTips = False
        LvPictures.LabelWrap = False
        _LargeImageList.ImageSize = New Size(200, 200)
        _LargeImageList.ColorDepth = ColorDepth.Depth32Bit
        LvPictures.LargeImageList = _LargeImageList
        Dim pasta As String = "C:\Users\leand\Downloads"
        Dim index As Integer = 0
        For Each arquivo In IO.Directory.GetFiles(pasta)
            Try
                Dim img As Image = Image.FromFile(arquivo)
                Dim thumb = CriarThumbnail(img, 200, 200)
                _LargeImageList.Images.Add(thumb)
                Dim item As New ListViewItem With {
                    .Tag = arquivo,
                    .ImageIndex = index
                }
                LvPictures.Items.Add(item)
                index += 1
            Catch
            End Try
            Dim spacingX As Integer = 205
            Dim spacingY As Integer = 205
            Dim lParam As Integer = spacingX Or (spacingY << 16)
            SendMessage(LvPictures.Handle, LVM_SETICONSPACING, 0, lParam)
        Next
    End Sub

    Private Function CriarThumbnail(img As Image, largura As Integer, altura As Integer) As Image
        Dim bmp As New Bitmap(largura, altura)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Transparent)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Dim ratioX = largura / img.Width
            Dim ratioY = altura / img.Height
            Dim ratio = Math.Min(ratioX, ratioY)
            Dim novaLargura = CInt(img.Width * ratio)
            Dim novaAltura = CInt(img.Height * ratio)
            Dim posX = (largura - novaLargura) \ 2
            Dim posY = (altura - novaAltura) \ 2
            g.DrawImage(img, posX, posY, novaLargura, novaAltura)
        End Using
        Return bmp
    End Function
    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAll.CheckedChanged
        If CbxAll.Checked Then
            For Each item As ListViewItem In LvPictures.Items
                item.Checked = True
            Next
        Else
            For Each item As ListViewItem In LvPictures.Items
                item.Checked = False
            Next
        End If
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim SelectedPictures As New List(Of String)
        Dim ShowIdAsCode As Boolean = CbxCode.SelectedIndex = 0
        For Each SelectedItem As ListViewItem In LvPictures.CheckedItems
            SelectedPictures.Add(SelectedItem.Tag.ToString())
        Next SelectedItem

        Dim Result As ReportResult
        Try
            Cursor = Cursors.WaitCursor
            BtnGenerate.Enabled = False
            Result = EvaluationReport.EvaluationTreatment(_Evaluation, ShowIdAsCode, SelectedPictures)
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New UcReport(Result), "Relatório de Ficha Cadastral da Pessoa")
        Catch ex As Exception
            CMessageBox.Show("ERRO PS013", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class
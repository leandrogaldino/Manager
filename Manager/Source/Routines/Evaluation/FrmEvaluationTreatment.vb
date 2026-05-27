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
    Private Sub FrmEvaluationTreatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CbxCode.SelectedIndex = 0
        LvPictures.View = View.LargeIcon
        LvPictures.CheckBoxes = True
        LvPictures.MultiSelect = True
        LvPictures.ShowItemToolTips = False
        LvPictures.LabelWrap = False
        _LargeImageList.ImageSize = New Size(200, 200)
        _LargeImageList.ColorDepth = ColorDepth.Depth32Bit
        LvPictures.LargeImageList = _LargeImageList
        Dim Directory As String = ManagerCore.ApplicationPaths.EvaluationPictureDirectory
        Dim Index As Integer = 0
        For Each EvaluationPicture In _Evaluation.Pictures
            Try
                Dim Img As Image = Image.FromFile(EvaluationPicture.Picture.CurrentFile)
                Dim Thumb = CreateThumbnail(Img, 200, 200)
                _LargeImageList.Images.Add(Thumb)
                Dim Item As New ListViewItem With {
                    .Tag = EvaluationPicture,
                    .ImageIndex = Index
                }
                LvPictures.Items.Add(Item)
                Index += 1
            Catch
            End Try
            Dim SpacingX As Integer = 205
            Dim SpacingY As Integer = 205
            Dim LParam As Integer = SpacingX Or (SpacingY << 16)
            SendMessage(LvPictures.Handle, LVM_SETICONSPACING, 0, LParam)
        Next
    End Sub
    Private Function CreateThumbnail(Img As Image, Width As Integer, Height As Integer) As Image
        Dim Bmp As New Bitmap(Width, Height)
        Using g As Graphics = Graphics.FromImage(Bmp)
            g.Clear(Color.Transparent)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Dim RatioX = Width / Img.Width
            Dim RatioY = Height / Img.Height
            Dim Ratio = Math.Min(RatioX, RatioY)
            Dim NewWidth = CInt(Img.Width * Ratio)
            Dim NewHeight = CInt(Img.Height * Ratio)
            Dim PosX = (Width - NewWidth) \ 2
            Dim PosY = (Height - NewHeight) \ 2
            g.DrawImage(Img, PosX, PosY, NewWidth, NewHeight)
        End Using
        Return Bmp
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
            SelectedPictures.Add(CType(SelectedItem.Tag, EvaluationPicture).Picture.CurrentFile)
        Next SelectedItem
        Dim Result As ReportResult
        Try
            Cursor = Cursors.WaitCursor
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
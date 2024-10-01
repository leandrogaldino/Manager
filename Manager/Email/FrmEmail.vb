Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmEmail
    Private _Attachments As New List(Of Attachment)
    Private _EmailModel As New EmailModel
    Public Sub New(Attachments As List(Of ReportResult.ReportAttachment))
        InitializeComponent()
        Dim DefaultEmail As UserEmail
        Dim Sb As New StringBuilder
        Dim Signatures As List(Of EmailSignature)
        Attachments.ForEach(Sub(x) _Attachments.Add(New Attachment(x.AttachmentPath) With {.Name = x.AttachmentAlias}))
        QbxFrom.Conditions.Add(New QueriedBox.Condition With {.FieldName = "ofuserid", .[Operator] = "=", .TableNameOrAlias = "useremail", .Value = "@userid"})
        QbxFrom.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@userid", .ParameterValue = Locator.GetInstance(Of Session).User.ID})
        DefaultEmail = Locator.GetInstance(Of Session).User.Emails.SingleOrDefault(Function(x) x.IsMainEmail = True)
        If DefaultEmail IsNot Nothing Then
            QbxFrom.Freeze(DefaultEmail.ID)
        End If
        Signatures = EmailSignature.GetSignatures(Locator.GetInstance(Of Session).User.ID)
        Signatures.Insert(0, New EmailSignature With {.Name = ""})
        CbxSignature.DataSource = Signatures
        CbxSignature.DisplayMember = "Name"
        CbxSignature.ValueMember = "ID"
        TsBody.Renderer = New CustomToolstripRender
        TxtFont.Text = TxtBody.Font.Name
        Sb.AppendLine("#sdl#: é substituido por bom dia, boa tarde ou boa noite.")
        Sb.AppendLine("#sdn#: é substituido por Bom dia, Boa tarde ou Boa noite.")
        Sb.Append("#sdu#: é substituido por BOM DIA, BOA TARDE ou BOA NOITE.")
        EprInformation.SetError(TsBody, Sb.ToString())
        EprInformation.SetIconAlignment(TsBody, ErrorIconAlignment.MiddleRight)
        EprInformation.SetIconPadding(TsBody, -25)
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Dim Message As New MailMessage
        Dim [To] As New List(Of MailAddress)
        Dim Cc As New List(Of MailAddress)
        Dim Bcc As New List(Of MailAddress)
        If IsValidFields() Then
            Try
                Cursor = Cursors.WaitCursor
                _EmailModel.Body = TxtBody.Rtf
                _EmailModel.Subject = TxtSubject.Text
                If CbxSignature.SelectedIndex > 0 Then _EmailModel.Signature = New EmailSignature().Load(CbxSignature.SelectedValue, False)
                If Not String.IsNullOrEmpty(TxtTo.Text) Then TxtTo.Text.Split(";").ToList.ForEach(Sub(x) [To].Add(New MailAddress(x.Trim)))
                If Not String.IsNullOrEmpty(TxtCc.Text) Then TxtCc.Text.Split(";").ToList.ForEach(Sub(x) Cc.Add(New MailAddress(x.Trim)))
                If Not String.IsNullOrEmpty(TxtBcc.Text) Then TxtBcc.Text.Split(";").ToList.ForEach(Sub(x) Bcc.Add(New MailAddress(x.Trim)))
                Email.Send(Locator.GetInstance(Of Session).User.Emails.SingleOrDefault(Function(x) x.ID = QbxFrom.FreezedPrimaryKey), _EmailModel, [To], Cc, Bcc, _Attachments)
                CMessageBox.Show("Email enviado com sucesso.", CMessageBoxType.Done)
                Dispose()
            Catch ex As Exception
                CMessageBox.Show("ERRO EM001", "Ocorreu um erro enviar o e-mail.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        Dim InvalidTo As New List(Of String)
        Dim InvalidCc As New List(Of String)
        Dim InvalidBcc As New List(Of String)
        If Not String.IsNullOrEmpty(TxtTo.Text) Then
            TxtTo.Text.Split(";").ToList.ForEach(Sub(x)
                                                     If Not IsValidEmail(x.Trim) Then
                                                         InvalidTo.Add(x.Trim)
                                                     End If
                                                 End Sub)
        End If
        If Not String.IsNullOrEmpty(TxtCc.Text) Then
            TxtCc.Text.Split(";").ToList.ForEach(Sub(x)
                                                     If Not IsValidEmail(x.Trim) Then
                                                         InvalidCc.Add(x.Trim)
                                                     End If
                                                 End Sub)
        End If
        If Not String.IsNullOrEmpty(TxtBcc.Text) Then
            TxtBcc.Text.Split(";").ToList.ForEach(Sub(x)
                                                      If Not IsValidEmail(x.Trim) Then
                                                          InvalidBcc.Add(x.Trim)
                                                      End If
                                                  End Sub)
        End If

        If String.IsNullOrEmpty(QbxFrom.Text) Then
            EprValidation.SetError(LblFrom, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblTo, ErrorIconAlignment.MiddleRight)
            QbxFrom.Select()
            Return False
        ElseIf Not QbxFrom.IsFreezed Then
            EprValidation.SetError(LblFrom, "E-mail não encontrado.")
            EprValidation.SetIconAlignment(LblFrom, ErrorIconAlignment.MiddleRight)
            QbxFrom.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(TxtTo.Text) Then
            EprValidation.SetError(LblTo, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblTo, ErrorIconAlignment.MiddleRight)
            TxtTo.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtTo.Text) And InvalidTo.Count = 1 Then
            EprValidation.SetError(LblTo, "E-mail inválido.")
            EprValidation.SetIconAlignment(LblTo, ErrorIconAlignment.MiddleRight)
            TxtTo.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtTo.Text) And InvalidTo.Count > 1 Then
            EprValidation.SetError(LblTo, "Os seguintes e-mails não são válidos:" & vbNewLine & Join(InvalidTo.ToArray, vbNewLine))
            EprValidation.SetIconAlignment(LblTo, ErrorIconAlignment.MiddleRight)
            TxtTo.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtCc.Text) And InvalidTo.Count = 1 Then
            EprValidation.SetError(LblCc, "E-mail inválido.")
            EprValidation.SetIconAlignment(LblCc, ErrorIconAlignment.MiddleRight)
            TxtCc.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtCc.Text) And InvalidTo.Count > 1 Then
            EprValidation.SetError(LblCc, "Os seguintes e-mails não são válidos:" & vbNewLine & Join(InvalidTo.ToArray, vbNewLine))
            EprValidation.SetIconAlignment(LblCc, ErrorIconAlignment.MiddleRight)
            TxtCc.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtBcc.Text) And InvalidTo.Count = 1 Then
            EprValidation.SetError(LblBcc, "E-mail inválido.")
            EprValidation.SetIconAlignment(LblBcc, ErrorIconAlignment.MiddleRight)
            TxtBcc.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(TxtBcc.Text) And InvalidTo.Count > 1 Then
            EprValidation.SetError(LblBcc, "Os seguintes e-mails não são válidos:" & vbNewLine & Join(InvalidTo.ToArray, vbNewLine))
            EprValidation.SetIconAlignment(LblBcc, ErrorIconAlignment.MiddleRight)
            TxtBcc.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub TxtTo_TextChanged(sender As Object, e As EventArgs) Handles QbxFrom.TextChanged, TxtTo.TextChanged, TxtCc.TextChanged, TxtBcc.TextChanged
        EprValidation.Clear()
    End Sub
    Private Sub TxtBody_TextChanged(sender As Object, e As EventArgs) Handles TxtBody.TextChanged
        EprValidation.Clear()
    End Sub
    Private Sub TxtTo_Enter(sender As Object, e As EventArgs) Handles TxtTo.Enter
        TmrTo.Stop()
        BtnImportTo.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub TxtTo_Leave(sender As Object, e As EventArgs) Handles TxtTo.Leave
        Dim Emails As List(Of String)
        TmrTo.Stop()
        TmrTo.Start()
        Emails = TxtTo.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x) Or Not String.IsNullOrWhiteSpace(x)).ToList
        Emails = Emails.Where(Function(x) Not String.IsNullOrEmpty(x) And Not String.IsNullOrWhiteSpace(x)).ToList
        TxtTo.Text = String.Join("; ", Emails)
    End Sub
    Private Sub TmrTo_Tick(sender As Object, e As EventArgs) Handles TmrTo.Tick
        BtnImportTo.Visible = False
        TmrTo.Stop()
    End Sub
    Private Sub TxtCc_Enter(sender As Object, e As EventArgs) Handles TxtCc.Enter
        TmrCc.Stop()
        BtnImportCc.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub TxtCc_Leave(sender As Object, e As EventArgs) Handles TxtCc.Leave
        Dim Emails As List(Of String)
        TmrCc.Stop()
        TmrCc.Start()
        Emails = TxtCc.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x) Or Not String.IsNullOrWhiteSpace(x)).ToList
        Emails = Emails.Where(Function(x) Not String.IsNullOrEmpty(x) And Not String.IsNullOrWhiteSpace(x)).ToList
        TxtCc.Text = String.Join("; ", Emails)
    End Sub
    Private Sub TmrCc_Tick(sender As Object, e As EventArgs) Handles TmrCc.Tick
        BtnImportCc.Visible = False
        TmrCc.Stop()
    End Sub
    Private Sub TxtBcc_Enter(sender As Object, e As EventArgs) Handles TxtBcc.Enter
        TmrBcc.Stop()
        BtnImportBcc.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub TxtBcc_Leave(sender As Object, e As EventArgs) Handles TxtBcc.Leave
        Dim Emails As List(Of String)
        TmrBcc.Stop()
        TmrBcc.Start()
        Emails = TxtBcc.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x) Or Not String.IsNullOrWhiteSpace(x)).ToList
        Emails = Emails.Where(Function(x) Not String.IsNullOrEmpty(x) And Not String.IsNullOrWhiteSpace(x)).ToList
        TxtBcc.Text = String.Join("; ", Emails)
    End Sub
    Private Sub TmrBcc_Tick(sender As Object, e As EventArgs) Handles TmrBcc.Tick
        BtnImportBcc.Visible = False
        TmrBcc.Stop()
    End Sub
    Private Sub BtnImportTo_Click(sender As Object, e As EventArgs) Handles BtnImportTo.Click
        Dim Emails As List(Of String)
        Using Form As New FrmEmailImportContact
            If Form.ShowDialog = DialogResult.OK Then
                Emails = TxtTo.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x)).ToList
                Emails.ForEach(Sub(x) x.Trim())
                Emails.AddRange(Form.Tag)
                TxtTo.Text = String.Join("; ", Emails)
            End If
        End Using
    End Sub
    Private Sub BtnImportCc_Click(sender As Object, e As EventArgs) Handles BtnImportCc.Click
        Dim Emails As List(Of String)
        Using Form As New FrmEmailImportContact
            If Form.ShowDialog = DialogResult.OK Then
                Emails = TxtCc.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x)).ToList
                Emails.ForEach(Sub(x) x.Trim())
                Emails.AddRange(Form.Tag)
                TxtCc.Text = String.Join("; ", Emails)
            End If
        End Using
    End Sub
    Private Sub BtnImportBcc_Click(sender As Object, e As EventArgs) Handles BtnImportBcc.Click
        Dim Emails As List(Of String)
        Using Form As New FrmEmailImportContact
            If Form.ShowDialog = DialogResult.OK Then
                Emails = TxtBcc.Text.Split(";").ToList.Where(Function(x) Not String.IsNullOrEmpty(x)).ToList
                Emails.ForEach(Sub(x) x.Trim())
                Emails.AddRange(Form.Tag)
                TxtBcc.Text = String.Join("; ", Emails)
            End If
        End Using
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim Frm As New FrmEmailImportEmailModel
        If Frm.ShowDialog = DialogResult.OK Then
            _EmailModel = Frm.ImportedEmailModel
            TxtSubject.Text = _EmailModel.Subject
            TxtBody.Rtf = _EmailModel.Body
            CbxSignature.SelectedValue = _EmailModel.Signature.ID
        End If
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Frm As FrmHtmlPreview
        Dim TempModel As New EmailModel
        TempModel.Body = TxtBody.Rtf
        If CbxSignature.SelectedIndex > 0 Then TempModel.Signature = New EmailSignature().Load(CbxSignature.SelectedValue, False)
        Frm = New FrmHtmlPreview(TempModel)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtBody_SelectionChanged(sender As Object, e As EventArgs) Handles TxtBody.SelectionChanged
        TxtFont.Text = TxtBody.SelectionFont.Name
        BtnColor.Image = GetRecoloredImage(BtnColor.Image, TxtBody.SelectionColor)
        TxtFont.ForeColor = TxtBody.SelectionColor
    End Sub
    Private Sub BtnColor_Click(sender As Object, e As EventArgs) Handles BtnColor.Click
        CdColor.Color = TxtBody.SelectionColor
        If CdColor.ShowDialog = DialogResult.OK Then
            TxtBody.SelectionColor = CdColor.Color
            BtnColor.Image = GetRecoloredImage(BtnColor.Image, CdColor.Color)
        End If
    End Sub
    Private Sub TxtFont_Click(sender As Object, e As EventArgs) Handles TxtFont.Click
        FdFont.Font = TxtBody.SelectionFont
        If FdFont.ShowDialog = DialogResult.OK Then
            TxtBody.SelectionFont = FdFont.Font
            TxtFont.Text = TxtBody.SelectionFont.Name
        End If
    End Sub
    Private Sub TxtFont_MouseEnter(sender As Object, e As EventArgs) Handles TxtFont.MouseEnter, BtnColor.MouseEnter, BtnLeft.MouseEnter, BtnCenter.MouseEnter, BtnRight.MouseEnter
        TsBody.Cursor = Cursors.Hand
    End Sub
    Private Sub TxtFont_MouseLeave(sender As Object, e As EventArgs) Handles TxtFont.MouseLeave, BtnColor.MouseLeave, BtnLeft.MouseLeave, BtnCenter.MouseLeave, BtnRight.MouseLeave
        TsBody.Cursor = Cursors.Default
    End Sub
    Private Sub BtnLeft_Click(sender As Object, e As EventArgs) Handles BtnLeft.Click
        BtnLeft.Checked = True
        BtnCenter.Checked = False
        BtnRight.Checked = False
        TxtBody.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub BtnCenter_Click(sender As Object, e As EventArgs) Handles BtnCenter.Click
        BtnLeft.Checked = False
        BtnCenter.Checked = True
        BtnRight.Checked = False
        TxtBody.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub BtnRight_Click(sender As Object, e As EventArgs) Handles BtnRight.Click
        BtnLeft.Checked = False
        BtnCenter.Checked = False
        BtnRight.Checked = True
        TxtBody.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dispose()
    End Sub
End Class
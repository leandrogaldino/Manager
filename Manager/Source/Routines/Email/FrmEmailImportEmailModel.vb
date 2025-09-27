Imports ControlLibrary
Public Class FrmEmailImportEmailModel
    Public Property ImportedEmailModel As EmailModel
    Public Sub New()
        InitializeComponent()
        QbxEmailModel.Conditions.Add(New QueriedBox.Condition With {.FieldName = "ofuserid", .[Operator] = "=", .TableNameOrAlias = "emailmodel", .Value = "@userid"})
        QbxEmailModel.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@userid", .ParameterValue = Locator.GetInstance(Of Session).User.ID})
    End Sub
    Private Sub QbxEmailModel_Enter(sender As Object, e As EventArgs) Handles QbxEmailModel.Enter
        TmrModel.Stop()
        BtnViewModel.Visible = QbxEmailModel.IsFreezed
    End Sub
    Private Sub QbxEmailModel_Leave(sender As Object, e As EventArgs) Handles QbxEmailModel.Leave
        TmrModel.Stop()
        TmrModel.Start()
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNewModel.Click
        Dim Model As EmailModel
        Model = New EmailModel
        Using Form As New FrmEmailModel(Model)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Model.ID > 0 Then
            QbxEmailModel.Freeze(Model.ID)
        End If
        QbxEmailModel.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnViewModel.Click
        Using Form As New FrmEmailModel(New EmailModel().Load(QbxEmailModel.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxEmailModel.Freeze(QbxEmailModel.FreezedPrimaryKey)
        QbxEmailModel.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilterModel.Click
        Using Form As New FrmFilter(New EmailModelFilter(), QbxEmailModel) With {.Text = "Filtro de Modelos de E-Mail"}
            Form.ShowDialog()
        End Using
        QbxEmailModel.Select()
    End Sub
    Private Sub TmrModel_Tick(sender As Object, e As EventArgs) Handles TmrModel.Tick
        BtnViewModel.Visible = False
        TmrModel.Stop()
    End Sub
    Private Sub QbxEmailModel_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxEmailModel.FreezedPrimaryKeyChanged
        BtnViewModel.Visible = QbxEmailModel.IsFreezed
        If QbxEmailModel.IsFreezed Then
            ImportedEmailModel = New EmailModel().Load(QbxEmailModel.FreezedPrimaryKey, False)
            WebMailPreview.Navigate(ImportedEmailModel.CreateHtmlFile())
            BtnImport.Enabled = True
        Else
            WebMailPreview.DocumentText = String.Empty
            BtnImport.Enabled = False
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        If IsValidFields() Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxEmailModel.Text) Then
            EprValidation.SetError(LblEmailModel, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblEmailModel, ErrorIconAlignment.MiddleRight)
            QbxEmailModel.Select()
            Return False
        ElseIf Not QbxEmailModel.IsFreezed Then
            EprValidation.SetError(LblEmailModel, "Modelo de e-mail não encontrado.")
            EprValidation.SetIconAlignment(LblEmailModel, ErrorIconAlignment.MiddleRight)
            QbxEmailModel.Select()
            Return False
        End If
        Return True
    End Function
End Class
Imports ControlLibrary
Public Class FrmPersonRegistrationForm
    Private _User As User
    <DebuggerStepThrough>
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Const _MouseButtonDown As Long = &HA1
        Const _MouseButtonUp As Long = &HA0
        Const _CloseButton As Long = 20
        If CLng(m.Msg) = _MouseButtonDown And Not m.WParam = _CloseButton Then
            If Opacity <> 0.5 Then Opacity = 0.5
        ElseIf CLng(m.Msg) = _MouseButtonUp Then
            If Opacity <> 1.0 Then Opacity = 1.0
        End If
        MyBase.DefWndProc(m)
    End Sub

    Public Sub New()
        InitializeComponent()
        _User = Locator.GetInstance(Of Session).User
    End Sub

    Private Sub FrmPersonReportRegistrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QbxPerson.Select()
    End Sub
    Private Sub QbxPerson_TextChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        If QbxPerson.IsFreezed Then
            BtnGenerate.Enabled = True
        Else
            BtnGenerate.Enabled = False
        End If
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Result As ReportResult
        Try
            Cursor = Cursors.WaitCursor
            BtnGenerate.Enabled = False
            Result = PersonReport.ProcessRegistrationForm(QbxPerson.FreezedPrimaryKey, CbxShowAddresses.Checked, CbxShowContacts.Checked, CbxShowCompressors.Checked)
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New FrmReport(Result), EnumHelper.GetEnumDescription(Routine.PersonRegistrationFormReport))
        Catch ex As Exception
            CMessageBox.Show("ERRO PS013", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub QbxPerson_Enter(sender As Object, e As EventArgs) Handles QbxPerson.Enter
        TmrQueriedBox.Stop()
        BtnViewPerson.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNewPerson.Visible = _User.CanWrite(Routine.Person)
        BtnFilterPerson.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxPerson_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxPerson.FreezedPrimaryKeyChanged
        BtnViewPerson.Visible = QbxPerson.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub QbxPerson_Leave(sender As Object, e As EventArgs) Handles QbxPerson.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub BtnNewPerson_Click(sender As Object, e As EventArgs) Handles BtnNewPerson.Click
        Dim Person As Person
        Person = New Person
        Using Form As New FrmPerson(Person)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Person.ID > 0 Then
            QbxPerson.Freeze(Person.ID)
        End If
        QbxPerson.Select()
    End Sub
    Private Sub BtnViewPerson_Click(sender As Object, e As EventArgs) Handles BtnViewPerson.Click
        Using Form As New FrmPerson(New Person().Load(QbxPerson.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxPerson.Freeze(QbxPerson.FreezedPrimaryKey)
        QbxPerson.Select()
    End Sub
    Private Sub BtnFilterPerson_Click(sender As Object, e As EventArgs) Handles BtnFilterPerson.Click
        Using Form As New FrmFilter(New PersonFilter(), QbxPerson) With {.Text = "Filtro de Pessoas"}
            Form.ShowDialog()
        End Using
        QbxPerson.Select()
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnViewPerson.Visible = False
        BtnNewPerson.Visible = False
        BtnFilterPerson.Visible = False
        TmrQueriedBox.Stop()
    End Sub
End Class
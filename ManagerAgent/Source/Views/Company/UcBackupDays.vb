Imports ControlLibrary

Public Class UcBackupDays
    Private _Container As ControlContainer

    Public Sub New(Container As ControlContainer)
        InitializeComponent()
        _Container = Container
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        _Container.CloseDropDown()
    End Sub

End Class
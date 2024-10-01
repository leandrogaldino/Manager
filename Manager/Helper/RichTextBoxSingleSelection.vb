Public Class RichTextBoxSingleSelection
    Inherits RichTextBox
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        If Not MyBase.AutoWordSelection Then
            MyBase.AutoWordSelection = True
            MyBase.AutoWordSelection = False
        End If
    End Sub
    Protected Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Tab Then
            e.IsInputKey = True
        Else
            MyBase.OnPreviewKeyDown(e)
        End If
    End Sub
End Class

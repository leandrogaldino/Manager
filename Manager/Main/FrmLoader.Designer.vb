<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLoader
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.WbLoader = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.SuspendLayout()
        '
        'WbLoader
        '
        Me.WbLoader.ActivateBrowserOnCreation = True
        Me.WbLoader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WbLoader.Location = New System.Drawing.Point(0, 0)
        Me.WbLoader.Name = "WbLoader"
        Me.WbLoader.Size = New System.Drawing.Size(284, 161)
        Me.WbLoader.TabIndex = 0
        '
        'FrmLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 161)
        Me.Controls.Add(Me.WbLoader)
        Me.Name = "FrmLoader"
        Me.Text = "FrmLoader"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WbLoader As CefSharp.WinForms.ChromiumWebBrowser
End Class

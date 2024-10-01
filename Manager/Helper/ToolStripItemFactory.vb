Public Class ToolStripItemFactory
    Public Shared Function GetToolStripButton(Text As String, ToolTipText As String, Image As Image, OnClick As Action, Optional Alignment As ToolStripItemAlignment = ToolStripItemAlignment.Left) As ToolStripButton
        Dim Btn As New ToolStripButton
        Btn.AutoSize = False
        Btn.AutoToolTip = False
        Btn.BackColor = Color.White
        Btn.Font = New Font("Century Gothic", 9.75)
        Btn.Image = Image
        Btn.ImageScaling = ToolStripItemImageScaling.None
        Btn.Size = New Size(120, 55)
        Btn.TextImageRelation = TextImageRelation.ImageAboveText
        Btn.Text = Text
        Btn.ToolTipText = ToolTipText
        Btn.Alignment = Alignment
        Btn.Margin = New Padding(0, 0, 5, 0)
        If OnClick IsNot Nothing Then
            AddHandler Btn.Click, AddressOf OnClick.Invoke
        End If
        Return Btn
    End Function

    Public Shared Function GetToolStripSplitButton(Text As String, ToolTipText As String, Image As Image, OnButtonClick As Action) As ToolStripSplitButton
        Dim Btn As New ToolStripSplitButton
        Btn.AutoSize = False
        Btn.AutoToolTip = False
        Btn.BackColor = Color.White
        Btn.Font = New Font("Century Gothic", 9.75)
        Btn.Image = Image
        Btn.ImageScaling = ToolStripItemImageScaling.None
        Btn.Size = New Size(120, 55)
        Btn.TextImageRelation = TextImageRelation.ImageAboveText
        Btn.Text = Text
        Btn.ToolTipText = ToolTipText
        Btn.Margin = New Padding(0, 0, 5, 0)
        If OnButtonClick IsNot Nothing Then
            AddHandler Btn.ButtonClick, AddressOf OnButtonClick.Invoke
        End If
        Return Btn
    End Function
    Public Shared Function GetToolStripMenuItem(Text As String, ToolTipText As String, Image As Image, OnClick As Action, Optional RemoveImagePlace As Boolean = False) As ToolStripMenuItem
        Dim Item As New ToolStripMenuItem
        Item.Font = New Font("Century Gothic", 9.75)
        Item.Image = Image
        Item.Text = Text
        Item.ToolTipText = ToolTipText
        If RemoveImagePlace Then
            CType(Item.DropDown, ToolStripDropDownMenu).ShowImageMargin = False
        End If
        If OnClick IsNot Nothing Then
            AddHandler Item.Click, AddressOf OnClick.Invoke
        End If
        Return Item
    End Function
    Public Shared Function GetToolStripLabel(Text As String, ToolTipText As String, Image As Image) As ToolStripLabel
        Dim Item As New ToolStripLabel
        Item.Font = New Font("Century Gothic", 9.75)
        Item.Image = Image
        Item.Text = Text
        Item.ToolTipText = ToolTipText
        Return Item
    End Function
End Class

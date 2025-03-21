﻿Imports ControlLibrary
Public Class UcTristatePrivilegeItem
    Public Event CheckedChanged As EventHandler
    Public Property Routine As Routine
        Get
            Return EnumHelper.GetEnumValue(Of Routine)(LblPrivilege.Text)
        End Get
        Set(value As Routine)
            LblPrivilege.Text = EnumHelper.GetEnumDescription(value)
            Dim Dependency = AttributeHelper.GetAttribute(Of RoutineDependencyAttribute)(value.GetType, value.ToString)
            If Dependency IsNot Nothing Then
                CbxTip.SetToolTip(CbxAccess, $"{CbxTip.GetToolTip(CbxAccess)} - Dependente de {EnumHelper.GetEnumDescription(Dependency.Dependency)}")
                CbxTip.SetToolTip(CbxWrite, $"{CbxTip.GetToolTip(CbxWrite)} - Dependente de {EnumHelper.GetEnumDescription(Dependency.Dependency)}")
                CbxTip.SetToolTip(CbxDelete, $"{CbxTip.GetToolTip(CbxDelete)} - Dependente de {EnumHelper.GetEnumDescription(Dependency.Dependency)}")
            End If
        End Set
    End Property

    Public Property CanAccess As Boolean
        Get
            Return CbxAccess.Checked
        End Get
        Set(value As Boolean)
            If CbxAccess.Checked <> value Then
                CbxAccess.Checked = value
            End If
        End Set
    End Property
    Public Property CanWrite As Boolean
        Get
            Return CbxWrite.Checked
        End Get
        Set(value As Boolean)
            If CbxWrite.Checked <> value Then
                CbxWrite.Checked = value
            End If
        End Set
    End Property
    Public Property CanDelete As Boolean
        Get
            Return CbxDelete.Checked
        End Get
        Set(value As Boolean)
            If CbxDelete.Checked <> value Then
                CbxDelete.Checked = value
            End If
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(Routine As Routine, CanAccess As Boolean, CanWrite As Boolean, CanDelete As Boolean)
        InitializeComponent()
        Me.Routine = Routine
        Me.CanAccess = CanAccess
        Me.CanWrite = CanWrite
        Me.CanDelete = CanDelete
        LblPrivilege.Text = EnumHelper.GetEnumDescription(Routine)
        CbxAccess.Checked = CanAccess
        CbxWrite.Checked = CanWrite
        CbxDelete.Checked = CanDelete
    End Sub

    Private Sub CbxAccess_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAccess.CheckedChanged
        CbxAccess.Image = If(CbxAccess.Checked, My.Resources.Approve, My.Resources.Reject)
        If Not CbxAccess.Checked Then
            CanWrite = False
            CanDelete = False
        End If
        OnCheckedChanged()
    End Sub
    Private Sub CbxWrite_CheckedChanged(sender As Object, e As EventArgs) Handles CbxWrite.CheckedChanged
        CbxWrite.Image = If(CbxWrite.Checked, My.Resources.Approve, My.Resources.Reject)
        If CbxWrite.Checked Then
            CanAccess = True
        End If
        OnCheckedChanged()
    End Sub
    Private Sub CbxDelete_CheckedChanged(sender As Object, e As EventArgs) Handles CbxDelete.CheckedChanged
        CbxDelete.Image = If(CbxDelete.Checked, My.Resources.Approve, My.Resources.Reject)
        If CbxDelete.Checked Then
            CanAccess = True
        End If
        OnCheckedChanged()
    End Sub
    Private Sub OnCheckedChanged()
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
End Class



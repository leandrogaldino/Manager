﻿Imports System.IO
Imports System.Reflection
Imports ControlLibrary
Imports ManagerCore
''' <summary>
''' Representa o caminho de uma foto de um produto.
''' </summary>
Public Class ProductPicture
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
    Private _Picture As Image
    Public ReadOnly Property Order As Long
        Get
            Return _Order
        End Get
    End Property
    Public ReadOnly Property ID As Long
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Creation As Date
        Get
            Return _Creation
        End Get
    End Property
    Public Property PictureName As New FileManager(ApplicationPaths.ProductPictureDirectory())
    Public ReadOnly Property Picture As Image
        Get
            If Not String.IsNullOrEmpty(PictureName.CurrentFile) AndAlso File.Exists(PictureName.CurrentFile) Then
                Return Image.FromStream(New MemoryStream(File.ReadAllBytes(PictureName.CurrentFile)))
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property Caption As String
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
    Public Function Clone() As ProductPicture
        Dim ProductPictureClone As New ProductPicture
        ProductPictureClone.GetType.GetField("_ID", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ProductPictureClone, ID)
        ProductPictureClone.GetType.GetField("_Creation", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ProductPictureClone, Creation)
        ProductPictureClone.GetType.GetField("_Order", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(ProductPictureClone, Order)
        ProductPictureClone.PictureName = New FileManager(ApplicationPaths.ProductPictureDirectory())
        ProductPictureClone.PictureName.SetCurrentFile(PictureName.OriginalFile, True)
        ProductPictureClone.PictureName.SetCurrentFile(PictureName.CurrentFile)
        ProductPictureClone.Caption = Caption
        ProductPictureClone.IsSaved = IsSaved
        Return ProductPictureClone
    End Function
End Class

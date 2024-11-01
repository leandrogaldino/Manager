﻿Imports ControlLibrary
Imports ManagerCore

Public Class EvaluationPhoto
    Public IsSaved As Boolean
    Private _Order As Long
    Private _ID As Long
    Private _Creation As Date = Today
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
    Public Property Photo As New FileManager(ApplicationPaths.EvaluationPhotoDirectory)
    Public ReadOnly User As User = Locator.GetInstance(Of Session).User
End Class

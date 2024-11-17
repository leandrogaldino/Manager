Imports ControlLibrary
Imports ManagerCore

Public Class EvaluationPhoto
    Inherits ChildModel
    Public Property Photo As New FileManager(ApplicationPaths.EvaluationPhotoDirectory)
    Public Sub New()
        SetRoutine(Routine.EvaluationPhoto)
    End Sub
End Class

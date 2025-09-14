Imports ManagerCore
''' <summary>
''' Representa o caminho de uma foto de uma avaliação.
''' </summary>
Public Class EvaluationPhoto
    Inherits ChildModel
    Public Property Photo As New FileManager(ApplicationPaths.EvaluationPhotoDirectory)
    Public Sub New()
        SetRoutine(Routine.EvaluationPhoto)
    End Sub
End Class

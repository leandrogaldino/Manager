Imports ManagerCore
''' <summary>
''' Representa o caminho de uma foto de uma avaliação.
''' </summary>
Public Class EvaluationPicture
    Inherits ChildModel
    Public Property Picture As New FileManager(ApplicationPaths.EvaluationPictureDirectory)
    Public Sub New()
        SetRoutine(Routine.EvaluationPicture)
    End Sub
End Class

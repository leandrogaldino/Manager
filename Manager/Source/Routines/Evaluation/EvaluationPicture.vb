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

    Public Overrides Function Clone() As BaseModel
        Dim Cloned As New EvaluationPicture With {
            .Picture = Picture.Clone()
        }
        Cloned.SetCreation(Creation)
        Cloned.SetID(ID)
        Cloned.SetIsSaved(IsSaved)
        Cloned.SetGuid(Guid)
        Return Cloned
    End Function

End Class

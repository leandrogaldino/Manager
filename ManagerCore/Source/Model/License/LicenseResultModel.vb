Public Class LicenseResultModel
    Implements ICloneable

    Public Property Success As Boolean
    Public Property License As New LicenseModel
    Public Property Flag As LicenseMessages
    Public Function Clone() As Object Implements ICloneable.Clone
        Return New LicenseResultModel With {
            .Success = Me.Success,
            .License = DirectCast(License.Clone(), LicenseModel),
            .Flag = Flag
        }
    End Function
End Class

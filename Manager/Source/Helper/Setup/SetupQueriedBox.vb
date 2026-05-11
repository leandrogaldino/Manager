Imports ControlLibrary
Imports ManagerCore

Public Class SetupQueriedBox
    Public Shared Sub Setup()
        Dim Session = Locator.GetInstance(Of Session)
        QueriedBox.Connection = Locator.GetInstance(Of LocalDB).GetConnection()
    End Sub
End Class

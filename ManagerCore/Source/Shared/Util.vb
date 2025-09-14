
Public Class Util
    Public Shared Sub AsyncLock(Action As Action)
        Nito.AsyncEx.AsyncContext.Run(Action)
    End Sub
    Public Shared Function AsyncLock(Of T)(Action As Func(Of Task(Of T))) As T
        Return Nito.AsyncEx.AsyncContext.Run(Action)
    End Function
End Class

Imports System.Threading
Public Class TaskStackService
    Private ReadOnly _Timer As Timers.Timer
    Private _TaskStack As List(Of TaskBase)
    Public Event TaskWillRun As EventHandler(Of TaskBase)
    Public Event TaskRunned As EventHandler(Of TaskBase)
    Public Event TaskListChanged As EventHandler(Of TaskBase)
    Private ReadOnly _TaskSemaphore As New SemaphoreSlim(1, 1)
    Public Function GetTaskStack() As List(Of TaskBase)
        Return _TaskStack
    End Function
    Public ReadOnly TaskProgress As Progress(Of AsyncResponseModel)
    Public Sub Start()
        _Timer.Start()
    End Sub
    Public Sub [Stop]()
        _Timer.Stop()
    End Sub
    Public Sub New()
        _TaskStack = New List(Of TaskBase)
        TaskProgress = New Progress(Of AsyncResponseModel)
        _Timer = New Timers.Timer With {.Interval = 5000}
        AddHandler _Timer.Elapsed, AddressOf TimerElapsed
    End Sub
    Public Async Sub AddTask(Task As TaskBase, Optional OnTop As Boolean = False)
        Await _TaskSemaphore.WaitAsync()
        If OnTop Then
            _TaskStack.Insert(0, Task)
        Else
            _TaskStack.Add(Task)
        End If
        RaiseEvent TaskListChanged(Me, Task)
        _TaskSemaphore.Release()
    End Sub
    Public Async Sub RemoveTask(Task As TaskBase)
        Await _TaskSemaphore.WaitAsync()
        _TaskStack.Remove(Task)
        RaiseEvent TaskListChanged(Me, Task)
        _TaskSemaphore.Release()
    End Sub

    Private Async Sub TimerElapsed()
        _Timer.Stop()
        Await _TaskSemaphore.WaitAsync()
        For Each AddedTask In _TaskStack
            If AddedTask IsNot Nothing AndAlso AddedTask.IsRunNeeded Then
                SetupApp.SetupData()
                SetupSession.Setup()
                AddedTask.IsRunning = True
                RaiseEvent TaskWillRun(Me, AddedTask)
                If Not AddedTask.CancelRun Then
                    Await AddedTask.Run(TaskProgress)
                    If AddedTask.IsManual Then
                        AddedTask.NextRun = Nothing
                        AddedTask.IsRunNeeded = False
                    End If
                End If
                AddedTask.IsRunning = False
                RaiseEvent TaskRunned(Me, AddedTask)
            End If
        Next AddedTask
        _TaskSemaphore.Release()
        _Timer.Start()
    End Sub
End Class


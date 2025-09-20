Imports System.Threading
Public Class TaskStackService
    Private ReadOnly _Timer As Timers.Timer
    Private _TaskStack As List(Of TaskBase)
    Public Event TaskWillRun As EventHandler(Of TaskBase)
    Public Event TaskRunned As EventHandler(Of TaskBase)
    Public Event TaskListChanged As EventHandler(Of TaskBase)
    Private _Semaphore As SemaphoreSlim
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
    Public Sub New(Semaphore As SemaphoreSlim)
        _TaskStack = New List(Of TaskBase)
        TaskProgress = New Progress(Of AsyncResponseModel)
        _Timer = New Timers.Timer With {.Interval = 5000}
        _Semaphore = Semaphore
        AddHandler _Timer.Elapsed, AddressOf TimerElapsed
    End Sub
    Public Async Sub AddTask(Task As TaskBase, Optional OnTop As Boolean = False)
        Await _Semaphore.WaitAsync()
        If OnTop Then
            _TaskStack.Insert(0, Task)
        Else
            _TaskStack.Add(Task)
        End If
        RaiseEvent TaskListChanged(Me, Task)
        _Semaphore.Release()
    End Sub
    Public Async Sub RemoveTask(Task As TaskBase)
        Await _Semaphore.WaitAsync()
        _TaskStack.Remove(Task)
        RaiseEvent TaskListChanged(Me, Task)
        _Semaphore.Release()
    End Sub

    Private Async Sub TimerElapsed()
        _Timer.Stop()
        Await _Semaphore.WaitAsync()
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
        _Semaphore.Release()
        _Timer.Start()
    End Sub
End Class


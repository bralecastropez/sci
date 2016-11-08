Imports System.Windows.Input

Namespace SCI.Infrastructure.Helpers
    Public Class RelayCommand
        Implements ICommand
#Region "Fields"
        Private ReadOnly _execute As Action(Of Object)
        Private ReadOnly _canExecute As Predicate(Of Object)
#End Region
#Region "Methods"
        Public Sub New(ByVal execute As Action(Of Object))
            Me.New(execute, Nothing)
        End Sub

        Public Sub New(ByVal execute As Action(Of Object), ByVal canExecute As Predicate(Of Object))
            If execute Is Nothing Then
                Throw New ArgumentNullException("execute")
            End If

            _execute = execute
            _canExecute = canExecute
        End Sub
        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            _execute(parameter)
        End Sub
#End Region
#Region "Functions"
        <DebuggerStepThrough()>
        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return If(_canExecute Is Nothing, True, _canExecute(parameter))
        End Function
#End Region
#Region "Events"
        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As EventHandler)
                AddHandler CommandManager.RequerySuggested, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                RemoveHandler CommandManager.RequerySuggested, value
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event
#End Region
    End Class

    Public Class RelayCommand(Of T)
        Implements ICommand
#Region "Fields"
        Private ReadOnly _execute As Action(Of T)
        Private ReadOnly _canExecute As Predicate(Of T)
#End Region
#Region "Methods"
        Public Sub New(ByVal execute As Action(Of T))
            Me.New(execute, Nothing)
        End Sub
        Public Sub New(ByVal execute As Action(Of T), ByVal canExecute As Predicate(Of T))
            If execute Is Nothing Then
                Throw New ArgumentNullException("execute")
            End If

            _execute = execute
            _canExecute = canExecute
        End Sub
        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            _execute(CType(parameter, T))
        End Sub
#End Region
#Region "Functions"
        <DebuggerStepThrough()>
        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return If(_canExecute Is Nothing, True, _canExecute(CType(parameter, T)))
        End Function
#End Region
#Region "Events"
        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As EventHandler)
                AddHandler CommandManager.RequerySuggested, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                RemoveHandler CommandManager.RequerySuggested, value
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event
#End Region
    End Class
End Namespace


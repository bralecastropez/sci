Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Input

Namespace MaterialDesignColors.WpfExample.Domain
    ''' <summary>
    ''' No WPF project is complete without it's own version of this.
    ''' </summary>
    Public Class AnotherCommandImplementation
        Implements ICommand
        Private ReadOnly _execute As Action(Of Object)
        Private ReadOnly _canExecute As Func(Of Object, Boolean)

        Public Sub New(execute As Action(Of Object))
            Me.New(execute, Nothing)
        End Sub

        Public Sub New(execute As Action(Of Object), canExecute As Func(Of Object, Boolean))
            If execute Is Nothing Then
                Throw New ArgumentNullException(NameOf(execute))
            End If

            _execute = execute
            _canExecute = If(canExecute, (Function(x) True))
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return _canExecute(parameter)
        End Function

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            _execute(parameter)
        End Sub

        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As EventHandler)
                AddHandler CommandManager.RequerySuggested, value
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                RemoveHandler CommandManager.RequerySuggested, value
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
            End RaiseEvent
        End Event

        Public Sub Refresh()
            CommandManager.InvalidateRequerySuggested()
        End Sub
    End Class
End Namespace

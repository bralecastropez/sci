Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports System.Threading
Imports SCI.BusinessObjects.Models
Imports SCI.Infrastructure
Imports SCI.Infrastructure.Helpers
Imports SCI.BusinessLogic.Services
Imports System.Windows
Imports SCI.Modules.Category.Views

Namespace SCI.Modules.UserLogin.ViewModels
    Public Class UserLoginViewModel
        Inherits ViewModelBase

#Region "Declaraciones"
        Private _user As Usuario
        Private _userName As String
        Private _password As String
        Private _loginMessage As String
        Private _loginSuccess As Boolean = False
        Private _MostrarError As String = "Hidden"
        Private _userAccess As IUsuarioDataService
#End Region
#Region "Propiedades"
        Public Property User As Usuario
            Get
                Return _user
            End Get
            Set(value As Usuario)
                _user = value
                OnPropertyChanged("User")
            End Set
        End Property
        Public Property MostrarError As String
            Get
                Return _MostrarError
            End Get
            Set(value As String)
                _MostrarError = value
                OnPropertyChanged("MostrarError")
            End Set
        End Property
        Public Property UserName As String
            Get
                Return _userName
            End Get
            Set(value As String)
                _userName = value
                OnPropertyChanged("UserName")
            End Set
        End Property
        Public Property Password As String
            Get
                Return _password
            End Get
            Set(value As String)
                _password = value
                OnPropertyChanged("Password")
            End Set
        End Property
        Public Property LoginMessage As String
            Get
                Return _loginMessage
            End Get
            Set(value As String)
                _loginMessage = value
                OnPropertyChanged("LoginMessage")
            End Set
        End Property
        Public Property LoginSuccess As Boolean
            Get
                Return _loginSuccess
            End Get
            Set(value As Boolean)
                _loginSuccess = value
                OnPropertyChanged("LoginSuccess")
            End Set
        End Property
        Public Property LoginCommand As ICommand
#End Region

#Region "Constructores"
        Public Sub New()
            ServiceLocator.RegisterService(Of IUsuarioDataService)(New UsuarioDataService)
            _userAccess = GetService(Of IUsuarioDataService)()
            LoginCommand = New RelayCommand(AddressOf LoginExecute, AddressOf CanLoginExecute)
            MostrarError = "Hidden"
        End Sub
#End Region

#Region "Metodos"

        Private Sub LoginExecute()
            Dim paramUserName = UserName
            Dim paramPassword = Password
            Try
                If _userAccess.Login(paramUserName, paramPassword) Then
                    LoginSuccess = True
                    LoginMessage = "Bienvenido " & _userAccess.GetUserByUserName(UserName).Nick
                    Application.Current.MainWindow.Content = New CategoryView
                End If
            Catch ex As Exception
                LoginMessage = ex.Message
                MostrarError = "Visible"
            End Try
        End Sub

        Public Function CanLoginExecute(ByVal param As Object) As Boolean
            Return (Not String.IsNullOrEmpty(UserName)) AndAlso (Not String.IsNullOrEmpty(Password))
        End Function
#End Region

    End Class
End Namespace
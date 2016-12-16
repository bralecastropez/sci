Imports SCI.Infrastructure.Helpers

Namespace SCI.Modules.Checkout.ViewModels
    Public Class CheckoutViewModel
        Inherits GuiViewBase
#Region "Fields"
        Private _CheckoutsList As List(Of Global.Checkout)
        Private _SelectedCheckout As Global.Checkout
        Private _ReaderId As Global.Reader
        Private _BranchOfficeId As Global.BranchOffice
        Private _Balance As Decimal
        Private _Total As Decimal
        Private _CheckoutDate As Date
#End Region
#Region "Properties"
        Public Property ReaderId As Global.Reader
            Get
                Return _ReaderId
            End Get
            Set(value As Global.Reader)
                _ReaderId = value
                OnPropertyChanged("ReaderId")
            End Set
        End Property
        Public Property BranchOfficeId As Global.BranchOffice
            Get
                Return _BranchOfficeId
            End Get
            Set(value As Global.BranchOffice)
                _BranchOfficeId = value
                OnPropertyChanged("BranchOfficeId")
            End Set
        End Property
        Public Property Balance As Decimal
            Get
                Return _Balance
            End Get
            Set(value As Decimal)
                _Balance = value
                OnPropertyChanged("Balance")
            End Set
        End Property
        Public Property Total As Decimal
            Get
                Return _Total
            End Get
            Set(value As Decimal)
                _Total = value
                OnPropertyChanged("Total")
            End Set
        End Property
        Public Property CheckoutDate As Date
            Get
                Return _CheckoutDate
            End Get
            Set(value As Date)
                _CheckoutDate = value
                OnPropertyChanged("CheckoutDate")
            End Set
        End Property
#End Region
#Region "Methods"
        Public Overrides Sub CleanFields()
            Throw New NotImplementedException()
        End Sub

        Public Overrides Sub LoadFields()
            Throw New NotImplementedException()
        End Sub
#End Region
#Region "Functions"

#End Region
#Region "Constructors"
        Sub New()

        End Sub
#End Region
    End Class
End Namespace


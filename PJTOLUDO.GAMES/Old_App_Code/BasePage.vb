Namespace PJTOLUDO.GAMES.Master.Master
    Public Class BasePage
        Inherits System.Web.UI.Page
        Public Property BodyCssClass() As String
            Get
                Return m_BodyCssClass
            End Get
            Set(value As String)
                m_BodyCssClass = value
            End Set
        End Property
        Private m_BodyCssClass As String
    End Class

End Namespace


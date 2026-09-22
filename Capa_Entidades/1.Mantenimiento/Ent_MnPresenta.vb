Public Class Ent_MnPresenta

    Private _c_codi_presenta As String
    Private _c_desc_presenta As String
    Private _c_valor_presenta As Integer
    Private _c_usuario As String

    Private _copcion As String

    Public Property c_codi_presenta() As String
        Get
            Return _c_codi_presenta
        End Get
        Set(ByVal value As String)
            _c_codi_presenta = value
        End Set
    End Property
    Public Property c_desc_presenta() As String
        Get
            Return _c_desc_presenta
        End Get
        Set(ByVal value As String)
            _c_desc_presenta = value
        End Set
    End Property

    Public Property c_valor_presenta() As Integer
        Get
            Return _c_valor_presenta
        End Get
        Set(ByVal value As Integer)
            _c_valor_presenta = value
        End Set
    End Property
    Public Property c_usuario() As String
        Get
            Return _c_usuario
        End Get
        Set(ByVal value As String)
            _c_usuario = value
        End Set
    End Property
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property

End Class

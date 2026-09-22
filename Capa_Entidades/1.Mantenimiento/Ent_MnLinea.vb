Public Class Ent_MnLinea

    Private _c_codi_linea As String
    Private _c_desc_linea As String
    Private _c_concar_cta As String
    Private _c_usuario As String

    Private _copcion As String

    Public Property c_codi_linea() As String
        Get
            Return _c_codi_linea
        End Get
        Set(ByVal value As String)
            _c_codi_linea = value
        End Set
    End Property
    Public Property c_desc_linea() As String
        Get
            Return _c_desc_linea
        End Get
        Set(ByVal value As String)
            _c_desc_linea = value
        End Set
    End Property

    Public Property c_concar_cta() As String
        Get
            Return _c_concar_cta
        End Get
        Set(ByVal value As String)
            _c_concar_cta = value
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

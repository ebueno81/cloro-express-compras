Public Class Ent_MnSCaidas
    Dim _c_codi_tg As String
    Dim _c_codi_cd As String
    Dim _c_codi_scd As String
    Dim _c_desc_scd As String
    Dim _c_codi_articulo As String
    Dim _c_anexo_concar As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_tg() As String
        Get
            Return _c_codi_tg
        End Get
        Set(ByVal value As String)
            _c_codi_tg = value
        End Set
    End Property
    Public Property c_codi_cd() As String
        Get
            Return _c_codi_cd
        End Get
        Set(ByVal value As String)
            _c_codi_cd = value
        End Set
    End Property
    Public Property c_codi_scd() As String
        Get
            Return _c_codi_scd
        End Get
        Set(ByVal value As String)
            _c_codi_scd = value
        End Set
    End Property
    Public Property c_desc_scd() As String
        Get
            Return _c_desc_scd
        End Get
        Set(ByVal value As String)
            _c_desc_scd = value
        End Set
    End Property
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
        End Set
    End Property
    Public Property c_anexo_concar() As String
        Get
            Return _c_anexo_concar
        End Get
        Set(value As String)
            _c_anexo_concar = value
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

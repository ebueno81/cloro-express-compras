Public Class Ent_OQ
    Dim _c_nro_serie As String
    Dim _c_nro_oq As String
    Dim _c_tpo_oq As Integer
    Dim _c_fecha_emi As Date
    Dim _c_codi_area As String
    Dim _c_usuario As String
    Dim _c_obs As String
    Dim _copcion As String
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_oq() As String
        Get
            Return _c_nro_oq
        End Get
        Set(ByVal value As String)
            _c_nro_oq = value
        End Set
    End Property
    Public Property c_tpo_oq() As Integer
        Get
            Return _c_tpo_oq
        End Get
        Set(ByVal value As Integer)
            _c_tpo_oq = value
        End Set
    End Property
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
        End Set
    End Property
    Public Property c_codi_area() As String
        Get
            Return _c_codi_area
        End Get
        Set(ByVal value As String)
            _c_codi_area = value
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
    Public Property c_obs() As String
        Get
            Return _c_obs
        End Get
        Set(ByVal value As String)
            _c_obs = value
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

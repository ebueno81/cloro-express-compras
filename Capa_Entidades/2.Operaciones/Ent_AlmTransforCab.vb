Public Class Ent_AlmTransforCab
    Private _c_nro_transforma As String
    Private _c_codi_alm_sal As String
    Private _c_codi_alm_ing As String
    Private _c_fecha_sal As Date
    Private _c_fecha_ing As Date
    Private _c_obs As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_nro_transforma() As String
        Get
            Return _c_nro_transforma
        End Get
        Set(ByVal value As String)
            _c_nro_transforma = value
        End Set
    End Property
    Public Property c_codi_alm_sal() As String
        Get
            Return _c_codi_alm_sal
        End Get
        Set(ByVal value As String)
            _c_codi_alm_sal = value
        End Set
    End Property
    Public Property c_codi_alm_ing() As String
        Get
            Return _c_codi_alm_ing
        End Get
        Set(ByVal value As String)
            _c_codi_alm_ing = value
        End Set
    End Property
    Public Property c_fecha_sal() As Date
        Get
            Return _c_fecha_sal
        End Get
        Set(ByVal value As Date)
            _c_fecha_sal = value
        End Set
    End Property
    Public Property c_fecha_ing() As Date
        Get
            Return _c_fecha_ing
        End Get
        Set(ByVal value As Date)
            _c_fecha_ing = value
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

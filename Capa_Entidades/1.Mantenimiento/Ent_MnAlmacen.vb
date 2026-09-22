Public Class Ent_MnAlmacen
    Private _c_codi_alm As String
    Private _c_desc_alm As String
    Private _c_direc_alm As String
    Private _c_dist_alm As String
    Private _c_prov_alm As String
    Private _c_dpto_alm As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_alm() As String
        Get
            Return _c_codi_alm
        End Get
        Set(ByVal value As String)
            _c_codi_alm = value
        End Set
    End Property
    Public Property c_desc_alm() As String
        Get
            Return _c_desc_alm
        End Get
        Set(ByVal value As String)
            _c_desc_alm = value
        End Set
    End Property
    Public Property c_direc_alm() As String
        Get
            Return _c_direc_alm
        End Get
        Set(ByVal value As String)
            _c_direc_alm = value
        End Set
    End Property
    Public Property c_dist_alm() As String
        Get
            Return _c_dist_alm
        End Get
        Set(ByVal value As String)
            _c_dist_alm = value
        End Set
    End Property
    Public Property c_prov_alm() As String
        Get
            Return _c_prov_alm
        End Get
        Set(ByVal value As String)
            _c_prov_alm = value
        End Set
    End Property
    Public Property c_dpto_alm() As String
        Get
            Return _c_dpto_alm
        End Get
        Set(ByVal value As String)
            _c_dpto_alm = value
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

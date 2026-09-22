Public Class Ent_MnArticulo
    Private _c_codi_articulo As String
    Private _c_desc_articulo As String
    Private _c_codi_linea As String
    Private _c_codi_familia As String
    Private _c_codi_sfamilia As String
    Private _c_codi_artsunat As String
    Private _c_codi_unimed As String
    Private _c_valor_unidad As Integer
    Private _c_codi_prov As String
    Private _c_obs As String
    Private _c_codi_mon As String
    Private _c_precio_art As Decimal
    Private _c_stock_min As Decimal
    Private _c_codi_tg As String
    Private _c_codi_cd As String
    Private _c_codi_scd As String
    Private _c_control_art As Integer
    Private _c_opc_noinventario As Integer
    Private _c_opc_transforma As Integer
    Private _c_opc_ingtransforma As Integer
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
        End Set
    End Property
    Public Property c_desc_articulo() As String
        Get
            Return _c_desc_articulo
        End Get
        Set(ByVal value As String)
            _c_desc_articulo = value
        End Set
    End Property
    Public Property c_codi_linea() As String
        Get
            Return _c_codi_linea
        End Get
        Set(ByVal value As String)
            _c_codi_linea = value
        End Set
    End Property
    Public Property c_codi_familia() As String
        Get
            Return _c_codi_familia
        End Get
        Set(ByVal value As String)
            _c_codi_familia = value
        End Set
    End Property
    Public Property c_codi_sfamilia() As String
        Get
            Return _c_codi_sfamilia
        End Get
        Set(ByVal value As String)
            _c_codi_sfamilia = value
        End Set
    End Property
    Public Property c_codi_unimed() As String
        Get
            Return _c_codi_unimed
        End Get
        Set(ByVal value As String)
            _c_codi_unimed = value
        End Set
    End Property
    Public Property c_codi_artsunat() As String
        Get
            Return _c_codi_artsunat
        End Get
        Set(ByVal value As String)
            _c_codi_artsunat = value
        End Set
    End Property
    Public Property c_valor_unidad() As Integer
        Get
            Return _c_valor_unidad
        End Get
        Set(ByVal value As Integer)
            _c_valor_unidad = value
        End Set
    End Property
    Public Property c_codi_prov() As String
        Get
            Return _c_codi_prov
        End Get
        Set(ByVal value As String)
            _c_codi_prov = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_precio_art() As Decimal
        Get
            Return _c_precio_art
        End Get
        Set(ByVal value As Decimal)
            _c_precio_art = value
        End Set
    End Property
    Public Property c_stock_min() As Decimal
        Get
            Return _c_stock_min
        End Get
        Set(ByVal value As Decimal)
            _c_stock_min = value
        End Set
    End Property
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
    Public Property c_control_art() As Integer
        Get
            Return _c_control_art
        End Get
        Set(ByVal value As Integer)
            _c_control_art = value
        End Set
    End Property
    Public Property c_opc_noinventario() As Integer
        Get
            Return _c_opc_noinventario
        End Get
        Set(ByVal value As Integer)
            _c_opc_noinventario = value
        End Set
    End Property
    Public Property c_opc_transforma() As Integer
        Get
            Return _c_opc_transforma
        End Get
        Set(ByVal value As Integer)
            _c_opc_transforma = value
        End Set
    End Property
    Public Property c_opc_ingtransforma() As Integer
        Get
            Return _c_opc_ingtransforma
        End Get
        Set(ByVal value As Integer)
            _c_opc_ingtransforma = value
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
    Public Property copcion()
        Get
            Return _copcion
        End Get
        Set(ByVal value)
            _copcion = value
        End Set
    End Property
End Class

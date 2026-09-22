Public Class Ent_DuasCab
    Private _c_nro_operacion As String
    Private _c_fecha_emision As Date
    Private _c_fecha_prd As Date
    Private _c_tpo_cambio As Decimal
    Private _c_codi_prove As String
    Private _c_serie_dua As String
    Private _c_nro_dua As String
    Private _c_codi_mon As String
    Private _c_imp_inaf As Decimal
    Private _c_imp_afecto As Decimal
    Private _c_imp_igv As Decimal
    Private _c_imp_total As Decimal
    Private _c_opc_afecto As Integer
    Private _c_obs As String
    Private _c_usuario As String
    Private _cOpcion As String
    Public Property c_nro_operacion() As String
        Get
            Return _c_nro_operacion
        End Get
        Set(ByVal value As String)
            _c_nro_operacion = value
        End Set
    End Property
    Public Property c_fecha_emision() As Date
        Get
            Return _c_fecha_emision
        End Get
        Set(ByVal value As Date)
            _c_fecha_emision = value
        End Set
    End Property
    Public Property c_fecha_prd() As Date
        Get
            Return _c_fecha_prd
        End Get
        Set(ByVal value As Date)
            _c_fecha_prd = value
        End Set
    End Property
    Public Property c_tpo_cambio() As Decimal
        Get
            Return _c_tpo_cambio
        End Get
        Set(ByVal value As Decimal)
            _c_tpo_cambio = value
        End Set
    End Property
    Public Property c_codi_prove() As String
        Get
            Return _c_codi_prove
        End Get
        Set(ByVal value As String)
            _c_codi_prove = value
        End Set
    End Property
    Public Property c_serie_dua() As String
        Get
            Return _c_serie_dua
        End Get
        Set(ByVal value As String)
            _c_serie_dua = value
        End Set
    End Property
    Public Property c_nro_dua() As String
        Get
            Return _c_nro_dua
        End Get
        Set(ByVal value As String)
            _c_nro_dua = value
        End Set
    End Property
    Public Property c_codi_mon As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_imp_inaf() As Decimal
        Get
            Return _c_imp_inaf
        End Get
        Set(ByVal value As Decimal)
            _c_imp_inaf = value
        End Set
    End Property
    Public Property c_imp_afecto() As Decimal
        Get
            Return _c_imp_afecto
        End Get
        Set(ByVal value As Decimal)
            _c_imp_afecto = value
        End Set
    End Property
    Public Property c_imp_igv() As Decimal
        Get
            Return _c_imp_igv
        End Get
        Set(ByVal value As Decimal)
            _c_imp_igv = value
        End Set
    End Property
    Public Property c_imp_total() As Decimal
        Get
            Return _c_imp_total
        End Get
        Set(ByVal value As Decimal)
            _c_imp_total = value
        End Set
    End Property
    Public Property c_opc_afecto() As Integer
        Get
            Return _c_opc_afecto
        End Get
        Set(ByVal value As Integer)
            _c_opc_afecto = value
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
    Public Property cOpcion() As String
        Get
            Return _cOpcion
        End Get
        Set(ByVal value As String)
            _cOpcion = value
        End Set
    End Property

End Class
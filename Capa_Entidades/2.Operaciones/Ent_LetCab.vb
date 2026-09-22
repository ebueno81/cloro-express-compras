Public Class Ent_LetCab
    Dim _c_nro_liq As String
    Dim _c_id_letra As Integer
    Dim _c_nro_letra As String
    Dim _c_codi_prove As String
    Dim _c_codi_mon As String
    Dim _c_codi_stletra As String
    Dim _c_nro_dias As Integer
    Dim _c_fecha_giro As Date
    Dim _c_fecha_venci As Date
    Dim _c_codi_bco As String
    Dim _c_mt_anula As String
    Dim _c_nro_unico As String
    Dim _c_imp_letra As Decimal
    Dim _c_renovac_letra As Integer
    Dim _c_tpo_cambio As Decimal
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_liq() As String
        Get
            Return _c_nro_liq
        End Get
        Set(ByVal value As String)
            _c_nro_liq = value
        End Set
    End Property
    Public Property c_id_letra() As Integer
        Get
            Return _c_id_letra
        End Get
        Set(ByVal value As Integer)
            _c_id_letra = value
        End Set
    End Property
    Public Property c_nro_letra() As String
        Get
            Return _c_nro_letra
        End Get
        Set(ByVal value As String)
            _c_nro_letra = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_codi_stletra() As String
        Get
            Return _c_codi_stletra
        End Get
        Set(ByVal value As String)
            _c_codi_stletra = value
        End Set
    End Property
    Public Property c_nro_dias() As Integer
        Get
            Return _c_nro_dias
        End Get
        Set(ByVal value As Integer)
            _c_nro_dias = value
        End Set
    End Property
    Public Property c_fecha_giro() As Date
        Get
            Return _c_fecha_giro
        End Get
        Set(ByVal value As Date)
            _c_fecha_giro = value
        End Set
    End Property
    Public Property c_fecha_venci() As Date
        Get
            Return _c_fecha_venci
        End Get
        Set(ByVal value As Date)
            _c_fecha_venci = value
        End Set
    End Property
    Public Property c_codi_bco() As String
        Get
            Return _c_codi_bco
        End Get
        Set(ByVal value As String)
            _c_codi_bco = value
        End Set
    End Property
    Public Property c_mt_anula() As String
        Get
            Return _c_mt_anula
        End Get
        Set(ByVal value As String)
            _c_mt_anula = value
        End Set
    End Property
    Public Property c_nro_unico() As String
        Get
            Return _c_nro_unico
        End Get
        Set(ByVal value As String)
            _c_nro_unico = value
        End Set
    End Property
    Public Property c_imp_letra() As Decimal
        Get
            Return _c_imp_letra
        End Get
        Set(ByVal value As Decimal)
            _c_imp_letra = value
        End Set
    End Property
    Public Property c_renovac_letra() As Integer
        Get
            Return _c_renovac_letra
        End Get
        Set(ByVal value As Integer)
            _c_renovac_letra = value
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

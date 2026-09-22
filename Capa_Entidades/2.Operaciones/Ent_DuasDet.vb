Public Class Ent_DuasDet
    Private _c_nro_correl As String
    Private _c_nro_operacion As String
    Private _c_codi_tg As String
    Private _c_codi_cd As String
    Private _c_codi_scd As String
    Private _c_codi_unimed As String
    Private _c_nro_cant As Decimal
    Private _c_prec_unit As Decimal
    Private _c_imp_total As Decimal
    Private _c_opc_afecto As Integer
    Private _cOpcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_operacion() As String
        Get
            Return _c_nro_operacion
        End Get
        Set(ByVal value As String)
            _c_nro_operacion = value
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
    Public Property c_codi_unimed() As String
        Get
            Return _c_codi_unimed
        End Get
        Set(ByVal value As String)
            _c_codi_unimed = value
        End Set
    End Property
    Public Property c_nro_cant() As Decimal
        Get
            Return _c_nro_cant
        End Get
        Set(ByVal value As Decimal)
            _c_nro_cant = value
        End Set
    End Property
    Public Property c_prec_unit() As Decimal
        Get
            Return _c_prec_unit
        End Get
        Set(ByVal value As Decimal)
            _c_prec_unit = value
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
    Public Property cOpcion() As String
        Get
            Return _cOpcion
        End Get
        Set(ByVal value As String)
            _cOpcion = value
        End Set
    End Property

End Class
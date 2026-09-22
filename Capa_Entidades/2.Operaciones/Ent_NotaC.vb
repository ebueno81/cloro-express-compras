Public Class Ent_NotaC
    Dim _c_ing_nc As String
    Dim _c_serie_nc As String
    Dim _c_nro_nc As String
    Dim _c_fecha_emi As Date
    Dim _c_fecha_prd As Date
    Dim _c_codi_prov As String
    Dim _c_codi_mon As String
    Dim _c_tpo_cambio As Decimal
    Dim _c_cant_igv As Decimal
    Dim _c_imp_afecto As Decimal
    Dim _c_imp_igv As Decimal
    Dim _c_imp_total As Decimal
    Dim _c_opc_afecto As Integer
    Dim _c_obs As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_ing_nc() As String
        Get
            Return _c_ing_nc
        End Get
        Set(ByVal value As String)
            _c_ing_nc = value
        End Set
    End Property
    Public Property c_serie_nc() As String
        Get
            Return _c_serie_nc
        End Get
        Set(ByVal value As String)
            _c_serie_nc = value
        End Set
    End Property
    Public Property c_nro_nc() As String
        Get
            Return _c_nro_nc
        End Get
        Set(ByVal value As String)
            _c_nro_nc = value
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
    Public Property c_fecha_prd() As Date
        Get
            Return _c_fecha_prd
        End Get
        Set(ByVal value As Date)
            _c_fecha_prd = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
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
    Public Property c_cant_igv() As Decimal
        Get
            Return _c_cant_igv
        End Get
        Set(ByVal value As Decimal)
            _c_cant_igv = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class

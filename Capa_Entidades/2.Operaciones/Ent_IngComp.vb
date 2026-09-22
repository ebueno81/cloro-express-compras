Public Class Ent_IngComp
    Dim _c_nro_ing As String
    Dim _c_codi_mon As String
    Dim _c_codi_doc As String
    Dim _c_serie_doc As String
    Dim _c_nro_doc As String
    Dim _c_nro_maq As String

    Dim _c_fecha_emi As Date
    Dim _c_fecha_prd As Date
    Dim _c_fecha_venci As Date
    Dim _c_nro_dias As Integer
    Dim _c_codi_prov As String
    Dim _c_codi_pago As String
    Dim _c_usuario As String
    Dim _c_obs As String
    Dim _c_tpo_cambio As Decimal
    Dim _c_cant_igv As Decimal
    Dim _c_imp_inaf As Decimal
    Dim _c_imp_igv As Decimal
    Dim _c_imp_afecto As Decimal
    Dim _c_imp_total As Decimal
    Dim _c_mt_anula As String

    Dim _c_opc_detracc As Integer
    Dim _c_codi_detracc As String
    Dim _c_porc_detracc As Decimal
    Dim _c_imp_detracc As Decimal
    Dim _c_opc_reten As Integer
    Dim _c_porc_reten As Decimal
    Dim _c_base_reten As Decimal
    Dim _c_imp_reten As Decimal
    Dim _c_nro_leasing As String
    Dim _c_nro_cuota As Integer
    Dim _c_correl_leasing As String
    Dim _c_opc_apertura As Integer
    Dim _c_opc_importacion As Integer

    Dim _copcion As String
    Public Property c_nro_ing() As String
        Get
            Return _c_nro_ing
        End Get
        Set(ByVal value As String)
            _c_nro_ing = value
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
    Public Property c_codi_doc() As String
        Get
            Return _c_codi_doc
        End Get
        Set(ByVal value As String)
            _c_codi_doc = value
        End Set
    End Property
    Public Property c_serie_doc() As String
        Get
            Return _c_serie_doc
        End Get
        Set(ByVal value As String)
            _c_serie_doc = value
        End Set
    End Property
    Public Property c_nro_doc() As String
        Get
            Return _c_nro_doc
        End Get
        Set(ByVal value As String)
            _c_nro_doc = value
        End Set
    End Property
    Public Property c_nro_maq() As String
        Get
            Return _c_nro_maq
        End Get
        Set(ByVal value As String)
            _c_nro_maq = value
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
    Public Property c_fecha_venci() As Date
        Get
            Return _c_fecha_venci
        End Get
        Set(ByVal value As Date)
            _c_fecha_venci = value
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
    Public Property c_codi_prov() As String
        Get
            Return _c_codi_prov
        End Get
        Set(ByVal value As String)
            _c_codi_prov = value
        End Set
    End Property
    Public Property c_codi_pago() As String
        Get
            Return _c_codi_pago
        End Get
        Set(ByVal value As String)
            _c_codi_pago = value
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
    Public Property c_imp_inaf() As Decimal
        Get
            Return _c_imp_inaf
        End Get
        Set(ByVal value As Decimal)
            _c_imp_inaf = value
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
    Public Property c_imp_afecto() As Decimal
        Get
            Return _c_imp_afecto
        End Get
        Set(ByVal value As Decimal)
            _c_imp_afecto = value
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
    Public Property c_mt_anula() As String
        Get
            Return _c_mt_anula
        End Get
        Set(ByVal value As String)
            _c_mt_anula = value
        End Set
    End Property

    Public Property c_opc_detracc() As Integer
        Get
            Return _c_opc_detracc
        End Get
        Set(ByVal value As Integer)
            _c_opc_detracc = value
        End Set
    End Property
    Public Property c_codi_detracc() As String
        Get
            Return _c_codi_detracc
        End Get
        Set(ByVal value As String)
            _c_codi_detracc = value
        End Set
    End Property
    Public Property c_porc_detracc() As Decimal
        Get
            Return _c_porc_detracc
        End Get
        Set(ByVal value As Decimal)
            _c_porc_detracc = value
        End Set
    End Property
    Public Property c_imp_detracc() As Decimal
        Get
            Return _c_imp_detracc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_detracc = value
        End Set
    End Property
    Public Property c_opc_reten() As Integer
        Get
            Return _c_opc_reten
        End Get
        Set(ByVal value As Integer)
            _c_opc_reten = value
        End Set
    End Property
    Public Property c_porc_reten() As Decimal
        Get
            Return _c_porc_reten
        End Get
        Set(ByVal value As Decimal)
            _c_porc_reten = value
        End Set
    End Property
    Public Property c_base_reten() As Decimal
        Get
            Return _c_base_reten
        End Get
        Set(ByVal value As Decimal)
            _c_base_reten = value
        End Set
    End Property
    Public Property c_imp_reten() As Decimal
        Get
            Return _c_imp_reten
        End Get
        Set(ByVal value As Decimal)
            _c_imp_reten = value
        End Set
    End Property
    Public Property c_nro_leasing() As String
        Get
            Return _c_nro_leasing
        End Get
        Set(ByVal value As String)
            _c_nro_leasing = value
        End Set
    End Property
    Public Property c_nro_cuota() As Integer
        Get
            Return _c_nro_cuota
        End Get
        Set(ByVal value As Integer)
            _c_nro_cuota = value
        End Set
    End Property
    Public Property c_correl_leasing() As String
        Get
            Return _c_correl_leasing
        End Get
        Set(ByVal value As String)
            _c_correl_leasing = value
        End Set
    End Property
    Public Property c_opc_apertura() As Integer
        Get
            Return _c_opc_apertura
        End Get
        Set(ByVal value As Integer)
            _c_opc_apertura = value
        End Set
    End Property
    Public Property c_opc_importacion() As Integer
        Get
            Return _c_opc_importacion
        End Get
        Set(ByVal value As Integer)
            _c_opc_importacion = value
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

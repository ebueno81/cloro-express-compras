Public Class Ent_CostosCab
    Private _c_nro_costo As String
    Private _c_nro_file As String
    Private _c_codi_prov As String
    Private _c_fecha_costo As Date
    Private _c_fecha_emi As Date
    Private _c_fecha_embarque As Date
    Private _c_fecha_llegada As Date
    Private _c_agencia_comercial As String
    Private _c_nro_dua As String
    Private _c_imp_dua As Decimal
    Private _c_tpo_cambio As Decimal
    Private _c_mon_costo As String
    Private _c_codi_mon As String
    Private _c_codi_doc As String
    Private _c_serie_doc As String
    Private _c_nro_doc As String
    Private _c_total_costo As Decimal
    Private _c_total_peso As Decimal
    Private _c_total_item As Decimal
    Private _c_imp_total As Decimal
    Private _c_total_invoice As Decimal
    Private _c_costo_bcos As Decimal
    Private _c_imp_otros As Decimal

    Private _c_imp_dua_mn As Decimal
    Private _c_total_costo_mn As Decimal
    Private _c_imp_total_mn As Decimal
    Private _c_total_invoice_mn As Decimal
    Private _c_costo_bcos_mn As Decimal
    Private _c_imp_otros_mn As Decimal

    Private _c_obs As String
    Private _c_usuario As String
    Private _cOpcion As String
    Public Property c_nro_costo() As String
        Get
            Return _c_nro_costo
        End Get
        Set(ByVal value As String)
            _c_nro_costo = value
        End Set
    End Property
    Public Property c_nro_file() As String
        Get
            Return _c_nro_file
        End Get
        Set(ByVal value As String)
            _c_nro_file = value
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
    Public Property c_fecha_costo() As Date
        Get
            Return _c_fecha_costo
        End Get
        Set(ByVal value As Date)
            _c_fecha_costo = value
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
    Public Property c_fecha_embarque() As Date
        Get
            Return _c_fecha_embarque
        End Get
        Set(ByVal value As Date)
            _c_fecha_embarque = value
        End Set
    End Property
    Public Property c_fecha_llegada() As Date
        Get
            Return _c_fecha_llegada
        End Get
        Set(ByVal value As Date)
            _c_fecha_llegada = value
        End Set
    End Property
    Public Property c_agencia_comercial() As String
        Get
            Return _c_agencia_comercial
        End Get
        Set(ByVal value As String)
            _c_agencia_comercial = value
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
    Public Property c_imp_dua() As Decimal
        Get
            Return _c_imp_dua
        End Get
        Set(ByVal value As Decimal)
            _c_imp_dua = value
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
    Public Property c_mon_costo() As String
        Get
            Return _c_mon_costo
        End Get
        Set(ByVal value As String)
            _c_mon_costo = value
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
    Public Property c_serie_doc As String
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
    Public Property c_total_costo() As Decimal
        Get
            Return _c_total_costo
        End Get
        Set(ByVal value As Decimal)
            _c_total_costo = value
        End Set
    End Property
    Public Property c_total_peso() As Decimal
        Get
            Return _c_total_peso
        End Get
        Set(ByVal value As Decimal)
            _c_total_peso = value
        End Set
    End Property
    Public Property c_total_item() As Decimal
        Get
            Return _c_total_item
        End Get
        Set(ByVal value As Decimal)
            _c_total_item = value
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
    Public Property c_total_invoice() As Decimal
        Get
            Return _c_total_invoice
        End Get
        Set(ByVal value As Decimal)
            _c_total_invoice = value
        End Set
    End Property
    Public Property c_costo_bcos() As Decimal
        Get
            Return _c_costo_bcos
        End Get
        Set(ByVal value As Decimal)
            _c_costo_bcos = value
        End Set
    End Property
    Public Property c_imp_otros() As Decimal
        Get
            Return _c_imp_otros
        End Get
        Set(ByVal value As Decimal)
            _c_imp_otros = value
        End Set
    End Property

    Public Property c_imp_dua_mn() As Decimal
        Get
            Return _c_imp_dua_mn
        End Get
        Set(ByVal value As Decimal)
            _c_imp_dua_mn = value
        End Set
    End Property
    Public Property c_total_costo_mn() As Decimal
        Get
            Return _c_total_costo_mn
        End Get
        Set(ByVal value As Decimal)
            _c_total_costo_mn = value
        End Set
    End Property
    Public Property c_imp_total_mn() As Decimal
        Get
            Return _c_imp_total_mn
        End Get
        Set(ByVal value As Decimal)
            _c_imp_total_mn = value
        End Set
    End Property
    Public Property c_total_invoice_mn() As Decimal
        Get
            Return _c_total_invoice_mn
        End Get
        Set(ByVal value As Decimal)
            _c_total_invoice_mn = value
        End Set
    End Property
    Public Property c_costo_bcos_mn() As Decimal
        Get
            Return _c_costo_bcos_mn
        End Get
        Set(ByVal value As Decimal)
            _c_costo_bcos_mn = value
        End Set
    End Property
    Public Property c_imp_otros_mn() As Decimal
        Get
            Return _c_imp_otros_mn
        End Get
        Set(ByVal value As Decimal)
            _c_imp_otros_mn = value
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
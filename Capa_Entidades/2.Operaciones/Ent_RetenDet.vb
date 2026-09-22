Public Class Ent_RetenDet
    Dim _c_nro_correl As String
    Dim _c_nro_serie As String
    Dim _c_nro_reten As String
    Dim _c_nro_ing As String
    Dim _c_correl_reten As String
    Dim _c_fecha_doc As Date
    Dim _c_codi_doc As String
    Dim _c_serie_doc As String
    Dim _c_nro_doc As String
    Dim _c_codi_mon As String
    Dim _c_imp_doc As Decimal
    Dim _c_imp_reten As Decimal
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_reten() As String
        Get
            Return _c_nro_reten
        End Get
        Set(ByVal value As String)
            _c_nro_reten = value
        End Set
    End Property
    Public Property c_nro_ing() As String
        Get
            Return _c_nro_ing
        End Get
        Set(ByVal value As String)
            _c_nro_ing = value
        End Set
    End Property
    Public Property c_correl_reten() As String
        Get
            Return _c_correl_reten
        End Get
        Set(ByVal value As String)
            _c_correl_reten = value
        End Set
    End Property
    Public Property c_fecha_doc() As Date
        Get
            Return _c_fecha_doc
        End Get
        Set(ByVal value As Date)
            _c_fecha_doc = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_imp_doc() As Decimal
        Get
            Return _c_imp_doc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_doc = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class

Public Class Ent_CostosDet
    Dim _c_nro_correl As String
    Dim _c_nro_costo As String
    Dim _c_serie_guia As String
    Dim _c_nro_guia As String
    Dim _c_codi_articulo As String
    Dim _c_codi_unimed As String
    Dim _c_nro_cant As Decimal
    Dim _c_precio_unit As Decimal
    Dim _c_precio_costo As Decimal
    Dim _c_imp_total As Decimal

    Dim _c_precio_unit_mn As Decimal
    Dim _c_precio_costo_mn As Decimal
    Dim _c_imp_total_mn As Decimal

    Dim _c_porc_costo As Decimal
    Dim _c_correl_guia As String
    Dim _c_correl_ing As String
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_costo() As String
        Get
            Return _c_nro_costo
        End Get
        Set(ByVal value As String)
            _c_nro_costo = value
        End Set
    End Property
    Public Property c_serie_guia() As String
        Get
            Return _c_serie_guia
        End Get
        Set(ByVal value As String)
            _c_serie_guia = value
        End Set
    End Property
    Public Property c_nro_guia() As String
        Get
            Return _c_nro_guia
        End Get
        Set(ByVal value As String)
            _c_nro_guia = value
        End Set
    End Property
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
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
    Public Property c_precio_unit() As Decimal
        Get
            Return _c_precio_unit
        End Get
        Set(ByVal value As Decimal)
            _c_precio_unit = value
        End Set
    End Property
    Public Property c_precio_costo() As Decimal
        Get
            Return _c_precio_costo
        End Get
        Set(ByVal value As Decimal)
            _c_precio_costo = value
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
    Public Property c_precio_unit_mn() As Decimal
        Get
            Return _c_precio_unit_mn
        End Get
        Set(ByVal value As Decimal)
            _c_precio_unit_mn = value
        End Set
    End Property
    Public Property c_precio_costo_mn() As Decimal
        Get
            Return _c_precio_costo_mn
        End Get
        Set(ByVal value As Decimal)
            _c_precio_costo_mn = value
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
    Public Property c_porc_costo() As Decimal
        Get
            Return _c_porc_costo
        End Get
        Set(ByVal value As Decimal)
            _c_porc_costo = value
        End Set
    End Property
    Public Property c_correl_guia() As String
        Get
            Return _c_correl_guia
        End Get
        Set(ByVal value As String)
            _c_correl_guia = value
        End Set
    End Property
    Public Property c_correl_ing() As String
        Get
            Return _c_correl_ing
        End Get
        Set(ByVal value As String)
            _c_correl_ing = value
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

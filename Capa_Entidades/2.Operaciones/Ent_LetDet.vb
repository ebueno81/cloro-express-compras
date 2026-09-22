Public Class Ent_LetDet
    Dim _c_nro_letra As String
    Dim _c_codi_prov As String
    Dim _c_nro_ing As String
    Dim _c_monto_doc As Decimal
    Dim _c_id_letra As Integer
    Dim _c_codi_mon As String
    Dim _c_codi_doc As String
    Dim _c_serie_doc As String
    Dim _c_nro_doc As String
    Dim _c_fecha_giro As Date
    Dim _c_tpo_cambio As Decimal
    Dim _copcion As String
    Public Property c_nro_letra() As String
        Get
            Return _c_nro_letra
        End Get
        Set(ByVal value As String)
            _c_nro_letra = value
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
    Public Property c_nro_ing() As String
        Get
            Return _c_nro_ing
        End Get
        Set(ByVal value As String)
            _c_nro_ing = value
        End Set
    End Property
    Public Property c_monto_doc() As Decimal
        Get
            Return _c_monto_doc
        End Get
        Set(ByVal value As Decimal)
            _c_monto_doc = value
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
    Public Property c_fecha_giro() As Date
        Get
            Return _c_fecha_giro
        End Get
        Set(ByVal value As Date)
            _c_fecha_giro = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class

Public Class Ent_DetracDet
    Dim _c_nro_correl As String
    Dim _c_año_lote As String
    Dim _c_nro_lote As String
    Dim _c_nro_ing As String
    Dim _c_monto_mn As Decimal
    Dim _c_monto_us As Decimal
    Dim _c_tpo_cambio As Decimal
    Dim _c_detracc_us As Decimal
    Dim _c_detracc_mn As Decimal
    Dim _c_fecha_cancel As Date
    Dim _c_nro_constancia As String
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_año_lote() As String
        Get
            Return _c_año_lote
        End Get
        Set(ByVal value As String)
            _c_año_lote = value
        End Set
    End Property
    Public Property c_nro_lote() As String
        Get
            Return _c_nro_lote
        End Get
        Set(ByVal value As String)
            _c_nro_lote = value
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
    Public Property c_monto_mn() As Decimal
        Get
            Return _c_monto_mn
        End Get
        Set(ByVal value As Decimal)
            _c_monto_mn = value
        End Set
    End Property
    Public Property c_monto_us() As Decimal
        Get
            Return _c_monto_us
        End Get
        Set(ByVal value As Decimal)
            _c_monto_us = value
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

    Public Property c_detracc_us() As Decimal
        Get
            Return _c_detracc_us
        End Get
        Set(ByVal value As Decimal)
            _c_detracc_us = value
        End Set
    End Property
    Public Property c_detracc_mn() As Decimal
        Get
            Return _c_detracc_mn
        End Get
        Set(ByVal value As Decimal)
            _c_detracc_mn = value
        End Set
    End Property
    Public Property c_fecha_cancel() As Date
        Get
            Return _c_fecha_cancel
        End Get
        Set(ByVal value As Date)
            _c_fecha_cancel = value
        End Set
    End Property
    Public Property c_nro_constancia() As String
        Get
            Return _c_nro_constancia
        End Get
        Set(ByVal value As String)
            _c_nro_constancia = value
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

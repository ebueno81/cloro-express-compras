Public Class Ent_LeasingDet
    Private _c_nro_correl As String
    Private _c_nro_operacion As String
    Private _c_nro_cuota As Integer
    Private _c_fecha_venci As Date
    Private _c_imp_capital As Decimal
    Private _c_imp_principal As Decimal
    Private _c_imp_interes As Decimal
    Private _c_imp_igv As Decimal
    Private _c_imp_total As Decimal
    Private _c_serie_cyb As String
    Private _c_ing_cyb As String
    Private _c_tpo_cyb As String
    Private _c_usuario As String
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
    Public Property c_nro_cuota() As Integer
        Get
            Return _c_nro_cuota
        End Get
        Set(ByVal value As Integer)
            _c_nro_cuota = value
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
    Public Property c_imp_capital() As Decimal
        Get
            Return _c_imp_capital
        End Get
        Set(ByVal value As Decimal)
            _c_imp_capital = value
        End Set
    End Property
    Public Property c_imp_principal() As Decimal
        Get
            Return _c_imp_principal
        End Get
        Set(ByVal value As Decimal)
            _c_imp_principal = value
        End Set
    End Property
    Public Property c_imp_interes() As Decimal
        Get
            Return _c_imp_interes
        End Get
        Set(ByVal value As Decimal)
            _c_imp_interes = value
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
    Public Property c_serie_cyb() As String
        Get
            Return _c_serie_cyb
        End Get
        Set(ByVal value As String)
            _c_serie_cyb = value
        End Set
    End Property
    Public Property c_ing_cyb() As String
        Get
            Return _c_ing_cyb
        End Get
        Set(ByVal value As String)
            _c_ing_cyb = value
        End Set
    End Property
    Public Property c_tpo_cyb() As String
        Get
            Return _c_tpo_cyb
        End Get
        Set(ByVal value As String)
            _c_tpo_cyb = value
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
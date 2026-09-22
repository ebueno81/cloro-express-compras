Public Class Ent_OCDetTR
    Dim _c_nro_serie As String
    Dim _c_nro_oc As String
    Dim _c_nro_partida As String
    Dim _c_tpo_mov As String
    Dim _c_codi_tg As String
    Dim _c_codi_cd As String
    Dim _c_codi_scd As String
    Dim _c_nro_cant As Decimal
    Dim _c_codi_unimed As String
    Dim _c_prec_unit As Decimal
    Dim _c_imp_total As Decimal
    Dim _c_opt_igv As Integer
    Dim _copcion As String
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_oc() As String
        Get
            Return _c_nro_oc
        End Get
        Set(ByVal value As String)
            _c_nro_oc = value
        End Set
    End Property
    Public Property c_nro_partida() As String
        Get
            Return _c_nro_partida
        End Get
        Set(ByVal value As String)
            _c_nro_partida = value
        End Set
    End Property
    Public Property c_tpo_mov() As String
        Get
            Return _c_tpo_mov
        End Get
        Set(ByVal value As String)
            _c_tpo_mov = value
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
    Public Property c_nro_cant() As Decimal
        Get
            Return _c_nro_cant
        End Get
        Set(ByVal value As Decimal)
            _c_nro_cant = value
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
    Public Property c_opt_igv() As Integer
        Get
            Return _c_opt_igv
        End Get
        Set(ByVal value As Integer)
            _c_opt_igv = value
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

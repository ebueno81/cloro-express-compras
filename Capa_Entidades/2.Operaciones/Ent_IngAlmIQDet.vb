Public Class Ent_IngAlmIQDet
    Private _c_nro_correl As String
    Private _c_codi_ing As String
    Private _c_sist_bahia As String
    Private _c_nro_lote As String
    Private _c_codi_articulo As String
    Private _c_nro_cant As Decimal
    Private _c_cant_caja As Decimal
    Private _c_codi_unimed As String
    Private _c_prec_unit As Decimal
    Private _c_imp_total As Decimal
    Private _c_opt_igv As Integer
    Private _c_codi_mon As String
    Private _c_correl_sal As String
    Private _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_codi_ing() As String
        Get
            Return _c_codi_ing
        End Get
        Set(ByVal value As String)
            _c_codi_ing = value
        End Set
    End Property
    Public Property c_sist_bahia() As Integer
        Get
            Return _c_sist_bahia
        End Get
        Set(ByVal value As Integer)
            _c_sist_bahia = value
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
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
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
    Public Property c_cant_caja() As Decimal
        Get
            Return _c_cant_caja
        End Get
        Set(ByVal value As Decimal)
            _c_cant_caja = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_correl_sal() As String
        Get
            Return _c_correl_sal
        End Get
        Set(ByVal value As String)
            _c_correl_sal = value
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

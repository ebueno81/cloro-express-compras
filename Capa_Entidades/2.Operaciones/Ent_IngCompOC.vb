Public Class Ent_IngCompOC
    Dim _c_nro_correl As String
    Dim _c_nro_ing As String
    Dim _c_nro_oc As String
    Dim _c_serie_oc As String
    Dim _c_tpo_doc As String
    Dim _c_codi_ing As String
    Dim _c_imp_total As Decimal
    Dim _c_fecha_emi As Date
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
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
    Public Property c_nro_oc() As String
        Get
            Return _c_nro_oc
        End Get
        Set(ByVal value As String)
            _c_nro_oc = value
        End Set
    End Property
    Public Property c_serie_oc() As String
        Get
            Return _c_serie_oc
        End Get
        Set(ByVal value As String)
            _c_serie_oc = value
        End Set
    End Property
    Public Property c_tpo_doc() As String
        Get
            Return _c_tpo_doc
        End Get
        Set(ByVal value As String)
            _c_tpo_doc = value
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
    Public Property c_imp_total() As Decimal
        Get
            Return _c_imp_total
        End Get
        Set(ByVal value As Decimal)
            _c_imp_total = value
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
   

    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class

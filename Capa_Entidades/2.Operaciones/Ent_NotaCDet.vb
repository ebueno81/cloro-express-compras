Public Class Ent_NotaCDet
    Dim _c_ing_nc As String
    Dim _c_nro_ing As String
    Dim _c_imp_ing As Decimal
    Dim _c_imp_nc As Decimal
    Dim _c_imp_saldo As Decimal
    Dim _copcion As String
    Public Property c_ing_nc() As String
        Get
            Return _c_ing_nc
        End Get
        Set(ByVal value As String)
            _c_ing_nc = value
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
    Public Property c_imp_ing() As Decimal
        Get
            Return _c_imp_ing
        End Get
        Set(ByVal value As Decimal)
            _c_imp_ing = value
        End Set
    End Property
    Public Property c_imp_nc() As Decimal
        Get
            Return _c_imp_nc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_nc = value
        End Set
    End Property
    Public Property c_imp_saldo() As Decimal
        Get
            Return _c_imp_saldo
        End Get
        Set(ByVal value As Decimal)
            _c_imp_saldo = value
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

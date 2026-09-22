Public Class Ent_MnTblDetraccion
    Dim _c_codi_detracc As String
    Dim _c_desc_detracc As String
    Dim _c_porc_detracc As Integer
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_detracc() As String
        Get
            Return _c_codi_detracc
        End Get
        Set(ByVal value As String)
            _c_codi_detracc = value
        End Set
    End Property
    Public Property c_desc_detracc() As String
        Get
            Return _c_desc_detracc
        End Get
        Set(ByVal value As String)
            _c_desc_detracc = value
        End Set
    End Property
    Public Property c_porc_detracc() As Decimal
        Get
            Return _c_porc_detracc
        End Get
        Set(ByVal value As Decimal)
            _c_porc_detracc = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property
End Class

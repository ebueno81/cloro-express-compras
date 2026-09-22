Public Class Ent_Detrac
    Dim _c_año_lote As String
    Dim _c_nro_lote As String
    Dim _c_fecha_emi As Date
    Dim _c_usuario As String
    Dim _copcion As String
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
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
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

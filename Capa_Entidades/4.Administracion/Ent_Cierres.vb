Public Class Ent_Cierres
    Dim _c_fecha_prd As Date
    Dim _c_año_prd As Integer
    Dim _c_mes_prd As String
    Dim _c_estado_prd As Integer
    Dim _c_obs As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_fecha_prd() As Date
        Get
            Return _c_fecha_prd
        End Get
        Set(ByVal value As Date)
            _c_fecha_prd = value
        End Set
    End Property
    Public Property c_año_prd() As Integer
        Get
            Return _c_año_prd
        End Get
        Set(ByVal value As Integer)
            _c_año_prd = value
        End Set
    End Property
    Public Property c_mes_prd() As String
        Get
            Return _c_mes_prd
        End Get
        Set(ByVal value As String)
            _c_mes_prd = value
        End Set
    End Property
    Public Property c_obs() As String
        Get
            Return _c_obs
        End Get
        Set(ByVal value As String)
            _c_obs = value
        End Set
    End Property
    Public Property c_estado_prd() As Integer
        Get
            Return _c_estado_prd
        End Get
        Set(ByVal value As Integer)
            _c_estado_prd = value
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

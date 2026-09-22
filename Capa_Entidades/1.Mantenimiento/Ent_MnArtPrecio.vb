Public Class Ent_MnArtPrecio
    Private _c_codi_precio As String
    Private _c_codi_articulo As String
    Private _c_codi_mon As String
    Private _c_precio_art As Decimal
    Private _c_fecha_art As Date
    Private _c_obs As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_precio() As String
        Get
            Return _c_codi_precio
        End Get
        Set(ByVal value As String)
            _c_codi_precio = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_precio_art() As Decimal
        Get
            Return _c_precio_art
        End Get
        Set(ByVal value As Decimal)
            _c_precio_art = value
        End Set
    End Property
    Public Property c_fecha_art() As Date
        Get
            Return _c_fecha_art
        End Get
        Set(ByVal value As Date)
            _c_fecha_art = value
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
    Public Property c_usuario() As String
        Get
            Return _c_usuario
        End Get
        Set(ByVal value As String)
            _c_usuario = value
        End Set
    End Property
    Public Property copcion()
        Get
            Return _copcion
        End Get
        Set(ByVal value)
            _copcion = value
        End Set
    End Property
End Class

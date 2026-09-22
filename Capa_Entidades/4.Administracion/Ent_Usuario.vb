Public Class Ent_Usuario
    Dim _c_codi_usua As String
    Dim _c_clave_usua As String
    Dim _c_nom_usua As String
    Dim _c_nom_pc As String
    Dim _c_codi_area As String
    Dim _c_email_usua As String
    Dim _c_usua_admin As Integer
    Dim _c_usua_transforma As Integer
    Dim _c_obs As String

    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_usua() As String
        Get
            Return _c_codi_usua
        End Get
        Set(ByVal value As String)
            _c_codi_usua = value
        End Set
    End Property
    Public Property c_clave_usua() As String
        Get
            Return _c_clave_usua
        End Get
        Set(ByVal value As String)
            _c_clave_usua = value
        End Set
    End Property
    Public Property c_nom_usua() As String
        Get
            Return _c_nom_usua
        End Get
        Set(ByVal value As String)
            _c_nom_usua = value
        End Set
    End Property
    Public Property c_nom_pc() As String
        Get
            Return _c_nom_pc
        End Get
        Set(ByVal value As String)
            _c_nom_pc = value
        End Set
    End Property
    Public Property c_codi_area() As String
        Get
            Return _c_codi_area
        End Get
        Set(ByVal value As String)
            _c_codi_area = value
        End Set
    End Property
    Public Property c_email_usua() As String
        Get
            Return _c_email_usua
        End Get
        Set(ByVal value As String)
            _c_email_usua = value
        End Set
    End Property
    Public Property c_usua_admin() As Integer
        Get
            Return _c_usua_admin
        End Get
        Set(ByVal value As Integer)
            _c_usua_admin = value
        End Set
    End Property
    Public Property c_usua_transforma() As Integer
        Get
            Return _c_usua_transforma
        End Get
        Set(ByVal value As Integer)
            _c_usua_transforma = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property

End Class

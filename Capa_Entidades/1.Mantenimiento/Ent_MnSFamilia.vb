Public Class Ent_MnSFamilia
    Dim _c_codi_linea As String
    Dim _c_codi_familia As String
    Dim _c_codi_subfamilia As String
    Dim _c_desc_subfamilia As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_linea() As String
        Get
            Return _c_codi_linea
        End Get
        Set(ByVal value As String)
            _c_codi_linea = value
        End Set
    End Property
    Public Property c_codi_familia() As String
        Get
            Return _c_codi_familia
        End Get
        Set(ByVal value As String)
            _c_codi_familia = value
        End Set
    End Property
    Public Property c_codi_subfamilia() As String
        Get
            Return _c_codi_subfamilia
        End Get
        Set(ByVal value As String)
            _c_codi_subfamilia = value
        End Set
    End Property
    Public Property c_desc_subfamilia() As String
        Get
            Return _c_desc_subfamilia
        End Get
        Set(ByVal value As String)
            _c_desc_subfamilia = value
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

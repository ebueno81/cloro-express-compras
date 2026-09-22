Public Class Ent_MnUniMed
    Private _c_codi_unimed As String
    Private _c_desc_unimed As String
    Private _c_codi_sunat As String
    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_unimed() As String
        Get
            Return _c_codi_unimed
        End Get
        Set(ByVal value As String)
            _c_codi_unimed = value
        End Set
    End Property
    Public Property c_desc_unimed() As String
        Get
            Return _c_desc_unimed
        End Get
        Set(ByVal value As String)
            _c_desc_unimed = value
        End Set
    End Property
    Public Property c_codi_sunat() As String
        Get
            Return _c_codi_sunat
        End Get
        Set(ByVal value As String)
            _c_codi_sunat = value
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

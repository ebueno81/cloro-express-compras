Public Class Ent_MnTpoDoc
    Dim _c_codi_doc As String
    Dim _c_desc_doc As String
    Dim _c_codi_concar As String
    Dim _c_opt_regcomp As Integer
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_doc() As String
        Get
            Return _c_codi_doc
        End Get
        Set(ByVal value As String)
            _c_codi_doc = value
        End Set
    End Property
    Public Property c_desc_doc() As String
        Get
            Return _c_desc_doc
        End Get
        Set(ByVal value As String)
            _c_desc_doc = value
        End Set
    End Property
    Public Property c_codi_concar() As String
        Get
            Return _c_codi_concar
        End Get
        Set(ByVal value As String)
            _c_codi_concar = value
        End Set
    End Property
    Public Property c_opt_regcomp() As Integer
        Get
            Return _c_opt_regcomp
        End Get
        Set(ByVal value As Integer)
            _c_opt_regcomp = value
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

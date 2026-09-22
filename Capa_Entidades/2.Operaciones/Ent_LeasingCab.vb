Public Class Ent_LeasingCab
    Private _c_nro_operacion As String
    Private _c_fecha_emision As Date
    Private _c_codi_prove As String
    Private _c_nro_serie As String
    Private _c_nro_credito As String
    Private _c_codi_mon As String
    Private _c_codi_doc As String
    Private _c_nro_cuotas As Integer
    Private _c_imp_total As Decimal
    Private _c_obs As String
    Private _c_usuario As String
    Private _cOpcion As String
    Public Property c_nro_operacion() As String
        Get
            Return _c_nro_operacion
        End Get
        Set(ByVal value As String)
            _c_nro_operacion = value
        End Set
    End Property
    Public Property c_fecha_emision() As Date
        Get
            Return _c_fecha_emision
        End Get
        Set(ByVal value As Date)
            _c_fecha_emision = value
        End Set
    End Property
    Public Property c_codi_prove() As String
        Get
            Return _c_codi_prove
        End Get
        Set(ByVal value As String)
            _c_codi_prove = value
        End Set
    End Property
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_credito() As String
        Get
            Return _c_nro_credito
        End Get
        Set(ByVal value As String)
            _c_nro_credito = value
        End Set
    End Property
  
    Public Property c_codi_mon As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_codi_doc As String
        Get
            Return _c_codi_doc
        End Get
        Set(ByVal value As String)
            _c_codi_doc = value
        End Set
    End Property
    Public Property c_nro_cuotas() As Integer
        Get
            Return _c_nro_cuotas
        End Get
        Set(ByVal value As Integer)
            _c_nro_cuotas = value
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
    Public Property cOpcion() As String
        Get
            Return _cOpcion
        End Get
        Set(ByVal value As String)
            _cOpcion = value
        End Set
    End Property

End Class
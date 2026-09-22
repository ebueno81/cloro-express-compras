Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnArticulos
    Dim c_Articulo As New Cls_MnArticulo
    Public Function set_Articulo_Save(ByVal c_Entidades As Ent_MnArticulo)
        Return c_Articulo.set_Articulo_SAVE(c_Entidades)
    End Function
    Public Function set_ArtPrecio_Save(ByVal c_Entidades As Ent_MnArtPrecio)
        Return c_Articulo.set_ArtPrecio_SAVE(c_Entidades)
    End Function
    Public Function get_Articulo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Articulo.Get_Articulo_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros 2 dos combos...
    Public Function Get_Articulo_Cbo_2(ByVal Cadena As String, ByVal Combo1 As ComboBox, ByVal Combo2 As ComboBox)
        c_Articulo.get_Articulo_Cbo_2(Cadena, Combo1, Combo2)
    End Function
    'Cargamos Registros al combo...
    Public Function Get_Articulo_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        c_Articulo.get_Articulo_Cbo(Cadena, Combo1)
    End Function
End Class

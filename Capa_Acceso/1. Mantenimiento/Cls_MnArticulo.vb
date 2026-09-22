Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnArticulo

    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_Articulo_SAVE(ByVal ent As Ent_MnArticulo) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_Articulos"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 8).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_desc_articulo", OleDbType.VarChar, 500).Value = ent.c_desc_articulo
            cmd.Parameters.Add("@c_codi_linea", OleDbType.VarChar, 2).Value = ent.c_codi_linea
            cmd.Parameters.Add("@c_codi_familia", OleDbType.VarChar, 2).Value = ent.c_codi_familia
            cmd.Parameters.Add("@c_codi_sfamilia", OleDbType.VarChar, 3).Value = ent.c_codi_sfamilia
            cmd.Parameters.Add("@c_codi_artsunat", OleDbType.VarChar, 10).Value = ent.c_codi_artsunat
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_valor_unidad", OleDbType.Integer).Value = ent.c_valor_unidad
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_precio_art", OleDbType.Decimal, 12, 6).Value = ent.c_precio_art
            cmd.Parameters.Add("@c_stock_min", OleDbType.Decimal, 10, 3).Value = ent.c_stock_min
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = ent.c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = ent.c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = ent.c_codi_scd
            cmd.Parameters.Add("@c_control_art", OleDbType.Integer).Value = ent.c_control_art
            cmd.Parameters.Add("@c_opc_noinventario", OleDbType.Integer).Value = ent.c_opc_noinventario
            cmd.Parameters.Add("@c_opc_transforma", OleDbType.Integer).Value = ent.c_opc_transforma
            cmd.Parameters.Add("@c_opc_ingtransforma", OleDbType.Integer).Value = ent.c_opc_ingtransforma

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 8)
            Codi_Auto.Direction = ParameterDirection.Output
            'MsgBox(ent.copcion)
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_Articulo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_Articulos"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt


            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    
    Public Function set_ArtPrecio_SAVE(ByVal ent As Ent_MnArtPrecio) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_upt_ArtPrecio"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_precio", OleDbType.VarChar, 2).Value = ent.c_codi_precio
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 8).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_precio_art", OleDbType.Decimal, 10, 3).Value = ent.c_precio_art
            cmd.Parameters.Add("@c_fecha_art", OleDbType.Date).Value = ent.c_fecha_art
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 2)
            Codi_Auto.Direction = ParameterDirection.Output
            'MsgBox(ent.copcion)
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    'Cargar datos a dos combos...
    Public Function get_Articulo_Cbo_2(ByVal Cadena As String, ByVal Combo1 As ComboBox, ByVal Combo2 As ComboBox)
        With Get_Articulo_Datos(Cadena, "DAT")
            Combo1.Items.Clear() : Combo2.Items.Clear()
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Combo1.Items.Add(.Rows(i)("c_codi_articulo").ToString)
                    Combo2.Items.Add(.Rows(i)("c_desc_articulo").ToString)
                Next
                Combo1.SelectedIndex = -1 : Combo2.SelectedIndex = -1
            End If
        End With
    End Function
    'Cargar datos al combo...
    Public Function get_Articulo_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Articulo_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_articulo"
        Combo1.ValueMember = "c_codi_articulo"
        Combo1.SelectedIndex = -1
    End Function
End Class

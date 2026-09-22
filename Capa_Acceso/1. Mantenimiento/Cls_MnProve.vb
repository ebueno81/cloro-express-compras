Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnProve
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_Proveedor_Save(ByVal ent As Ent_MnProve) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_Proveedor"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_desc_prov", OleDbType.VarChar, 120).Value = ent.c_desc_prov
            cmd.Parameters.Add("@c_nom_prov", OleDbType.VarChar, 120).Value = ent.c_nom_prov
            cmd.Parameters.Add("@c_codi_ubigeo", OleDbType.VarChar, 6).Value = ent.c_codi_ubigeo
            cmd.Parameters.Add("@c_pais_prov", OleDbType.VarChar, 40).Value = ent.c_pais_prov
            cmd.Parameters.Add("@c_ciudad_prov", OleDbType.VarChar, 40).Value = ent.c_ciudad_prov
            cmd.Parameters.Add("@c_dist_prov", OleDbType.VarChar, 40).Value = ent.c_dist_prov
            cmd.Parameters.Add("@c_direc_prov", OleDbType.VarChar, 100).Value = ent.c_direc_prov
            cmd.Parameters.Add("@c_ruc_prov", OleDbType.VarChar, 11).Value = ent.c_ruc_prov
            cmd.Parameters.Add("@c_telf_prov", OleDbType.VarChar, 50).Value = ent.c_telf_prov
            cmd.Parameters.Add("@c_cel_prov", OleDbType.VarChar, 50).Value = ent.c_cel_prov
            cmd.Parameters.Add("@c_contac_prov", OleDbType.VarChar, 50).Value = ent.c_contac_prov
            cmd.Parameters.Add("@c_mail_prov", OleDbType.VarChar, 50).Value = ent.c_mail_prov
            cmd.Parameters.Add("@c_web_prov", OleDbType.VarChar, 50).Value = ent.c_web_prov
            cmd.Parameters.Add("@c_codi_tpoprov", OleDbType.VarChar, 2).Value = ent.c_codi_tpoprov
            cmd.Parameters.Add("@c_cta_detraccion", OleDbType.VarChar, 30).Value = ent.c_cta_detraccion
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_tpo_compra", OleDbType.Integer).Value = ent.c_tpo_compra
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 5)
            Codi_Auto.Direction = ParameterDirection.Output
            'ejecutamos query
            cmd.ExecuteNonQuery()
            'enviamos el nro de orden autogenerado...
            Codigo = Codi_Auto.Value.ToString

            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_Proveedor_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_Proveedor"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
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
    Public Function Get_Cargar_MtProve_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Proveedor_Datos(Cadena, "DAT")
        Combo1.DisplayMember = "c_desc_prov"
        Combo1.ValueMember = "c_codi_prov"
        Combo1.SelectedIndex = -1
    End Function
End Class

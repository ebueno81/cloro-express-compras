Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_IngCompDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_IngCompDet_SAVE(ByVal ent As Ent_IngCompDet, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_upt_IngCompDet"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_correl_ing", OleDbType.VarChar, 8).Value = ent.c_correl_ing
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 10).Value = ent.c_nro_oc
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = ent.c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = ent.c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 8).Value = ent.c_codi_scd
            cmd.Parameters.Add("@c_nro_cant", OleDbType.Numeric, 15, 4).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_prec_unit", OleDbType.Numeric, 15, 4).Value = ent.c_prec_unit
            cmd.Parameters.Add("@c_imp_total", OleDbType.Numeric, 15, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_opt_igv", OleDbType.Integer).Value = ent.c_opt_igv
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar).Value = ent.c_obs
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
            Codi_Auto.Direction = ParameterDirection.Output
            'Ejecutamos query
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
        Return Codigo
    End Function
    Public Function Get_IngComp_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_IngCompDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = Emp

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
End Class

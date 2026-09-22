Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_CostosCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_CostosCab_SAVE(ByVal ent As Ent_CostosCab) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_CostosCab"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_costo", OleDbType.VarChar, 7).Value = ent.c_nro_costo
            cmd.Parameters.Add("@c_nro_file", OleDbType.VarChar, 30).Value = ent.c_nro_file
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_fecha_costo", OleDbType.Date).Value = ent.c_fecha_costo
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_fecha_embarque", OleDbType.Date).Value = ent.c_fecha_embarque
            cmd.Parameters.Add("@c_fecha_llegada", OleDbType.Date).Value = ent.c_fecha_llegada
            cmd.Parameters.Add("@c_agencia_comercial", OleDbType.VarChar, 100).Value = ent.c_agencia_comercial
            cmd.Parameters.Add("@c_nro_dua", OleDbType.VarChar, 10).Value = ent.c_nro_dua
            cmd.Parameters.Add("@c_imp_dua", OleDbType.Numeric, 12, 2).Value = ent.c_imp_dua
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_mon_costo", OleDbType.VarChar, 2).Value = ent.c_mon_costo
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 10).Value = ent.c_nro_doc

            cmd.Parameters.Add("@c_total_costo", OleDbType.Decimal, 12, 2).Value = ent.c_total_costo
            cmd.Parameters.Add("@c_total_peso", OleDbType.Decimal, 12, 2).Value = ent.c_total_peso
            cmd.Parameters.Add("@c_total_item", OleDbType.Decimal, 12, 2).Value = ent.c_total_item
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_total_invoice", OleDbType.Decimal, 15, 2).Value = ent.c_total_invoice
            cmd.Parameters.Add("@c_costo_bcos", OleDbType.Decimal, 12, 2).Value = ent.c_costo_bcos
            cmd.Parameters.Add("@c_imp_otros", OleDbType.Decimal, 15, 2).Value = ent.c_imp_otros

            cmd.Parameters.Add("@c_imp_dua_mn", OleDbType.Numeric, 12, 2).Value = ent.c_imp_dua_mn
            cmd.Parameters.Add("@c_total_costo_mn", OleDbType.Decimal, 12, 2).Value = ent.c_total_costo_mn
            cmd.Parameters.Add("@c_imp_total_mn", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total_mn
            cmd.Parameters.Add("@c_total_invoice_mn", OleDbType.Decimal, 15, 2).Value = ent.c_total_invoice_mn
            cmd.Parameters.Add("@c_costo_bcos_mn", OleDbType.Decimal, 12, 2).Value = ent.c_costo_bcos_mn
            cmd.Parameters.Add("@c_imp_otros_mn", OleDbType.Decimal, 15, 2).Value = ent.c_imp_otros_mn

            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_opcion", OleDbType.VarChar, 3).Value = ent.cOpcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 7)
            Codi_Auto.Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString()
            Conex.Close()
        Catch ex As Exception
            MsgBox("1. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_CostosCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_CostosCab"

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
End Class

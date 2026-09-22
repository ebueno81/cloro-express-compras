Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_CostosDocs
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_CostosDocs_SAVE(ByVal ent As Ent_CostosDocs) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_CostosDocs"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_costo", OleDbType.VarChar, 7).Value = ent.c_nro_costo
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.VarChar, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 3).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_mon_doc", OleDbType.VarChar, 2).Value = ent.c_mon_doc
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_imp_total_mn", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total_mn
            cmd.Parameters.Add("@c_opcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
            Codi_Auto.Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString()
            Conex.Close()
        Catch ex As Exception
            MsgBox("1. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_CostosDocs_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_CostosDocs"

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

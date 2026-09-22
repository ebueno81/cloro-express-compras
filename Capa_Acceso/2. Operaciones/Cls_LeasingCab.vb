Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LeasingCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_LeasingCab_SAVE(ByVal ent As Ent_LeasingCab) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_LeasingCab"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_operacion", OleDbType.VarChar, 7).Value = ent.c_nro_operacion
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emision
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prove
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_credito", OleDbType.VarChar, 10).Value = ent.c_nro_credito
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc

            cmd.Parameters.Add("@c_nro_cuotas", OleDbType.Integer).Value = ent.c_nro_cuotas
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
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
    Public Function Get_LeasingCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_LeasingCab"

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

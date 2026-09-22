Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LeasingDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_LeasingDet_SAVE(ByVal ent As Ent_LeasingDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_LeasingDet"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_operacion", OleDbType.VarChar, 7).Value = ent.c_nro_operacion
            cmd.Parameters.Add("@c_nro_cuota", OleDbType.Integer).Value = ent.c_nro_cuota
            cmd.Parameters.Add("@c_fecha_venci", OleDbType.Date).Value = ent.c_fecha_venci
            cmd.Parameters.Add("@c_imp_capital", OleDbType.Decimal, 12, 2).Value = ent.c_imp_capital
            cmd.Parameters.Add("@c_imp_principal", OleDbType.Decimal, 12, 2).Value = ent.c_imp_principal
            cmd.Parameters.Add("@c_imp_interes", OleDbType.Decimal, 12, 2).Value = ent.c_imp_interes
            cmd.Parameters.Add("@c_imp_igv", OleDbType.Decimal, 12, 2).Value = ent.c_imp_igv
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_opcion", OleDbType.VarChar, 3).Value = ent.cOpcion

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
    Public Function Scom_LeasingDetCancel_SAVE(ByVal ent As Ent_LeasingDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_LeasingDetCancel"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_serie_cyb", OleDbType.VarChar, 3).Value = ent.c_serie_cyb
            cmd.Parameters.Add("@c_ing_cyb", OleDbType.VarChar, 7).Value = ent.c_ing_cyb
            cmd.Parameters.Add("@c_tpo_cyb", OleDbType.VarChar, 1).Value = ent.c_tpo_cyb
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_opcion", OleDbType.VarChar, 3).Value = ent.cOpcion


            cmd.ExecuteNonQuery()
            Conex.Close()
        Catch ex As Exception
            MsgBox("1. " & ex.Message)
        End Try
        Return ""
    End Function
    Public Function Get_LeasingDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_LeasingDet"

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

Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_CostosDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_CostosDet_SAVE(ByVal ent As Ent_CostosDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandTimeout = 6000
        cmd.CommandText = "Sp_Scom_upt_CostosDet"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_costo", OleDbType.VarChar, 7).Value = ent.c_nro_costo
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = ent.c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 10).Value = ent.c_nro_guia
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_nro_cant", OleDbType.VarChar, 12, 2).Value = ent.c_nro_cant

            cmd.Parameters.Add("@c_precio_unit", OleDbType.Numeric, 14, 6).Value = ent.c_precio_unit
            cmd.Parameters.Add("@c_precio_costo", OleDbType.Decimal, 14, 6).Value = ent.c_precio_costo
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total

            cmd.Parameters.Add("@c_precio_unit_mn", OleDbType.Numeric, 14, 6).Value = ent.c_precio_unit_mn
            cmd.Parameters.Add("@c_precio_costo_mn", OleDbType.Decimal, 14, 6).Value = ent.c_precio_costo_mn
            cmd.Parameters.Add("@c_imp_total_mn", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total_mn

            cmd.Parameters.Add("@c_porc_costo", OleDbType.Decimal, 10, 6).Value = ent.c_porc_costo
            cmd.Parameters.Add("@c_correl_guia", OleDbType.VarChar, 8).Value = ent.c_correl_guia
            cmd.Parameters.Add("@c_correl_ing", OleDbType.VarChar, 8).Value = ent.c_correl_ing
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
    Public Function Get_CostosDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_CostosDet"

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

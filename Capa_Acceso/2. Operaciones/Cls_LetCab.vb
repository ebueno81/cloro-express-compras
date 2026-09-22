Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LetCab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_LetCab_SAVE(ByVal ent As Ent_LetCab, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & c_codi_emp & "_upt_LetCab"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_liq", OleDbType.VarChar, 7).Value = ent.c_nro_liq
            cmd.Parameters.Add("@c_id_let", OleDbType.Integer).Value = ent.c_id_letra
            cmd.Parameters.Add("@c_nro_letra", OleDbType.VarChar, 9).Value = ent.c_nro_letra
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prove
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_stletra", OleDbType.VarChar, 2).Value = ent.c_codi_stletra
            cmd.Parameters.Add("@c_nro_dias", OleDbType.Integer).Value = ent.c_nro_dias
            cmd.Parameters.Add("@c_fecha_giro", OleDbType.Date).Value = ent.c_fecha_giro
            cmd.Parameters.Add("@c_fecha_venci", OleDbType.Date).Value = ent.c_fecha_venci
            cmd.Parameters.Add("@c_codi_bco", OleDbType.VarChar, 2).Value = ent.c_codi_bco
            cmd.Parameters.Add("@c_mt_anula", OleDbType.VarChar, 300).Value = ent.c_mt_anula
            cmd.Parameters.Add("@c_nro_unico", OleDbType.VarChar, 20).Value = ent.c_nro_unico

            cmd.Parameters.Add("@c_imp_letra", OleDbType.Decimal, 15, 2).Value = ent.c_imp_letra

            cmd.Parameters.Add("@c_renovac_let", OleDbType.Integer).Value = ent.c_renovac_letra
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
            Codi_Auto = cmd.Parameters.Add("@c_codi_auto", OleDbType.VarChar, 7)
            Codi_Auto.Direction = ParameterDirection.Output
            'ejecutamos query
            cmd.ExecuteNonQuery()
            'enviamos el nro de orden autogenerado...
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
        Return Codigo
    End Function
    Public Function Get_LetCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_LetCab"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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

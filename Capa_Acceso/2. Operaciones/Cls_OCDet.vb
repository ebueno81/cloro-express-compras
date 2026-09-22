Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_OCDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_OCDet_SAVE(ByVal ent As Ent_OCDet, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & c_codi_emp & "_upt_OCDet"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 7).Value = ent.c_nro_oc
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = ent.c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = ent.c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = ent.c_codi_scd
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo

            cmd.Parameters.Add("@c_nro_cant", OleDbType.Numeric, 15, 4).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_prec_unit", OleDbType.Numeric, 15, 6).Value = ent.c_prec_unit
            cmd.Parameters.Add("@c_imp_total", OleDbType.Numeric, 9, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_opt_igv", OleDbType.Integer).Value = ent.c_opt_igv
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs

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
    Public Function Get_OCDet_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_OCDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@c_codi_emp", OleDbType.VarChar, 2).Value = c_codi_emp
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

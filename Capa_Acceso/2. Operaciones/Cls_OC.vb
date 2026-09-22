Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_OC
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_OC_SAVE(ByVal ent As Ent_OC, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & c_codi_emp & "_upt_Oc"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 7).Value = ent.c_nro_oc
            cmd.Parameters.Add("@c_serie_oq", OleDbType.VarChar, 3).Value = ent.c_serie_oq
            cmd.Parameters.Add("@c_nro_oq", OleDbType.VarChar, 7).Value = ent.c_nro_oq
            cmd.Parameters.Add("@c_tpo_oc", OleDbType.Integer).Value = ent.c_tpo_oc
            cmd.Parameters.Add("@c_codi_prove", OleDbType.VarChar, 5).Value = ent.c_codi_prove
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_pago", OleDbType.VarChar, 2).Value = ent.c_codi_pago
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = ent.c_codi_alm
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_cant_igv", OleDbType.Numeric, 10).Value = ent.c_cant_igv
            cmd.Parameters.Add("@c_imp_inaf", OleDbType.Numeric, 10, 2).Value = ent.c_imp_inaf
            cmd.Parameters.Add("@c_imp_igv", OleDbType.Numeric, 10, 2).Value = ent.c_imp_igv
            cmd.Parameters.Add("@c_imp_afecto", OleDbType.Numeric, 10, 2).Value = ent.c_imp_afecto
            cmd.Parameters.Add("@c_imp_total", OleDbType.Numeric, 10, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 8)
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
    Public Function Get_OC_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_OC"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = c_codi_emp
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

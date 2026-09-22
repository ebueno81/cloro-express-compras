Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_IngAlmIQ
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_IngAlmIQ_Save(ByVal ent As Ent_IngAlmIQ, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_upt_IngAlm"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_ing", OleDbType.VarChar, 7).Value = ent.c_codi_ing
            cmd.Parameters.Add("@c_serie_oc", OleDbType.VarChar, 3).Value = ent.c_serie_oc
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 7).Value = ent.c_nro_oc
            cmd.Parameters.Add("@c_sist_bahia", OleDbType.Integer).Value = ent.c_sist_bahia
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_codi_clie", OleDbType.VarChar, 6).Value = ent.c_codi_clie
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 5).Value = ent.c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 8).Value = ent.c_nro_guia
            cmd.Parameters.Add("@c_fecha_ing", OleDbType.Date).Value = ent.c_fecha_ing
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Decimal, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = ent.c_codi_mt
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = ent.c_codi_alm
            cmd.Parameters.Add("@c_total_ing", OleDbType.Decimal, 9, 2).Value = ent.c_total_ing

            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_opc_devol", OleDbType.Integer).Value = ent.c_opc_devol

            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion


            Codi_Auto = cmd.Parameters.Add("@c_codigo", OleDbType.VarChar, 7)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_IngAlm_Datos(ByVal Cadena As String, ByVal Emp As String, ByVal vOpt As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlm"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@cadena", OleDbType.VarChar, 500).Value = Cadena
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 2).Value = Emp
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
    Public Function Get_IngAlmCOM_Datos(ByVal Cadena As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlmCOM"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = Cadena
            cmd.Parameters.Add("@c_codi_emp", OleDbType.VarChar, 2).Value = c_codi_emp

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_IngAlmCOM_Datos2(ByVal Cadena As String, ByVal c_codi_emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlmCOM2"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_IngAlmRpt_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String, ByVal c_codi_prov As String,
                                       ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String,
                                        ByVal c_nro_ing As String, ByVal c_serie_guia As String, ByVal c_nro_guia As String,
                                         ByVal c_serie_doc As String, ByVal c_nro_doc As String, ByVal c_codi_mon As String,
                                        ByVal c_opc_noingsal As String, ByVal c_codi_alm As String, ByVal cOpcion As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Rpt_IngAlm"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_mt", OleDbType.VarChar, 2).Value = c_codi_mt
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = c_codi_prov
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = c_codi_scd
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = c_nro_ing
            cmd.Parameters.Add("@c_serie_guia", OleDbType.VarChar, 3).Value = c_serie_guia
            cmd.Parameters.Add("@c_nro_guia", OleDbType.VarChar, 7).Value = c_nro_guia
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 3).Value = c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = c_nro_doc
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
            cmd.Parameters.Add("@c_opc_noingsal", OleDbType.VarChar, 1).Value = c_opc_noingsal
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm

            cmd.Parameters.Add("@cOpcion", OleDbType.VarChar, 3).Value = cOpcion

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

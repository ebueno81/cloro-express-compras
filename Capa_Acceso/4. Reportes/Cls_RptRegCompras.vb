Imports System.Data
Imports System.Data.OleDb
Public Class Cls_RptRegCompras
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_RptRegCompras_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                          ByVal c_codi_mon As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Rpt_RegCompras"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
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
    ' Registro de Compras por Totales '
    Public Function Get_RptRegComprasTot_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                          ByVal c_codi_mon As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Rpt_RegComprasTOT"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon
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
    ' Facturas pendientes por pagar '
    Public Function Get_RptRegDocPend_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                         ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_Rpt_DocPendxPagar"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = c_codi_prov
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
    ' Facturas pendientes por pagar Total'
    Public Function Get_RptRegDocPendTotal_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                         ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_Rpt_DocPendxPagarTot"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = c_codi_prov
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
    ' Reporte movimiento detallado '
    Public Function Get_RptMovDet(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                         ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String,
                                         ByVal c_codi_mon As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_Rpt_MovDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = c_codi_scd
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    ' Movimientos Detallados por SubCaidas '
    Public Function Get_RptMovTot(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, _
                                         ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String,
                                         ByVal c_codi_mon As String, ByVal Emp As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_Rpt_MovDetTotScd"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = Fecha_Inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = Fecha_Final
            cmd.Parameters.Add("@c_codi_tg", OleDbType.VarChar, 2).Value = c_codi_tg
            cmd.Parameters.Add("@c_codi_cd", OleDbType.VarChar, 2).Value = c_codi_cd
            cmd.Parameters.Add("@c_codi_scd", OleDbType.VarChar, 4).Value = c_codi_scd
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = c_codi_mon

            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)

            Conex.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Tabla
    End Function
    Public Function Get_IngCompLista_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_IngCompLista"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@Emp", OleDbType.VarChar, 1000).Value = Emp

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

Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_RptKardexIQ
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Get_KardexIQ_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_KardexIQ"

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
    Public Function scal_ActualizarKdx_SAVE(ByVal c_fecha_ing As Date, ByVal c_codi_alm As String, ByVal c_codi_articulo As String) As String
        cmd.Connection = Conex
        cmd.CommandTimeout = 6000
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_Scal_upt_KdxAlmIng_PRUEBAS"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_ing", OleDbType.Date).Value = c_fecha_ing
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo

            'ejecutamos query
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
    End Function
    Public Function scal_KdxValorEspecial_rpt(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_alm As String,
                                               ByVal c_codi_articulo As String, ByVal cOpcion As String) As String
        cmd.Connection = Conex
        cmd.CommandTimeout = 6000
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_Scal_upt_KdxAlmSunatValorEspecial"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_final
            cmd.Parameters.Add("@c_codi_alm", OleDbType.VarChar, 2).Value = c_codi_alm
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = c_codi_articulo
            cmd.Parameters.Add("@cOpcion", OleDbType.VarChar, 3).Value = cOpcion

            'ejecutamos query
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
    End Function
End Class

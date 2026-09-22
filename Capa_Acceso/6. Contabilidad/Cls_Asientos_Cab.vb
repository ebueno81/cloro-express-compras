Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_Asientos_Cab
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function get_AsientosCab_Datos(ByVal c_codi_doc As String, ByVal c_Fecha_Inicio As Date, ByVal c_Fecha_Final As Date) As DataTable
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_ConcarCab"
        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = c_codi_doc
            cmd.Parameters.Add("@c_fecha_inicio", OleDbType.Date).Value = c_fecha_inicio
            cmd.Parameters.Add("@c_fecha_final", OleDbType.Date).Value = c_fecha_final
            aD = New OleDbDataAdapter(cmd)
            Tabla = New DataTable
            aD.Fill(Tabla)
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
        Return Tabla
    End Function

    Public Function Sca_AsientosCab_Save(ByVal n_factura As String, ByVal Ccompro As String, ByVal c_codi_doc As String)
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_Asiento_Cab"
        'Definimos variable de salida

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 15).Value = n_factura
            cmd.Parameters.Add("@Ccompro", OleDbType.VarChar, 6).Value = Ccompro
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 6).Value = c_codi_doc

            'ejecutamos query
            cmd.ExecuteNonQuery()
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...

    End Function
End Class

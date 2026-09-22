Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_DetracDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_Detrac_SAVE(ByVal ent As Ent_DetracDet) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_DetracDet"
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_año_lote", OleDbType.VarChar, 4).Value = ent.c_año_lote
            cmd.Parameters.Add("@c_nro_lote", OleDbType.VarChar, 4).Value = ent.c_nro_lote
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_monto_mn", OleDbType.Numeric, 10, 2).Value = ent.c_monto_mn
            cmd.Parameters.Add("@c_monto_us", OleDbType.Numeric, 10, 2).Value = ent.c_monto_us
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_detracc_mn", OleDbType.Numeric, 10, 2).Value = ent.c_detracc_mn
            cmd.Parameters.Add("@c_detracc_us", OleDbType.Numeric, 10, 2).Value = ent.c_detracc_us
            cmd.Parameters.Add("@c_fecha_cancel", OleDbType.Date).Value = ent.c_fecha_cancel
            cmd.Parameters.Add("@c_nro_constancia", OleDbType.VarChar, 20).Value = ent.c_nro_constancia

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            'eviamos el codigo autogenerado...
            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
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
    Public Function scom_DetracCancel_SAVE(ByVal ent As Ent_DetracCancel) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_upt_DetracCancel"
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_año_lote", OleDbType.VarChar, 4).Value = ent.c_año_lote
            cmd.Parameters.Add("@c_nro_lote", OleDbType.VarChar, 4).Value = ent.c_nro_lote
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_fecha_detracc", OleDbType.VarChar, 20).Value = ent.c_fecha_cancel
            cmd.Parameters.Add("@c_nro_constancia", OleDbType.VarChar, 20).Value = ent.c_nro_constancia
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'ejecutamos query
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try 'retorna el valor para enlazarlo a la caja de texto...
    End Function
    Public Function Get_DetracDet_Datos(ByVal Cadena As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_DetracDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena

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

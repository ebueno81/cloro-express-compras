Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_LetDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_LetDet_SAVE(ByVal ent As Ent_LetDet, ByVal Emp As String) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_fa_upt_LetDet"
        'Definimos variable de salida
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_letra", OleDbType.VarChar, 9).Value = ent.c_nro_letra
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 9).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_monto_doc", OleDbType.Numeric, 15, 2).Value = ent.c_monto_doc
            cmd.Parameters.Add("@c_id_letra", OleDbType.Integer).Value = ent.c_id_letra
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 9).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_fecha_giro", OleDbType.Date).Value = ent.c_fecha_giro
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio

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
    Public Function Get_LetDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_LetDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = vOpt
            cmd.Parameters.Add("@emp", OleDbType.VarChar, 2).Value = Emp

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

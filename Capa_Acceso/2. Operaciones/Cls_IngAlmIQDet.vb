Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_IngAlmIQDet
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function set_AlmIngDet_Save(ByVal ent As Ent_IngAlmIQDet, ByVal Emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_upt_IngAlmDet"
        cmd.CommandTimeout = 6000
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_codi_ing", OleDbType.VarChar, 7).Value = ent.c_codi_ing
            cmd.Parameters.Add("@c_sist_bahia", OleDbType.Integer).Value = ent.c_sist_bahia
            cmd.Parameters.Add("@c_nro_lote", OleDbType.VarChar, 10).Value = ent.c_nro_lote
            cmd.Parameters.Add("@c_codi_articulo", OleDbType.VarChar, 10).Value = ent.c_codi_articulo
            cmd.Parameters.Add("@c_nro_cant", OleDbType.Decimal, 16, 6).Value = ent.c_nro_cant
            cmd.Parameters.Add("@c_cant_caja", OleDbType.Decimal, 10, 2).Value = ent.c_cant_caja
            cmd.Parameters.Add("@c_codi_unimed", OleDbType.VarChar, 3).Value = ent.c_codi_unimed
            cmd.Parameters.Add("@c_prec_unit", OleDbType.Decimal, 12, 6).Value = ent.c_prec_unit
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_opt_igv", OleDbType.Integer).Value = ent.c_opt_igv
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_correl_sal", OleDbType.VarChar, 8).Value = ent.c_correl_sal

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion

            Codi_Auto = cmd.Parameters.Add("@c_codiauto", OleDbType.VarChar, 8)
            Codi_Auto.Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Codigo = Codi_Auto.Value.ToString
            Conex.Close()

        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
        Return Codigo
    End Function
    Public Function Get_IngAlmDet_DATOS(ByVal Cadena As String, ByVal Emp As String, ByVal vOpt As String) As DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Datos_IngAlmDet"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
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
    
End Class

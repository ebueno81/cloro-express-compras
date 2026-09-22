Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_MnSeries
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function Scom_Series_Save(ByVal Ent As Ent_SeriesDoc, ByVal Emp As String) As Boolean
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_" & Emp & "_upt_Series"

        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = Ent.c_codi_doc
            cmd.Parameters.Add("@c_nro_serie", OleDbType.VarChar, 3).Value = Ent.c_nro_serie
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = Ent.c_nro_doc
            cmd.Parameters.Add("@c_desc_serie", OleDbType.VarChar, 100).Value = Ent.c_desc_serie
            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = Ent.copcion
            'Ejecutamos query
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            Conex.Close()
        Catch ex As Exception
            MsgBox("01. " & ex.Message)
        End Try
    End Function
    Public Function Get_Series_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_Series"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 500).Value = Cadena
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
    'Cargar Lineas en el Combo
    Public Function Get_Cargar_Series_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox, ByVal Emp As String)
        Combo1.Items.Clear()
        Combo1.DataSource = Get_Series_Datos(Cadena, "DAT", Emp)
        Combo1.DisplayMember = "c_nro_serie"
        Combo1.ValueMember = "c_nro_serie"
        Combo1.SelectedIndex = -1
    End Function
End Class

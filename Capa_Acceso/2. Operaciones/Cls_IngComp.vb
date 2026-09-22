Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Cls_IngComp
    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand
    Public Function scom_IngComp_SAVE(ByVal ent As Ent_IngComp, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Fa_upt_IngComp"
        'Definimos variable de salida
        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_codi_mon", OleDbType.VarChar, 2).Value = ent.c_codi_mon
            cmd.Parameters.Add("@c_codi_doc", OleDbType.VarChar, 2).Value = ent.c_codi_doc
            cmd.Parameters.Add("@c_serie_doc", OleDbType.VarChar, 5).Value = ent.c_serie_doc
            cmd.Parameters.Add("@c_nro_doc", OleDbType.VarChar, 7).Value = ent.c_nro_doc
            cmd.Parameters.Add("@c_nro_maq", OleDbType.VarChar, 15).Value = ent.c_nro_maq

            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
            cmd.Parameters.Add("@c_fecha_prd", OleDbType.Date).Value = ent.c_fecha_prd
            cmd.Parameters.Add("@c_fecha_venci", OleDbType.Date).Value = ent.c_fecha_venci
            cmd.Parameters.Add("@c_nro_dias", OleDbType.Integer).Value = ent.c_nro_dias
            cmd.Parameters.Add("@c_codi_prov", OleDbType.VarChar, 5).Value = ent.c_codi_prov
            cmd.Parameters.Add("@c_codi_pago", OleDbType.VarChar, 2).Value = ent.c_codi_pago
            cmd.Parameters.Add("@c_usuario", OleDbType.VarChar, 10).Value = ent.c_usuario
            cmd.Parameters.Add("@c_obs", OleDbType.VarChar, 300).Value = ent.c_obs
            cmd.Parameters.Add("@c_tpo_cambio", OleDbType.Numeric, 10, 3).Value = ent.c_tpo_cambio
            cmd.Parameters.Add("@c_cant_igv", OleDbType.Numeric, 10, 2).Value = ent.c_cant_igv
            cmd.Parameters.Add("@c_imp_inaf", OleDbType.Numeric, 10, 2).Value = ent.c_imp_inaf
            cmd.Parameters.Add("@c_imp_igv", OleDbType.Numeric, 10, 2).Value = ent.c_imp_igv
            cmd.Parameters.Add("@c_imp_afecto", OleDbType.Numeric, 10, 2).Value = ent.c_imp_afecto
            cmd.Parameters.Add("@c_imp_total", OleDbType.Numeric, 10, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_mt_anula", OleDbType.VarChar, 300).Value = ent.c_mt_anula

            cmd.Parameters.Add("@c_opc_detracc", OleDbType.Integer).Value = ent.c_opc_detracc
            cmd.Parameters.Add("@c_codi_detracc", OleDbType.VarChar, 3).Value = ent.c_codi_detracc
            cmd.Parameters.Add("@c_porc_detracc", OleDbType.Decimal, 10, 2).Value = ent.c_porc_detracc
            cmd.Parameters.Add("@c_imp_detracc", OleDbType.Decimal, 10, 2).Value = ent.c_imp_detracc
            cmd.Parameters.Add("@c_opc_reten", OleDbType.Integer).Value = ent.c_opc_reten
            cmd.Parameters.Add("@c_porc_reten", OleDbType.Decimal, 10, 2).Value = ent.c_porc_reten
            cmd.Parameters.Add("@c_base_reten", OleDbType.Decimal, 10, 2).Value = ent.c_base_reten
            cmd.Parameters.Add("@c_imp_reten", OleDbType.Decimal, 10, 2).Value = ent.c_imp_reten
            cmd.Parameters.Add("@c_nro_leasing", OleDbType.VarChar, 15).Value = ent.c_nro_leasing
            cmd.Parameters.Add("@c_nro_cuota", OleDbType.Integer).Value = ent.c_nro_cuota
            cmd.Parameters.Add("@c_correl_leasing", OleDbType.VarChar, 8).Value = ent.c_correl_leasing
            cmd.Parameters.Add("@c_opc_apertura", OleDbType.Integer).Value = ent.c_opc_apertura
            cmd.Parameters.Add("@c_opc_importacion", OleDbType.Integer).Value = ent.c_opc_importacion

            cmd.Parameters.Add("@copcion", OleDbType.VarChar, 3).Value = ent.copcion
            'eviamos el codigo autogenerado...
            Codi_Auto = cmd.Parameters.Add("@c_codi_auto", OleDbType.VarChar, 7)
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
    Public Function scom_IngCompOC_SAVE(ByVal ent As Ent_IngCompOC, ByVal c_codi_emp As String) As String
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Fa_upt_IngCompOC"

        Dim Codi_Auto As OleDbParameter
        Dim Codigo As String = ""
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@c_nro_correl", OleDbType.VarChar, 8).Value = ent.c_nro_correl
            cmd.Parameters.Add("@c_nro_ing", OleDbType.VarChar, 7).Value = ent.c_nro_ing
            cmd.Parameters.Add("@c_serie_oc", OleDbType.VarChar, 5).Value = ent.c_serie_oc
            cmd.Parameters.Add("@c_nro_oc", OleDbType.VarChar, 8).Value = ent.c_nro_oc
            cmd.Parameters.Add("@c_tpo_doc", OleDbType.VarChar, 2).Value = ent.c_tpo_doc
            cmd.Parameters.Add("@c_codi_ing", OleDbType.VarChar, 7).Value = ent.c_codi_ing
            cmd.Parameters.Add("@c_imp_total", OleDbType.Decimal, 12, 2).Value = ent.c_imp_total
            cmd.Parameters.Add("@c_fecha_emi", OleDbType.Date).Value = ent.c_fecha_emi
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
    Public Function Get_IngComp_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_IngComp"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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
    Public Function Get_IngCompOC_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_IngCompOC"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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
    ' ingreso de Comprobantes de Pago '
    Public Function Get_IngCompPagos_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        'Sven_Articulo_Dgv
        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scom_Datos_IngCompPagos"

        Dim Tabla As New DataTable
        Dim aD As New OleDbDataAdapter
        Try
            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Cadena", OleDbType.VarChar, 1000).Value = Cadena
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
    Public Function Get_Cargar_HistorialCancelacion_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Combo1.DataSource = Nothing
        Combo1.Items.Clear()
        Combo1.DataSource = Get_IngCompPagos_Datos(Cadena, "LEC", "")
        Combo1.DisplayMember = "Voucher"
        Combo1.ValueMember = "Voucher"
        Combo1.SelectedIndex = -1
    End Function
End Class

Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Capa_Negocios
Module Module1
    Public Forma_1_1 As String = "##0.0"
    Public Forma_1_2 As String = "##0.00"
    Public Forma_1_3 As String = "##0.000"
    Public Forma_1_4 As String = "##0.0000"
    Public Forma_1_5 As String = "##0.00000"
    Public Forma_1_6 As String = "##0.000000"

    Public Forma_2_1 As String = "#,##0.0"
    Public Forma_2_2 As String = "#,##0.00"
    Public Forma_2_3 As String = "#,##0.000"
    Public Forma_2_4 As String = "#,##0.0000"

    Public c_Neg_FecCierres As New Neg_Cierres
    Public Compañia As String = "Sistema Administrativo - SysComprAS 3.0"

    Public Sub Limpiar_Texto(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.text = ""
        Next
    End Sub
    'metodo que nos permite avanzar al dar enter
    Public Sub Avanzar_Enter(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Dim control As Object
        'For Each control In obj.controls
        'If TypeOf Control Is TextBox Then
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    'Metodo que nos permite activar las cajas de textos
    Public Sub Activar(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.enabled = True
        Next
    End Sub
    'Metodo que nos permite desactivar las cajas de textos
    Public Sub Desactivar(ByVal pana As Object)
        Dim control As Object
        For Each control In pana.controls
            If TypeOf control Is TextBox Then control.enabled = False
        Next
    End Sub
    Public Sub solonumeros(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789,-,." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    'Validamos fecha de cierres...
    Public Sub Validar_Fecha_Cierre(ByVal x As TextBox, ByVal Fecha As Date)
        If Fecha >= "01/01/2013" Then
            With c_Neg_FecCierres.get_Cierres_Datos(" and month(c_fecha_prd)=" & Month(Fecha) & " and year(c_fecha_prd)=" & Year(Fecha) & " and c_anula_reg=0 and c_estado_prd=1")
                If .Rows.Count > 0 Then
                    x.Text = 1
                Else
                    x.Text = 0
                End If
            End With
        Else
            x.Text = 1
        End If
    End Sub
    'Metodo que nos permite movilizarnos en un datagrid desde una caja de texto por medio de las teclas direccionales...
    Public Sub Movilizar_Grid(ByVal Dgv As DataGridView, ByVal x As Integer, ByVal Tipo_Avance As String)
        With Dgv
            On Error Resume Next
            If Tipo_Avance = "ABAJO" Then
                If Not .CurrentCell.RowIndex + 1 = .NewRowIndex Then
                    .Rows(x).Selected = True
                    .CurrentCell = Dgv(.CurrentCell.ColumnIndex, x)
                End If
            End If
            If Tipo_Avance = "ARRIBA" Then
                If Not .CurrentCell.RowIndex - 1 = -1 Then
                    .Rows(x).Selected = True
                    .CurrentCell = Dgv(.CurrentCell.ColumnIndex, x)
                End If
            End If
        End With
    End Sub
    Public Sub Movilizar_Registros(ByVal Dgv As DataGridView, ByVal TxtReg As TextBox, ByVal TxtTpo As Integer)
        With Dgv
            Dim Fila As Integer = 0
            If .RowCount > 0 Then
                If TxtTpo = 1 Then
                    Fila = 0
                End If 'Atras
                If TxtTpo = 2 Then
                    Fila = .CurrentCellAddress.Y
                    If Fila > 0 Then Fila = Fila - 1
                End If 'Avanza
                If TxtTpo = 3 Then
                    Fila = .CurrentCellAddress.Y
                    If Fila < .RowCount - 1 Then Fila = Fila + 1
                End If 'Final
                If TxtTpo = 4 Then
                    Fila = .RowCount - 1
                End If
                For i = 0 To .RowCount - 1
                    .Rows(i).Selected = False
                Next 'Inicio
                .Rows(Fila).Selected = True : .CurrentCell = Dgv(.CurrentCell.ColumnIndex, Fila)
                TxtReg.Text = Fila + 1 & " / " & .RowCount
            End If
        End With
    End Sub
    'Metodo que nos permite validar la numeracion de comprobantes de pago...
    Public Sub Concar_Numeracion(ByVal Tabla As String, ByVal Dsubdia As String, ByVal Fecha As String, ByVal Ruta_concar As String, ByVal TxtCorrel As TextBox)
        Dim x As Integer = 0
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Ruta_concar & " Extended Properties=dBASE IV;")
        Dim sql As String = ""
        conn.Open()
        Dim Sdata As New OleDbDataAdapter("select*from Cnu" & Tabla & " Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'", conn)
        Dim Dts As New DataSet
        Sdata.Fill(Dts, "Existe_Num")
        With Dts.Tables("Existe_Num")
            If .Rows.Count > 0 Then
                sql = "update Cnu" & Tabla & " set Ctnumer=Ctnumer+1 Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'"
            Else
                sql = "insert into Cnu" & Tabla & "(Ctsubdia,Ctano,Ctmes,Ctnumer,Ctfeccre,Ctfecact) values('" & Dsubdia & "','" & Strings.Left(Fecha, 2) & "','" & _
                Strings.Mid(Fecha, 3, 2) & "',1,'" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "')"
            End If
        End With
        Dim cmd As New OleDbCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Dim data As New OleDbDataAdapter("select*from Cnu" & Tabla & " Where Ctsubdia='" & Dsubdia & "' and Ctano='" & Strings.Left(Fecha, 2) & "' and Ctmes='" & Strings.Mid(Fecha, 3, 2) & "'", conn)
        data.Fill(Dts, "Correl")
        With Dts.Tables("Correl")
            TxtCorrel.Clear()
            If .Rows.Count > 0 Then TxtCorrel.Text = Mid(Fecha, 3, 2) & Strings.Right(Val(.Rows(0)("Ctnumer").ToString) + 10000, 4)
        End With
        conn.Dispose() : cmd.Dispose() : Sdata.Dispose() : data.Dispose()
    End Sub
    'Metodo que nos Permite Buscar si un archivo esta registrado...
    Public Sub Buscar_Valor_Tablas_Concar(ByVal sql As String, ByVal x As TextBox, ByVal ruta_concar As String)
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ruta_concar & " Extended Properties=dBASE IV;")
        'Dim sql As String = "SELECT * FROM CCC0210.dbf"
        Dim Adt As New OleDb.OleDbDataAdapter(sql, conn)
        Dim dts As New DataSet
        Adt.Fill(dts, "Tabla")
        With dts.Tables("Tabla")
            'Validamos si existe el valor ingresado
            x.Clear()
            If .Rows.Count > 0 Then 'si existe
                x.Text = 1
            Else 'No existe  
                x.Text = 0
            End If
        End With 'eliminamos variables...
        conn.Dispose() : Adt.Dispose() : dts.Dispose()
    End Sub
    ' Metodo que nos permite cambiar de color a los registros anulados '
    Public Sub Grid_Registros_anulados(ByVal Dgv01 As DataGridView)
        With Dgv01
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub
    Public Function fEncripta_Key(ByVal cKey As String, ByVal lKey As Boolean) As String
        Dim nLen As Integer
        Dim R As Integer
        Dim cOld, cNew, cPas As String
        nLen = Len(cKey)
        For R = 1 To Len(cKey)
            cNew = Chr(Asc(Mid(cKey, R, 1)) + IIf(lKey, nLen, nLen * -1))
            cPas = cPas + cNew
        Next R
        fEncripta_Key = cPas
    End Function
    'Metodo que nos permite validar los permisos por usuarios...
    Public Sub Validar_Permiso(ByVal Name_Form As String, ByVal BtnNuevo As Button, ByVal BtnEditar As Button, ByVal BtnEliminar As Button)
        With FrmMenu.Dgv01
            For i = 0 To .RowCount - 1
                If UCase(.Rows(i).Cells("c_nom_formu").Value.ToString) = UCase(Name_Form) Then
                    If Val(.Rows(i).Cells("c_add_obj").Value) = 0 Then BtnNuevo.Enabled = False
                    If Val(.Rows(i).Cells("c_edit_obj").Value) = 0 Then BtnEditar.Enabled = False
                    If Val(.Rows(i).Cells("c_del_obj").Value) = 0 Then BtnEliminar.Enabled = False
                    i = .RowCount
                End If
            Next
        End With

    End Sub
    Function GridAExcel_Valor(ByVal elgrid As DataGridView, ByVal Exportar As Integer, ByVal Pan As Panel, _
                             ByVal Prb01 As ProgressBar, ByVal Ruta_Archivo As String) As Boolean
        Dim Preguntar As String = ""
        If Exportar = 0 Then 'enviar a excel
            Preguntar = "¿Desea Enviar los Datos a Excel?"
        Else 'exportar a excel
            Preguntar = "¿Desea Exportar los Datos a Excel?"
        End If
        Dim F As String = MsgBox(" " & Preguntar & " ", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            Dim y As Integer = 0

            Dim exapp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            With elgrid
                Try
                    Pan.Visible = True
                    Prb01.Visible = True : Prb01.Value = 0
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exapp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Add()

                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = .Columns.Count
                    Dim NRow As Integer = .Rows.Count
                    'mostramos encabezado

                    'aplicamos tamaño y negrita

                    For I = 1 To NCol
                        'ponemos lineas para el titulo
                        exHoja.Cells(1, I).Borders(8).LineStyle = 1 'BOTTOM
                        exHoja.Cells(1, I).Borders(9).LineStyle = 1 'TOP

                        'ponemos lineas para las cabeceras
                        exHoja.Cells(1, I).Borders(8).LineStyle = 1 'BOTTOM
                        exHoja.Cells(1, I).Borders(9).LineStyle = 1 'TOP
                        exHoja.Cells.Item(1, I) = .Columns(I - 1).HeaderText
                        exHoja.Cells.Item(1, I).Font.Bold = True
                    Next
                    'APLICAMOS EL VALOR MAXIMO
                    Prb01.Maximum = NRow
                    .ClearSelection()
                    For Fila As Integer = 0 To NRow - 1
                        'exportamos detalles del listview...
                        For Col = 1 To NCol
                            exHoja.Cells(Fila + 1, Col).Font.Bold = False
                            exHoja.Cells(Fila + 1, Col).Font.Colorindex = 1
                            'validamos el campo fecha para mostrarlo en formato corto
                            exHoja.Cells.Item(Fila + 2, Col) = .Rows(Fila).Cells(Col - 1).Value
                        Next
                        'ponemos en negrita
                        'For I = 7 To 11
                        'exHoja.Cells.Item(fila + 5, I).Font.Bold = True

                        'Next
                        .CurrentCell = .Rows(Fila).Cells(0)
                        Prb01.Value = Fila
                        'exHoja.Cells(Fila + 2, NCol).Borders(8).LineStyle = 1 'BOTTOM
                    Next
                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    'ajuste al texto
                    exHoja.Columns.AutoFit()
                    'ajustamos columnas
                    exHoja.Cells.Select()
                    exHoja.Range("A1:Z1").Font.Bold = True

                    If Exportar = 0 Then
                        exapp.Application.Visible = True
                        MsgBox("Los datos se enviaron a Excel correctamente", MsgBoxStyle.Information)
                    Else
                        exapp.Application.Visible = False
                        exLibro.SaveAs(Ruta_Archivo)
                        exLibro.Close() : exapp.Quit()
                        MsgBox("Archivo se exporto correctamente...", vbExclamation, Compañia)
                    End If
                    .ClearSelection()
                    .CurrentCell = .Rows(0).Cells(0)
                    exHoja = Nothing
                    exLibro = Nothing
                    exapp = Nothing
                    Prb01.Visible = False : Pan.Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                    Return False
                    Prb01.Visible = False
                End Try

                Return True
            End With
        End If

    End Function
    Public Function num2text(ByVal value As Double) As String
        Select Case value
            Case 0 : num2text = "CERO"
            Case 1 : num2text = "UN"
            Case 2 : num2text = "DOS"
            Case 3 : num2text = "TRES"
            Case 4 : num2text = "CUATRO"
            Case 5 : num2text = "CINCO"
            Case 6 : num2text = "SEIS"
            Case 7 : num2text = "SIETE"
            Case 8 : num2text = "OCHO"
            Case 9 : num2text = "NUEVE"
            Case 10 : num2text = "DIEZ"
            Case 11 : num2text = "ONCE"
            Case 12 : num2text = "DOCE"
            Case 13 : num2text = "TRECE"
            Case 14 : num2text = "CATORCE"
            Case 15 : num2text = "QUINCE"
            Case Is < 20 : num2text = "DIECI" & num2text(value - 10)
            Case 20 : num2text = "VEINTE"
            Case Is < 30 : num2text = "VEINTI" & num2text(value - 20)
            Case 30 : num2text = "TREINTA"
            Case 40 : num2text = "CUARENTA"
            Case 50 : num2text = "CINCUENTA"
            Case 60 : num2text = "SESENTA"
            Case 70 : num2text = "SETENTA"
            Case 80 : num2text = "OCHENTA"
            Case 90 : num2text = "NOVENTA"
            Case Is < 100 : num2text = num2text(Int(value \ 10) * 10) & " Y " & num2text(value Mod 10)
            Case 100 : num2text = "CIEN"
            Case Is < 200 : num2text = "CIENTO " & num2text(value - 100)
            Case 200, 300, 400, 600, 800 : num2text = num2text(Int(value \ 100)) & "CIENTOS"
            Case 500 : num2text = "QUINIENTOS"
            Case 700 : num2text = "SETECIENTOS"
            Case 900 : num2text = "NOVECIENTOS"
            Case Is < 1000 : num2text = num2text(Int(value \ 100) * 100) & " " & num2text(value Mod 100)
            Case 1000 : num2text = "MIL"
            Case Is < 2000 : num2text = "MIL " & num2text(value Mod 1000)
            Case Is < 1000000 : num2text = num2text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then num2text = num2text & " " & num2text(value Mod 1000)
            Case 1000000 : num2text = "UN MILLON"
            Case Is < 2000000 : num2text = "UN MILLON " & num2text(value Mod 1000000)
            Case Is < 1000000000000.0# : num2text = num2text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then num2text = num2text & " " & num2text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : num2text = "UN BILLON"
            Case Is < 2000000000000.0# : num2text = "UN BILLON " & num2text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : num2text = num2text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then num2text = num2text & " " & num2text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function
    ' Generar Archivo de Retenciones '
    Public Sub Generar_TXT(ByVal Cadena As String, ByVal Nombre_Archivo As String)
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        Dim i As Integer

        Try

            If Directory.Exists("D:\Retenciones") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("D:\Retenciones")
            End If

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = "D:\Retenciones\" & Nombre_Archivo & ".TXT" ' Se determina el nombre del archivo con la fecha actual
            If File.Exists(PathArchivo) = True Then
                My.Computer.FileSystem.DeleteFile(PathArchivo)
            End If
            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            With c_Neg_RetenDet.get_RetenDet_Datos(Cadena, "TXT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Dim Ruc, Empresa, Ape_Pat, Ape_Mat, Nombres, Serie_Reten, Nro_Reten, Tpo_Doc, Serie_Doc, Nro_Doc, Linea As String
                        Dim Fecha_Reten, Fecha_doc As Date : Dim Total_Reten, Total_Doc As Decimal
                        Ruc = Strings.Left(.Rows(i)("c_ruc_prov").ToString, 40)
                        Empresa = .Rows(i)("c_desc_prov").ToString
                        Ape_Pat = ""
                        Ape_Mat = ""
                        Nombres = ""
                        Serie_Reten = .Rows(i)("c_nro_serie").ToString
                        Nro_Reten = .Rows(i)("c_nro_reten").ToString
                        Tpo_Doc = .Rows(i)("c_codi_doc").ToString
                        Serie_Doc = .Rows(i)("c_serie_doc").ToString
                        Nro_Doc = .Rows(i)("c_nro_doc").ToString
                        Fecha_Reten = FormatDateTime(.Rows(i)("c_fecha_emi").ToString, DateFormat.ShortDate)
                        Fecha_doc = FormatDateTime(.Rows(i)("c_fecha_doc").ToString, DateFormat.ShortDate)
                        Total_Reten = Format(Val(.Rows(i)("c_imp_reten").ToString), Forma_1_2)
                        Total_Doc = Format(Val(.Rows(i)("c_imp_doc").ToString), Forma_1_2)
                        Linea = Ruc & "|" & Empresa & "|" & Ape_Pat & "|" & Ape_Mat & "|" & Nombres & "|" & Serie_Reten & "|" & Nro_Reten & _
                            "|" & Fecha_Reten & "|" & Total_Reten & "|" & Tpo_Doc & "|" & Serie_Doc & "|" & Nro_Doc & "|" & Fecha_Reten & "|" & Fecha_doc & "|" & Total_Doc
                        strStreamWriter.WriteLine(Linea)
                    Next
                End If
            End With


            'escribimos en el archivo


            strStreamWriter.Close() ' cerramos
            MsgBox(" Registro se creo correctamente en: " & PathArchivo)
        Catch ex As Exception
            MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
    End Sub
    'Metodo que nos permite jalar el codigo de un combo que se encuentre amarrado al combo
    Public Sub Combo_Jalar_Codigo(ByVal combo As ComboBox, ByVal Caja As TextBox)
        If combo.SelectedIndex > -1 Then
            On Error Resume Next : Caja.Text = combo.SelectedValue
        End If
    End Sub
    ' Cargamos datos de la base de datos
    Public Sub Cargar_Datos_BD()
        Dim fic As String = My.Application.Info.DirectoryPath & "\config.ini"
        Dim texto As String = ""
        Dim objReader As New StreamReader(fic)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        'Leemos Archivos
        Dim x As Integer = 0 : Dim Servidor, DbProcesos, Usuario, Password, Timeout, Provider As String

        For Each sLine In arrText
            If x = 7 Then Servidor = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            If x = 8 Then DbProcesos = Trim(Mid(arrText.Item(x).ToString, 12, 30))
            If x = 9 Then Usuario = Trim(Mid(arrText.Item(x).ToString, 9, 30))
            If x = 10 Then Password = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            If x = 11 Then Timeout = Trim(Mid(arrText.Item(x).ToString, 9, 30))
            If x = 12 Then Provider = Trim(Mid(arrText.Item(x).ToString, 10, 30))
            x = x + 1
        Next
        FrmMenu.Text = "Sistema Administrativo de Compras - SysComprAS 3.0 - [\\" & Servidor & "\" & DbProcesos & "]"
    End Sub
    'Metodo que nos permite colorear registro anulado en un grid
    Public Sub Grid_Registro_Anulado(ByVal Dgv01 As DataGridView)
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next
            End If
        End With
    End Sub
    'Metodo que nos permite colorear registro anulado en un grid
    Public Sub Grid_Registro_Anulado2(ByVal Dgv01 As DataGridView)
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("c_anula_reg2").Value) = 1 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next
            End If
        End With
    End Sub
    'Metodo que nos permite colorear registro anulado en un grid
    Public Sub Grid_Registro_Campo_Anula(ByVal Dgv01 As DataGridView)
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("Anula").Value) = 1 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next
            End If
        End With
    End Sub
    ' Cargamos cuentas contables '
    Public Sub Mostrar_cuentas(ByVal Cadena As String, ByVal dgv01 As DataGridView)
        Dim conex As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtConcar_Ruta.Text & " Extended Properties=dBASE IV;")
        Dim sql As String = ""
        sql = "select Pcuenta,Pdescri,Pvanexo From " & FrmMenu.TxtConcar_Plan.Text & " where " & Cadena & "  "
        Dim data As New OleDbDataAdapter(sql, conex)
        Dim midataset As New DataSet
        data.Fill(midataset, "Cpl01")
        dgv01.DataSource = Nothing
        dgv01.DataSource = midataset.Tables("Cpl01")
        With dgv01
            .Columns("Pcuenta").Width = 55
            .Columns("Pdescri").Width = 270
            .Columns("Pvanexo").Width = 55
            ' Alineacion '
            .Columns("Pvanexo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Metodo para cargar areas para las caidas
    Public Sub Mostrar_Areas(ByVal Cadena As String, ByVal dgv01 As DataGridView)
        Dim conex As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtConcar_Ruta.Text & " Extended Properties=dBASE IV;")
        Dim sql As String = ""
        sql = "select Tclave, Tdescri From " & FrmMenu.TxtConcar_Areas.Text & "   Where len(Tclave)>2 and len(Tclave)<4 " & Cadena & "  "
        Dim data As New OleDbDataAdapter(sql, conex)
        Dim midataset As New DataSet
        data.Fill(midataset, "CTG03")
        dgv01.DataSource = Nothing
        dgv01.DataSource = midataset.Tables("CTG03")
        With dgv01
            .Columns("Tclave").Width = 55
            .Columns("Tdescri").Width = 310
            ' Alineacion '
            .Columns("Tclave").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Metodo para cargar centro de costos para las caidas
    Public Sub Mostrar_Costos(ByVal Cadena As String, ByVal dgv01 As DataGridView)
        Dim conex As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtConcar_Ruta.Text & " Extended Properties=dBASE IV;")
        Dim sql As String = ""
        sql = "select Tclave, Tdescri From " & FrmMenu.TxtConcar_Areas.Text & "   Where len(Tclave)=3  " & Cadena & "  "
        Dim data As New OleDbDataAdapter(sql, conex)
        Dim midataset As New DataSet
        data.Fill(midataset, "CTG03")
        dgv01.DataSource = Nothing
        dgv01.DataSource = midataset.Tables("CTG03")
        With dgv01
            .Columns("Tclave").Width = 55
            .Columns("Tdescri").Width = 310
            ' Alineacion '
            .Columns("Tclave").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    'Mostramos tipo de cambio..
    Public Sub Mostrar_TpoCambio(ByVal Fecha As Date, ByVal x As TextBox)
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and T.c_fecha_cbo='" & Fecha & "'", "DAT")
            If .Rows.Count > 0 Then
                x.Text = Format(Val(.Rows(0)("c_venta_sunat").ToString), Forma_1_3)
            End If
        End With
    End Sub
    ' metodo para validar las cuentas '
    Public Function Validar_Cuentas(ByVal dgv01 As DataGridView) As Boolean
        With c_Neg_Asientos_Det.get_AsientosDet_Datos(" And Len(Isnull(Dcuenta,''))=0 order by N_Factura")
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    For u = 0 To dgv01.RowCount - 1
                        If dgv01.Rows(u).Cells("N_Factura").Value = .Rows(0)("N_Factura").ToString Then
                            dgv01.Rows(u).Selected = True : dgv01.CurrentCell = dgv01(0, u)
                            MsgBox("Falta ingresar una cuenta Valida para el Voucher: " & Strings.Left(dgv01.Rows(u).Cells("N_Factura").Value, 3) & "-" & Strings.Right(dgv01.Rows(u).Cells("N_Factura").Value, 7), vbCritical, Compañia)
                            u = dgv01.RowCount + 1 : i = .Rows.Count : Validar_Cuentas = False
                        End If
                    Next
                Next
                Validar_Cuentas = True
            Else
                Validar_Cuentas = True
            End If
        End With
    End Function
    ' metodo para validar que cuadre el Debe con el Haber
    Public Function Validar_Montos(ByVal dgv01 As DataGridView) As Boolean
        Dim N_Factura As String = "" : Dim Dcodmon As String = "" : Dim Dif As Decimal = 0 : Dim DifTot As Decimal = 0
        With dgv01
            For i = 0 To .RowCount - 1
                N_Factura = .Rows(i).Cells("N_Factura").Value
                Dcodmon = .Rows(i).Cells("Ccodmon").Value
                With c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, 0, "DET")
                    If .Rows.Count > 0 Then
                        Dim Tot_01, Tot_Us_01, Tot_Mn_01, Tot_02, Tot_Us_02, Tot_Mn_02 As Decimal
                        Tot_01 = Val(.Rows(0)("Dimport").ToString)
                        Tot_Us_01 = Val(.Rows(0)("Dusimpor").ToString)
                        Tot_Mn_01 = Val(.Rows(0)("Dmnimpor").ToString)
                        Tot_02 = Val(.Rows(1)("Dimport").ToString)
                        Tot_Us_02 = Val(.Rows(1)("Dusimpor").ToString)
                        Tot_Mn_02 = Val(.Rows(1)("Dmnimpor").ToString)
                        If (Tot_01 - Tot_02) = 0 And (Tot_Mn_01 - Tot_Mn_02) = 0 And (Tot_Us_01 - Tot_Us_02) = 0 Then
                            Validar_Montos = True
                        Else
                            If Dcodmon = "US" Then
                                Dif = Tot_Mn_01 - Tot_Mn_02
                                If Dif < 1 Then
                                    c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(Dif), "AMN")
                                End If
                            Else
                                Dif = Tot_Us_01 - Tot_Us_02
                                If Dif < 1 Then
                                    c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(Dif), "AUS")
                                End If
                            End If
                            ' Importe '
                            DifTot = Tot_01 - Tot_02
                            If DifTot < 1 Then
                                c_Neg_Asientos_Det.get_AsientosDet_Valida(N_Factura, Math.Abs(DifTot), "DIF")
                            End If
                            Validar_Montos = True
                        End If
                    Else
                        MsgBox("Montos del Detalle no conciden...", vbCritical, Compañia)
                        Validar_Montos = True : i = dgv01.RowCount
                    End If
                End With
            Next
        End With
    End Function
    ' Metodo para validar fecha de cierre '
    Public Function ValidarCierre(ByVal Fecha As Date) As Boolean
        ' MsgBox("Fecha Actual " & Fecha & " Fecha de Cierre: " & FrmMenu.TxtFecha_Cierre.Text)
        Dim FechaCierre As Date
        With c_Neg_MnEmpresa.get_Empresa_Datos(" ", "CIE")
            If .Rows.Count > 0 Then
                FechaCierre = .Rows(0)("c_fecha_cierre").ToString
            Else
                MsgBox("No existe fecha de Cierre...", vbCritical, Compañia)
            End If
        End With
        If Fecha > FechaCierre Then
            ValidarCierre = True
        Else
            ValidarCierre = False
            MsgBox("No puede realizar ningún tipo de operacion con esta Fecha, esta dentro de la fecha de Cierre: " & FechaCierre, vbCritical, Compañia)
        End If
    End Function
    Public Function ValidarMotivo(ByVal c_codi_mt As String)
        With c_Neg_MnMtMov.get_MtMov_Datos(" and c_anula_Reg=0 and c_codi_mt ='" & c_codi_mt & "'", "DAT")
            If .Rows.Count > 0 Then
                ValidarMotivo = True
            Else
                ValidarMotivo = False
                MsgBox("1. El codigo de motivo ingresado es invalido, revisarlo", vbCritical, Compañia)
            End If
        End With
    End Function
    Public Sub MostrarProveDefecto(ByVal txtCodProv As TextBox, ByVal txtDescProv As TextBox)
        With c_Neg_MnEmpresa.get_Empresa_Datos(" ", "SCA")
            If .Rows.Count > 0 Then
                txtCodProv.Text = .Rows(0)("c_codi_prov").ToString
                With c_Neg_mnProve.get_Prove_Datos(" and c_codi_prov='" & txtCodProv.Text & "'", "DAT")
                    If .Rows.Count > 0 Then
                        txtDescProv.Text = .Rows(0)("c_desc_prov").ToString
                    End If
                End With
            End If
        End With
    End Sub
    Public Function MostrarIgv() As Decimal
        With c_Neg_Igv.get_Igv_Datos(" and c_anula_reg=0 order by c_fecha_emi desc", "DAT")
            If .Rows.Count > 0 Then
                Return Val(.Rows(0)("c_por_igv").ToString)
            Else
                Return 0
            End If
        End With
    End Function
    Public Function ValidarIGV(ByVal igv As Decimal) As Boolean
        With c_Neg_Igv.get_Igv_Datos(" and c_anula_reg=0 order by c_fecha_emi desc", "VAL")
            '    InputBox("", "", " and c_anula_reg=0 order by c_fecha_emi desc")
            If .Rows.Count > 0 Then
                '  MsgBox(Val(.Rows(0)("c_por_igv").ToString) & " " & Val(.Rows(0)("c_por_igv_2").ToString) & " " & Val(.Rows(0)("c_por_igv_3").ToString))
                'VALIDAMOS SI coincide con algun igv
                If Val(.Rows(0)("c_por_igv").ToString) = igv Or Val(.Rows(0)("c_por_igv_2").ToString) = igv Or Val(.Rows(0)("c_por_igv_3").ToString) = igv Then
                    Return True
                Else
                    MsgBox("1. IGV ingresado no es validao", vbCritical, Compañia)
                    Return False
                End If
            Else
                MsgBox("2. No existen IGV Validos para realizar esta operacion", vbCritical, Compañia)
                Return False
            End If
        End With
    End Function
End Module

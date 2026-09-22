Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class Cls_Conexion

    Public Function GetConexion_Sql() As String
        'Dim Conex As String = "Provider=sqloledb;Data Source=PC-PROGRAM;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"
        'Dim Conex As String = "Provider=sqloledb;Data Source=192.168.173.50;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"  
        'Dim Conex As String = "Provider=sqloledb;Data Source=201.230.227.1,1434;Initial Catalog=DBFastDye;User Id=sa;Password=ACEace11;"
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
        
        Dim Conex As String = "Provider=" & Provider & ";Data Source=" & Servidor & ";Initial Catalog=" & DbProcesos & ";User Id=" & fEncripta_Key(Usuario, False).ToString & _
        ";Password=" & fEncripta_Key(Password, False).ToString & ";Connect Timeout=" & Timeout
        'Dim Conex As String = texto
        If Conex Is String.Empty Then
            Return String.Empty
        Else
            Return Conex
        End If
    End Function
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
End Class

﻿Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Class MainWindow

    Dim conexion As New MySqlConnection("host=127.0.0.1; user=root; database=dbturnos")
    Dim consulta As String = String.Empty
    Dim comando As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla As New DataTable

    Private Sub win_mov_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles win_mov.MouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub btn_close_IsEnabledChanged(sender As Object, e As RoutedEventArgs) Handles btn_close.Selected
        Me.Close()
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Finalize()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        'Try
        '    conexion.Open()
        '    consulta = "SELECT docnom, tiket, clinica FROM usuarios, pacientes"
        '    comando = New MySqlCommand(consulta, conexion)
        '    adaptador = New MySqlDataAdapter(comando)
        '    adaptador.Fill(tabla)
        '    Listado_tikets.ItemsSource = tabla(0)
        'Catch ex As MySqlException
        '    MessageBox.Show(ex.Message)
        'Finally
        '    conexion.Close()
        'End Try
    End Sub
End Class

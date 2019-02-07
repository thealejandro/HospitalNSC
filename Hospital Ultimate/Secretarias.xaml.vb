﻿Imports System.Data
Imports MySql.Data.MySqlClient
Imports MaterialDesignThemes.Wpf
Imports System.ComponentModel
Imports System.Windows.Threading

Public Class Secretarias

    Dim formadecerrar As Integer = 0
    Dim WithEvents Ds As New DispatcherTimer
    Dim conexion As New MySqlConnection("server=192.168.1.90; user=TheAlejandRo; password=Tech.Code; database=dbturnos")
    Dim conexion1 As New MySqlConnection("server=192.168.1.90; user=TheAlejandRo; password=Tech.Code; database=dbturnos")
    Dim consulta As String = String.Empty
    Dim comando As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla As New DataTable
    Dim tiket As String = String.Empty

    Private Sub win_move_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles win_move.MouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub btn_menu_Click(sender As Object, e As RoutedEventArgs) Handles btn_menu.Click
        lat_menu.SelectedIndex = -1
    End Sub

    Private Sub config_pnlespera_Selected(sender As Object, e As RoutedEventArgs) Handles config_pnlespera.Selected
        btn_menu.IsChecked = False
        DoctoresActivos.IsEnabled = False
        DoctoresActivos.Visibility = Visibility.Collapsed
        FuncionesExtras.IsEnabled = True
        FuncionesExtras.Visibility = Visibility.Visible
        FuncionesExtras.Children.Clear()
        FuncionesExtras.Children.Add(New ScrConfig)
    End Sub

    Private Sub btn_close_Selected(sender As Object, e As RoutedEventArgs) Handles btn_close.Selected
        btn_menu.IsChecked = False
        Dim dlgclshw As New MessageClsDlg
        dlgclshw.Message.Text = "¿Quieres cerrar el programa?"
        DialogHost.Show(dlgclshw, "RootDialogClose")
    End Sub

    Private Sub cls_sesion_Selected(sender As Object, e As RoutedEventArgs) Handles cls_sesion.Selected
        btn_menu.IsChecked = False
        Dim login As New Login
        login.Show()
        formadecerrar = 1
        Ds.Stop()
        Me.Finalize()
        Me.Close()
    End Sub

    Private Sub pnl_espera_Selected(sender As Object, e As RoutedEventArgs) Handles pnl_espera.Selected
        btn_menu.IsChecked = False
        Dim panel As New Panel
        panel.Show()
    End Sub

    Private Sub Secretarias_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        formadecerrar = 0
        Ds.Interval = New TimeSpan(0, 0, 1)
        Ds.Start()
    End Sub

    Private Sub Secretarias_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        If formadecerrar = 1 Then
            e.Cancel = False
        Else
            Dim dlgclshw As New MessageClsDlg
            dlgclshw.Message.Text = "¿Quieres cerrar el programa?"
            DialogHost.Show(dlgclshw, "RootDialog")
        End If
    End Sub

    Private Sub generador_ticket_Selected(sender As Object, e As RoutedEventArgs) Handles generador_ticket.Selected
        btn_menu.IsChecked = False
        DoctoresActivos.IsEnabled = True
        DoctoresActivos.Visibility = Visibility.Visible
        FuncionesExtras.IsEnabled = False
        FuncionesExtras.Visibility = Visibility.Collapsed
    End Sub

    Private Sub ActiveDR()
        Try
            conexion1.Open()
            consulta = "SELECT idusuario, estado FROM usuarios WHERE tipo_usuario='Doctor'"
            comando = New MySqlCommand(consulta, conexion1)
            adaptador = New MySqlDataAdapter(comando)
            Dim tabl As New DataTable
            tabl.Clear()
            adaptador.Fill(tabl)
            If tabl.Rows.Count = 1 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                Doc2.IsEnabled = False
                Doc3.IsEnabled = False
                Doc4.IsEnabled = False
                Doc5.IsEnabled = False
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 2 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                Doc3.IsEnabled = False
                Doc4.IsEnabled = False
                Doc5.IsEnabled = False
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 3 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                Doc4.IsEnabled = False
                Doc5.IsEnabled = False
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 4 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                Doc5.IsEnabled = False
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 5 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 6 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                If tabl.Rows(5)(1).ToString = "1" Then
                    Doc6.IsEnabled = True
                ElseIf tabl.Rows(5)(1).ToString = "0" Then
                    Doc6.IsEnabled = False
                End If
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 7 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                If tabl.Rows(5)(1).ToString = "1" Then
                    Doc6.IsEnabled = True
                ElseIf tabl.Rows(5)(1).ToString = "0" Then
                    Doc6.IsEnabled = False
                End If
                If tabl.Rows(6)(1).ToString = "1" Then
                    Doc7.IsEnabled = True
                ElseIf tabl.Rows(6)(1).ToString = "0" Then
                    Doc7.IsEnabled = False
                End If
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 8 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                If tabl.Rows(5)(1).ToString = "1" Then
                    Doc6.IsEnabled = True
                ElseIf tabl.Rows(5)(1).ToString = "0" Then
                    Doc6.IsEnabled = False
                End If
                If tabl.Rows(6)(1).ToString = "1" Then
                    Doc7.IsEnabled = True
                ElseIf tabl.Rows(6)(1).ToString = "0" Then
                    Doc7.IsEnabled = False
                End If
                If tabl.Rows(7)(1).ToString = "1" Then
                    Doc8.IsEnabled = True
                ElseIf tabl.Rows(7)(1).ToString = "0" Then
                    Doc8.IsEnabled = False
                End If
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 9 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                If tabl.Rows(5)(1).ToString = "1" Then
                    Doc6.IsEnabled = True
                ElseIf tabl.Rows(5)(1).ToString = "0" Then
                    Doc6.IsEnabled = False
                End If
                If tabl.Rows(6)(1).ToString = "1" Then
                    Doc7.IsEnabled = True
                ElseIf tabl.Rows(6)(1).ToString = "0" Then
                    Doc7.IsEnabled = False
                End If
                If tabl.Rows(7)(1).ToString = "1" Then
                    Doc8.IsEnabled = True
                ElseIf tabl.Rows(7)(1).ToString = "0" Then
                    Doc8.IsEnabled = False
                End If
                If tabl.Rows(8)(1).ToString = "1" Then
                    Doc9.IsEnabled = True
                ElseIf tabl.Rows(8)(1).ToString = "0" Then
                    Doc9.IsEnabled = False
                End If
                Doc10.IsEnabled = False
            ElseIf tabl.Rows.Count = 10 Then
                If tabl.Rows(0)(1).ToString = "1" Then
                    Doc1.IsEnabled = True
                ElseIf tabl.Rows(0)(1).ToString = "0" Then
                    Doc1.IsEnabled = False
                End If
                If tabl.Rows(1)(1).ToString = "1" Then
                    Doc2.IsEnabled = True
                ElseIf tabl.Rows(1)(1).ToString = "0" Then
                    Doc2.IsEnabled = False
                End If
                If tabl.Rows(2)(1).ToString = "1" Then
                    Doc3.IsEnabled = True
                ElseIf tabl.Rows(2)(1).ToString = "0" Then
                    Doc3.IsEnabled = False
                End If
                If tabl.Rows(3)(1).ToString = "1" Then
                    Doc4.IsEnabled = True
                ElseIf tabl.Rows(3)(1).ToString = "0" Then
                    Doc4.IsEnabled = False
                End If
                If tabl.Rows(4)(1).ToString = "1" Then
                    Doc5.IsEnabled = True
                ElseIf tabl.Rows(4)(1).ToString = "0" Then
                    Doc5.IsEnabled = False
                End If
                If tabl.Rows(5)(1).ToString = "1" Then
                    Doc6.IsEnabled = True
                ElseIf tabl.Rows(5)(1).ToString = "0" Then
                    Doc6.IsEnabled = False
                End If
                If tabl.Rows(6)(1).ToString = "1" Then
                    Doc7.IsEnabled = True
                ElseIf tabl.Rows(6)(1).ToString = "0" Then
                    Doc7.IsEnabled = False
                End If
                If tabl.Rows(7)(1).ToString = "1" Then
                    Doc8.IsEnabled = True
                ElseIf tabl.Rows(7)(1).ToString = "0" Then
                    Doc8.IsEnabled = False
                End If
                If tabl.Rows(8)(1).ToString = "1" Then
                    Doc9.IsEnabled = True
                ElseIf tabl.Rows(8)(1).ToString = "0" Then
                    Doc9.IsEnabled = False
                End If
                If tabl.Rows(9)(1).ToString = "1" Then
                    Doc10.IsEnabled = True
                ElseIf tabl.Rows(9)(1).ToString = "0" Then
                    Doc10.IsEnabled = False
                End If
            ElseIf tabla.Rows.Count = 0 Then
                Doc1.IsEnabled = False
                Doc2.IsEnabled = False
                Doc3.IsEnabled = False
                Doc4.IsEnabled = False
                Doc5.IsEnabled = False
                Doc6.IsEnabled = False
                Doc7.IsEnabled = False
                Doc8.IsEnabled = False
                Doc9.IsEnabled = False
                Doc10.IsEnabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            conexion1.Close()
        End Try
    End Sub

    Private Sub DRnames()
        Try
            conexion.Open()
            consulta = "SELECT idusuario, docnom, apnom FROM usuarios WHERE tipo_usuario='Doctor'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            tabla.Clear()
            adaptador.Fill(tabla)
            If tabla.Rows.Count = 1 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 2 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 3 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 4 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 5 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 6 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
                If tabla.Rows(5)(0).ToString = "11" Then
                    Drname6.Text = tabla.Rows(5)(1).ToString
                    Drfristname6.Text = tabla.Rows(5)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 7 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
                If tabla.Rows(5)(0).ToString = "11" Then
                    Drname6.Text = tabla.Rows(5)(1).ToString
                    Drfristname6.Text = tabla.Rows(5)(2).ToString
                End If
                If tabla.Rows(6)(0).ToString = "12" Then
                    Drname7.Text = tabla.Rows(6)(1).ToString
                    Drfristname7.Text = tabla.Rows(6)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 8 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
                If tabla.Rows(5)(0).ToString = "11" Then
                    Drname6.Text = tabla.Rows(5)(1).ToString
                    Drfristname6.Text = tabla.Rows(5)(2).ToString
                End If
                If tabla.Rows(6)(0).ToString = "12" Then
                    Drname7.Text = tabla.Rows(6)(1).ToString
                    Drfristname7.Text = tabla.Rows(6)(2).ToString
                End If
                If tabla.Rows(7)(0).ToString = "13" Then
                    Drname8.Text = tabla.Rows(7)(1).ToString
                    Drfristname8.Text = tabla.Rows(7)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 9 Then
                If tabla.Rows(0)(0).ToString = "6" Then
                    Drname1.Text = tabla.Rows(0)(1).ToString
                    Drfristname1.Text = tabla.Rows(0)(2).ToString
                End If
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
                If tabla.Rows(5)(0).ToString = "11" Then
                    Drname6.Text = tabla.Rows(5)(1).ToString
                    Drfristname6.Text = tabla.Rows(5)(2).ToString
                End If
                If tabla.Rows(6)(0).ToString = "12" Then
                    Drname7.Text = tabla.Rows(6)(1).ToString
                    Drfristname7.Text = tabla.Rows(6)(2).ToString
                End If
                If tabla.Rows(7)(0).ToString = "13" Then
                    Drname8.Text = tabla.Rows(7)(1).ToString
                    Drfristname8.Text = tabla.Rows(7)(2).ToString
                End If
                If tabla.Rows(8)(0).ToString = "14" Then
                    Drname9.Text = tabla.Rows(8)(1).ToString
                    Drfristname9.Text = tabla.Rows(8)(2).ToString
                End If
            ElseIf tabla.Rows.Count = 10 Then
                If tabla.Rows(1)(0).ToString = "7" Then
                    Drname2.Text = tabla.Rows(1)(1).ToString
                    Drfristname2.Text = tabla.Rows(1)(2).ToString
                End If
                If tabla.Rows(2)(0).ToString = "8" Then
                    Drname3.Text = tabla.Rows(2)(1).ToString
                    Drfristname3.Text = tabla.Rows(2)(2).ToString
                End If
                If tabla.Rows(3)(0).ToString = "9" Then
                    Drname4.Text = tabla.Rows(3)(1).ToString
                    Drfristname4.Text = tabla.Rows(3)(2).ToString
                End If
                If tabla.Rows(4)(0).ToString = "10" Then
                    Drname5.Text = tabla.Rows(4)(1).ToString
                    Drfristname5.Text = tabla.Rows(4)(2).ToString
                End If
                If tabla.Rows(5)(0).ToString = "11" Then
                    Drname6.Text = tabla.Rows(5)(1).ToString
                    Drfristname6.Text = tabla.Rows(5)(2).ToString
                End If
                If tabla.Rows(6)(0).ToString = "12" Then
                    Drname7.Text = tabla.Rows(6)(1).ToString
                    Drfristname7.Text = tabla.Rows(6)(2).ToString
                End If
                If tabla.Rows(7)(0).ToString = "13" Then
                    Drname8.Text = tabla.Rows(7)(1).ToString
                    Drfristname8.Text = tabla.Rows(7)(2).ToString
                End If
                If tabla.Rows(8)(0).ToString = "14" Then
                    Drname9.Text = tabla.Rows(8)(1).ToString
                    Drfristname9.Text = tabla.Rows(8)(2).ToString
                End If
                If tabla.Rows(9)(0).ToString = "15" Then
                    Drname10.Text = tabla.Rows(9)(1).ToString
                    Drfristname10.Text = tabla.Rows(9)(2).ToString
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub Ds_Tick(sender As Object, e As EventArgs) Handles Ds.Tick
        DRnames()
        ActiveDR()
    End Sub

    Private Sub DR1_Click(sender As Object, e As RoutedEventArgs) Handles DR1.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='6'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '6', '" & Drname1.Text & "', '" & TiketDr1.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr1.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR2_Click(sender As Object, e As RoutedEventArgs) Handles DR2.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='7'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '7', '" & Drname2.Text & "', '" & TiketDr2.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr2.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR3_Click(sender As Object, e As RoutedEventArgs) Handles DR3.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='8'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '8', '" & Drname3.Text & "', '" & TiketDr3.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr3.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR4_Click(sender As Object, e As RoutedEventArgs) Handles DR4.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='9'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '9', '" & Drname4.Text & "', '" & TiketDr4.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr4.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR5_Click(sender As Object, e As RoutedEventArgs) Handles DR5.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='10'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '10', '" & Drname5.Text & "', '" & TiketDr5.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr5.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR6_Click(sender As Object, e As RoutedEventArgs) Handles DR6.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='11'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '11', '" & Drname6.Text & "', '" & TiketDr6.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr6.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR7_Click(sender As Object, e As RoutedEventArgs) Handles DR7.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='12'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '12', '" & Drname7.Text & "', '" & TiketDr7.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr7.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR8_Click(sender As Object, e As RoutedEventArgs) Handles DR8.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='13'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '13', '" & Drname8.Text & "', '" & TiketDr8.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr8.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR9_Click(sender As Object, e As RoutedEventArgs) Handles DR9.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='14'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '14', '" & Drname9.Text & "', '" & TiketDr9.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr9.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DR10_Click(sender As Object, e As RoutedEventArgs) Handles DR10.Click
        Try
            conexion.Open()
            consulta = "SELECT codclinica FROM usuarios WHERE idusuario='15'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            Dim clinicatbl As New DataTable
            clinicatbl.Clear()
            adaptador.Fill(clinicatbl)
            tiket = "INSERT INTO pacientes (IDcliente, idDoctor, Doctor, Tiket, Clinica, estado_paciente) VALUES ('NULL', '15', '" & Drname10.Text & "', '" & TiketDr10.Text & "', '" & clinicatbl.Rows(0)(0).ToString & "', '0')"
            comando = New MySqlCommand(tiket, conexion)
            comando.ExecuteNonQueryAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
            Log.e("Error con Excepción y Traza", ex, New StackFrame(True))
        Finally
            TiketDr10.Text = ""
            conexion.Close()
        End Try
    End Sub

    Private Sub DeleteTiket_Selected(sender As Object, e As RoutedEventArgs) Handles DeleteTiket.Selected
        btn_menu.IsChecked = False
        DoctoresActivos.IsEnabled = False
        DoctoresActivos.Visibility = Visibility.Collapsed
        FuncionesExtras.IsEnabled = True
        FuncionesExtras.Visibility = Visibility.Visible
        FuncionesExtras.Children.Clear()
        FuncionesExtras.Children.Add(New ScrDeleteTiket)
    End Sub
End Class
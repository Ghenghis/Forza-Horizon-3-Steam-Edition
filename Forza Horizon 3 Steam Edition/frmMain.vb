﻿Public Class frmMain
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Process.Start("shell:AppsFolder\Microsoft.OpusPG_8wekyb3d8bbwe!OpusReleaseFinal")

            Timer1.Start()
            WindowState = FormWindowState.Minimized

        Catch ex As Exception
            NotifyIcon1.Visible = True
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
            NotifyIcon1.BalloonTipTitle = "Forza Horizon 3 Steam Edition"
            NotifyIcon1.BalloonTipText = ex.Message
            NotifyIcon1.ShowBalloonTip(6000)
            ShowInTaskbar = False
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim p() As Process

        p = Process.GetProcessesByName("forza_x64_release_final")
        If p.Count > 0 Then
            ' Process is running
            'Do nothing This means that we know that the process is running. We close this after the process has ended.
        Else
            ' Process is Not running. Close at this state.
            ShowInTaskbar = False
            Close()
        End If

        GC.Collect()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            If My.Settings.QUIETHOURS = False Then
                NotifyIcon1.Visible = True
                'NotifyIcon1.Icon = My.Resources
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
                NotifyIcon1.BalloonTipTitle = "Forza Horizon 3 Steam Edition"
                NotifyIcon1.BalloonTipText = "Closing."
                NotifyIcon1.ShowBalloonTip(6000)
            End If
            ShowInTaskbar = False
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        'Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If My.Settings.QUIETHOURS = False Then
            NotifyIcon1.Visible = True
            'NotifyIcon1.Icon = My.Resources
            NotifyIcon1.BalloonTipIcon = ToolTipIcon.None
            NotifyIcon1.BalloonTipTitle = "Forza Horizon 3 Steam Edition"
            NotifyIcon1.BalloonTipText = "Closing."
            NotifyIcon1.ShowBalloonTip(6000)
        End If
        System.Threading.Thread.Sleep(3000)
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Try
            Dim p() As Process

            p = Process.GetProcessesByName("forza_x64_release_final")
            If p.Count > 0 Then
                ' Process is running
                'Do nothing This means that we know that the process is running. We close this after the process has ended.
                Process.GetProcessesByName("forza_x64_release_final")(0).Kill()
                Close()
            Else
                ' Process is not running
                Close()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cbxQuietHours_CheckedChanged(sender As Object, e As EventArgs) Handles cbxQuietHours.CheckedChanged
        'Set the notifications to off/on with this.
        If cbxQuietHours.Checked = True Then
            My.Settings.QUIETHOURS = True
            My.Settings.Save()
        Else
            My.Settings.QUIETHOURS = False
            My.Settings.Save()
        End If
    End Sub
End Class

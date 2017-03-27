
Namespace LightSwitchApplication

    Public Class CreateNew

        Private Sub SayHi_Execute()
            ' Write your code here.
            ShowMessageBox("Say Hi!")

        End Sub

        'Private Sub SayHi()
        '    ' Write your code here.
        '    ShowMessageBox("2")
        'End Sub

        'Private Sub SaveData()
        '    Me.Save()
        '    ' You can call some some other logic here...
        '    ShowMessageBox("Data Saved")
        'End Sub

        Private Sub SaveData_Execute()
            Me.Save()
            ' You can call some some other logic here...
            ShowMessageBox("Data Saved")
        End Sub

        Private Sub CreateNew_Activated()
            ' Write your code here.

            strSayHi = "SayHi"
            Me.FindControl("Property4").SetBinding(CentralControlsCS.CustomButtonReusable.CommandNameProperty, strSayHi, Windows.Data.BindingMode.OneWay)

            'custButtonResuable.SetBinding(CentralControlsCS.CustomButtonReusable.CommandNameProperty, "")

            'AddHandler CType(Me.FindControl("Property4"), CentralControlsCS.CustomButtonReusable).

            'AddHandler Me.FindControl("Property4").ControlAvailable,
            '    Sub(sender As Object, e As ControlAvailableEventArgs)
            '        CType(e.Control, CentralControlsCS.CustomButtonReusable).CommandName = "SayHi"
            '    End Sub


            ' Me.DataWorkspace.SecurityData



        End Sub

    End Class

End Namespace



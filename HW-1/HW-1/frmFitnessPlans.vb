Public Class frmFitnessPlans
    Private arrRadPlans(7) As RadioButton
    Private arrRadTrainers(1) As RadioButton
    Private Const BASIC_IND As Single = 14.95
    Private Const BASIC_FAMILY As Single = 24.95
    Private Const BASICPLUS_IND As Single = 26.95
    Private Const BASICPLUS_FAMILY As Single = 23.0
    Private Const PREFERRED_IND As Single = 35.95
    Private Const PREFERRED_FAMILY As Single = 48.0
    Private Const DELUXE_IND As Single = 45.95
    Private Const DELXUE_FAMILY As Single = 60.0
    Private Const IND_TRAINER As Single = 20.0
    Private Const FAMILY_TRAINER As Single = 25.0
    Private Sub frmFitnessPlans_Load(sender As Object, e As EventArgs) Handles Me.Load
        'loading the control arrays

    End Sub




    Private Sub chkTrainer_Click(sender As Object, e As EventArgs) Handles chkTrainer.Click
        If chkTrainer.Checked Then
            radTrainerInd.Visible = True
            radTrainerFamily.Visible = True
        Else
            radTrainerInd.Visible = False
            radTrainerInd.Checked = False
            radTrainerFamily.Visible = False
            radTrainerFamily.Checked = False
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub


End Class

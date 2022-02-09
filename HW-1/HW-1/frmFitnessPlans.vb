Public Class frmFitnessPlans
    Private arrRadPlans(7) As RadioButton
    Private arrRadTrainers(1) As RadioButton
    Private arrPlanCosts(7) As Single
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
        arrRadPlans(0) = radBasicInd
        arrRadPlans(1) = radBasicFamily
        arrRadPlans(2) = radBasicPlusInd
        arrRadPlans(3) = radBasicPlusFamily
        arrRadPlans(4) = radPreferredInd
        arrRadPlans(5) = radPreferredFamily
        arrRadPlans(6) = radDeluxeInd
        arrRadPlans(7) = radDeluxeFamily

        arrRadTrainers(0) = radTrainerInd
        arrRadTrainers(1) = radTrainerFamily

        arrPlanCosts(0) = BASIC_IND
        arrPlanCosts(1) = BASIC_FAMILY
        arrPlanCosts(2) = BASICPLUS_IND
        arrPlanCosts(3) = BASICPLUS_FAMILY
        arrPlanCosts(4) = PREFERRED_IND
        arrPlanCosts(5) = PREFERRED_FAMILY
        arrPlanCosts(6) = DELUXE_IND
        arrPlanCosts(7) = DELXUE_FAMILY


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

    Private Sub radPlanCosts_CheckedChanged(sender As Object, e As EventArgs) Handles radBasicInd.CheckedChanged, radBasicFamily.CheckedChanged, radBasicPlusInd.CheckedChanged,
            radBasicFamily.CheckedChanged, radPreferredInd.CheckedChanged, radPreferredFamily.CheckedChanged, radDeluxeInd.CheckedChanged, radDeluxeFamily.CheckedChanged

        Dim i As Integer

        For i = 0 To arrRadPlans.Length - 1
            If arrRadPlans(i).Checked Then
                lblTotal.Text = FormatCurrency(arrPlanCosts(i))
            End If
        Next


    End Sub
End Class

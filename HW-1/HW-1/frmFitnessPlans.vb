Public Class frmFitnessPlans
    Private arrRadPlans(7) As RadioButton
    Private arrRadTrainers(1) As RadioButton
    Private arrPlanCosts(7) As Single
    Private arrTrainerPlans(1) As Single
    Private arrPlanLabels(7) As String
    Private arrPlanDesc(7) As String
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
    Private Summary As frmSummary
    Private strPlan As String
    Private strTrainerPlan As String


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

        arrTrainerPlans(0) = IND_TRAINER
        arrTrainerPlans(1) = FAMILY_TRAINER

        arrPlanLabels(0) = "Basic Individual"
        arrPlanLabels(1) = "Basic Family"
        arrPlanLabels(2) = "Basic Plus Individual"
        arrPlanLabels(3) = "Basic Plus Family"
        arrPlanLabels(4) = "Preferred Individual"
        arrPlanLabels(5) = "Preferred Family"
        arrPlanLabels(6) = "Deluxe Individual"
        arrPlanLabels(7) = "Deluxe Family"

        arrPlanDesc(0) = "use of gym facilities with basic equipment only"
        arrPlanDesc(1) = "use of gym facilities with basic equipment only"
        arrPlanDesc(2) = "use of gym facilities and locker room with basic equipment only"
        arrPlanDesc(3) = "use of gym facilities and locker room with basic equipment only"
        arrPlanDesc(4) = "use of gym facilities and locker room with advanced equipment"
        arrPlanDesc(5) = "use of gym facilities and locker room with advanced equipment"
        arrPlanDesc(6) = "use of gym facilities and locker room with advanced equipment, plus free refreshments at the smoothie bar"
        arrPlanDesc(7) = "use of gym facilities and locker room with advanced equipment, plus free refreshments at the smoothie bar"
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

    Private Sub radPlanCosts_CheckedChanged(sender As Object, e As EventArgs) Handles radBasicInd.CheckedChanged, radBasicFamily.CheckedChanged,
        radBasicPlusInd.CheckedChanged, radBasicPlusFamily.CheckedChanged, radPreferredInd.CheckedChanged, radPreferredFamily.CheckedChanged,
        radDeluxeInd.CheckedChanged, radDeluxeFamily.CheckedChanged, radTrainerInd.CheckedChanged, radTrainerFamily.CheckedChanged

        Dim i As Integer
        Dim j As Integer

        For i = 0 To arrRadPlans.Length - 1
            If arrRadPlans(i).Checked Then
                strPlan = FormatCurrency(arrPlanCosts(i))
                lblTotal.Text = FormatCurrency(strPlan)
            End If

        Next
        For j = 0 To arrRadTrainers.Length - 1
            If arrRadTrainers(j).Checked Then
                strTrainerPlan = FormatCurrency(arrTrainerPlans(j))
                lblTotal.Text = FormatCurrency(CSng(strTrainerPlan) + CSng(strPlan))
            End If
        Next

    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim i As Integer
        For i = 0 To arrRadPlans.Length - 1
            arrRadPlans(i).Checked = False
        Next

        chkTrainer.CheckState = False
        lblTotal.Text = FormatCurrency(0)
        radTrainerInd.Visible = False
        radTrainerInd.Checked = False
        radTrainerFamily.Visible = False
        radTrainerFamily.Checked = False
        strPlan = 0
        strTrainerPlan = 0
    End Sub

    Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
        Dim strSummary As String
        Dim i As Integer
        Dim blnError As Boolean
        errP.Clear()

        If strPlan = 0 Then 'no plan was selected
            errP.SetError(grpPlanChoices, "You must select a plan")
            blnError = True
        End If
        If chkTrainer.Checked Then 'if trainer option checked, they must choose a trainer plan
            If strTrainerPlan = 0 Then 'no trainer plan was selected
                errP.SetError(grpTrainer, "You must select a plan")
                blnError = True
            End If
        End If
        If blnError Then 'cant go forward, some of the data is missing or bad
                Exit Sub 'early jump out of this procedure
            End If
        'if we get this far, all of the data is good

        If Not chkTrainer.Checked Then
            strTrainerPlan = 0
        End If

        strSummary = "You selected the following fitness plan:" & vbCrLf
        For i = 0 To arrRadPlans.Length - 1
            If arrRadPlans(i).Checked Then
                strSummary &= arrPlanLabels(i) & vbCrLf
                strSummary &= "You will have " & arrPlanDesc(i) & vbCrLf
                strSummary &= "Your monthly plan will cost: " & strPlan & vbCrLf
                strSummary &= "" & vbCrLf
            End If
        Next
        If Not chkTrainer.Checked Then
            strSummary &= "You decided not select the optional personal trainer" & vbCrLf
            strSummary &= "" & vbCrLf
        End If
        If chkTrainer.Checked Then
            For i = 0 To arrRadTrainers.Length - 1
                If arrRadTrainers(i).Checked Then
                    strSummary &= "You accepted the optional personal trainer" & vbCrLf
                    strSummary &= "An additional charge of: " & strTrainerPlan & " will be added to your monthly cost." & vbCrLf
                    strSummary &= "" & vbCrLf
                End If
            Next
        End If
        strSummary &= "Your total monthly plan cost is: " & FormatCurrency(CSng(strPlan) + CSng(strTrainerPlan))
        Summary = New frmSummary
        Summary.lblSummary.Text = strSummary
        Summary.ShowDialog()


    End Sub
End Class

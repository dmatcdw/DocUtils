Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim test As DocUtils.DocUtils = New DocUtils.DocUtils
        Select Case ComboBox1.SelectedItem
            Case "FormatDocResponse"
                txtResult.Text = test.FormatDocResponse(txtQuoteResults.Text, txtPolicy.Text, txtFormat.Text, txtEnv.Text, txtUser.Text, txtPassword.Text, txtPath.Text)
            Case "GetFormattedDocument"
                txtResult.Text = test.GetFormattedDocument(txtFormat.Text, txtQuoteResults.Text)
        End Select
    End Sub
End Class
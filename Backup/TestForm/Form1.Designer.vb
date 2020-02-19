<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtQuoteResults = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtEnv = New System.Windows.Forms.TextBox
        Me.txtPolicy = New System.Windows.Forms.TextBox
        Me.txtFormat = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblPathResults = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtQuoteResults
        '
        Me.txtQuoteResults.Location = New System.Drawing.Point(16, 58)
        Me.txtQuoteResults.Multiline = True
        Me.txtQuoteResults.Name = "txtQuoteResults"
        Me.txtQuoteResults.Size = New System.Drawing.Size(697, 96)
        Me.txtQuoteResults.TabIndex = 0
        Me.txtQuoteResults.Text = resources.GetString("txtQuoteResults.Text")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(146, 412)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Run Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(16, 193)
        Me.txtPath.Multiline = True
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(703, 87)
        Me.txtPath.TabIndex = 2
        Me.txtPath.Text = "<Document><Document_Date Val= ""25-01-2013""/><Document_Desc Val= ""Adjustment State" & _
            "ment of Facts""/><Document_Url Val= ""I:\DM_Intra\Web_Test\policyfast\docs\ZA\1646" & _
            "257713A.pdf"" /></Document>"
        '
        'txtEnv
        '
        Me.txtEnv.Location = New System.Drawing.Point(91, 305)
        Me.txtEnv.Name = "txtEnv"
        Me.txtEnv.Size = New System.Drawing.Size(100, 20)
        Me.txtEnv.TabIndex = 3
        Me.txtEnv.Text = "T"
        '
        'txtPolicy
        '
        Me.txtPolicy.Location = New System.Drawing.Point(91, 335)
        Me.txtPolicy.Name = "txtPolicy"
        Me.txtPolicy.Size = New System.Drawing.Size(100, 20)
        Me.txtPolicy.TabIndex = 4
        '
        'txtFormat
        '
        Me.txtFormat.Location = New System.Drawing.Point(91, 365)
        Me.txtFormat.Name = "txtFormat"
        Me.txtFormat.Size = New System.Drawing.Size(100, 20)
        Me.txtFormat.TabIndex = 5
        Me.txtFormat.Text = "xml"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Environment"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 335)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Policy"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 365)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Format"
        '
        'lblPathResults
        '
        Me.lblPathResults.AutoSize = True
        Me.lblPathResults.Location = New System.Drawing.Point(16, 166)
        Me.lblPathResults.Name = "lblPathResults"
        Me.lblPathResults.Size = New System.Drawing.Size(64, 13)
        Me.lblPathResults.TabIndex = 9
        Me.lblPathResults.Text = "PathResults"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "QuoteResults"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(277, 305)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "User"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(277, 335)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Password"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(388, 305)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 20)
        Me.txtUser.TabIndex = 13
        Me.txtUser.Text = "chris"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(388, 335)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 14
        Me.txtPassword.Text = "dm3081180"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"FormatDocResponse", "CheckDocsDone", "FormDocArrays", "ExtractFromXml", "GetFormattedDocument"})
        Me.ComboBox1.Location = New System.Drawing.Point(19, 411)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 15
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(20, 471)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(719, 153)
        Me.txtResult.TabIndex = 16
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(16, 449)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(37, 13)
        Me.lblResult.TabIndex = 17
        Me.lblResult.Text = "Result"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 629)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblPathResults)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFormat)
        Me.Controls.Add(Me.txtPolicy)
        Me.Controls.Add(Me.txtEnv)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtQuoteResults)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuoteResults As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtEnv As System.Windows.Forms.TextBox
    Friend WithEvents txtPolicy As System.Windows.Forms.TextBox
    Friend WithEvents txtFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPathResults As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label
End Class

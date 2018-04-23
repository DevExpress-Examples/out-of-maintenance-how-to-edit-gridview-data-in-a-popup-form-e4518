' Developer Express Code Central Example:
' How to edit GridView data in a popup form
' 
' This example demonstrates how to switch a GridView to read-only mode and
' implement the Create, Update, Delete, and Insert operations in a popup form. In
' this example, you can also edit data after double-clicking a row.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4518


Imports Microsoft.VisualBasic
Imports System
Namespace GridSample
	Partial Public Class EditForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			Me.textEdit2 = New DevExpress.XtraEditors.TextEdit()
			Me.textEdit3 = New DevExpress.XtraEditors.TextEdit()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.textEdit4 = New DevExpress.XtraEditors.TextEdit()
			Me.labelControl4 = New DevExpress.XtraEditors.LabelControl()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' textEdit1
			' 
			Me.textEdit1.Location = New System.Drawing.Point(81, 35)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(100, 20)
			Me.textEdit1.TabIndex = 0
			' 
			' textEdit2
			' 
			Me.textEdit2.Location = New System.Drawing.Point(81, 61)
			Me.textEdit2.Name = "textEdit2"
			Me.textEdit2.Size = New System.Drawing.Size(100, 20)
			Me.textEdit2.TabIndex = 1
			' 
			' textEdit3
			' 
			Me.textEdit3.Location = New System.Drawing.Point(81, 87)
			Me.textEdit3.Name = "textEdit3"
			Me.textEdit3.Size = New System.Drawing.Size(100, 20)
			Me.textEdit3.TabIndex = 2
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(27, 42)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(48, 13)
			Me.labelControl1.TabIndex = 3
			Me.labelControl1.Text = "FirstName"
			' 
			' labelControl2
			' 
			Me.labelControl2.Location = New System.Drawing.Point(13, 68)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(62, 13)
			Me.labelControl2.TabIndex = 4
			Me.labelControl2.Text = "SecondName"
			' 
			' labelControl3
			' 
			Me.labelControl3.Location = New System.Drawing.Point(48, 94)
			Me.labelControl3.Name = "labelControl3"
			Me.labelControl3.Size = New System.Drawing.Size(20, 13)
			Me.labelControl3.TabIndex = 5
			Me.labelControl3.Text = "Info"
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(12, 151)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton1.TabIndex = 6
			Me.simpleButton1.Text = "Ok"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' simpleButton2
			' 
			Me.simpleButton2.Location = New System.Drawing.Point(143, 151)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(75, 23)
			Me.simpleButton2.TabIndex = 7
			Me.simpleButton2.Text = "Cancel"
'			Me.simpleButton2.Click += New System.EventHandler(Me.simpleButton2_Click);
			' 
			' textEdit4
			' 
			Me.textEdit4.Location = New System.Drawing.Point(81, 113)
			Me.textEdit4.Name = "textEdit4"
			Me.textEdit4.Size = New System.Drawing.Size(100, 20)
			Me.textEdit4.TabIndex = 8
			' 
			' labelControl4
			' 
			Me.labelControl4.Location = New System.Drawing.Point(6, 120)
			Me.labelControl4.Name = "labelControl4"
			Me.labelControl4.Size = New System.Drawing.Size(69, 13)
			Me.labelControl4.TabIndex = 9
			Me.labelControl4.Text = "Insert position"
			' 
			' EditForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(248, 189)
			Me.Controls.Add(Me.labelControl4)
			Me.Controls.Add(Me.textEdit4)
			Me.Controls.Add(Me.simpleButton2)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.labelControl3)
			Me.Controls.Add(Me.labelControl2)
			Me.Controls.Add(Me.labelControl1)
			Me.Controls.Add(Me.textEdit3)
			Me.Controls.Add(Me.textEdit2)
			Me.Controls.Add(Me.textEdit1)
			Me.Name = "EditForm"
			Me.Text = "EditForm"
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private textEdit1 As DevExpress.XtraEditors.TextEdit
		Private textEdit2 As DevExpress.XtraEditors.TextEdit
		Private textEdit3 As DevExpress.XtraEditors.TextEdit
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private labelControl2 As DevExpress.XtraEditors.LabelControl
		Private labelControl3 As DevExpress.XtraEditors.LabelControl
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private textEdit4 As DevExpress.XtraEditors.TextEdit
		Private labelControl4 As DevExpress.XtraEditors.LabelControl
	End Class
End Namespace
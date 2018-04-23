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
	Partial Public Class Form1
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
			Me.gridControl = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton3 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton4 = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl
			' 
			Me.gridControl.Dock = System.Windows.Forms.DockStyle.Top
			Me.gridControl.Location = New System.Drawing.Point(0, 0)
			Me.gridControl.MainView = Me.gridView1
			Me.gridControl.Name = "gridControl"
			Me.gridControl.Size = New System.Drawing.Size(841, 478)
			Me.gridControl.TabIndex = 0
			Me.gridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
			Me.gridView1.GridControl = Me.gridControl
			Me.gridView1.Name = "gridView1"
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(139, 513)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(96, 39)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Add Person"
'			Me.simpleButton1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' simpleButton2
			' 
			Me.simpleButton2.Location = New System.Drawing.Point(269, 513)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(96, 39)
			Me.simpleButton2.TabIndex = 2
			Me.simpleButton2.Text = "Edit Person"
'			Me.simpleButton2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' simpleButton3
			' 
			Me.simpleButton3.Location = New System.Drawing.Point(400, 513)
			Me.simpleButton3.Name = "simpleButton3"
			Me.simpleButton3.Size = New System.Drawing.Size(96, 39)
			Me.simpleButton3.TabIndex = 3
			Me.simpleButton3.Text = "Delete Person"
'			Me.simpleButton3.Click += New System.EventHandler(Me.button3_Click);
			' 
			' simpleButton4
			' 
			Me.simpleButton4.Location = New System.Drawing.Point(539, 513)
			Me.simpleButton4.Name = "simpleButton4"
			Me.simpleButton4.Size = New System.Drawing.Size(96, 39)
			Me.simpleButton4.TabIndex = 4
			Me.simpleButton4.Text = "Insert Person"
'			Me.simpleButton4.Click += New System.EventHandler(Me.simpleButton4_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(841, 586)
			Me.Controls.Add(Me.simpleButton4)
			Me.Controls.Add(Me.simpleButton3)
			Me.Controls.Add(Me.simpleButton2)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.gridControl)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.gridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private gridControl As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton3 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton4 As DevExpress.XtraEditors.SimpleButton

	End Class
End Namespace

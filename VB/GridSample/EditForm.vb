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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace GridSample
	Partial Public Class EditForm
		Inherits Form
		Public Sub New(ByVal person As Person, ByVal insertFlag As Boolean)
			InitializeComponent()
			textEdit1.DataBindings.Add("EditValue",person,"FirstName")
			textEdit2.DataBindings.Add("EditValue", person, "SecondName")
			textEdit3.DataBindings.Add("EditValue", person, "Info")
			If (Not insertFlag) Then
				labelControl4.Visible = False
				textEdit4.Visible = False
			Else
				AddHandler textEdit4.EditValueChanged, AddressOf textEdit4_EditValueChanged
			End If
		End Sub
		'// Fields...

		Private _NewPosition As String
		Public Property NewPosition() As String
			Get
				Return _NewPosition
			End Get
			Set(ByVal value As String)
				_NewPosition = value
			End Set
		End Property
		Private Sub textEdit4_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			NewPosition = (CType(sender, TextEdit)).EditValue.ToString()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
		End Sub
	End Class
End Namespace

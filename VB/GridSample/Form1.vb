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
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns


Namespace GridSample
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			InitGrid()
			gridView1.OptionsBehavior.Editable = False
			AddHandler gridView1.DoubleClick, AddressOf gridView1_DoubleClick
		End Sub

		Private Sub gridView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
			personToEdit = GetCurrentPerson()
			EditPerson(personToEdit, "EditPerson", AddressOf CloseEditPersonHandler)

		End Sub

		Private f1 As EditForm
		Private personToEdit As Person
		Private personList As New BindingList(Of Person)()
		Private Sub InitGrid()
			personList.Add(New Person("John", "Smith"))
			personList.Add(New Person("Gabriel", "Smith"))
			personList.Add(New Person("Ashley", "Smith", "some comment"))
			personList.Add(New Person("Adrian", "Smith", "some comment"))
			personList.Add(New Person("Gabriella", "Smith", "some comment"))
			gridControl.DataSource = personList
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			personToEdit = New Person()
			EditPerson(personToEdit, "NewPerson", AddressOf CloseNewPersonHandler)
		End Sub
		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton2.Click
			If gridView1.FocusedRowHandle < 0 Then
				MessageBox.Show("You didn' select a person to edit")
				Return
			End If
			personToEdit = GetCurrentPerson()
			EditPerson(personToEdit, "EditPerson", AddressOf CloseEditPersonHandler)
		End Sub

		Private Function GetCurrentPerson() As Person
		   Return TryCast(gridView1.GetRow(gridView1.FocusedRowHandle), Person)
		End Function
		Private Sub EditPerson(ByVal person As Person, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			f1 = New EditForm(person,False) With {.Text = windowTitle}
			AddHandler f1.FormClosing, closedDelegate
			f1.ShowDialog()
		End Sub
		Private Sub CloseEditPersonHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				Try
				   personList.ResetBindings()
				Catch ex As Exception
					HandleExcepton(ex)
				End Try
			End If
			personToEdit = Nothing
		End Sub
		Private Sub CloseNewPersonHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)

			If (CType(sender, EditForm)).DialogResult = System.Windows.Forms.DialogResult.OK Then
				Try
					personList.Add(personToEdit)
				Catch ex As Exception
					HandleExcepton(ex)
				End Try
				SetNewFocus()
			End If
			personToEdit = Nothing
		End Sub

		Private Sub SetNewFocus()
			For i As Integer = 0 To gridView1.DataRowCount - 1
				If personToEdit.FirstName = gridView1.GetRowCellValue(i, gridView1.Columns("FirstName")).ToString() Then
					gridView1.FocusedRowHandle = i
					Exit For
				End If
			Next i
		End Sub
		Private Sub HandleExcepton(ByVal ex As Exception)
			MessageBox.Show(ex.Message)
		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton3.Click
			DeletePerson(gridView1.FocusedRowHandle)
		End Sub
		Private Sub DeletePerson(ByVal focusedRowHandle As Integer)
			If focusedRowHandle < 0 Then
				MessageBox.Show("You didn't select a person to delete")
				Return
			End If
			If MessageBox.Show("Do you really want to delete the selected person?", "Delete Person", MessageBoxButtons.OKCancel) <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If
			Try
				personToEdit = GetCurrentPerson()
				personList.Remove(personToEdit)
			Catch ex As Exception
				HandleExcepton(ex)
			End Try
			gridView1.FocusedRowHandle = focusedRowHandle
			personToEdit = Nothing
		End Sub

		Private Sub simpleButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton4.Click
			personToEdit = New Person()
			InsertPerson(personToEdit, "InsertForm", AddressOf InsertPersonHandler)
		End Sub
		Private Sub InsertPerson(ByVal person As Person, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)
			f1 = New EditForm(person, True) With {.Text = windowTitle}
			AddHandler f1.FormClosing, closedDelegate
			f1.ShowDialog()
		End Sub
		Private Sub InsertPersonHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			Dim form As EditForm = TryCast(sender, EditForm)
			If form IsNot Nothing Then
				If form.DialogResult = System.Windows.Forms.DialogResult.OK Then
					Try
						If (Not String.IsNullOrWhiteSpace(form.NewPosition)) Then
							Dim pos As Integer = Convert.ToInt32(form.NewPosition)
							If pos > personList.Count - 1 Then
								personList.Add(personToEdit)
							Else
								personList.Insert(pos, personToEdit)
							End If
						Else
							MessageBox.Show("Incorrect position value")
						End If

					Catch ex As Exception
						HandleExcepton(ex)
					End Try
				End If
				SetNewFocus()
			End If
			personToEdit = Nothing
		End Sub


	End Class
End Namespace
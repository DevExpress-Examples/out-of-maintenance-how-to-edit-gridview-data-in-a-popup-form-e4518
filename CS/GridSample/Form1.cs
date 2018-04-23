// Developer Express Code Central Example:
// How to edit GridView data in a popup form
// 
// This example demonstrates how to switch a GridView to read-only mode and
// implement the Create, Update, Delete, and Insert operations in a popup form. In
// this example, you can also edit data after double-clicking a row.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4518

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;


namespace GridSample
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            InitGrid();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
        }

        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            personToEdit = GetCurrentPerson();
            EditPerson(personToEdit, "EditPerson", CloseEditPersonHandler);    
           
        }

        private EditForm f1;
        private Person personToEdit;
        BindingList<Person> personList = new BindingList<Person>();
        void InitGrid()
        {
            personList.Add(new Person("John", "Smith"));
            personList.Add(new Person("Gabriel", "Smith"));
            personList.Add(new Person("Ashley", "Smith", "some comment"));
            personList.Add(new Person("Adrian", "Smith", "some comment"));
            personList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = personList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personToEdit = new Person();
            EditPerson(personToEdit, "NewPerson", CloseNewPersonHandler);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("You didn' select a person to edit");
                return;
            }
            personToEdit = GetCurrentPerson();
            EditPerson(personToEdit, "EditPerson", CloseEditPersonHandler);               
        }

        private Person GetCurrentPerson()
        {
           return gridView1.GetRow(gridView1.FocusedRowHandle) as Person;
        }
        private void EditPerson(Person person, string windowTitle, FormClosingEventHandler closedDelegate)
        {
            f1 = new EditForm(person,false) { Text = windowTitle };
            f1.FormClosing += closedDelegate;
            f1.ShowDialog();
        }    
        private void CloseEditPersonHandler(object sender, EventArgs e)
        {
            if (((EditForm)sender).DialogResult == DialogResult.OK)
            {
                try
                {                   
                   personList.ResetBindings();
                }
                catch (Exception ex)
                {
                    HandleExcepton(ex);
                }
            }
            personToEdit = null;
        }
        private void CloseNewPersonHandler(object sender, FormClosingEventArgs e)
        {

            if (((EditForm)sender).DialogResult == DialogResult.OK)
            {
                try
                {
                    personList.Add(personToEdit);
                }
                catch (Exception ex)
                {
                    HandleExcepton(ex);
                }
                SetNewFocus();
            }
            personToEdit = null;          
        }

        private void SetNewFocus()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (personToEdit.FirstName == gridView1.GetRowCellValue(i, gridView1.Columns["FirstName"]).ToString())
                {
                    gridView1.FocusedRowHandle = i;
                    break;
                }
            }
        }
        private void HandleExcepton(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeletePerson(gridView1.FocusedRowHandle);
        }        
        private void DeletePerson(int focusedRowHandle)
        {
            if (focusedRowHandle < 0)
            {
                MessageBox.Show("You didn't select a person to delete");
                return;
            }
            if (MessageBox.Show("Do you really want to delete the selected person?", "Delete Person", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            try
            {
                personToEdit = GetCurrentPerson();
                personList.Remove(personToEdit);
            }
            catch (Exception ex)
            {
                HandleExcepton(ex);
            }           
            gridView1.FocusedRowHandle = focusedRowHandle;
            personToEdit = null;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            personToEdit = new Person();
            InsertPerson(personToEdit, "InsertForm", InsertPersonHandler);
        }
        private void InsertPerson(Person person, string windowTitle, FormClosingEventHandler closedDelegate)
        {
            f1 = new EditForm(person, true) { Text = windowTitle };
            f1.FormClosing += closedDelegate;
            f1.ShowDialog();
        }
        private void InsertPersonHandler(object sender, FormClosingEventArgs e)
        {
            EditForm form = sender as EditForm;
            if (form != null)
            {
                if (form.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(form.NewPosition))
                        {
                            int pos = Convert.ToInt32(form.NewPosition);
                            if (pos > personList.Count - 1)
                            {
                                personList.Add(personToEdit);
                            }
                            else
                            {
                                personList.Insert(pos, personToEdit);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect position value");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        HandleExcepton(ex);
                    }
                }
                SetNewFocus();
            }      
            personToEdit = null;
        }
    

    }
}
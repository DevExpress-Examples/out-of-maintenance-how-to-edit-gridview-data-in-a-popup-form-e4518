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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GridSample
{
    public partial class EditForm : Form
    {
        public EditForm(Person person, bool insertFlag)
        {
            InitializeComponent();            
            textEdit1.DataBindings.Add("EditValue",person,"FirstName");
            textEdit2.DataBindings.Add("EditValue", person, "SecondName");
            textEdit3.DataBindings.Add("EditValue", person, "Info");
            if (!insertFlag)
            {
                labelControl4.Visible = false;
                textEdit4.Visible = false;
            }
            else
            {
                textEdit4.EditValueChanged += new EventHandler(textEdit4_EditValueChanged);
            }
        }
        //// Fields...

        private string _NewPosition;
        public string NewPosition
        {
            get { return _NewPosition; }
            set { _NewPosition = value; }
        }
        void textEdit4_EditValueChanged(object sender, EventArgs e)
        {
            NewPosition = ((TextEdit)sender).EditValue.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

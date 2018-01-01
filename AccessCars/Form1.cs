using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessCars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tblCarsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblCarsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.honestRalphsUsedCarsDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'honestRalphsUsedCarsDataSet.tblCars' table. You can move, or remove it, as needed.
            //this.tblCarsTableAdapter.Fill(this.honestRalphsUsedCarsDataSet.tblCars);

        }

        private void btnDisplayToList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); ;
            const int HIGHPRICE = 20000;
            this.tblCarsTableAdapter.Fill(this.honestRalphsUsedCarsDataSet.tblCars);
            var inExpensiveCarsBox =
                from c in this.honestRalphsUsedCarsDataSet.tblCars
                    where c.Price < HIGHPRICE
                    select c;
            
            foreach (var c in inExpensiveCarsBox)
                listBox1.Items.Add(c.ID + "-" + c.ModelYear + " " + c.Make);

        }
    }
}

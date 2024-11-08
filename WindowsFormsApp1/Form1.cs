using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Company company = new Company();
        public Form1()
        {
            InitializeComponent();
        }
        // добавление объекта класса в лист и отображение в datagridview
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Airplane airplane = new Airplane(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToDouble(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToDouble(numericUpDown4.Value));
                company.AddAirplane(airplane);
                airplane.SetQuality();
                company.LoadData(company.GetAirplaneList(), dataGridView1);
            }
            
        }
        // добавление объекта класса в словарь и отображение в datagridview
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                SpecialAirplane specAirplane = new SpecialAirplane(textBox2.Text, Convert.ToInt32(numericUpDown6.Value), Convert.ToDouble(numericUpDown7.Value), Convert.ToInt32(numericUpDown8.Value), Convert.ToDouble(numericUpDown9.Value), Convert.ToInt32(numericUpDown10.Value));
                company.AddAirplane(specAirplane.Name, specAirplane);
                specAirplane.SetQuality();
                company.LoadData(company.GetAirplaneDictionary(), dataGridView2);
            }
          
        }
        // удаление объекта класса в листе и отображение в datagridview
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                company.GetAirplaneList().RemoveAt(index);
                company.LoadData(company.GetAirplaneList(), dataGridView1);
            }
        }
        // удаление объекта класса в словаре и отображение в datagridview
        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                company.GetAirplaneDictionary().Remove(dataGridView2.Rows[index].Cells[0].Value.ToString());
                company.LoadData(company.GetAirplaneDictionary(), dataGridView2);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SPZ_LB2
{
    public partial class Form1 : Form
    {
        static List<AutoShop> Shops = new List<AutoShop>();
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            table.Columns.Add("Название магазина", typeof(string));
            table.Columns.Add("Адрес магазина", typeof(string));
            table.Columns.Add("Количество отделов", typeof(int));
            table.Columns.Add("Количество сотрудников", typeof(int));
            table.Columns.Add("Средний доход магазина за месяц", typeof(decimal));
            table.Columns.Add("Общая з/п сотрудников", typeof(decimal));
            table.Columns.Add("Общие затраты на закупку товара", typeof(decimal));
            table.Columns.Add("Кол-во наименований товара", typeof(int));
            dataGridView1.DataSource = table;
        }

        private void button_enter_Click_1(object sender, EventArgs e)
        {
            string name;
            string adres;
            int n_dep;
            int n_emp;
            decimal avg_inc;
            decimal com_sal;
            decimal com_cost;
            int name_prod;
            bool error = false;
            if (!Regex.IsMatch(textBoxName.Text, @"^[а-яА-ЯA-za-z ]+$") || String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Название университета не может содержать цифры или быть пустой!", "Ошибка ввода",
                    MessageBoxButtons.OK);
                textBoxName.Clear();
                error = true;
            }
            if (String.IsNullOrEmpty(textBoxAddress.Text))
            {
                MessageBox.Show("Строка адреса не может быть пустой!", "Ошибка ввода",
                    MessageBoxButtons.OK);
                error = true;
                textBoxAddress.Clear();
            }
            if (!error)
            {
                name = textBoxName.Text;
                adres = textBoxAddress.Text;
                n_dep = Decimal.ToInt32(numericUpDownDep.Value);
                n_emp = Decimal.ToInt32(numericUpDownEmp.Value);
                avg_inc = numericInc.Value;
                com_sal = numericSal.Value;
                com_cost = numericCost.Value;
                name_prod = Decimal.ToInt32(numericProd.Value);
                AutoShop shop = new AutoShop(n_dep, n_emp, name, adres, avg_inc, com_sal, com_cost, name_prod);
                Shops.Add(shop);
                textBoxAddress.Clear();
                textBoxName.Clear();
                numericCost.Value = numericCost.Minimum;
                numericInc.Value = numericInc.Minimum;
                numericProd.Value = numericProd.Minimum;
                numericSal.Value = numericSal.Minimum;
                numericUpDownDep.Value = numericUpDownDep.Minimum;
                numericUpDownEmp.Value = numericUpDownEmp.Minimum;
            }
        }

        private void buttonInc_Click(object sender, EventArgs e)
        {
            if (Shops.Count > 0)
            {
                textBoxInc.Text = Shops[Shops.Count - 1].Incom().ToString();
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Shops[Shops.Count - 1].Add_employee();
        }

        private void buttonRmv_Click(object sender, EventArgs e)
        {
            Shops[Shops.Count - 1].Rem_employee();
        }

        private void buttonNalog_Click(object sender, EventArgs e)
        {
           textBoxNlg.Text = Shops[Shops.Count - 1].Nalog().ToString();
        }

        private void buttonIndex1_Click(object sender, EventArgs e)
        {
            textBoxSal.Text = Shops[Shops.Count-1][200].ToString(); 
        }

        private void buttonIndex2_Click(object sender, EventArgs e)
        {
            textBoxIncom.Text = Shops[Shops.Count - 1][100].ToString();
        }

        private void buttonIndex3_Click(object sender, EventArgs e)
        {
            textBoxCost.Text = Shops[Shops.Count - 1][300].ToString();
        }

        private void buttonCmp_Click(object sender, EventArgs e)
        {
           textBoxCmp.Text = Shops[Shops.Count - 1].CompareTo(Shops[Shops.Count-2]).ToString();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            table.Clear();
            for (int i = 0; i < Shops.Count; i++) 
            {
                table.Rows.Add(Shops[i].Name, Shops[i].Adress, Shops[i].N_dep, Shops[i].N_emp, Shops[i].Avg_inc, Shops[i].Com_sal, Shops[i].Com_cost, Shops[i].Name_prod);
            }
            dataGridView1.DataSource = table;
        }

        
    }
}

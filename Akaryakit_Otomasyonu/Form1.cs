using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Akaryakit_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Data.accdb");
        int hak = 3; bool durum = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Yönetici Girişi...";
            this.AcceptButton = button1;
            this.CancelButton = button2;
            label4.Text = Convert.ToString(hak);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (hak != 0)
            {
                baglanti.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanici",baglanti);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text)
                    {
                        durum = true;
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.Show();
                        break;
                    }
                }
                if (durum == false)
                    hak--;
                baglanti.Close();
            }
            label4.Text = Convert.ToString(hak);
            if (hak == 0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş hakkı kalmadı!", "Akaryakıt Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }


        
    }
}

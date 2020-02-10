using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InsertGridview
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EEPVHHG;Initial Catalog=db_Eder;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            carregarLista();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                conn.Open();
                comando.CommandText = "INSERT INTO clientes(Nome, Telefone, Endereco, CEP, Sexo,Idade)VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "')";
                comando.ExecuteNonQuery();
                conn.Close();
                carregarLista();
                textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
            }          
         
        }
        private void carregarLista()
        {
            listBox1.Items.Clear(); listBox2.Items.Clear(); listBox3.Items.Clear(); listBox4.Items.Clear(); listBox5.Items.Clear(); listBox6.Items.Clear(); listBox7.Items.Clear();
            conn.Open();
            comando.CommandText = "SELECT*FROM clientes";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[1].ToString());
                    listBox3.Items.Add(dr[2].ToString());
                    listBox4.Items.Add(dr[3].ToString());
                    listBox5.Items.Add(dr[4].ToString());
                    listBox6.Items.Add(dr[5].ToString());
                    listBox7.Items.Add(dr[6].ToString());
                }
            }
            conn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Cadastro VALUES(@Email,@Nome, @Senha, @Telefone, @CPF)";

            sqlCommand.Parameters.AddWithValue ("@Email", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Senha", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@Telefone", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@CPF", maskedTextBox2.Text);

            sqlCommand.ExecuteNonQuery();
            //MessageBox.Show(textBox1.Text + "\n" + textBox3.Text + "\n" + textBox2.Text + "\n" + maskedTextBox1.Text + "\n" + maskedTextBox2.Text,
            //                 "Cadastro Realizado",
            //                  MessageBoxButtons.OK,
            //                  MessageBoxIcon.Information


            //        );
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

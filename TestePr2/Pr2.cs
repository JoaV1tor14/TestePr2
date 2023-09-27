using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestePr2
{
    public partial class Form1 : Form
    {
        private int ID; 
    
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            lv.Items.Clear();

            Conexao conn = new Conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro";
            // conexão com o sql 
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    int id = (int)dr["ID"];
                    string name = (string)dr["Nome"];
                   
                    string tel = (string)dr["Telefone"];
                   

                    ListViewItem lv = new ListViewItem(id.ToString());
                    lv.SubItems.Add(name);
                    
                    lv.SubItems.Add(tel);
                    
                    
                   this.lv.Items.Add(lv);

                }
                dr.Close();
                //mostrar as infermações no banco
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Cadastro VALUES(@Email, @Senha, @CPF,@Telefone,@Nome)";

            sqlCommand.Parameters.AddWithValue ("@Email", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Senha", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@Telefone", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@CPF", maskedTextBox2.Text);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Cadastrado com sucesso","AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

            UpdateListView();

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
          UpdateListView();
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

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"Update Cadastro SET
           Email = @Email, 
           Nome = @Nome,
           Semha = @Senha,
           Telefone = @Telefone,
           Cpf = @CPF      
           WHERE Id = @ID";

       

            //@"INSERT INTO Cadastro VALUES(@Email, @Senha, @CPF,@Telefone,@Nome)";

            sqlCommand.Parameters.AddWithValue("@Email", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@Nome", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Senha", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@Telefone", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@CPF", maskedTextBox2.Text);
            sqlCommand.Parameters.AddWithValue("@ID", ID);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Atualizado com sucesso", "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

            UpdateListView();
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = lv.FocusedItem.Index;
            ID = int.Parse(lv.Items[index].SubItems[0].Text);
            textBox3.Text = lv.Items[index].SubItems[1].Text;
            textBox1.Text = lv.Items[index].SubItems[2].Text;
            textBox2.Text = lv.Items[index].SubItems[3].Text;
            maskedTextBox1.Text = lv.Items[index].SubItems[4].Text;
            maskedTextBox2.Text = lv.Items[index].SubItems[5].Text;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Conexao connection = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection= connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Cadastro WHERE Id = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();

                UpdateListView();
            }

        }
    }
}

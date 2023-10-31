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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

            UserDAO userDAO = new UserDAO();
            List<User> usuarios = userDAO.SelectUser();
            try
            {
                foreach (User user in usuarios)
                {
                    ListViewItem lv = new ListViewItem(user.Id.ToString());
                    lv.SubItems.Add(user.email);
                    lv.SubItems.Add(user.Name);
                    lv.SubItems.Add(user.senha);
                    lv.SubItems.Add(user.Telephone);
                    lv.SubItems.Add(user.Cpf);


                    this.lv.Items.Add(lv);


                }


                //mostrar as infermações no banco
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //vriar obj da classe user
                User user = new User(textBox1.Text, textBox3.Text, textBox2.Text, maskedTextBox1.Text, maskedTextBox2.Text);

                UserDAO nomeobj = new UserDAO();
                nomeobj.InsertUser(user);

                MessageBox.Show("Cadastrado com sucesso", "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }


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
           Senha = @Senha,
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

            UserDAO obj = new UserDAO();
            obj.DeleteUsuario(ID);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();

            UpdateListView();


        }
    }
}

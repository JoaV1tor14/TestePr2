﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TestePr2
{
    internal class UserDAO




    {
        public bool LoginUser(string usuario, string senha)
        {

            Conexao conn = new Conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro WHERE Nome = @usuario AND  Senha = @senha ";
            // conexão com o sql 

            sqlCom.Parameters.AddWithValue("@usuario", usuario);
            sqlCom.Parameters.AddWithValue("@senha", senha);

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    return true;
                }

                dr.Close();
               


            }
            catch (Exception err)
            {
                throw new Exception(
                    "Erro na leitura dos dados. \n" +
                     err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return false;
        }
        public List<User> SelectUser()
        {

            Conexao conn = new Conexao();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Cadastro";
            // conexão com o sql 

            List<User> usuarios = new List<User>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    User objeto = new User(
                    (int)dr["ID"],
                     (string)dr["Email"],
                     (string)dr["Nome"],
                     (string)dr["Senha"],
                     (string)dr["Telefone"],
                     (string)dr["CPF"]
                    );


                    usuarios.Add(objeto);
                }
                dr.Close();



            }
            catch (Exception err)
            {
                throw new Exception(
                    "Erro na leitura dos dados. \n" +
                     err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return usuarios;
        }
        public void InsertUser(User user)
        {
            Conexao conexao = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = conexao.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Cadastro VALUES(@Email,@Nome, @Senha, @CPF,@Telefone,)";

            sqlCommand.Parameters.AddWithValue("@Email", user.email);
            sqlCommand.Parameters.AddWithValue("@Nome", user.Name);
            sqlCommand.Parameters.AddWithValue("@Senha", user.senha);
            sqlCommand.Parameters.AddWithValue("@Telefone", user.Telephone);
            sqlCommand.Parameters.AddWithValue("@CPF", user.Cpf);

            sqlCommand.ExecuteNonQuery();
        }

        public void DeleteUsuario(int ID)
        {
            Conexao connection = new Conexao();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
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
            }


        }
    }
}



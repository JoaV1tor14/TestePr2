using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePr2
{
    internal class User
    {



        private int _id;
        private string _email;
        private string _name;
        private string _senha;
        private string _telefone;
        private string _cpf;

        public User(string Email,
                       string Nome,
                       string Senha,
                       string Telefone,
                       string CPF)
        {
            _email = Email;
            Name = Nome;
            _senha = Senha;
            Telephone = Telefone;
            Cpf = CPF;


        }
        public User(int ID, string Email,
                    string Nome,
                    string Senha,
                    string Telefone,
                    string CPF)
        {
            Id = ID;    
            _email = Email;
            Name = Nome;
            _senha = Senha;
            Telephone = Telefone;
            Cpf = CPF;


        }

        //Propriedades
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Nome está vazio");

                _name = value;
            }
            get { return _name; }
        }
        public string email
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("email está vazio");
                _email = value;
            }
            get { return _email; }
        }
        public string Cpf
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("CPF está vazio");
                _cpf = value;
            }
            get { return _cpf; }
        }
        public string senha
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Senha está vazio");
                _senha = value;
            }
            get { return _senha; }
        }
        public string Telephone
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Telefone está vazio");
                _telefone = value;
            }
            get { return _telefone; }
        }

    }
}



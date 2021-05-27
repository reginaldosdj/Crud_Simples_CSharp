using System;
using System.Collections.Generic;
using System.Text;
using ProjetoRegis.DAL;
namespace ProjetoRegis.Modelo
{
    class Controller
    {
        public bool acessar = false;
        public string msg = "";
        public bool Acessar(string login, string senha)
        {
            LoginDAL LoginDAO = new LoginDAL();
            acessar = LoginDAO.verificarLogin(login, senha);
            if (!LoginDAO.msg.Equals(""))
            {
                this.msg = LoginDAO.msg;
            }
            return acessar;
        }

        public String Cadastrar(string email, string senha, string confirmarsenha)
        {
            LoginDAL LoginDAO = new LoginDAL();
            this.msg = LoginDAO.cadastrar(email, senha, confirmarsenha);
            if (LoginDAO.verificar)
            {
                this.acessar = true;
            }
            return msg;
        }
    }
}

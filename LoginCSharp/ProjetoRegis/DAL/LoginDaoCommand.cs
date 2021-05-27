using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoRegis.DAL
{
    class LoginDAL
    {
        public bool verificar = false;
        public string msg = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            cmd.CommandText = "SELECT * FROM logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    verificar = true;
                }
                con.Desconectar();
                dr.Close();
            }
            catch (SqlException)
            {

                this.msg = "Erro com banco de dados!";
            }

            return verificar;
        }

        public String cadastrar(String email, String senha, String confirmarSenha)
        {
            verificar = false;
            if (senha.Equals(confirmarSenha))
            {
                cmd.CommandText = "INSERT INTO logins values (@e,@s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);
                try
                {
                    cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();
                    con.Desconectar();
                    this.msg = "Cadastrado com sucesso!";
                    verificar = true;
                }
                catch (SqlException)
                {

                    this.msg = "Erro com Banco de dados!";
                }
            }
            else
            {
                this.msg = "Senhas não são iguais!";
            }
            return msg;
        }
    }
}

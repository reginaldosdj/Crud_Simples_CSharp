using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ProjetoRegis.DAL
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();
        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-KQTT09C\SQLEXPRESS;Initial Catalog=ProjetoLogin;Integrated Security=True";
        }
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

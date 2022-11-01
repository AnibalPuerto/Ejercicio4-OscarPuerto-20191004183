using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BD_Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> InicioSesion(string Correo, string Contraseña)
        {
            bool verificar = false;
            try { 
            string sql = "SELECT 1 FROM loginusuario WHERE Correo=@Correo AND Contraseña=@Contraseña;";

            using (MySqlConnection _conexion_Ejercicio = new MySqlConnection(CadenaConexion.Cadena))
            {
                await _conexion_Ejercicio.OpenAsync();
                using (MySqlCommand comando = new MySqlCommand(sql, _conexion_Ejercicio))
                {
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = Correo;
                    comando.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 45).Value = Contraseña;
                    verificar = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                }

            }

        }
            catch (Exception ex)
            {

                throw;
            }
    return verificar;
   }
 }
}

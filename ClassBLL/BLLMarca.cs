using ClassDAL;
using ClassEntidadesTaller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBLL
{
    public class BLLMarca
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=tallermecanico; Uid=root; SSL Mode=None;");

        public List<Marca> ListaMarcas(ref string msj)
        {
            List<Marca> lista = new List<Marca>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from marca order by Marca";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Marca()
                    {
                        idMarc = (int)contAtrapa[0],
                        marca = contAtrapa[1].ToString()
                    }) ;
                }
                cn3.Close();
                cn3.Dispose();
            }
            else
            {
                if (contAtrapa != null && contAtrapa.IsClosed)
                {
                    msj = msj + ", Esta cerrado el data reader";

                }
                lista = null;
            }
            return lista;
        }
    }
}

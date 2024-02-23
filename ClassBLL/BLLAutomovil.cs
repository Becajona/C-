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
    public class BLLAutomovil
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1;Port=3306;Database=tallersss;Uid=root;Pwd=;SslMode=None;");


        public Boolean InsertaAutomovil(Automovil nuevo, ref string msj/*, ref string senten*/)
        {
            Boolean salida = false;
            string insercion = "Insert into automovil(modelo, marca, año, color, placas, estado)" +
                " values('" + nuevo.modelo + "','" + nuevo.fkmarca + "','" + nuevo.año + "','" + nuevo.color + "','" + nuevo.placas + "','" + nuevo.estado + "');";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDB(insercion, cn3, ref msj);
            return salida;
        }

        public Boolean InsertaAutomovilSeguro(Automovil nuevo, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into automovil(modelo, marca, año, color, placas, estado)" +
                " values(@modelo, @fkmarca,@año, @color, @placas, @estado);";
            //hay que declarar los parametros dela sentencia
            List<MySqlParameter>listap= new List<MySqlParameter>();

            MySqlParameter par1 = new MySqlParameter("modelo", MySqlDbType.VarChar, 110);
            MySqlParameter par2 = new MySqlParameter("fkmarca", MySqlDbType.Int32);

            listap.Add(par1);
            listap.Add(par2);
            listap.Add(new MySqlParameter("año",MySqlDbType.Int32));
            listap.Add(new MySqlParameter("color", MySqlDbType.VarChar,100));
            listap.Add(new MySqlParameter("placas", MySqlDbType.VarChar,15));
            listap.Add(new MySqlParameter("estado", MySqlDbType.VarChar, 45));

            //asignacion de valores a los parametros que ya estan en la lista
            listap[0].Value= nuevo.modelo;
            listap[1].Value = nuevo.fkmarca;
            listap[2].Value = nuevo.año;
            listap[3].Value = nuevo.color;
            listap[4].Value = nuevo.placas;
            listap[5].Value = nuevo.estado;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj,listap);
            return salida;

        }
        public List<Automovil> ListarAutomovil(ref string msj)
        {
            List<Automovil> lista = new List<Automovil>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from automovil";
            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            contAtrapa = obj1.ConsultaDR(consulta, cn3, ref msj);
            if (contAtrapa != null && !contAtrapa.IsClosed)
            {
                while (contAtrapa.Read())
                {
                    lista.Add(new Automovil()
                    {
                        IdAuto = (int)contAtrapa[0],
                        modelo = (string)contAtrapa[1].ToString(),
                        fkmarca = (int)contAtrapa[2],
                        año = (int)contAtrapa[3],
                        color = (string)contAtrapa[4].ToString(),
                        placas = (string)contAtrapa[5].ToString(),
                        estado = (string)contAtrapa[6].ToString(),
                    });
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

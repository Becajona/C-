using ClassDAL;
using ClassEntidadesTaller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassBLL
{
    public class BLLEntrada
    {
        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=tallermecanico; Uid=root; SSL Mode=None;");

        public Boolean InsertaEntrada(EntradaAuto nu, ref string msj)
        {
            Boolean salida = false;

            string insercion = "Insert into entradaauto(cliente, auto, fecha, extra, falla)" +
                " values(@fkCliente, @fkAuto,@fecha, @extra, @falla);";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();

            listEnt.Add(new MySqlParameter("fkCliente", MySqlDbType.Int32));
            listEnt.Add(new MySqlParameter("fkAuto", MySqlDbType.Int32));
            listEnt.Add(new MySqlParameter("fecha", MySqlDbType.Date));
            listEnt.Add(new MySqlParameter("extra", MySqlDbType.VarChar, 100));
            listEnt.Add(new MySqlParameter("falla", MySqlDbType.VarChar, 45));

            //asignacion de valores a los parametros que ya estan en la lista
            listEnt[0].Value = nu.fkCliente;
            listEnt[1].Value = nu.fkAuto;
            listEnt[2].Value = nu.fecha;
            listEnt[3].Value = nu.extra;
            listEnt[4].Value = nu.falla;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(insercion, cn3, ref msj, listEnt);
            return salida;

        }
        public DataTable MostrarEntradaTabla(ref string msj)
        {
            string consulta = "select * from entradaauto";
            MySqlConnection cna = null;
            DataSet dsAtrapa = null;
            DataTable dtSalida = null;
            cna = obj1.conectarDB(ref msj);
            dsAtrapa = obj1.ConsultaDataSet(consulta, cna, ref msj);
            if (dsAtrapa != null)
            {
                dtSalida = dsAtrapa.Tables[0];
            }
            else
            {
                dtSalida = null;
            }

            return dtSalida;

        }
        public Boolean EliminarEntradaPorId(EntradaAuto id, ref string msj)
        {
            Boolean salida = false;

            string eliminacion = "DELETE FROM entradaauto WHERE idEntradaAuto = @IdEntrada";

            List<MySqlParameter> listEnt = new List<MySqlParameter>();
            listEnt.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32));
            listEnt[0].Value = id.IdEntrada;

            MySqlConnection cn3 = null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDBseguro(eliminacion, cn3, ref msj, listEnt);
            return salida;
        }

        public void ActualizarEntrada(EntradaAuto entrada, ref string mensaje)
        {

            string actualizacion = "UPDATE entradaauto SET cliente = @Cliente, auto = @Auto, extra = @Extra, falla = @Falla WHERE idEntradaAuto = @IdEntrada";
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("Cliente", MySqlDbType.Int32) { Value = entrada.fkCliente });
            parametros.Add(new MySqlParameter("Auto", MySqlDbType.Int32) { Value = entrada.fkAuto });
            parametros.Add(new MySqlParameter("Extra", MySqlDbType.VarChar, 100) { Value = entrada.extra });
            parametros.Add(new MySqlParameter("Falla", MySqlDbType.VarChar, 45) { Value = entrada.falla });
            parametros.Add(new MySqlParameter("IdEntrada", MySqlDbType.Int32) { Value = entrada.IdEntrada });

            MySqlConnection conexion = obj1.conectarDB(ref mensaje);
            bool exito = obj1.ModificarDBseguro(actualizacion, conexion, ref mensaje, parametros);

            if (exito)
            {
                mensaje = "La entrada se actualizó correctamente.";
            }
            else
            {
                mensaje = "Hubo un error al actualizar la entrada.";
            }
        }


    }
}

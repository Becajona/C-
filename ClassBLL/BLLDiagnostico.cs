using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClassBLL;
using ClassDAL;
using ClassEntidadesTaller;
using System.Data;

namespace ClassBLL
{
    class BLLDiagnostico
    {
        private string cadenaConexion = "Server=127.0.0.1; Port=3306; Database=tallersss; Uid=root SSL Mode=None;";

        public object asignaid { get; private set; }
        public object diagnostico { get; private set; }

        public bool InsertarDiagnostico(BLLDiagnostico diagnostico, ref string mensaje)
        {
            try
            {
                DALMysql dal = new DALMysql(cadenaConexion);

                string consulta = $"INSERT INTO diagnostico (asignaid, diagnostico, refacciones,CostoAprox,Extra) VALUES ({diagnostico.asignaid}, {diagnostico.diagnostico}')";

                MySqlConnection conexion = dal.conectarDB(ref mensaje);
                if (conexion != null)
                {
                    bool exito = dal.ModificarDBseguro(consulta, conexion, ref mensaje);
                    conexion.Close();
                    return exito;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error en la inserción: " + ex.Message;
                return false;
            }
        }

        public DataTable ObtenerDiagnostico(ref string mensaje)
        {
            try
            {
                DALMysql dal = new DALMysql(cadenaConexion);

                string consulta = "select * from diagnostico";

                MySqlConnection conexion = dal.conectarDB(ref mensaje);
                if (conexion != null)
                {
                    DataSet dataSet = dal.ConsultaDS(consulta, conexion, ref mensaje);
                    conexion.Close();

                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        return dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al obtener los diagnosticos: " + ex.Message;
            }

            return new DataTable();
        }

        public bool EliminarDiagnostico(int iddiagnostico, ref string mensaje)
        {
            try
            {
                DALMysql dal = new DALMysql(cadenaConexion);

                string consulta = $"delete from diagnostico WHERE iddiagnostico = {iddiagnostico}";

                MySqlConnection conexion = dal.conectarDB(ref mensaje);
                if (conexion != null)
                {
                    bool exito = dal.ModificarDBseguro(consulta, conexion, ref mensaje);
                    conexion.Close();
                    return exito;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al eliminar el diagnostico: " + ex.Message;
                return false;
            }
        }

        public bool ActualizarDiagnostico(BLLDiagnostico diagnostico, ref string mensaje)
        {
            try
            {
                DALMysql dal = new DALMysql(cadenaConexion);

                string consulta = $"UPDATE asigna SET asignaid = {diagnostico.asignaid}, diagnostico = {diagnostico.diagnostico}";

                MySqlConnection conexion = dal.conectarDB(ref mensaje);
                if (conexion != null)
                {
                    bool exito = dal.ModificarDBseguro(consulta, conexion, ref mensaje);
                    conexion.Close();
                    return exito;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar la asignación: " + ex.Message;
                return false;
            }
        }
    }
}

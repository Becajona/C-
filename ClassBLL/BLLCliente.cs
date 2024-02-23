using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using MySql.Data.MySqlClient;
using ClassEntidadesTaller;
using System.Data;


namespace ClassBLL
{
    public class BLLCliente
    {
        //regla para comprobar la conexiona la DB

        DALMysql obj1 = new DALMysql("Server=127.0.0.1; port=3306; DataBase=tallermecanico; Uid=root; SSL Mode=None;");
        public string ProbarConexionMysql()
        {
            string cadmsj = "";
            obj1.conectarDB(ref cadmsj);
            return cadmsj;
        }
        public Boolean InsertaCliente(Cliente nuevo, ref string msj)
        {
            Boolean salida=false;
            string insercion = "Insert into cliente(Nombre, App, Apm, Celular, TelOficina, CorreoPer, CorreoCorp)" +
                " values('" + nuevo.Nombre + "','" + nuevo.App + "','" + nuevo.Apm + "','" + nuevo.Celular + "','" + nuevo.TelOficina + "','" + nuevo.CorreoPer + "','" + nuevo.CorreoCorp + "');";
            MySqlConnection cn3=null;
            cn3 = obj1.conectarDB(ref msj);
            salida = obj1.ModificarDB(insercion, cn3, ref msj);
            return salida;
        }
        public List<Cliente> ListaClientes(ref string msj)
        {
            List<Cliente> lista=new List<Cliente>();
            MySqlDataReader contAtrapa = null;
            string consulta = "select * from cliente";
            MySqlConnection cn3 = null;
            cn3=obj1.conectarDB(ref msj);
            contAtrapa= obj1.ConsultaDR(consulta,cn3, ref msj);
            if(contAtrapa!=null && !contAtrapa.IsClosed)
            {
                while(contAtrapa.Read())
                {
                    lista.Add(new Cliente()
                    {
                        IdCliente = (int)contAtrapa[0],
                        Nombre = (string)contAtrapa[1].ToString(),
                        App = (string)contAtrapa[2].ToString(),
                        Apm = (string)contAtrapa[3].ToString(),
                        Celular = (string)contAtrapa[4].ToString(),
                        TelOficina = (string)contAtrapa[5].ToString(),
                        CorreoPer = (string)contAtrapa[6].ToString(),
                        CorreoCorp = (string)contAtrapa[7].ToString(),
                    });
                }
                cn3.Close();
                cn3.Dispose();
            }
            else
            {
                if(contAtrapa!=null&& contAtrapa.IsClosed)
                {
                    msj = msj + ", Esta cerrado el data reader";
                    
                }     
                    lista = null;
            }
            return lista;
        }



        public DataTable MostrarClientesTabla(ref string msj)
        {
            string consulta = "select * from cliente";
            MySqlConnection cna = null;
            DataSet dsAtrapa = null;
            DataTable dtSalida = null;
            cna = obj1.conectarDB(ref msj);
            dsAtrapa = obj1.ConsultaDataSet(consulta, cna,ref msj);
            if(dsAtrapa !=null)
            {
                dtSalida = dsAtrapa.Tables[0];
            }
            else
            {
                dtSalida = null;
            }

            return dtSalida;   
            
        }

        public DataSet BdVirtual (ref string msj)
        {
            DataSet tdbd = new DataSet();
            MySqlConnection cna6 = null;
            cna6 = obj1.conectarDB(ref msj);
            if(obj1.MultiplesConsultasDS(tdbd,"Select * from cliente" ,cna6,"cliente",ref msj))
            {
                cna6 = obj1.conectarDB(ref msj);

                if(obj1.MultiplesConsultasDS(tdbd, "Select * from automovil", cna6, "automovil", ref msj))
                {
                    cna6 = obj1.conectarDB(ref msj);

                    if (obj1.MultiplesConsultasDS(tdbd, "Select * from marca", cna6, "marca", ref msj))
                    {
                        cna6 = obj1.conectarDB(ref msj);

                        obj1.MultiplesConsultasDS(tdbd, "Select * from entradaauto", cna6, "entradaauto", ref msj);

                    }
                }
            }


            return tdbd;

        }



    }
}

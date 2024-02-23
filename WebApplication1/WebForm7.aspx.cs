using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm7 : System.Web.UI.Page
    {

        private Class.BLLDiagnostico bllDiagnostico = new BLLDiagnostico();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDiagnosticos();
            }
        }

        private void CargarDiagnosticos()
        {
            string mensaje = "";
            GridView1.DataSource = bllDiagnostico.ObtenerDiagnostico(ref mensaje);
            GridView1.DataBind();
        }

        protected void EliminarDiagnostico(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int idDiagnostico = Convert.ToInt32(btnEliminar.CommandArgument);

            string mensaje = "";
            if (bllDiagnostico.EliminarDiagnostico(idDiagnostico, ref mensaje))
            {
                LabelEliminar.Text = "Diagnóstico eliminado correctamente.";
            }
            else
            {
                LabelEliminar.Text = "Error al eliminar el diagnóstico: " + mensaje;
            }

            CargarDiagnosticos();
        }

        protected void ActualizarDiagnostico(object sender, EventArgs e)
        {
            Button btnActualizar = (Button)sender;
            int idDiagnostico = Convert.ToInt32(btnActualizar.CommandArgument);

            Response.Redirect("ActualizarDiagnostico.aspx?id=" + idDiagnostico);
        }

        protected void NuevoDiagnostico(object sender, EventArgs e)
        {
            Response.Redirect("CrearDiagnostico.aspx");
        }
    }
}
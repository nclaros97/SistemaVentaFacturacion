using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGICA.LFacturacion;

namespace SistemaVentaFacturacion.Inventario
{
    public partial class FormListaInventario : Form
    {
        public FormListaInventario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text.Equals("Buscar"))
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Equals(""))
            {
                txtBuscar.Text = "Buscar";
                txtBuscar.ForeColor = SystemColors.GrayText;
            }
        }
        
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FormListaInventario_Load(object sender, EventArgs e)
        {
            GridInventario.DataSource = scriptFacturacion.getDataInventario();
        }
    }
}

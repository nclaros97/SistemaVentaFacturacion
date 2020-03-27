using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaFacturacion
{
    public partial class FormLogin : Form
    {
        public bool estado = false;
        public bool c = true;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogo_Load(object sender, EventArgs e)
        {
            FormMenuPrincipal frm = Owner as FormMenuPrincipal;
            frm.cerrar = c;
            frm.isLogin = true;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            if (txtUsuario.Text.Equals("nclaros") && txtPass.Text.Equals("1997"))
            {
                
                FormMenuPrincipal frm = Owner as FormMenuPrincipal;
                frm.sesion = true;
                frm.cerrar = false;
                frm.isLogin = false;
                this.Close();
            }
            else
            {
                FormMenuPrincipal frm = Owner as FormMenuPrincipal;
                frm.sesion = false;
                frm.cerrar = false;
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal frm = Owner as FormMenuPrincipal;
            frm.sesion = true;
            frm.cerrar = c;
            this.Close();
            Application.Exit();
        }
    }
}

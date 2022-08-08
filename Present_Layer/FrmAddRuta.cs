using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic_Layer;
using Entity_Layer;

namespace Present_Layer
{
    public partial class FrmAddRuta : Form
    {
        Tools_Rutas tools = new Tools_Rutas();
        private bool Edit = false;
        static Entity entity = new Entity();
        private string idRoute = entity.Id;

        public FrmAddRuta()
        {
            InitializeComponent();
        }

        private void FrmAddRuta_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //To Create on Click Save
            if (Edit==false)
            {
                if (tbxAddRutas.Text != "" )
                {
                    try
                    {

                        tools.Create_Routes(tbxAddRutas.Text);
                        MessageBox.Show("se creó correctamente");
                        LoadDgv();
                        ClearFrm();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("No se pudieron insertar los datos por:" + x);
                    }

                }
                else
                {
                    MessageBox.Show("Asegurese de llenar todos los campos correctamente");
                }


                //To Edit on Click Save
                if (Edit == true)
                {
                    try
                    {

                        tools.Edit_Routes(tbxAddRutas.Text, idRoute);
                        MessageBox.Show("Se editó correctamente");
                        Edit = false;
                        LoadDgv();
                        ClearFrm();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("No se pudieron editar los datos por:" + x);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count > 0)
            {
                Edit = true;

                tbxAddRutas.Text = dgvRoutes.CurrentRow.Cells["Nombre_ruta"].Value.ToString();
                idRoute = dgvRoutes.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvRoutes.SelectedRows.Count > 0)
            {
                idRoute = dgvRoutes.CurrentRow.Cells["Id"].Value.ToString();
                tools.Delete_Routes(idRoute);
                MessageBox.Show("Se ha eliminado correctamente");
                LoadDgv();
                ClearFrm();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila primero,\npor favor");
            }

        }

        //Methods: 

        //for Load DataGrid
        private void LoadDgv()
        {
            Tools_Rutas tool = new Tools_Rutas();
            dgvRoutes.DataSource = tool.ViewAllRoutes();
        }

        
        public void ClearFrm()
        {
            tbxAddRutas.Text = "";
        }
    }
}

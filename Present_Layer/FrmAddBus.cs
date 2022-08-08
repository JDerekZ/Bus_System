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
    public partial class FrmAddBus : Form
    {

        Tools_Buses tools = new Tools_Buses();
        private bool Edit = false;
        static Entity entity = new Entity();
        private string idBus = entity.Id;


        public FrmAddBus()
        {
            InitializeComponent();
        }

        private void FrmAddBus_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        //Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            string brand_status = entity.Brand_status = cbxBrand.SelectedItem.ToString();
            string color_status = entity.Color_status = cbxColor.SelectedItem.ToString();

            //To Create on Click Save
            if (Edit == false)
            {

                if (tbxModel.Text != "" && brand_status !="" && tbxPlate.Text !="" && color_status != "" && tbxYear.Text != "")
                {
                    try
                    {

                        tools.Create_Buses(brand_status, tbxModel.Text, tbxPlate.Text, color_status, tbxYear.Text);
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
                };               
                
            }

            //To Edit on Click Save
            if (Edit == true)
            {

                try
                {
                    tools.Edit_Buses(brand_status, tbxModel.Text, tbxPlate.Text, color_status, tbxYear.Text, idBus);
                    MessageBox.Show("Se editó correctamente");
                    Edit = false;
                    LoadDgv();
                    ClearFrm();
                }
                catch (Exception x)
                {
                    MessageBox.Show("No se pudo editar los datos correctamente por:" + x); ;
                }
            
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dgvBuses.SelectedRows.Count > 0)
            {
                Edit = true;
                cbxBrand.Text = dgvBuses.CurrentRow.Cells["Marca"].Value.ToString();
                tbxModel.Text = dgvBuses.CurrentRow.Cells["Modelo"].Value.ToString();
                tbxPlate.Text = dgvBuses.CurrentRow.Cells["Placa"].Value.ToString();
                cbxColor.Text = dgvBuses.CurrentRow.Cells["Color"].Value.ToString();
                tbxYear.Text = dgvBuses.CurrentRow.Cells["Año"].Value.ToString();
                idBus = dgvBuses.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            };

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBuses.SelectedRows.Count > 0)
            {
                idBus = dgvBuses.CurrentRow.Cells["Id"].Value.ToString();
                tools.Delete_Buses(idBus);
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
            Tools_Buses tool = new Tools_Buses();
            dgvBuses.DataSource = tool.ViewAllBuses();
        }

        //for Clear Frm
        private void ClearFrm()
        {
            tbxModel.Text = "";
            tbxPlate.Text = "";
            tbxYear.Text = "";
            cbxBrand.SelectedItem = "";
            cbxColor.SelectedItem = "";
        }

    }

}

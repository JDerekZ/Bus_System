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
    public partial class FrmAddChofer : Form
    {

        Tools_Chofer tools = new Tools_Chofer();
        private bool Edit = false;
        static Entity entity = new Entity();
        private string idChofer = entity.Id;


        public FrmAddChofer()
        {
            InitializeComponent();
        }

        private void FrmAddChofer_Load(object sender, EventArgs e)
        {
            LoadDgv();
            LoadCbxBus();
            LoadCbxRoute();
            
        }

        //Events On_Click
        private void btnSave_Click(object sender, EventArgs e)
        {            

            string status_Bus_Assigment = cbxAllBuses.SelectedValue.ToString();//OJO MODIFICAR, INFORMACÍON ESTÁTICA.
            string status_routes_Assigment = cbxAllRoutes.SelectedValue.ToString();

            

            //To Create a New Chofer
            if (Edit == false)
            {

                //To find a register and check if it can be created
                    if (cbxAllBuses.Text != "" && cbxAllRoutes.Text != "" && tbxLastName.Text != "" && tbxLastName.Text != "" && tbxIdCard.Text != "")
                    {
                        
                        
                        try
                        {

                            tools.Create_Chofer(Convert.ToInt32(status_Bus_Assigment), Convert.ToInt32(status_routes_Assigment), tbxName.Text, tbxLastName.Text, dtpFecha_N.Value, tbxIdCard.Text);
                            MessageBox.Show("se creó correctamente");
                            LoadDgv();
                            ClearFrm();

                        }
                        catch (Exception x)
                        {

                            MessageBox.Show("No se pudieron insertar los datos por:" + x);

                            //MessageBox.Show("Estoy conteniendo:\n" + status_Bus_Assigment);

                            //MessageBox.Show("Tambien agarré esta wea:\n" + status_routes_Assigment);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de llenar todos los campos");
                    }
                

            }

            //To Edit on Click Save
            if (Edit == true)
            {

                //To find a register and check if it can be edited
                    if (cbxAllBuses.Text != "" && cbxAllRoutes.Text != "" && tbxLastName.Text != "" && tbxLastName.Text != "" && tbxIdCard.Text != "")
                    {
                            try
                            {
                                tools.Edit_Chofer(Convert.ToInt32(status_Bus_Assigment), Convert.ToInt32(status_routes_Assigment), tbxName.Text, tbxLastName.Text, dtpFecha_N.Value, tbxIdCard.Text, idChofer);
                                MessageBox.Show("Se editó correctamente");
                                Edit = false;
                                LoadDgv();
                                ClearFrm();
                            }
                            catch (Exception x)
                            {
                                MessageBox.Show("No se pudo editar los datos correctamente por:" + x);
                            }                                                 

                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de llenar todos los campos\npara poder editar");
                    }
                

            }

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvChoferes.SelectedRows.Count > 0)
            {
                Edit = true;

                cbxAllBuses.Text = dgvChoferes.CurrentRow.Cells["IdBus"].Value.ToString();
                cbxAllRoutes.Text = dgvChoferes.CurrentRow.Cells["IdRuta"].Value.ToString();
                tbxName.Text = dgvChoferes.CurrentRow.Cells["Nombre"].Value.ToString();
                tbxLastName.Text = dgvChoferes.CurrentRow.Cells["Apellido"].Value.ToString();
                dtpFecha_N.Text = dgvChoferes.CurrentRow.Cells["Fecha_nacimiento"].Value.ToString();
                tbxIdCard.Text = dgvChoferes.CurrentRow.Cells["Cedula"].Value.ToString();
                idChofer = dgvChoferes.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvChoferes.SelectedRows.Count > 0)
            {
                idChofer = dgvChoferes.CurrentRow.Cells["Id"].Value.ToString();
                tools.Delete_Chofer(idChofer);
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
            Tools_Chofer tool = new Tools_Chofer();
            dgvChoferes.DataSource = tool.ViewAllChoferes();
        }

        //for Clear Frm
        private void ClearFrm()
        {
            //cbxAllBuses
            //cbxAllRoutes
            tbxName.Text = "";
            tbxLastName.Text = "";
            dtpFecha_N.ResetText();
            tbxIdCard.Text = "";
        }

        //for Load Comboboxes
        private void LoadCbxBus()
        {
            cbxAllBuses.DataSource = tools.LoadComboBus();
            cbxAllBuses.DisplayMember = "Placa";
            cbxAllBuses.ValueMember = "Id";
        }

        private void LoadCbxRoute()
        {
            cbxAllRoutes.DataSource = tools.LoadComboRoute();
            cbxAllRoutes.DisplayMember = "Nombre_ruta";
            cbxAllRoutes.ValueMember = "Id";
        }

        //private bool VerifyBuses(int bus)
        //{
        //    return tools.SearchBus(bus);
        //}

        //private bool VerifyRoutes(int route) 
        //{ 
        //    return tools.SearchRoute(route); 
        //}

        //private bool Verify(int bus, int route)
        //{
        //    return tools.Search(bus, route);
        //}
    }
}

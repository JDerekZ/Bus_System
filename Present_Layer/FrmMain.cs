using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Layer;
using Logic_Layer;

namespace Present_Layer
{
    public partial class FrmMain : Form
    {

        Tools_Chofer cD_Chofer = new Tools_Chofer();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void btnAddChofer_Click(object sender, EventArgs e)
        {
            FrmAddChofer frmChofer = new FrmAddChofer();
            frmChofer.ShowDialog();
        }

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            FrmAddBus frmAddBus = new FrmAddBus();
            frmAddBus.ShowDialog();
        }

        private void btnAddRuta_Click(object sender, EventArgs e)
        {
            FrmAddRuta frmAddRuta = new FrmAddRuta(); 
            frmAddRuta.ShowDialog();
        }




        //Methods
        private void LoadDgv()
        {
            Tools_Chofer tool = new Tools_Chofer();
            dgvInnerJoin.DataSource = tool.ViewInnerJoin();
        }
    }
}

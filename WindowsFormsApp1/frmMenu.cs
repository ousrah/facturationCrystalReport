using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstMedecins cr = new lstMedecins();
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            frmImpression f = new frmImpression(cr);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ficheMedecin cr = new ficheMedecin();
            string filtre = "{medecin.nom} like '*" + textBox1.Text + "*' or {medecin.prenom} like '*" + textBox1.Text + "*' ";
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            cr.SetParameterValue("chemin", Application.StartupPath + @"\photos\");
            frmImpression f = new frmImpression(cr,filtre);
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            etiquette cr = new etiquette();
             cr.SetDatabaseLogon("sa", "P@ssw0rd");
            frmImpression f = new frmImpression(cr);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            ConsultationsParPatients cr = new ConsultationsParPatients();
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            frmImpression f = new frmImpression(cr);
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            frmImpression f = new frmImpression(cr);
            f.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            facture cr = new facture();
            string filtre = "{commande.id_commande} = " + comboBox1.SelectedValue;
            cr.SetDatabaseLogon("sa", "P@ssw0rd");
            frmImpression f = new frmImpression(cr, filtre);
            f.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("data source=.\\sqlexpress2008;initial catalog=gestionCommercialHamza;user id=sa; password=P@ssw0rd");
            cn.Open();
            SqlCommand com = new SqlCommand("select * from commande", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DisplayMember = "id_Commande";
            comboBox1.ValueMember = "id_Commande";
            comboBox1.DataSource = dt;


        }
    }
}

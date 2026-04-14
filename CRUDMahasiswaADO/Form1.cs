using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public partial class Form1 : Form
    {
        // Variabel Koneksi
        private readonly SqlConnection conn;
        // PENTING: Ganti DESKTOP-RAM20FI\\APRILIYA dengan nama server SQL Anda!
        private readonly string connectionString = "Data Source=LAPTOP-VL5SDNPR\\GHATANHARDANNI; Initial Catalog=DBAkademikADO; Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            // Inisialisasi koneksi
            conn = new SqlConnection(connectionString);
        }

        // -------------------------------------------------------------
        // METHOD TAMBAHAN
        // -------------------------------------------------------------

        private void ConnectDatabase()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                MessageBox.Show("Koneksi berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtNIM.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            txtAlamat.Clear();
            txtKodeProdi.Clear();
            dtpTanggalLahir.Value = DateTime.Now;
            txtNIM.Focus();
        }

        // Event Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbJK.Items.Clear();
            cmbJK.Items.Add("L");
            cmbJK.Items.Add("P");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // PERBAIKAN: Baris ini wajib ada agar tabel bisa merespon saat diklik
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // -------------------------------------------------------------
        // EVENT BAWAAN (Dibiarkan kosong agar form design tidak error)
        // -------------------------------------------------------------

        private void label2_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }


        // -------------------------------------------------------------
        // EVENT TOMBOL CRUD
        // -------------------------------------------------------------

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }

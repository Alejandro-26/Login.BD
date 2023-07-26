
using System.Data.SqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // RUTA DE CONEXION

        SqlConnection conexion = new SqlConnection("server = LAPTOP-VFV4BV6O\\SQLEXPRESS; database = Empresa; integrated security = True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // METODO LIMPIAR
        public void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // CONSULTA DE CONEXION

            conexion.Open();
            string consulta = "select * from Usuario where Usuario = '"
                + textBox1.Text
                + "' and Contraseña = '"
                + textBox2.Text
                + "'";

            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                limpiar();
                Usuario Bienvenido = new Usuario();
                this.Hide();
                Bienvenido.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");

            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
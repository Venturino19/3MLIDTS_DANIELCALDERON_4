using System;
using System.IO; // Agregado para solucionar el error de File
using System.Windows.Forms;

namespace FormularioApp
{
    public partial class Form1 : Form
    {
        private TextBox tbNombre;
        private TextBox tbApellidos;
        private TextBox tbEdad;
        private TextBox tbEstatura;
        private TextBox tbTelefono;
        private RadioButton rbHombre;
        private RadioButton rbMujer;
        private Button btnGuardar;
        private Button btnBorrar;
        private GroupBox groupBoxGenero;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbNombre = new TextBox();
            this.tbApellidos = new TextBox();
            this.tbEdad = new TextBox();
            this.tbEstatura = new TextBox();
            this.tbTelefono = new TextBox();
            this.rbHombre = new RadioButton();
            this.rbMujer = new RadioButton();
            this.groupBoxGenero = new GroupBox();
            this.btnGuardar = new Button();
            this.btnBorrar = new Button();

            this.SuspendLayout();

            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(100, 20);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(200, 20);
            this.tbNombre.TabIndex = 0;

            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(100, 50);
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(200, 20);
            this.tbApellidos.TabIndex = 1;

            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(100, 80);
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(100, 20);
            this.tbEdad.TabIndex = 2;

            // 
            // tbEstatura
            // 
            this.tbEstatura.Location = new System.Drawing.Point(100, 110);
            this.tbEstatura.Name = "tbEstatura";
            this.tbEstatura.Size = new System.Drawing.Size(100, 20);
            this.tbEstatura.TabIndex = 3;

            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(100, 140);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(100, 20);
            this.tbTelefono.TabIndex = 4;

            // 
            // groupBoxGenero
            // 
            this.groupBoxGenero.Controls.Add(this.rbHombre);
            this.groupBoxGenero.Controls.Add(this.rbMujer);
            this.groupBoxGenero.Location = new System.Drawing.Point(100, 170);
            this.groupBoxGenero.Name = "groupBoxGenero";
            this.groupBoxGenero.Size = new System.Drawing.Size(200, 70);
            this.groupBoxGenero.TabIndex = 5;
            this.groupBoxGenero.TabStop = false;
            this.groupBoxGenero.Text = "Género";

            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Location = new System.Drawing.Point(10, 20);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(63, 17);
            this.rbHombre.TabIndex = 0;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.UseVisualStyleBackColor = true;

            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.Location = new System.Drawing.Point(10, 40);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(54, 17);
            this.rbMujer.TabIndex = 1;
            this.rbMujer.TabStop = true;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.UseVisualStyleBackColor = true;

            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 250);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(225, 250);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 7;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);

            // 
            // Formulario
            // 
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBoxGenero);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.tbEstatura);
            this.Controls.Add(this.tbEdad);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbNombre);
            this.Name = "Formulario";
            this.Text = "Formulario Vr.01";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = tbNombre.Text;
            string apellidos = tbApellidos.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;
            string genero = rbHombre.Checked ? "Hombre" : rbMujer.Checked ? "Mujer" : "";

            string datos = $"Nombres: {nombres}\n" +
                           $"Apellidos: {apellidos}\n" +
                           $"Edad: {edad} años\n" +
                           $"Estatura: {estatura}\n" +
                           $"Telefono: {telefono}\n" +
                           $"Genero: {genero}\n";

            File.WriteAllText("datos_formulario.txt", datos);

            MessageBox.Show("Los datos se han guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            rbHombre.Enabled = false;
            rbMujer.Enabled = false;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }

        //[STAThread]
        //static void Main()
        //{
          //  Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        //}
    }
}

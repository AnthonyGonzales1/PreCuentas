using PresupuestoCuentas.DAL;
using PresupuestoCuentas.Entidades;
using PresupuestoCuentas.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class PreCuentasDetalleForm : Form
    {
        public int RowSelected { get; set; }
        List<PreCuentasDetalle> Detalle = new List<PreCuentasDetalle>();
        PreCuentas preCuentas = new PreCuentas();

        public PreCuentasDetalleForm()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            Repositorio<Cuentas> repositorio = new Repositorio<Cuentas>(new Contexto());
            CuentacomboBox.DataSource = repositorio.GetList(c => true);
            CuentacomboBox.ValueMember = "CuentaId";
            CuentacomboBox.DisplayMember = "Descripcion";
        }

            private bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IdnumericUpDown, "Llenar Presupuesto Id");
                paso = true;
            }
            if (error == 2 && CuentacomboBox.Text == string.Empty)
            {
                errorProvider.SetError(CuentacomboBox,
                   "Debes seleccionar un Tipo de Cuenta");
                paso = true;
            }
            if (error == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox,
                   "Debes ingresar una Descripcion");
                paso = true;
            }
            if (error == 2 && ValortextBox.Text == string.Empty)
            {
                errorProvider.SetError(ValortextBox,
                    "Debes ingresar un Valor");
                paso = true;
            }

            return paso;
        }

        private void LlenarCampos()
        {
            //CuentacomboBox.Text = preCuentas.cun.ToString();
            DescripciontextBox.Text = preCuentas.Descripcion.ToString();
            FechadateTimePicker.Value = preCuentas.Fecha;
            ValortextBox.Text = preCuentas.Monto.ToString();
            foreach (var item in preCuentas.Detalle)
            {
                PresupuestodataGridView.Rows.Add(item.Id, item.PreCuentaId, item.Valor);
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;

        }
        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);
            return retorno;

        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Clear();
            ValortextBox.Clear();
            FechadateTimePicker.ResetText();
            //TipoPartidocomboBox.SelectedIndex = -1;
            CuentacomboBox.ResetText();
        }

        private PreCuentas Llenaclase()
        {
            //PreCuentas preCuentas = new PreCuentas();
            if (IdnumericUpDown.Value == 0)
            {
                preCuentas.PreCuentaId = 0;
            }
            else
            {
                preCuentas.PreCuentaId = Convert.ToInt32(IdnumericUpDown.Value);
            }

            preCuentas.Descripcion = DescripciontextBox.Text;
            preCuentas.Fecha = FechadateTimePicker.Value;
            preCuentas.Monto = Convert.ToInt32(ValortextBox.Text);
            
            return preCuentas;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("Llenar Campos vacios");
                errorProvider.Clear();
                return;
            }
            else
            {
                preCuentas = Llenaclase();
                if (IdnumericUpDown.Value == 0)
                {
                    if (BLL.PreCuentasBLL.Guardar(preCuentas))
                    {
                        MessageBox.Show("Guardado!", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Guardar!!");
                    }
                }
                else
                {
                    var result = MessageBox.Show("Seguro de Modificar?", "+Presupuesto Cuentas",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (BLL.PreCuentas.Modificar(Llenaclase()))
                        {
                            MessageBox.Show("Modificado!!");
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Guardar!!");
                        }
                    }
                }
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            List<PreCuentasDetalle> preCuentasDetalles = new List<PreCuentasDetalle>();
            if (Validar(2))
            {
                MessageBox.Show("Llene los Campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                preCuentas.Detalle.Add(new PreCuentasDetalle
                        (Convert.ToInt32(IdnumericUpDown.Value),
                        Convert.ToInt32(CuentacomboBox.Text),
                        Convert.ToDecimal(ValortextBox.Text),
                        Convert.ToInt32(DescripciontextBox.Text)
                        

                    ));

                //Cargar el detalle al Grid
                PresupuestodataGridView.DataSource = null;
                PresupuestodataGridView.DataSource = preCuentas.Detalle;
            }

        }

        private void Borrarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

        }
    }
}

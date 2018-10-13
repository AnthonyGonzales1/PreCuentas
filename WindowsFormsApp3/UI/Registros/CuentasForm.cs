using PresupuestoCuentas.DAL;
using PresupuestoCuentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresupuestoCuentas.UI.Registros
{
    public partial class CuentasForm : Form
    {
        Cuentas cuentas = new Cuentas();
        public CuentasForm()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private Cuentas LlenaClase()
        {
            Cuentas cuentas = new Cuentas();
            if (IdnumericUpDown.Value == 0)
            {
                cuentas.CuentaId = 0;
            }
            else
            {
                cuentas.CuentaId = Convert.ToInt32(IdnumericUpDown.Value);
            }

            cuentas.Monto = Convert.ToInt32(MontotextBox.Text);
            cuentas.TipoId = Convert.ToInt32(TipocomboBox.Text);
            cuentas.Descripcion = DescripciontextBox.Text;

            return cuentas;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            MontotextBox.Clear();
            DescripciontextBox.Clear();
            TipocomboBox.SelectedText = string.Empty;
        }

        private void LlenarComboBox()
        {
            Repositorio<TipoCuentas> repositorio = new Repositorio<TipoCuentas>(new Contexto());
            TipocomboBox.DataSource = repositorio.GetList(c => true);
            TipocomboBox.ValueMember = "TipoId";
            TipocomboBox.DisplayMember = "Descripcion";
        }

        private bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IdnumericUpDown,
                   "Debe introducir un Id");
                paso = true;
            }

            if (error == 2 && MontotextBox.Text == string.Empty)
            {
                errorProvider.SetError(MontotextBox,
                   "Debe ingresar un Monto");
                paso = true;
            }

            if (error == 2 && TipocomboBox.Text == string.Empty)
            {
                errorProvider.SetError(TipocomboBox,
                   "Debe ingresar un Tipo");
                paso = true;
            }

            if (error == 2 && DescripciontextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripciontextBox,
                   "Debe ingresar una Descripcion");
                paso = true;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Favor de llenar la casilla para poder Buscar");
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                cuentas = BLL.CuentasBLL.Buscar(id);

                if (cuentas != null)
                {
                    IdnumericUpDown.Value = cuentas.CuentaId;
                    MontotextBox.Text = cuentas.Monto.ToString();
                    TipocomboBox.Text = cuentas.TipoId.ToString();
                    DescripciontextBox.Text = cuentas.Descripcion.ToString();
                }
                else
                {
                    MessageBox.Show("No Fue Encontrado!", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                errorProvider.Clear();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("Llenar Campos vacios");
                errorProvider.Clear();
                return;
            }
            else
            {
                cuentas = LlenaClase();
                if (IdnumericUpDown.Value == 0)
                {
                    if (BLL.CuentasBLL.Guardar(cuentas))
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
                    var result = MessageBox.Show("Seguro de Modificar?", "+Cuentas",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (BLL.CuentasBLL.Modificar(LlenaClase()))
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

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("Favor de llenar casilla para poder Eliminar");
            }
            var result = MessageBox.Show("Seguro de  Eliminar?", "+Cuentas",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (BLL.CuentasBLL.Eliminar(Convert.ToInt32(IdnumericUpDown.Value)))
                {
                    MessageBox.Show("Eliminado");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar");
                }
            }
        }
    }
}

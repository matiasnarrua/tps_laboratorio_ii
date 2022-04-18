using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Mi_Calculadora
{
    public partial class FormCalculadora : Form
    {
        public static bool flagDecimal = true;
        public static bool flagBinario = false;
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                else if (item is ComboBox)
                {
                    cmbOperador.SelectedIndex = 0;                   
                }
                else if (item is ListBox)
                {
                    lstOperaciones.Items.Clear();
                }
                else if (item is Label)
                {
                    ((Label)item).Text = "";
                }


            }
        }
        public static double Operar(String numero1, String numero2, String operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            return (Calculadora.Operar(num1, num2, operador));
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (!(cmbOperador.SelectedItem is null))
            {
                txtResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString()).ToString();
                lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.SelectedItem } {txtNumero2.Text} = {txtResultado.Text}");
            }
            else
            {
                MessageBox.Show("Operando invalido");
            }
            flagDecimal = true;
            flagBinario = false;
        }






        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero;
            if (txtResultado.Text != "")
            {
                if (flagDecimal)
                {
                    numero = txtResultado.Text;
                    txtResultado.Text = Operando.DecimalBinario(txtResultado.Text);

                    if (txtResultado.Text != "Valor invalido")
                    {
                        lstOperaciones.Items.Add($"{numero} a Binario es {txtResultado.Text} ");

                    }
                    else
                    {
                        lstOperaciones.Items.Add("Valor invalido");
                    }



                    flagBinario = true;
                    flagDecimal = false;
                }
                else
                {
                    MessageBox.Show("El valor ya es binario");
                }
            }
            else
            {
                MessageBox.Show("No existe valor a convertir");
            }
        }               


        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero;
            if(txtResultado.Text != "")
            {
                if (flagBinario)
                {
                    numero = txtResultado.Text;
                    txtResultado.Text = Operando.BinarioDecimal(txtResultado.Text);
                    if (txtResultado.Text != "Valor invalido")
                    {
                        lstOperaciones.Items.Add($"{numero} a Decimal es {txtResultado.Text} ");

                    }
                    else
                    {
                        lstOperaciones.Items.Add("Valor invalido");
                    }

                    flagBinario = false;
                    flagDecimal=true;
                }
                else
                {
                    MessageBox.Show("El valor ya es Decimal");
                }
            }
            else
            {
                MessageBox.Show("No existe valor a convertir");
            }

        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCalculadora_Load_1(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(" ");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;

                }
            }
        }
    }
}

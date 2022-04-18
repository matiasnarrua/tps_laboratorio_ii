using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double operando = 0;

        public Operando()
        {
            this.operando = 0;
        }

        public Operando(double numero)
        {
            this.operando = numero;
        }

        public Operando(String numero)
        {
            SetOperando = numero;
        }
        private double ValidarOperando(String strOperando)
        {
            double n;

            if (double.TryParse(strOperando, out n))
            {
                return n;
            }
            else
            {
                return 0;
            }
        }

        private String SetOperando
        {
            set
            {
                this.operando = ValidarOperando(value);
            }
        }

        private static bool EsBinario (string operando)
        {
            return true;
        }

        public static String BinarioDecimal(string binario)
        {
            int num;
            if (int.TryParse(binario, out num) && num >= 0)
            {
                return (Convert.ToInt64(binario, 2)).ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        public static String DecimalBinario(double operando)
        {
            int num = (int)operando;
            if (num >= 0 && num <= 255)
            {
                return Convert.ToString(Convert.ToByte(num), 2);
            }
            else
            {
                return "Valor invalido";
            }
        }

        public static String DecimalBinario(String operando)
        {
            double num;
            if (double.TryParse(operando, out num))
            {
                return DecimalBinario(num);
            }
            else
            {
                return "Valor invalido";
            }
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return (n1.operando + n2.operando);
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.operando - n2.operando);
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.operando * n2.operando);
        }

        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.operando != 0)
            {
                return (n1.operando / n2.operando);
            }
            else
            {
                return double.MinValue;
            }
        }

    }
}

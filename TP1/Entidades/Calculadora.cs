using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public  static class Calculadora
    {

        private static String ValidarOperador(String operador)
        {
            if (operador != "-" && operador != "+" && operador != "/" && operador != "*")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }

        public static double Operar(Operando num1, Operando num2, String operador)
        {
            operador = ValidarOperador(operador);
            double calculo = 0;
            switch (operador)
            {
                case "-":
                    calculo = num1 - num2;
                    break;
                case "+":
                    calculo = num1 + num2;
                    break;
                case "/":
                    calculo = num1 / num2;
                    break;
                case "*":
                    calculo = num1 * num2;
                    break;
            }
            return calculo;
        }




    }
}

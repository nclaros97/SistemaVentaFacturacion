using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LOGICA.LUsuarios
{
    public class validaciones
    {
        public static bool verificarPassw(string psw, bool editar)
        {
            if (editar)
            {
                if (psw.Equals(""))
                {
                    return true;
                }
                else
                {
                    //letras de la A a la Z, mayusculas y minusculas
                    Regex letras = new Regex(@"[a-zA-z]{6}");
                    //digitos del 0 al 9
                    Regex numeros = new Regex(@"[0-9]{1}");
                    //cualquier caracter del conjunto
                    Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]{1}");

                    //si no contiene las letras, regresa false
                    if (!letras.IsMatch(psw))
                    {
                        return false;
                    }
                    //si no contiene los numeros, regresa false
                    if (!numeros.IsMatch(psw))
                    {
                        return false;
                    }

                    //si no contiene los caracteres especiales, regresa false
                    if (!caracEsp.IsMatch(psw))
                    {
                        return false;
                    }
                    //si cumple con todo, regresa true
                }
            }
            else
            {
                //letras de la A a la Z, mayusculas y minusculas
                Regex letras = new Regex(@"[a-zA-z]{6}");
                //digitos del 0 al 9
                Regex numeros = new Regex(@"[0-9]{1}");
                //cualquier caracter del conjunto
                Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]{1}");

                //si no contiene las letras, regresa false
                if (!letras.IsMatch(psw))
                {
                    return false;
                }
                //si no contiene los numeros, regresa false
                if (!numeros.IsMatch(psw))
                {
                    return false;
                }

                //si no contiene los caracteres especiales, regresa false
                if (!caracEsp.IsMatch(psw))
                {
                    return false;
                }
                //si cumple con todo, regresa true
            }
            return true;
        }

        public static bool verificarEmail(string email)
        {
            string sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, sFormato) ==false)
            {
                return false;
            }
            return true;
        }
        public static string EncriptarPsw(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);

            return result;
        }
        public string DesencriptarPsw(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }
}

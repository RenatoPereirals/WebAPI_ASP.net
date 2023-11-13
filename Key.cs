using System;
using System.Security.Cryptography;

namespace WebAPI
{
    public class Key
    {
        public static string Secret = GerarChaveAleatoria(32); // Usando 32 bytes para uma chave de 256 bits

        private static string GerarChaveAleatoria(int tamanho)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] chaveBytes = new byte[tamanho];
                rng.GetBytes(chaveBytes);
                return BitConverter.ToString(chaveBytes).Replace("-", "");
            }
        }
    }
}

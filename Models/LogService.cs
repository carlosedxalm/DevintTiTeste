using System;
using System.IO;

namespace DavinTI.Models
{
    public static class LogService
    {
        private static string logPath = "log.txt";

        public static void RegistrarExclusao(Contato contato)
        {
            string log = $"Contato {contato.Nome} com ID {contato.Id} excluído em {DateTime.Now}.";
            File.AppendAllText(logPath, log + Environment.NewLine);
        }
    }
}

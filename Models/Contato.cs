﻿namespace DavinTI.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<string> Telefones { get; set; }
    }
}

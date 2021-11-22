using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
    public class CarroDTO
    {      
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Roda { get; set; }
        public int Porta { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public  decimal Preco { get; set; }
    }
}
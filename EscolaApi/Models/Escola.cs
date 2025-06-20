using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApi.Models
{
    public class Escola
    {
        public string CodEscola { get; set; }
        public string CnpjEscola { get; set; }
        public string CepEscola { get; set; }
        public string NumEnderecoEscola { get; set; }
        public string NomeEscola { get; set; }
    }
}
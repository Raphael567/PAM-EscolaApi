using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApi.Models
{
    public class Escola
    {
        public string CodEscola { get; set; }
        public string cnpjEscola { get; set; }
        public string cepEscola { get; set; }
        public string numEnderecoEscola { get; set; }
        public string nomeEscola { get; set; }
    }
}
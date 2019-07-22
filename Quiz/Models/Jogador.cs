using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public ICollection<RespostaJogador> Questao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class RespostaJogador
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public int QuestaoId { get; set; }
        public string Resposta { get; set; }
        [ForeignKey("QuestaoId")]
        public Questao Questao { get; set; }
        [ForeignKey("JogadorId")]
        public Jogador Jogador { get; set; }
    }
}

using System.Collections.Generic;

namespace Quiz.Models
{
    public class Questao
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Opcao_a { get; set; }
        public string Opcao_b { get; set; }
        public string Opcao_c { get; set; }
        public string Opcao_d { get; set; }
        public string Resposta_certa { get; set; }
        public ICollection<RespostaJogador> Jogadores { get; set; }
    }
}

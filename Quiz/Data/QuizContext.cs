using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

    public class QuizContext : DbContext
    {
        public QuizContext (DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public DbSet<Quiz.Models.Jogador> Jogador { get; set; }

        public DbSet<Quiz.Models.Questao> Questao { get; set; }

        public DbSet<Quiz.Models.RespostaJogador> RespostaJogador { get; set; }
    }

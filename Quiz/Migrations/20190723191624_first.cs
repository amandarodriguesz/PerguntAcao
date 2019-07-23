using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pergunta = table.Column<string>(nullable: true),
                    Opcao_a = table.Column<string>(nullable: true),
                    Opcao_b = table.Column<string>(nullable: true),
                    Opcao_c = table.Column<string>(nullable: true),
                    Opcao_d = table.Column<string>(nullable: true),
                    Resposta_certa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RespostaJogador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JogadorId = table.Column<int>(nullable: false),
                    QuestaoId = table.Column<int>(nullable: false),
                    Resposta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaJogador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostaJogador_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaJogador_Questao_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostaJogador_JogadorId",
                table: "RespostaJogador",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaJogador_QuestaoId",
                table: "RespostaJogador",
                column: "QuestaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostaJogador");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Questao");
        }
    }
}

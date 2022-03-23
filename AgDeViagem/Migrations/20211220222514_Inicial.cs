using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgDeViagem.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promoções",
                columns: table => new
                {
                    Id_Promoção = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor_Final = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promoções", x => x.Id_Promoção);
                });

            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<int>(type: "int", nullable: false),
                    ContatoId_Contato = table.Column<int>(type: "int", nullable: true),
                    PromoçãoId_Promoção = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id_Contato);
                    table.ForeignKey(
                        name: "FK_contatos_contatos_ContatoId_Contato",
                        column: x => x.ContatoId_Contato,
                        principalTable: "contatos",
                        principalColumn: "Id_Contato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contatos_promoções_PromoçãoId_Promoção",
                        column: x => x.PromoçãoId_Promoção,
                        principalTable: "promoções",
                        principalColumn: "Id_Promoção",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "passagens",
                columns: table => new
                {
                    Id_Passagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Ida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Volta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Contato = table.Column<int>(type: "int", nullable: false),
                    contatoId_Contato = table.Column<int>(type: "int", nullable: true),
                    Id_Promoção = table.Column<int>(type: "int", nullable: false),
                    promoçãoId_Promoção = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passagens", x => x.Id_Passagem);
                    table.ForeignKey(
                        name: "FK_passagens_contatos_contatoId_Contato",
                        column: x => x.contatoId_Contato,
                        principalTable: "contatos",
                        principalColumn: "Id_Contato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_passagens_promoções_promoçãoId_Promoção",
                        column: x => x.promoçãoId_Promoção,
                        principalTable: "promoções",
                        principalColumn: "Id_Promoção",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatos_ContatoId_Contato",
                table: "contatos",
                column: "ContatoId_Contato");

            migrationBuilder.CreateIndex(
                name: "IX_contatos_PromoçãoId_Promoção",
                table: "contatos",
                column: "PromoçãoId_Promoção");

            migrationBuilder.CreateIndex(
                name: "IX_passagens_contatoId_Contato",
                table: "passagens",
                column: "contatoId_Contato");

            migrationBuilder.CreateIndex(
                name: "IX_passagens_promoçãoId_Promoção",
                table: "passagens",
                column: "promoçãoId_Promoção");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passagens");

            migrationBuilder.DropTable(
                name: "contatos");

            migrationBuilder.DropTable(
                name: "promoções");
        }
    }
}

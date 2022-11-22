using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Despachantes.Migrations
{
    public partial class iniciar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoSV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoSV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MarcaModelo = table.Column<string>(type: "text", nullable: false),
                    Placa = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true),
                    Ano = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Cor = table.Column<string>(type: "text", nullable: false),
                    Renavam = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Fk_Cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_Fk_Cliente",
                        column: x => x.Fk_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculosServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fk_Servico = table.Column<int>(type: "int", nullable: false),
                    Fk_Veiculo = table.Column<int>(type: "int", nullable: false),
                    Fk_Situacao = table.Column<int>(type: "int", nullable: false),
                    DataDeEntrada = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculosServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculosServicos_Servicos_Fk_Servico",
                        column: x => x.Fk_Servico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculosServicos_SituacaoSV_Fk_Situacao",
                        column: x => x.Fk_Situacao,
                        principalTable: "SituacaoSV",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculosServicos_Veiculos_Fk_Veiculo",
                        column: x => x.Fk_Veiculo,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SituacaoSV",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "ATIVO" },
                    { 2, "FINALIZADO" },
                    { 3, "PENDENTE" },
                    { 4, "CANCELADO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Fk_Cliente",
                table: "Veiculos",
                column: "Fk_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosServicos_Fk_Servico",
                table: "VeiculosServicos",
                column: "Fk_Servico");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosServicos_Fk_Situacao",
                table: "VeiculosServicos",
                column: "Fk_Situacao");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculosServicos_Fk_Veiculo",
                table: "VeiculosServicos",
                column: "Fk_Veiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeiculosServicos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "SituacaoSV");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

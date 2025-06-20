using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaApi.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaEscola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESCOLA",
                columns: table => new
                {
                    CodEscola = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    CnpjEscola = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    CepEscola = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    NumEnderecoEscola = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    NomeEscola = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESCOLA", x => x.CodEscola);
                });

            migrationBuilder.InsertData(
                table: "TB_ESCOLA",
                columns: new[] { "CodEscola", "CepEscola", "CnpjEscola", "NomeEscola", "NumEnderecoEscola" },
                values: new object[] { "064", "12345-678", "62.823.257/0064-84", "Etec Professor Horácio Augusto da Silveira", "113" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ESCOLA");
        }
    }
}

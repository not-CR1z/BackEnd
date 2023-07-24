using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
	/// <inheritdoc />
	public partial class v11 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				 name: "FK_Cuestionario_Usuario_UsuarioId",
				 table: "Cuestionario");

			migrationBuilder.DropIndex(
				 name: "IX_Cuestionario_UsuarioId",
				 table: "Cuestionario");

			migrationBuilder.DropColumn(
				 name: "UsuariId",
				 table: "Cuestionario");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Int32>(
				 name: "UsuariId",
				 table: "Cuestionario",
				 type: "NUMBER(10)",
				 nullable: false,
				 defaultValue: 0);

			migrationBuilder.CreateIndex(
				 name: "IX_Cuestionario_UsuarioId",
				 table: "Cuestionario",
				 column: "UsuarioId");

			migrationBuilder.AddForeignKey(
				 name: "FK_Cuestionario_Usuario_UsuarioId",
				 table: "Cuestionario",
				 column: "UsuarioId",
				 principalTable: "Usuario",
				 principalColumn: "Id",
				 onDelete: ReferentialAction.Cascade);
		}
	}
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lab_Web_Grupo3.Migrations
{
    public partial class Distrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Concelho",
                table: "Utilizadores",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Ativacao",
                table: "Utilizadores",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Utilizadores",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Pontos",
                table: "Utilizadores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Promocoes",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Pacotes",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concelho",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Data_Ativacao",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Pontos",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Promocoes");

            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Pacotes");
        }
    }
}

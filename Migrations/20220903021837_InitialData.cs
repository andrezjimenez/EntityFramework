using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb1"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb2"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoryId", "Comments", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("b11da43b-c389-417d-bc6f-9c0be3b28eb2"), new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb2"), "Esta es una prueba 2", "Prueba de Descripcion 2", new DateTime(2022, 9, 2, 21, 18, 37, 690, DateTimeKind.Local).AddTicks(3224), 1, "Tarea 02" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoryId", "Comments", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("b21da43b-c389-417d-bc6f-9c0be3b28eb2"), new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb1"), "Esta es una prueba", "Prueba de Descripcion 1", new DateTime(2022, 9, 2, 21, 18, 37, 690, DateTimeKind.Local).AddTicks(3195), 1, "Tarea 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b11da43b-c389-417d-bc6f-9c0be3b28eb2"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b21da43b-c389-417d-bc6f-9c0be3b28eb2"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb1"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("3e1da43b-c389-417d-bc6f-9c0be3b28eb2"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

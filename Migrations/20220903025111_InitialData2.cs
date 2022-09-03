using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframework.Migrations
{
    public partial class InitialData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b11da43b-c389-417d-bc6f-9c0be3b28eb2"),
                columns: new[] { "FechaCreacion", "PrioridadTarea" },
                values: new object[] { new DateTime(2022, 9, 2, 21, 51, 11, 178, DateTimeKind.Local).AddTicks(8169), 0 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b21da43b-c389-417d-bc6f-9c0be3b28eb2"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 21, 51, 11, 178, DateTimeKind.Local).AddTicks(8154));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b11da43b-c389-417d-bc6f-9c0be3b28eb2"),
                columns: new[] { "FechaCreacion", "PrioridadTarea" },
                values: new object[] { new DateTime(2022, 9, 2, 21, 18, 37, 690, DateTimeKind.Local).AddTicks(3224), 1 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("b21da43b-c389-417d-bc6f-9c0be3b28eb2"),
                column: "FechaCreacion",
                value: new DateTime(2022, 9, 2, 21, 18, 37, 690, DateTimeKind.Local).AddTicks(3195));
        }
    }
}

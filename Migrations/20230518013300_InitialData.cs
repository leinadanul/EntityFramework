using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed101"), null, "Task to do", 20 },
                    { new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed102"), null, "Personal task", 50 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "TaskPrority", "Title" },
                values: new object[,]
                {
                    { new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed110"), new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed101"), new DateTime(2023, 5, 17, 20, 32, 59, 884, DateTimeKind.Local).AddTicks(4756), null, 1, "Pay public Services" },
                    { new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed111"), new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed102"), new DateTime(2023, 5, 17, 20, 32, 59, 884, DateTimeKind.Local).AddTicks(4772), null, 0, "Finish watching the movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed110"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed111"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed101"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("ea9301c2-0dfd-45e6-ae1a-491c67eed102"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

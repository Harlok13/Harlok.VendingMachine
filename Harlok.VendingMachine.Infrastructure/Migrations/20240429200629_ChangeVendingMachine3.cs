using System;
using System.Collections.Generic;
using Harlok.VendingMachine.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harlok.VendingMachine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVendingMachine3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("d45620ca-a571-49e5-b76c-6e98feed2b8a"));

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "coins" },
                values: new object[] { new Guid("ac4b5436-1762-4a7e-8c8c-2073e7e2668d"), new List<Coin>() });

            migrationBuilder.UpdateData(
                table: "vending_machine",
                keyColumn: "id",
                keyValue: 13L,
                column: "deposit",
                value: new List<Coin>());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("ac4b5436-1762-4a7e-8c8c-2073e7e2668d"));

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "coins" },
                values: new object[] { new Guid("d45620ca-a571-49e5-b76c-6e98feed2b8a"), new List<Coin>() });

            migrationBuilder.UpdateData(
                table: "vending_machine",
                keyColumn: "id",
                keyValue: 13L,
                column: "deposit",
                value: new List<Coin>());
        }
    }
}

using System;
using System.Collections.Generic;
using Harlok.VendingMachine.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Harlok.VendingMachine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVendingMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    coins = table.Column<IReadOnlyCollection<Coin>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vending_machine",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deposit = table.Column<IReadOnlyCollection<Coin>>(type: "jsonb", nullable: false),
                    earned_money = table.Column<decimal>(type: "numeric(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("vending_machine_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drink",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    picture_url = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<short>(type: "smallint", nullable: false),
                    VendingMachineId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("drink_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_drink_vending_machine_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "vending_machine",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "coins" },
                values: new object[] { new Guid("6c33c97a-92de-4e5b-b473-85f5f185f4a8"), new List<Coin>() });

            migrationBuilder.CreateIndex(
                name: "IX_drink_VendingMachineId",
                table: "drink",
                column: "VendingMachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drink");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "vending_machine");
        }
    }
}

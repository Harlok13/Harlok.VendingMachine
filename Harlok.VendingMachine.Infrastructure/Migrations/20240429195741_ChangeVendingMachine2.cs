using System;
using System.Collections.Generic;
using Harlok.VendingMachine.Domain.Primitives;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harlok.VendingMachine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVendingMachine2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drink_vending_machine_VendingMachineId",
                table: "drink");

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("6c33c97a-92de-4e5b-b473-85f5f185f4a8"));

            migrationBuilder.RenameColumn(
                name: "VendingMachineId",
                table: "drink",
                newName: "vending_machine_id");

            migrationBuilder.RenameIndex(
                name: "IX_drink_VendingMachineId",
                table: "drink",
                newName: "IX_drink_vending_machine_id");

            migrationBuilder.AlterColumn<long>(
                name: "vending_machine_id",
                table: "drink",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "vending_machine_fk",
                table: "drink",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "coins" },
                values: new object[] { new Guid("d45620ca-a571-49e5-b76c-6e98feed2b8a"), new List<Coin>() });

            migrationBuilder.InsertData(
                table: "vending_machine",
                columns: new[] { "id", "deposit", "earned_money" },
                values: new object[] { 13L, new List<Coin>(), 0m });

            migrationBuilder.CreateIndex(
                name: "IX_drink_vending_machine_fk",
                table: "drink",
                column: "vending_machine_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_drink_vending_machine_vending_machine_fk",
                table: "drink",
                column: "vending_machine_fk",
                principalTable: "vending_machine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_drink_vending_machine_vending_machine_id",
                table: "drink",
                column: "vending_machine_id",
                principalTable: "vending_machine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drink_vending_machine_vending_machine_fk",
                table: "drink");

            migrationBuilder.DropForeignKey(
                name: "FK_drink_vending_machine_vending_machine_id",
                table: "drink");

            migrationBuilder.DropIndex(
                name: "IX_drink_vending_machine_fk",
                table: "drink");

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: new Guid("d45620ca-a571-49e5-b76c-6e98feed2b8a"));

            migrationBuilder.DeleteData(
                table: "vending_machine",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DropColumn(
                name: "vending_machine_fk",
                table: "drink");

            migrationBuilder.RenameColumn(
                name: "vending_machine_id",
                table: "drink",
                newName: "VendingMachineId");

            migrationBuilder.RenameIndex(
                name: "IX_drink_vending_machine_id",
                table: "drink",
                newName: "IX_drink_VendingMachineId");

            migrationBuilder.AlterColumn<long>(
                name: "VendingMachineId",
                table: "drink",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "coins" },
                values: new object[] { new Guid("6c33c97a-92de-4e5b-b473-85f5f185f4a8"), new List<Coin>() });

            migrationBuilder.AddForeignKey(
                name: "FK_drink_vending_machine_VendingMachineId",
                table: "drink",
                column: "VendingMachineId",
                principalTable: "vending_machine",
                principalColumn: "id");
        }
    }
}

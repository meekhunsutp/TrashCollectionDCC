using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class trialofupdateddateformatincustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3523d995-f540-4946-872a-5d371c9131e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e489e61-f403-4345-bd3c-d53a1422dd6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "804aa1eb-75f2-4a05-b8cc-20b915c7048a");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CollectionDay",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf13afca-2c4f-492f-bac1-5d260c82e7a0", "8628a083-c761-4d46-b96e-de806703e573", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0f3b3fe-a04a-4d90-a308-eb75c3a21f11", "1868f2ca-e7b9-4208-aa2f-5aa9eeac6002", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26d5dd15-c7b5-4ca6-baa3-46a850b22ba3", "b26de81e-750c-4892-b0ee-19530f933f9f", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26d5dd15-c7b5-4ca6-baa3-46a850b22ba3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0f3b3fe-a04a-4d90-a308-eb75c3a21f11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf13afca-2c4f-492f-bac1-5d260c82e7a0");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionDay",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3523d995-f540-4946-872a-5d371c9131e9", "dd8ade3a-d845-4bd2-8678-7283bb9ffef5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e489e61-f403-4345-bd3c-d53a1422dd6e", "6205e215-f17f-4be5-bb4b-30cf2164d7b7", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "804aa1eb-75f2-4a05-b8cc-20b915c7048a", "00cfff60-c4e1-4a8e-8d60-2927fe286350", "Customer", "CUSTOMER" });
        }
    }
}

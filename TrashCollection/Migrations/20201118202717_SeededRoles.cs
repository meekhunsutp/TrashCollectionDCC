using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class SeededRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c950e21-241f-470e-979c-302027a20ffa");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c950e21-241f-470e-979c-302027a20ffa", "d6039ddc-c224-4bff-a605-f6bd0b6d90e2", "Admin", "ADMIN" });
        }
    }
}

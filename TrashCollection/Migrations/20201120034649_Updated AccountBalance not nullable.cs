using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class UpdatedAccountBalancenotnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17752a9f-04fe-45f8-b586-763979879061");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b618743f-f11c-41cb-beef-a2f1a938ef40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad2bdd5-c1bb-4f7c-b688-90191cf6066b");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80143ae2-7ce3-4886-bce6-c6872e32153d", "52a6f990-9f40-4dc1-a480-2572c8b0b700", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b795612e-7892-4b04-b784-c180594785a7", "357857d7-59ac-44c5-a1e2-f8db9580f628", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c50ab5bd-61bb-49ca-bfe2-ff2212bd0b03", "4a06f079-1550-4dcb-9b4d-2553d8a06e71", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80143ae2-7ce3-4886-bce6-c6872e32153d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b795612e-7892-4b04-b784-c180594785a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c50ab5bd-61bb-49ca-bfe2-ff2212bd0b03");

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Customer",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dad2bdd5-c1bb-4f7c-b688-90191cf6066b", "242a17dd-9ae7-43ed-9a08-f6b1d73eb146", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b618743f-f11c-41cb-beef-a2f1a938ef40", "953150ac-3ec5-4472-9afe-397207a2a6d5", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17752a9f-04fe-45f8-b586-763979879061", "8ff28577-e1a3-4367-8004-77d9add9b1d4", "Customer", "CUSTOMER" });
        }
    }
}

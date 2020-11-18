using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class CreatedCustomerListLogicTimetotest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ec44ba7-46bf-44a5-b2e0-394a71bec853");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c950e21-241f-470e-979c-302027a20ffa", "d6039ddc-c224-4bff-a605-f6bd0b6d90e2", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c950e21-241f-470e-979c-302027a20ffa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ec44ba7-46bf-44a5-b2e0-394a71bec853", "733f97bc-ba30-46cd-a794-01e809f4535f", "Admin", "ADMIN" });
        }
    }
}

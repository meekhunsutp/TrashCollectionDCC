using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class failedupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3ab86d-81a3-46d3-86ac-196944898965");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4832cb7-fa6d-4e82-bd98-f2333dc96e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1231cc-f4a2-4e0a-ad59-46c54120de12");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae37a850-b9a8-49f9-ab96-9cc065ebc8f6", "6df93358-cd54-47f9-9f9d-8a5f7a9dd38b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da77cbbb-4004-47e7-9c8f-952266604834", "4e3973e1-dd60-4a6d-b4fb-8a6488642d69", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ea0fa99-43c4-40eb-ae90-c251e0450910", "18fa7d47-f4cd-4432-9ba8-d8ccdea63fb2", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea0fa99-43c4-40eb-ae90-c251e0450910");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae37a850-b9a8-49f9-ab96-9cc065ebc8f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da77cbbb-4004-47e7-9c8f-952266604834");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ab3ab86d-81a3-46d3-86ac-196944898965", "b806bb39-e047-44be-8936-6ba6626020f4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd1231cc-f4a2-4e0a-ad59-46c54120de12", "8e8bc189-8165-4cc6-98b7-501780c04bd6", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4832cb7-fa6d-4e82-bd98-f2333dc96e13", "c9d9357a-26c6-42bb-8528-0b8340be696e", "Customer", "CUSTOMER" });
        }
    }
}

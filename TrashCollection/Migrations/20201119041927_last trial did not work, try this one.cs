using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class lasttrialdidnotworktrythisone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f126104-85b1-4cd0-98a5-9e387fe50cf4", "1e205e1f-24a4-4042-bb30-54c1f7a05276", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11a41798-31d7-40d6-8c8f-f582deac2721", "ba10fdc8-0dec-4b53-8a24-725a649cb8a1", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15677ccd-fd57-45e7-9eda-a9420ecccafd", "074bb054-627b-4318-8dd2-2a80ca6fd233", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a41798-31d7-40d6-8c8f-f582deac2721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15677ccd-fd57-45e7-9eda-a9420ecccafd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f126104-85b1-4cd0-98a5-9e387fe50cf4");

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
    }
}

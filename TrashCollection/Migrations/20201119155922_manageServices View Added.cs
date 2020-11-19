using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class manageServicesViewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Customer",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

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
    }
}

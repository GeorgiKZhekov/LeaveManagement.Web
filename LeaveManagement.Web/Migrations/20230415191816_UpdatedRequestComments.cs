using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Migrations
{
    public partial class UpdatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestsComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FAE750D3-5866-42F9-A55F-E68349AF69F1",
                column: "ConcurrencyStamp",
                value: "9f000653-2291-4e19-bb55-51291b0390c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FB04C3E1-2134-48FB-A187-44107D90ED38",
                column: "ConcurrencyStamp",
                value: "9d5978a3-fb18-49f5-9c21-f8a3164cda57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b7ba29f-36f7-4f3f-b9f8-beea0bc8b329", "AQAAAAEAACcQAAAAENrr64PtnNGfLJnVR9HFI+ZNz5OFIgTbLkDASsOsWDKood3EAVSOAxjL58WzNf5hTQ==", "da7731a4-c0f6-454e-9759-aaeb1f527143" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b37900c7-8840-41a7-adc1-db1666502657",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700a45a1-02fb-4d39-a55d-23b0d5dcbee3", "AQAAAAEAACcQAAAAEPB8P9JERS0dE4nEw7Wq4L3DydtI3NGwyAiinnGpdGvuWZ+ab93/fFkKaeTZL1WDVw==", "8ed0b80f-5755-4aea-8dbb-dfbd0080cff1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestsComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FAE750D3-5866-42F9-A55F-E68349AF69F1",
                column: "ConcurrencyStamp",
                value: "7f1e02a0-7e27-418e-a86e-e0e0e41b3e5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FB04C3E1-2134-48FB-A187-44107D90ED38",
                column: "ConcurrencyStamp",
                value: "7e35f302-eb1d-40ed-81ff-02e2ed1a14d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902c75f6-97ea-4f6d-af52-7895f578a0f1", "AQAAAAEAACcQAAAAEIH455qqMkmPSi6LQ9gIGKd55+NWxWy97tbvh+YxI3HM9xddHPpZB/umIUiIC/o+ig==", "77e487ce-557a-4a12-85f7-57e1a543f753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b37900c7-8840-41a7-adc1-db1666502657",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39c6b24-3c7b-41ae-830c-191642dfc801", "AQAAAAEAACcQAAAAEExa0qOxLU7gTmky0h/Aure9hLZsLxQQFQjiQU63Dbxhk7/+pkJ/DO1ncuPxHOKRAA==", "982cd208-a66c-4bb8-9df3-9df608cab19a" });
        }
    }
}

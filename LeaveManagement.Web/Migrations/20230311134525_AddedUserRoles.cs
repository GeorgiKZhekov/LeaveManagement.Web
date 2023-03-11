using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Migrations
{
    public partial class AddedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "FAE750D3-5866-42F9-A55F-E68349AF69F1", "6d5623b4-f7eb-4096-b2ff-2e9e3882665c", "User", "USER" },
                    { "FB04C3E1-2134-48FB-A187-44107D90ED38", "dd30517b-e092-4d8e-99c5-2b5cfaf3a377", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42", 0, "8b7646cf-9e71-4f8c-bb58-71696e8e5eea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jototheg@gmail.com", true, "Ioana", "Palova", false, null, "JOTOTHEG@GMAIL.COM", "JOTOTHEG@GMAIL.COM", "AQAAAAEAACcQAAAAEL/nykvcFob/1cs3FCZpOIVlgNmjU6RsOrBHne5CJjuIvv6FIUPUX3OK5oLD9Pj74A==", null, false, "ad0a11cf-a9c9-4607-aa4c-4573d0dfa0df", null, false, "jototheg@gmail.com" },
                    { "b37900c7-8840-41a7-adc1-db1666502657", 0, "0a9830c8-5063-441c-8e9c-ccb54e79818b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gtothejo@gmail.com", true, "Georgi", "Zhekov", false, null, "GTOTHEJO@GMAIL.COM", "GTOTHEJO@GMAIL.COM", "AQAAAAEAACcQAAAAEO4jJydfYM3TxVzIDoSzzhcCzmLJKi2xjmryzOJgJ+B47ziUEv6XA047SBZBqB5Y+g==", null, false, "8ec23e30-fed4-40d7-a3dc-5ab0e7c87263", null, false, "gtothejo@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "FAE750D3-5866-42F9-A55F-E68349AF69F1", "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "FB04C3E1-2134-48FB-A187-44107D90ED38", "b37900c7-8840-41a7-adc1-db1666502657" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FAE750D3-5866-42F9-A55F-E68349AF69F1", "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FB04C3E1-2134-48FB-A187-44107D90ED38", "b37900c7-8840-41a7-adc1-db1666502657" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FAE750D3-5866-42F9-A55F-E68349AF69F1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FB04C3E1-2134-48FB-A187-44107D90ED38");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5E8EBDC0-7AD3-41CC-A8C6-6CB1DB9FDB42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b37900c7-8840-41a7-adc1-db1666502657");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<int>(maxLength: 5, nullable: false),
                    Country = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { new Guid("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), "+46", "Sweden" },
                    { new Guid("ba2dc307-32bf-4d24-8cd2-45f070975889"), "+45", "Denmark" },
                    { new Guid("0f72123d-6095-490e-a051-6bb7fbcbc010"), "+47", "Norway" },
                    { new Guid("01d942ed-522e-4e5f-908b-cae029c820d7"), "+358", "Finland" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "PersonalNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("e2c46906-2ea4-4672-a81f-bd69890c9b16"), "user1@domain.com", "199205251045", "+467455535" },
                    { new Guid("21d937d1-f020-4e4f-9f26-add9801b6e75"), "user2@domain.com", "199307121428", "+4560555269" },
                    { new Guid("5cee819a-f78d-49a9-866e-b69aba44c4f4"), "user3@domain.com", "198904208493", "+4795552843" },
                    { new Guid("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), "user4@domain.com", "198602182748", "+3585005557352" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Country", "CustomerId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("78cebe6c-6dac-403e-82bd-43f3142ea805"), "Sweden", new Guid("e2c46906-2ea4-4672-a81f-bd69890c9b16"), 15132 },
                    { new Guid("a02b03b7-36cb-4839-911c-f782bb3009e9"), "Denmark", new Guid("21d937d1-f020-4e4f-9f26-add9801b6e75"), 4268 },
                    { new Guid("5c3ac12f-ec83-449e-a37e-de7442cde7da"), "Norway", new Guid("5cee819a-f78d-49a9-866e-b69aba44c4f4"), 30415 },
                    { new Guid("b84178a0-b0ff-4721-96cc-5d271d93f6b9"), "Finland", new Guid("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), 55603 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

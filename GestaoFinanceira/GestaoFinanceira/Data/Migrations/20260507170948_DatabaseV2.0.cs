using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFinanceira.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campanies_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Campanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Campanies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialTransctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<int>(type: "int", nullable: false),
                    ReferenceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Repeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepeatTimes = table.Column<int>(type: "int", nullable: false),
                    InteresPenalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AmoundPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialTransctions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialTransctions_Campanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Campanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialTransctions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialTransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAttachments_FinancialTransctions_FinancialTransactionId",
                        column: x => x.FinancialTransactionId,
                        principalTable: "FinancialTransctions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyId",
                table: "Accounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Campanies_UserId1",
                table: "Campanies",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAttachments_FinancialTransactionId",
                table: "DocumentAttachments",
                column: "FinancialTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransctions_AccountId",
                table: "FinancialTransctions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransctions_CategoryId",
                table: "FinancialTransctions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransctions_CompanyId",
                table: "FinancialTransctions",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentAttachments");

            migrationBuilder.DropTable(
                name: "FinancialTransctions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Campanies");
        }
    }
}

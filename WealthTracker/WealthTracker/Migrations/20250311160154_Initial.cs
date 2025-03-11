using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WealthTracker.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    AssetTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.AssetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RegularTradingPeriods",
                columns: table => new
                {
                    RegularTradingPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketOpenTime = table.Column<int>(type: "int", nullable: false),
                    MarketCloseTime = table.Column<int>(type: "int", nullable: false),
                    TimezoneDifference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularTradingPeriods", x => x.RegularTradingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    SectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.SectorId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashBalance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidHistoricalDataRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstTradeDate = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    IconType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RegularTradingPeriodId = table.Column<int>(type: "int", nullable: false),
                    CurrentDataTime = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<float>(type: "real", nullable: false),
                    CurrentHigh = table.Column<float>(type: "real", nullable: false),
                    CurrentLow = table.Column<float>(type: "real", nullable: false),
                    CurrentVolume = table.Column<int>(type: "int", nullable: false),
                    PreviousClose = table.Column<float>(type: "real", nullable: false),
                    TimezoneDifference = table.Column<int>(type: "int", nullable: false),
                    YearlyHigh = table.Column<float>(type: "real", nullable: false),
                    YearlyLow = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Ticker);
                    table.ForeignKey(
                        name: "FK_Stocks_RegularTradingPeriods_RegularTradingPeriodId",
                        column: x => x.RegularTradingPeriodId,
                        principalTable: "RegularTradingPeriods",
                        principalColumn: "RegularTradingPeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStocks",
                columns: table => new
                {
                    UserStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StockTicker = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStocks", x => x.UserStockId);
                    table.ForeignKey(
                        name: "FK_UserStocks_Stocks_StockTicker",
                        column: x => x.StockTicker,
                        principalTable: "Stocks",
                        principalColumn: "Ticker");
                    table.ForeignKey(
                        name: "FK_UserStocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_RegularTradingPeriodId",
                table: "Stocks",
                column: "RegularTradingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_StockTicker",
                table: "UserStocks",
                column: "StockTicker");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_UserId",
                table: "UserStocks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "UserStocks");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RegularTradingPeriods");
        }
    }
}

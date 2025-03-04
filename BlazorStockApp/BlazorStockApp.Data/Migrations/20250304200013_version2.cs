using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorStockApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class version2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStocks_StockMeta_StockMetaTicker",
                table: "UserStocks");

            migrationBuilder.DropTable(
                name: "StockMeta");

            migrationBuilder.RenameColumn(
                name: "StockMetaTicker",
                table: "UserStocks",
                newName: "StockTicker");

            migrationBuilder.RenameIndex(
                name: "IX_UserStocks_StockMetaTicker",
                table: "UserStocks",
                newName: "IX_UserStocks_StockTicker");

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

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_RegularTradingPeriodId",
                table: "Stocks",
                column: "RegularTradingPeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Stocks_StockTicker",
                table: "UserStocks",
                column: "StockTicker",
                principalTable: "Stocks",
                principalColumn: "Ticker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStocks_Stocks_StockTicker",
                table: "UserStocks");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "RegularTradingPeriods");

            migrationBuilder.RenameColumn(
                name: "StockTicker",
                table: "UserStocks",
                newName: "StockMetaTicker");

            migrationBuilder.RenameIndex(
                name: "IX_UserStocks_StockTicker",
                table: "UserStocks",
                newName: "IX_UserStocks_StockMetaTicker");

            migrationBuilder.CreateTable(
                name: "StockMeta",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstTradeDate = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IconType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    ValidHistoricalDataRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMeta", x => x.Ticker);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_StockMeta_StockMetaTicker",
                table: "UserStocks",
                column: "StockMetaTicker",
                principalTable: "StockMeta",
                principalColumn: "Ticker");
        }
    }
}

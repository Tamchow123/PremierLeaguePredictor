using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePredictory.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialMigrationAuthDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81d0ca6e-768c-4a59-8e5a-1d04be638425",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08360fe7-5e8f-4ff5-93b2-06561bea5b0e", "AQAAAAIAAYagAAAAENMo5dvUnchEhqyPnLWFDz3KlVsvuR+LOSdrVFpj4bxukHcscELSSO3l9MIKtYyJTw==", "2db32464-42d5-47e7-beb7-d26cf505aea2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81d0ca6e-768c-4a59-8e5a-1d04be638425",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed8744dd-449b-42eb-8584-3b5a6438895b", "AQAAAAIAAYagAAAAEJenQR9Jf5QhXNax4BWqi7LNmZTi7jhFS/W5V9cEGz5ryE/evNSTgUAAQ1DRmfi5hQ==", "f515fb8d-76d8-42e5-9cdf-5fa47932bf4c" });
        }
    }
}

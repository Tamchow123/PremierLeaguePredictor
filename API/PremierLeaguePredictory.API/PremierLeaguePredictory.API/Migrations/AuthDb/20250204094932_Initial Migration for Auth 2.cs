using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePredictory.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialMigrationforAuth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81d0ca6e-768c-4a59-8e5a-1d04be638425",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ed8744dd-449b-42eb-8584-3b5a6438895b", "admin@plp.com", "ADMIN@PLP.COM", "ADMIN@PLP.COM", "AQAAAAIAAYagAAAAEJenQR9Jf5QhXNax4BWqi7LNmZTi7jhFS/W5V9cEGz5ryE/evNSTgUAAQ1DRmfi5hQ==", "f515fb8d-76d8-42e5-9cdf-5fa47932bf4c", "admin@plp.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81d0ca6e-768c-4a59-8e5a-1d04be638425",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "df841c80-dfdf-431b-ae88-4dff2e43f890", "admin@codepulse.com", "ADMIN@CODEPULSE.COM", "ADMIN@CODEPULSE.COM", "AQAAAAIAAYagAAAAEEboFJGaaTWhKIY2OzYJLeO/XPKEglwBAS2oGlMjAxfb+HjOwShJ+Nqb6U4zURbHvg==", "701ec703-36f8-496a-851b-f0792740edf1", "admin@codepulse.com" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace picpay_desafio.Migrations
{
    /// <inheritdoc />
    public partial class rename_userType_to_user_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userType",
                table: "Wallets",
                newName: "user_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "Wallets",
                newName: "userType");
        }
    }
}

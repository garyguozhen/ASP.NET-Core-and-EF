using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chapter4_LeaveManagmentSystemDB.Web.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f3fdff1-3daa-4978-ad34-e7c43781a7f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e58b413-123e-47db-83e2-9ce1dd0bf9a5", "AQAAAAIAAYagAAAAELAS157BHHpPGl96aihu6n7CgVWFTnR4buV9NTkY0/BlEcoiq//6vvMdNTMFn0PnMw==", "b0a11e53-11c6-403f-ad07-42fc68a6b8e9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f3fdff1-3daa-4978-ad34-e7c43781a7f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fe753d1-71d2-402e-a8e0-493c6d2aeca0", "AQAAAAIAAYagAAAAEIuq4EwGl6LdA5rhmKOWtWtux3MDzfzfnM/72O8oMIVCW501dIqgtOKF+ET4qwbDjQ==", "3c1872c8-2f0b-45a7-8220-b1bc82f8d86c" });
        }
    }
}

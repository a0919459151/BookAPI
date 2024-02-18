using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book.Dao.Migrations
{
    /// <inheritdoc />
    public partial class Add_Book_Sort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Books");
        }
    }
}

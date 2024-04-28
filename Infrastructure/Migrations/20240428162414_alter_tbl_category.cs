using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alter_tbl_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttachment_Products_ProductId",
                table: "ProductAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttachment",
                table: "ProductAttachment");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttachment_ProductId",
                table: "ProductAttachment");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductAttachment",
                newName: "ProductAttachments");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Products",
                type: "VARCHAR(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments",
                columns: new[] { "ProductId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameAr",
                table: "Products",
                column: "NameAr");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttachments_Products_ProductId",
                table: "ProductAttachments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttachments_Products_ProductId",
                table: "ProductAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Products_NameAr",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments");

            migrationBuilder.RenameTable(
                name: "ProductAttachments",
                newName: "ProductAttachment");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameAr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductAttachment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttachment",
                table: "ProductAttachment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsShowable = table.Column<bool>(type: "bit", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachment_ProductId",
                table: "ProductAttachment",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttachment_Products_ProductId",
                table: "ProductAttachment",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

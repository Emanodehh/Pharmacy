using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addbeauty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Medicines_MedicineId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BeautyId",
                table: "Stores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beauties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ImageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beauties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BeautyId",
                table: "Stores",
                column: "BeautyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Beauties_BeautyId",
                table: "Stores",
                column: "BeautyId",
                principalTable: "Beauties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Medicines_MedicineId",
                table: "Stores",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Beauties_BeautyId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Medicines_MedicineId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Beauties");

            migrationBuilder.DropIndex(
                name: "IX_Stores_BeautyId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "BeautyId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "MedicineId",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Medicines_MedicineId",
                table: "Stores",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

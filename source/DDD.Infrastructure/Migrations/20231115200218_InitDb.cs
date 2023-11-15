using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "medicine");

            migrationBuilder.CreateTable(
                name: "Medicine",
                schema: "medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterial",
                schema: "medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                schema: "medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FormulaForm = table.Column<int>(type: "integer", nullable: true),
                    FormulaSample = table.Column<int>(type: "integer", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formula_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalSchema: "medicine",
                        principalTable: "Medicine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormulaMessurement",
                schema: "medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    FormulaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaMessurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulaMessurement_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalSchema: "medicine",
                        principalTable: "Formula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialRatio",
                schema: "medicine",
                columns: table => new
                {
                    RawMaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormulaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ratio = table.Column<float>(type: "real", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialRatio", x => new { x.RawMaterialId, x.FormulaId });
                    table.ForeignKey(
                        name: "FK_RawMaterialRatio_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalSchema: "medicine",
                        principalTable: "Formula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formula_MedicineId",
                schema: "medicine",
                table: "Formula",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaMessurement_FormulaId",
                schema: "medicine",
                table: "FormulaMessurement",
                column: "FormulaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterial_Name",
                schema: "medicine",
                table: "RawMaterial",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialRatio_FormulaId",
                schema: "medicine",
                table: "RawMaterialRatio",
                column: "FormulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormulaMessurement",
                schema: "medicine");

            migrationBuilder.DropTable(
                name: "RawMaterial",
                schema: "medicine");

            migrationBuilder.DropTable(
                name: "RawMaterialRatio",
                schema: "medicine");

            migrationBuilder.DropTable(
                name: "Formula",
                schema: "medicine");

            migrationBuilder.DropTable(
                name: "Medicine",
                schema: "medicine");
        }
    }
}

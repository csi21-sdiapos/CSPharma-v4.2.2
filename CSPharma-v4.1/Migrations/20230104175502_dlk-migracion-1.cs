using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSPharma_v4._1.Migrations
{
    public partial class dlkmigracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dlk_torrecontrol");

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_empleados",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_roles",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_claim_empleados",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_claim_empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_claim_empleados_Dlk_cat_acc_empleados_UserId",
                        column: x => x.UserId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_login_empleados",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_login_empleados", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_login_empleados_Dlk_cat_acc_empleados_UserId",
                        column: x => x.UserId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_token_empleados",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_token_empleados", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_token_empleados_Dlk_cat_acc_empleados_UserId",
                        column: x => x.UserId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_claim_roles",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_claim_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_claim_roles_Dlk_cat_acc_roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dlk_cat_acc_empleados_roles",
                schema: "dlk_torrecontrol",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dlk_cat_acc_empleados_roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_empleados_roles_Dlk_cat_acc_empleados_UserId",
                        column: x => x.UserId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dlk_cat_acc_empleados_roles_Dlk_cat_acc_roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dlk_torrecontrol",
                        principalTable: "Dlk_cat_acc_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dlk_cat_acc_claim_empleados_UserId",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_claim_empleados",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dlk_cat_acc_claim_roles_RoleId",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_claim_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_empleados",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_empleados",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dlk_cat_acc_empleados_roles_RoleId",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_empleados_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Dlk_cat_acc_login_empleados_UserId",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_login_empleados",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dlk_torrecontrol",
                table: "Dlk_cat_acc_roles",
                column: "NormalizedName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_claim_empleados",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_claim_roles",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_empleados_roles",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_login_empleados",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_token_empleados",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_roles",
                schema: "dlk_torrecontrol");

            migrationBuilder.DropTable(
                name: "Dlk_cat_acc_empleados",
                schema: "dlk_torrecontrol");
        }
    }
}

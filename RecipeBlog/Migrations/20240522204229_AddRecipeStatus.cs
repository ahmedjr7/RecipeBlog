using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "C##MVCF1");

            migrationBuilder.CreateSequence(
                name: "CATEGORY_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.CreateSequence(
                name: "RECIPE_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.CreateSequence(
                name: "ROLE_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.CreateSequence(
                name: "USER_ID_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.CreateSequence(
                name: "USER_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                schema: "C##MVCF1",
                columns: table => new
                {
                    CATEGORYID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    CATEGORYNAME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    CATEGORYIMAGE = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008420", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                schema: "C##MVCF1",
                columns: table => new
                {
                    ROLEID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ROLENAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008415", x => x.ROLEID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "C##MVCF1",
                columns: table => new
                {
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USERNAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    ROLEID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    PROFILEIMAGE = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008416", x => x.USERID);
                    table.ForeignKey(
                        name: "SYS_C008419",
                        column: x => x.ROLEID,
                        principalSchema: "C##MVCF1",
                        principalTable: "ROLES",
                        principalColumn: "ROLEID");
                });

            migrationBuilder.CreateTable(
                name: "CHEF",
                schema: "C##MVCF1",
                columns: table => new
                {
                    CHEFID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    SUBSCRIPTIONTYPE = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: true),
                    SUBSCRIPTIONSTARTDATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    SUBSCRIPTIONENDDATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008438", x => x.CHEFID);
                    table.ForeignKey(
                        name: "SYS_C008439",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "GIFTCARDS",
                schema: "C##MVCF1",
                columns: table => new
                {
                    CARDID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    BALANCE = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true),
                    ACTIVATIONDATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    EXPIRATIONDATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008426", x => x.CARDID);
                    table.ForeignKey(
                        name: "SYS_C008427",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "RECIPES",
                schema: "C##MVCF1",
                columns: table => new
                {
                    RECIPEID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    NAME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    INGREDIENTS = table.Column<string>(type: "CLOB", nullable: true),
                    INSTRUCTIONS = table.Column<string>(type: "CLOB", nullable: true),
                    PRICE = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true),
                    CATEGORYID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    ADDEDTIME = table.Column<DateTime>(type: "DATE", nullable: true),
                    MAINIMAGE = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    STATUS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008421", x => x.RECIPEID);
                    table.ForeignKey(
                        name: "SYS_C008422",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                    table.ForeignKey(
                        name: "SYS_C008423",
                        column: x => x.CATEGORYID,
                        principalSchema: "C##MVCF1",
                        principalTable: "CATEGORIES",
                        principalColumn: "CATEGORYID");
                });

            migrationBuilder.CreateTable(
                name: "TESTIMONIALS",
                schema: "C##MVCF1",
                columns: table => new
                {
                    TESTIMONIALID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    TESTIMONIALCONTENT = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008424", x => x.TESTIMONIALID);
                    table.ForeignKey(
                        name: "SYS_C008425",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACK",
                schema: "C##MVCF1",
                columns: table => new
                {
                    FEEDBACKID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    RECIPEID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    USERCOMMENT = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    POSTEDAT = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008428", x => x.FEEDBACKID);
                    table.ForeignKey(
                        name: "SYS_C008429",
                        column: x => x.RECIPEID,
                        principalSchema: "C##MVCF1",
                        principalTable: "RECIPES",
                        principalColumn: "RECIPEID");
                    table.ForeignKey(
                        name: "SYS_C008430",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTS",
                schema: "C##MVCF1",
                columns: table => new
                {
                    PAYMENTID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true),
                    PAYMENTSTATUS = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    TRANSACTIONDATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    RECIPEID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    CARDID = table.Column<string>(type: "VARCHAR2(16)", unicode: false, maxLength: 16, nullable: true),
                    CARDHOLDERNAME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    CARDSECURITYNUMBER = table.Column<string>(type: "VARCHAR2(3)", unicode: false, maxLength: 3, nullable: true),
                    CARDEXPIRYDATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008434", x => x.PAYMENTID);
                    table.ForeignKey(
                        name: "SYS_C008436",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                    table.ForeignKey(
                        name: "SYS_C008437",
                        column: x => x.RECIPEID,
                        principalSchema: "C##MVCF1",
                        principalTable: "RECIPES",
                        principalColumn: "RECIPEID");
                });

            migrationBuilder.CreateTable(
                name: "RECIPESALES",
                schema: "C##MVCF1",
                columns: table => new
                {
                    SALEID = table.Column<decimal>(type: "NUMBER", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    RECIPEID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    SALEDATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "NUMBER(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008431", x => x.SALEID);
                    table.ForeignKey(
                        name: "SYS_C008432",
                        column: x => x.USERID,
                        principalSchema: "C##MVCF1",
                        principalTable: "USERS",
                        principalColumn: "USERID");
                    table.ForeignKey(
                        name: "SYS_C008433",
                        column: x => x.RECIPEID,
                        principalSchema: "C##MVCF1",
                        principalTable: "RECIPES",
                        principalColumn: "RECIPEID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHEF_USERID",
                schema: "C##MVCF1",
                table: "CHEF",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_RECIPEID",
                schema: "C##MVCF1",
                table: "FEEDBACK",
                column: "RECIPEID");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_USERID",
                schema: "C##MVCF1",
                table: "FEEDBACK",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_GIFTCARDS_USERID",
                schema: "C##MVCF1",
                table: "GIFTCARDS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_RECIPEID",
                schema: "C##MVCF1",
                table: "PAYMENTS",
                column: "RECIPEID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENTS_USERID",
                schema: "C##MVCF1",
                table: "PAYMENTS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "SYS_C008435",
                schema: "C##MVCF1",
                table: "PAYMENTS",
                column: "CARDID",
                unique: true,
                filter: "\"CARDID\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_CATEGORYID",
                schema: "C##MVCF1",
                table: "RECIPES",
                column: "CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_USERID",
                schema: "C##MVCF1",
                table: "RECIPES",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPESALES_RECIPEID",
                schema: "C##MVCF1",
                table: "RECIPESALES",
                column: "RECIPEID");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPESALES_USERID",
                schema: "C##MVCF1",
                table: "RECIPESALES",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_TESTIMONIALS_USERID",
                schema: "C##MVCF1",
                table: "TESTIMONIALS",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLEID",
                schema: "C##MVCF1",
                table: "USERS",
                column: "ROLEID");

            migrationBuilder.CreateIndex(
                name: "SYS_C008417",
                schema: "C##MVCF1",
                table: "USERS",
                column: "USERNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SYS_C008418",
                schema: "C##MVCF1",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHEF",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "FEEDBACK",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "GIFTCARDS",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "PAYMENTS",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "RECIPESALES",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "TESTIMONIALS",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "RECIPES",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "CATEGORIES",
                schema: "C##MVCF1");

            migrationBuilder.DropTable(
                name: "ROLES",
                schema: "C##MVCF1");

            migrationBuilder.DropSequence(
                name: "CATEGORY_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.DropSequence(
                name: "RECIPE_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.DropSequence(
                name: "ROLE_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.DropSequence(
                name: "USER_ID_SEQ",
                schema: "C##MVCF1");

            migrationBuilder.DropSequence(
                name: "USER_SEQ",
                schema: "C##MVCF1");
        }
    }
}

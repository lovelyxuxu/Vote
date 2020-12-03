using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPowerVote.Migrations
{
    public partial class init20201201165337 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "efusers",
                columns: table => new
                {
                    _id = table.Column<Guid>(nullable: false),
                    openid = table.Column<string>(nullable: false),
                    createTime = table.Column<DateTime>(nullable: false),
                    updateTime = table.Column<DateTime>(nullable: false),
                    vote = table.Column<int>(nullable: false),
                    reason = table.Column<string>(nullable: true),
                    __v = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_efusers", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "efusers");
        }
    }
}

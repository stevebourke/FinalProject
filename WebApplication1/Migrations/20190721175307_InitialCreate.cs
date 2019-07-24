using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    AltNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    EmailConfirm = table.Column<string>(nullable: false),
                    IsMondayChecked = table.Column<bool>(nullable: false),
                    IsTuesdayChecked = table.Column<bool>(nullable: false),
                    IsWednesdayChecked = table.Column<bool>(nullable: false),
                    IsThursdayChecked = table.Column<bool>(nullable: false),
                    IsFridayChecked = table.Column<bool>(nullable: false),
                    IsSaturdayChecked = table.Column<bool>(nullable: false),
                    IsSundayChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "SurfAlerts",
                columns: table => new
                {
                    SurfAlertID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    MinSwellHeight = table.Column<decimal>(nullable: false),
                    MaxSwellHeight = table.Column<decimal>(nullable: false),
                    MaxWind = table.Column<int>(nullable: false),
                    WindDirection = table.Column<string>(nullable: false),
                    MinPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfAlerts", x => x.SurfAlertID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SurfAlerts");
        }
    }
}

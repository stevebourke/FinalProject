using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurfProject.Migrations
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
                    Password = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AltNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    EmailConfirm = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "SurfProfiles",
                columns: table => new
                {
                    SurfProfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberID = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    MinWaveHeight = table.Column<decimal>(nullable: false),
                    MinPeriod = table.Column<int>(nullable: false),
                    SouthWindStrength = table.Column<int>(nullable: false),
                    NorthWindStrength = table.Column<int>(nullable: false),
                    WestWindStrength = table.Column<int>(nullable: false),
                    EastWindStrength = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_SurfProfiles", x => x.SurfProfileID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SurfProfiles");
        }
    }
}

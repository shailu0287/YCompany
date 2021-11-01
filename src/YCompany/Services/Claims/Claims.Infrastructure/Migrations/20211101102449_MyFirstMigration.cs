using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Claims.Infrastructure.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LossDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfAccident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfLoss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfRTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLearnerLicence = table.Column<bool>(type: "bit", nullable: false),
                    CoPassenger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdPartyInjury = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}

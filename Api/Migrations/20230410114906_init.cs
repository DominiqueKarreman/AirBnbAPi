using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        LocationId = table.Column<int>(type: "int", nullable: true),
                        IsCover = table.Column<bool>(type: "bit", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Landlord",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Age = table.Column<int>(type: "int", nullable: false),
                        AvatarId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landlord_Image_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Rooms = table.Column<int>(type: "int", nullable: false),
                        LandlordId = table.Column<int>(type: "int", nullable: false),
                        PricePerDay = table.Column<float>(type: "real", nullable: false),
                        Features = table.Column<int>(type: "int", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Type = table.Column<int>(type: "int", nullable: false),
                        NumberOfGuests = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Landlord_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Discount = table.Column<float>(type: "real", nullable: false),
                        CustomerId = table.Column<int>(type: "int", nullable: false),
                        LocationId = table.Column<int>(type: "int", nullable: false),
                        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Reservation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Image_LocationId",
                table: "Image",
                column: "LocationId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_AvatarId",
                table: "Landlord",
                column: "AvatarId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Location_LandlordId",
                table: "Location",
                column: "LandlordId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocationId",
                table: "Reservation",
                column: "LocationId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Location_LocationId",
                table: "Image",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Image_Location_LocationId", table: "Image");

            migrationBuilder.DropTable(name: "Reservation");

            migrationBuilder.DropTable(name: "Customer");

            migrationBuilder.DropTable(name: "Location");

            migrationBuilder.DropTable(name: "Landlord");

            migrationBuilder.DropTable(name: "Image");
        }
    }
}

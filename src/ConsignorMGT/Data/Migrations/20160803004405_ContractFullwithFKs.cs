using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsignorMGT.Data.Migrations
{
    public partial class ContractFullwithFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractHeader",
                columns: table => new
                {
                    ContractHeaderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsignorCode = table.Column<string>(nullable: true),
                    DateSigned = table.Column<DateTime>(nullable: false),
                    EventNumber = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractHeader", x => x.ContractHeaderID);
                });

            migrationBuilder.CreateTable(
                name: "ContractDetail",
                columns: table => new
                {
                    ContractDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractHeaderID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Manufacture = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    RandRBudget = table.Column<int>(nullable: false),
                    SurchargeRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDetail", x => x.ContractDetailID);
                    table.ForeignKey(
                        name: "FK_ContractDetail_ContractHeader_ContractHeaderID",
                        column: x => x.ContractHeaderID,
                        principalTable: "ContractHeader",
                        principalColumn: "ContractHeaderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractDetail_ContractHeaderID",
                table: "ContractDetail",
                column: "ContractHeaderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractDetail");

            migrationBuilder.DropTable(
                name: "ContractHeader");
        }
    }
}

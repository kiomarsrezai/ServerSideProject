using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHousingApi.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDbAddEntitysTablesRequestBudget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StructureId = table.Column<int>(type: "int", nullable: true),
                    OrganizationKind = table.Column<byte>(type: "tinyint", nullable: true),
                    AreaNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToGetherBudget = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCodingKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodingKindName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCodingNatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodingNatureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingNatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCodingPbbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNumber = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingPbbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCodingPbbs_TblCodingPbbs_MotherId",
                        column: x => x.MotherId,
                        principalTable: "TblCodingPbbs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCodingSemaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingSemaks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCodingSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCommiteKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommiteName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommiteKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCpdates",
                columns: table => new
                {
                    ChrisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParsDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TblCreaditors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaditorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCreaditors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblDoingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDoingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEditBudgetKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditKindName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEditBudgetKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEditBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditBudgetKindId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEditBudgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEditStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEditStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateCalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateDestructions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateDestructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectEstateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeMelli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Father = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstatePayBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectEstateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstatePayBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstatePayEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenovationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstatePayEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstatePayPatents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenovationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstatePayPatents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateProjectAgreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAgreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountCash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountEstate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountPatent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateProjectAgreements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateProjectEstimateDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateProjectEstimateId = table.Column<int>(type: "int", nullable: true),
                    LawDetailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateProjectEstimateDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateRegistries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectEstateId = table.Column<int>(type: "int", nullable: true),
                    NumberRegistry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateRegistries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeighborhoodId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenovationCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEstateUses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateUses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecognition = table.Column<int>(type: "int", nullable: true),
                    IdKind = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblIncomeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    IncomeId = table.Column<int>(type: "int", nullable: true),
                    CodingSemakId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: true),
                    IdKol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMoien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblIncomeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    ShSerialFish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShenaseGhabz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SdateSodoor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MablaghKol = table.Column<long>(type: "bigint", nullable: true),
                    SanadMd = table.Column<int>(type: "int", nullable: true),
                    SimakMalekName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblIncomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblInsuranceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInsuranceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblKols",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    IdGroup = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMoiens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    IdKol = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMoiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProctorNameShort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProjectScales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectScaleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProjectScales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRangBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromNumber = table.Column<long>(type: "bigint", nullable: true),
                    EndNumber = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRangBudgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRecognitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRecognitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblResponsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsibilityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblResponsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSalMds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    IdSalMdS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSalMds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSanadDetailMds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanadMd = table.Column<long>(type: "bigint", nullable: true),
                    IdSalSanadMd = table.Column<long>(type: "bigint", nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    IdKol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMoien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeVasetSazman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSotooh4 = table.Column<long>(type: "bigint", nullable: true),
                    IdTafsily5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSotooh5 = table.Column<long>(type: "bigint", nullable: true),
                    CodeVasetShahrdari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSotooh6 = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedehkar = table.Column<long>(type: "bigint", nullable: true),
                    Bestankar = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadDetailMds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSanadKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KindName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSanadMds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    SanadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SanadDateS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSanadkind = table.Column<long>(type: "bigint", nullable: true),
                    IdSanadState = table.Column<long>(type: "bigint", nullable: true),
                    DescSanadMd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadMds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSanadStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSanadStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblSuppliersCoKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyKindName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSuppliersCoKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblTafsilies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSotooh = table.Column<long>(type: "bigint", nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true),
                    IdTafsilyGroup = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsilyType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTafsilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblVasets",
                columns: table => new
                {
                    VasetId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    IdTafsily4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameTafsily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markhazhazine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supply = table.Column<long>(type: "bigint", nullable: true),
                    Takhsis = table.Column<long>(type: "bigint", nullable: true),
                    Expense = table.Column<long>(type: "bigint", nullable: true),
                    CodeVaset = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TblVasetsBanks",
                columns: table => new
                {
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    IdTafsily4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameTafsily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expense = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TblVasetTamins",
                columns: table => new
                {
                    BodgetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodgetDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPrice = table.Column<long>(type: "bigint", nullable: true),
                    ReqDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestRefStr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCredit = table.Column<int>(type: "int", nullable: true),
                    SectionExecutive = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TblVasetTarazSazmen",
                columns: table => new
                {
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMoien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTafsily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expense = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TblVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nmber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nmber8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pelak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblVehiclesKindInsurances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehiclesKindInsurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblVehiclestechnicalDiagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehiclestechnicalDiagnoses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblVehiclesTransfers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehiclesTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearName = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblDepartmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblDepartmen_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblDepartmen_TblDepartmen_MotherId",
                        column: x => x.MotherId,
                        principalTable: "TblDepartmen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    OrgCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblOrganizations_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblOrganizations_TblOrganizations_MotherId",
                        column: x => x.MotherId,
                        principalTable: "TblOrganizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblEstateProjectEstimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateProjectId = table.Column<int>(type: "int", nullable: true),
                    KindEstimateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEstateProjectEstimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblEstateProjectEstimates_TblEstateProjects_EstateProjectId",
                        column: x => x.EstateProjectId,
                        principalTable: "TblEstateProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCodings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelNumber = table.Column<int>(type: "int", nullable: true),
                    TblBudgetProcessId = table.Column<int>(type: "int", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: true),
                    Crud = table.Column<bool>(type: "bit", nullable: true),
                    CodingPbbid = table.Column<int>(type: "int", nullable: true),
                    CodePbb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeVaset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProctorId = table.Column<int>(type: "int", nullable: true),
                    CodingKindId = table.Column<int>(type: "int", nullable: true),
                    CodeVasetTaminEtebarat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true),
                    CodingNatureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCodings_TblBudgetProcesses_TblBudgetProcessId",
                        column: x => x.TblBudgetProcessId,
                        principalTable: "TblBudgetProcesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblCodingKinds_CodingKindId",
                        column: x => x.CodingKindId,
                        principalTable: "TblCodingKinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblCodingNatures_CodingNatureId",
                        column: x => x.CodingNatureId,
                        principalTable: "TblCodingNatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblCodingPbbs_CodingPbbid",
                        column: x => x.CodingPbbid,
                        principalTable: "TblCodingPbbs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblCodingSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "TblCodingSubjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblCodings_MotherId",
                        column: x => x.MotherId,
                        principalTable: "TblCodings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCodings_TblProctors_ProctorId",
                        column: x => x.ProctorId,
                        principalTable: "TblProctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblProgramOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TblAreaId = table.Column<int>(type: "int", nullable: true),
                    TblProgramId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProgramOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProgramOperations_TblAreas_TblAreaId",
                        column: x => x.TblAreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblProgramOperations_TblPrograms_TblProgramId",
                        column: x => x.TblProgramId,
                        principalTable: "TblPrograms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherId = table.Column<int>(type: "int", nullable: true),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AreaList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectScaleId = table.Column<int>(type: "int", nullable: true),
                    AreaArray = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProjects_TblProjectScales_ProjectScaleId",
                        column: x => x.ProjectScaleId,
                        principalTable: "TblProjectScales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblProjects_TblProjects_MotherId",
                        column: x => x.MotherId,
                        principalTable: "TblProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblSanads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearFinancialId = table.Column<int>(type: "int", nullable: true),
                    SanadKindId = table.Column<int>(type: "int", nullable: true),
                    SanadStatusId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSanads_TblSanadKinds_SanadKindId",
                        column: x => x.SanadKindId,
                        principalTable: "TblSanadKinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblSanads_TblSanadStatuses_SanadStatusId",
                        column: x => x.SanadStatusId,
                        principalTable: "TblSanadStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblSignDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignId = table.Column<int>(type: "int", nullable: true),
                    Sample = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSignDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSignDetails_TblSigns_SignId",
                        column: x => x.SignId,
                        principalTable: "TblSigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersCoKindId = table.Column<int>(type: "int", nullable: true),
                    Shenase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EconomicalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersKindId = table.Column<int>(type: "int", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirsrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumberCo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlackList = table.Column<bool>(type: "bit", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberBank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSuppliers_TblSuppliersCoKinds_SuppliersCoKindId",
                        column: x => x.SuppliersCoKindId,
                        principalTable: "TblSuppliersCoKinds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblVehiclesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiclesId = table.Column<int>(type: "int", nullable: true),
                    KindId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalcFuelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleFuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotaAllocate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceQuota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceFree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sanad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehiclesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblVehiclesDetails_TblVehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "TblVehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetPerformanceAccepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    MonthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetPerformanceAccepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetPerformanceAccepts_TblYears_YearId",
                        column: x => x.YearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TblYearId = table.Column<int>(type: "int", nullable: true),
                    TblAreaId = table.Column<int>(type: "int", nullable: true),
                    ActiveRevenue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveCurrent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveFinancial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationKind = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgets_TblAreas_TblAreaId",
                        column: x => x.TblAreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgets_TblYears_TblYearId",
                        column: x => x.TblYearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCommites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    CommiteKindId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCommites_TblCommiteKinds_CommiteKindId",
                        column: x => x.CommiteKindId,
                        principalTable: "TblCommiteKinds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCommites_TblYears_YearId",
                        column: x => x.YearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    PaymentKindId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: true),
                    YearId1 = table.Column<int>(type: "int", nullable: true),
                    AreaId1 = table.Column<int>(type: "int", nullable: true),
                    Number1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    SuppliersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PureAmount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPayments_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblPayments_TblYears_YearId",
                        column: x => x.YearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    SuppliersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PureAmount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPays_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblPays_TblYears_YearId",
                        column: x => x.YearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblDepartmentAcceptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartmentAcceptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblDepartmentAcceptors_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblDepartmentAcceptors_TblDepartmen_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "TblDepartmen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblRequestSigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRequestSigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRequestSigns_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequestSigns_TblDepartmen_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TblDepartmen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequestSigns_Users_Tbl_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users_Tbl",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "TblCodingsMapSazmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    CodingId = table.Column<int>(type: "int", nullable: true),
                    CodeAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentBud = table.Column<byte>(type: "tinyint", nullable: true),
                    CodeVasetShahrdari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearName = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodingsMapSazmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCodingsMapSazmen_TblCodings_CodingId",
                        column: x => x.CodingId,
                        principalTable: "TblCodings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDetails_TblProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TblProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblProgramOperationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TblProgramOperationId = table.Column<int>(type: "int", nullable: true),
                    TblProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProgramOperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProgramOperationDetails_TblProgramOperations_TblProgramOperationId",
                        column: x => x.TblProgramOperationId,
                        principalTable: "TblProgramOperations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblProgramOperationDetails_TblProjects_TblProjectId",
                        column: x => x.TblProjectId,
                        principalTable: "TblProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoingMethodId = table.Column<byte>(type: "tinyint", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: true),
                    Surplus = table.Column<long>(type: "bigint", nullable: true),
                    Final = table.Column<bool>(type: "bit", nullable: true),
                    ZemanatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ZemanatDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatBank = table.Column<int>(type: "int", nullable: true),
                    ZemanatShobe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatModat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatModatUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZemanatType = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agreement46 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agreement48 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContracts_TblSuppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "TblSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    BodgetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodgetDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    RequestKindId = table.Column<byte>(type: "tinyint", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    DoingMethodId = table.Column<int>(type: "int", nullable: true),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimateAmount = table.Column<long>(type: "bigint", nullable: true),
                    ResonDoingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DateS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRequests_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequests_TblDoingMethods_DoingMethodId",
                        column: x => x.DoingMethodId,
                        principalTable: "TblDoingMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequests_TblSuppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "TblSuppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequests_TblYears_YearId",
                        column: x => x.YearId,
                        principalTable: "TblYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblSanadDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanadId = table.Column<int>(type: "int", nullable: true),
                    CodingId = table.Column<int>(type: "int", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedehkar = table.Column<long>(type: "bigint", nullable: true),
                    Bestankar = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSanadDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSanadDetails_TblCodings_CodingId",
                        column: x => x.CodingId,
                        principalTable: "TblCodings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblSanadDetails_TblSanads_SanadId",
                        column: x => x.SanadId,
                        principalTable: "TblSanads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblSanadDetails_TblSuppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "TblSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblSuppliersCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSuppliersCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblSuppliersCalls_TblSuppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "TblSuppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetPerformanceAcceptDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetPerformanceAcceptId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetPerformanceAcceptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetPerformanceAcceptDetails_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgetPerformanceAcceptDetails_TblBudgetPerformanceAccepts_BudgetPerformanceAcceptId",
                        column: x => x.BudgetPerformanceAcceptId,
                        principalTable: "TblBudgetPerformanceAccepts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(type: "int", nullable: true),
                    TblCodingId = table.Column<int>(type: "int", nullable: true),
                    MosavabPublic = table.Column<long>(type: "bigint", nullable: true),
                    Allocation = table.Column<long>(type: "bigint", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetails_TblBudgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "TblBudgets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgetDetails_TblCodings_TblCodingId",
                        column: x => x.TblCodingId,
                        principalTable: "TblCodings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCommiteDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<byte>(type: "tinyint", nullable: true),
                    CommiteId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommiteDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCommiteDetails_TblCommites_CommiteId",
                        column: x => x.CommiteId,
                        principalTable: "TblCommites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblCommiteDetails_TblProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TblProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPaymentAcceptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accept = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPaymentAcceptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPaymentAcceptors_TblPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "TblPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblPaymentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    RequestContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPaymentDetails_TblPayments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "TblPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblDepartmentAcceptorUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAcceptorId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resposibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartmentAcceptorUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblDepartmentAcceptorUsers_TblDepartmentAcceptors_DepartmanAcceptorId",
                        column: x => x.DepartmanAcceptorId,
                        principalTable: "TblDepartmentAcceptors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblContractAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    ShareAmount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContractAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContractAreas_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblContractAreas_TblContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TblContracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblContractRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContractRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContractRequests_TblContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "TblContracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblContractRequests_TblRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TblRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblRequestAcceptors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAccept = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Accept = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRequestAcceptors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRequestAcceptors_TblRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TblRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblRequestTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    OthersDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRequestTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRequestTables_TblRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TblRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetailEdits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDetailId = table.Column<int>(type: "int", nullable: true),
                    Decrease = table.Column<long>(type: "bigint", nullable: true),
                    Increase = table.Column<long>(type: "bigint", nullable: true),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetailEdits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailEdits_TblBudgetDetails_BudgetDetailId",
                        column: x => x.BudgetDetailId,
                        principalTable: "TblBudgetDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetailProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDetailId = table.Column<int>(type: "int", nullable: true),
                    ProgramOperationDetailsId = table.Column<int>(type: "int", nullable: true),
                    Mosavab = table.Column<long>(type: "bigint", nullable: true),
                    EditProject = table.Column<long>(type: "bigint", nullable: true),
                    Supply = table.Column<long>(type: "bigint", nullable: true),
                    Takhsis = table.Column<long>(type: "bigint", nullable: true),
                    Expense = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetailProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjects_TblBudgetDetails_BudgetDetailId",
                        column: x => x.BudgetDetailId,
                        principalTable: "TblBudgetDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjects_TblProgramOperationDetails_ProgramOperationDetailsId",
                        column: x => x.ProgramOperationDetailsId,
                        principalTable: "TblProgramOperationDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCommiteDetailAccepts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommiteDetailId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resposibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAccept = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommiteDetailAccepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCommiteDetailAccepts_TblCommiteDetails_CommiteDetailId",
                        column: x => x.CommiteDetailId,
                        principalTable: "TblCommiteDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCommiteDetailEstimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommiteDetailId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommiteDetailEstimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCommiteDetailEstimates_TblCommiteDetails_CommiteDetailId",
                        column: x => x.CommiteDetailId,
                        principalTable: "TblCommiteDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblCommiteDetailWbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommiteDetailId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCommiteDetailWbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCommiteDetailWbs_TblCommiteDetails_CommiteDetailId",
                        column: x => x.CommiteDetailId,
                        principalTable: "TblCommiteDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetailProjectAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDetailProjectId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Mosavab = table.Column<long>(type: "bigint", nullable: true),
                    EditArea = table.Column<long>(type: "bigint", nullable: true),
                    Supply = table.Column<long>(type: "bigint", nullable: true),
                    Takhsis = table.Column<long>(type: "bigint", nullable: true),
                    Expense = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetailProjectAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjectAreas_TblAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TblAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjectAreas_TblBudgetDetailProjects_BudgetDetailProjectId",
                        column: x => x.BudgetDetailProjectId,
                        principalTable: "TblBudgetDetailProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetailProjectAreaDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDetailProjectAreaId = table.Column<int>(type: "int", nullable: true),
                    DepartmenId = table.Column<int>(type: "int", nullable: true),
                    MosavabDepartment = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetailProjectAreaDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjectAreaDepartments_TblBudgetDetailProjectAreas_BudgetDetailProjectAreaId",
                        column: x => x.BudgetDetailProjectAreaId,
                        principalTable: "TblBudgetDetailProjectAreas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblBudgetDetailProjectAreaEdit12345678910s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetDetailProjectAreaId = table.Column<int>(type: "int", nullable: true),
                    Decrease = table.Column<long>(type: "bigint", nullable: true),
                    Increase = table.Column<long>(type: "bigint", nullable: true),
                    EditStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBudgetDetailProjectAreaEdit12345678910s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjectAreaEdit12345678910s_TblBudgetDetailProjectAreas_BudgetDetailProjectAreaId",
                        column: x => x.BudgetDetailProjectAreaId,
                        principalTable: "TblBudgetDetailProjectAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblBudgetDetailProjectAreaEdit12345678910s_TblEditStatuses_EditStatusId",
                        column: x => x.EditStatusId,
                        principalTable: "TblEditStatuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TblRequestBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: true),
                    BudgetDetailProjectAreaId = table.Column<int>(type: "int", nullable: true),
                    RequestBudgetAmount = table.Column<long>(type: "bigint", nullable: true),
                    BodgetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodgetDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRequestBudgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblRequestBudgets_TblBudgetDetailProjectAreas_BudgetDetailProjectAreaId",
                        column: x => x.BudgetDetailProjectAreaId,
                        principalTable: "TblBudgetDetailProjectAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TblRequestBudgets_TblRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TblRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDetails_ProjectId",
                table: "FileDetails",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailEdits_BudgetDetailId",
                table: "TblBudgetDetailEdits",
                column: "BudgetDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjectAreaDepartments_BudgetDetailProjectAreaId",
                table: "TblBudgetDetailProjectAreaDepartments",
                column: "BudgetDetailProjectAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjectAreaEdit12345678910s_BudgetDetailProjectAreaId",
                table: "TblBudgetDetailProjectAreaEdit12345678910s",
                column: "BudgetDetailProjectAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjectAreaEdit12345678910s_EditStatusId",
                table: "TblBudgetDetailProjectAreaEdit12345678910s",
                column: "EditStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjectAreas_AreaId",
                table: "TblBudgetDetailProjectAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjectAreas_BudgetDetailProjectId",
                table: "TblBudgetDetailProjectAreas",
                column: "BudgetDetailProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjects_BudgetDetailId",
                table: "TblBudgetDetailProjects",
                column: "BudgetDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetailProjects_ProgramOperationDetailsId",
                table: "TblBudgetDetailProjects",
                column: "ProgramOperationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetails_BudgetId",
                table: "TblBudgetDetails",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetDetails_TblCodingId",
                table: "TblBudgetDetails",
                column: "TblCodingId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetPerformanceAcceptDetails_AreaId",
                table: "TblBudgetPerformanceAcceptDetails",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetPerformanceAcceptDetails_BudgetPerformanceAcceptId",
                table: "TblBudgetPerformanceAcceptDetails",
                column: "BudgetPerformanceAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgetPerformanceAccepts_YearId",
                table: "TblBudgetPerformanceAccepts",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgets_TblAreaId",
                table: "TblBudgets",
                column: "TblAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBudgets_TblYearId",
                table: "TblBudgets",
                column: "TblYearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodingPbbs_MotherId",
                table: "TblCodingPbbs",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_CodingKindId",
                table: "TblCodings",
                column: "CodingKindId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_CodingNatureId",
                table: "TblCodings",
                column: "CodingNatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_CodingPbbid",
                table: "TblCodings",
                column: "CodingPbbid");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_MotherId",
                table: "TblCodings",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_ProctorId",
                table: "TblCodings",
                column: "ProctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_SubjectId",
                table: "TblCodings",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodings_TblBudgetProcessId",
                table: "TblCodings",
                column: "TblBudgetProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCodingsMapSazmen_CodingId",
                table: "TblCodingsMapSazmen",
                column: "CodingId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommiteDetailAccepts_CommiteDetailId",
                table: "TblCommiteDetailAccepts",
                column: "CommiteDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommiteDetailEstimates_CommiteDetailId",
                table: "TblCommiteDetailEstimates",
                column: "CommiteDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommiteDetails_CommiteId",
                table: "TblCommiteDetails",
                column: "CommiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommiteDetails_ProjectId",
                table: "TblCommiteDetails",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommiteDetailWbs_CommiteDetailId",
                table: "TblCommiteDetailWbs",
                column: "CommiteDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommites_CommiteKindId",
                table: "TblCommites",
                column: "CommiteKindId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCommites_YearId",
                table: "TblCommites",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContractAreas_AreaId",
                table: "TblContractAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContractAreas_ContractId",
                table: "TblContractAreas",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContractRequests_ContractId",
                table: "TblContractRequests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContractRequests_RequestId",
                table: "TblContractRequests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblContracts_SuppliersId",
                table: "TblContracts",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDepartmen_AreaId",
                table: "TblDepartmen",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDepartmen_MotherId",
                table: "TblDepartmen",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDepartmentAcceptors_AreaId",
                table: "TblDepartmentAcceptors",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDepartmentAcceptors_DepartmanId",
                table: "TblDepartmentAcceptors",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDepartmentAcceptorUsers_DepartmanAcceptorId",
                table: "TblDepartmentAcceptorUsers",
                column: "DepartmanAcceptorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEstateProjectEstimates_EstateProjectId",
                table: "TblEstateProjectEstimates",
                column: "EstateProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrganizations_AreaId",
                table: "TblOrganizations",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOrganizations_MotherId",
                table: "TblOrganizations",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPaymentAcceptors_PaymentId",
                table: "TblPaymentAcceptors",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPaymentDetails_PaymentId",
                table: "TblPaymentDetails",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPayments_AreaId",
                table: "TblPayments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPayments_YearId",
                table: "TblPayments",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPays_AreaId",
                table: "TblPays",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPays_YearId",
                table: "TblPays",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProgramOperationDetails_TblProgramOperationId",
                table: "TblProgramOperationDetails",
                column: "TblProgramOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProgramOperationDetails_TblProjectId",
                table: "TblProgramOperationDetails",
                column: "TblProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProgramOperations_TblAreaId",
                table: "TblProgramOperations",
                column: "TblAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProgramOperations_TblProgramId",
                table: "TblProgramOperations",
                column: "TblProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProjects_MotherId",
                table: "TblProjects",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProjects_ProjectScaleId",
                table: "TblProjects",
                column: "ProjectScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestAcceptors_RequestId",
                table: "TblRequestAcceptors",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestBudgets_BudgetDetailProjectAreaId",
                table: "TblRequestBudgets",
                column: "BudgetDetailProjectAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestBudgets_RequestId",
                table: "TblRequestBudgets",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequests_AreaId",
                table: "TblRequests",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequests_DoingMethodId",
                table: "TblRequests",
                column: "DoingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequests_SuppliersId",
                table: "TblRequests",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequests_YearId",
                table: "TblRequests",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestSigns_AreaId",
                table: "TblRequestSigns",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestSigns_DepartmentId",
                table: "TblRequestSigns",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestSigns_EmployeeId",
                table: "TblRequestSigns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRequestTables_RequestId",
                table: "TblRequestTables",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSanadDetails_CodingId",
                table: "TblSanadDetails",
                column: "CodingId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSanadDetails_SanadId",
                table: "TblSanadDetails",
                column: "SanadId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSanadDetails_SuppliersId",
                table: "TblSanadDetails",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSanads_SanadKindId",
                table: "TblSanads",
                column: "SanadKindId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSanads_SanadStatusId",
                table: "TblSanads",
                column: "SanadStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSignDetails_SignId",
                table: "TblSignDetails",
                column: "SignId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSuppliers_SuppliersCoKindId",
                table: "TblSuppliers",
                column: "SuppliersCoKindId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSuppliersCalls_SuppliersId",
                table: "TblSuppliersCalls",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVehiclesDetails_VehiclesId",
                table: "TblVehiclesDetails",
                column: "VehiclesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "TblAudits");

            migrationBuilder.DropTable(
                name: "TblBudgetDetailEdits");

            migrationBuilder.DropTable(
                name: "TblBudgetDetailProjectAreaDepartments");

            migrationBuilder.DropTable(
                name: "TblBudgetDetailProjectAreaEdit12345678910s");

            migrationBuilder.DropTable(
                name: "TblBudgetPerformanceAcceptDetails");

            migrationBuilder.DropTable(
                name: "TblCodingSemaks");

            migrationBuilder.DropTable(
                name: "TblCodingsMapSazmen");

            migrationBuilder.DropTable(
                name: "TblCommiteDetailAccepts");

            migrationBuilder.DropTable(
                name: "TblCommiteDetailEstimates");

            migrationBuilder.DropTable(
                name: "TblCommiteDetailWbs");

            migrationBuilder.DropTable(
                name: "TblContractAreas");

            migrationBuilder.DropTable(
                name: "TblContractRequests");

            migrationBuilder.DropTable(
                name: "TblCpdates");

            migrationBuilder.DropTable(
                name: "TblCreaditors");

            migrationBuilder.DropTable(
                name: "TblDepartmentAcceptorUsers");

            migrationBuilder.DropTable(
                name: "TblEditBudgetKinds");

            migrationBuilder.DropTable(
                name: "TblEditBudgets");

            migrationBuilder.DropTable(
                name: "TblEstateCalls");

            migrationBuilder.DropTable(
                name: "TblEstateDestructions");

            migrationBuilder.DropTable(
                name: "TblEstateOwners");

            migrationBuilder.DropTable(
                name: "TblEstatePayBanks");

            migrationBuilder.DropTable(
                name: "TblEstatePayEstates");

            migrationBuilder.DropTable(
                name: "TblEstatePayPatents");

            migrationBuilder.DropTable(
                name: "TblEstateProjectAgreements");

            migrationBuilder.DropTable(
                name: "TblEstateProjectEstimateDetails");

            migrationBuilder.DropTable(
                name: "TblEstateProjectEstimates");

            migrationBuilder.DropTable(
                name: "TblEstateRegistries");

            migrationBuilder.DropTable(
                name: "TblEstates");

            migrationBuilder.DropTable(
                name: "TblEstateUses");

            migrationBuilder.DropTable(
                name: "TblGroups");

            migrationBuilder.DropTable(
                name: "TblIncomeDetails");

            migrationBuilder.DropTable(
                name: "TblIncomes");

            migrationBuilder.DropTable(
                name: "TblInsuranceCompanies");

            migrationBuilder.DropTable(
                name: "TblKinds");

            migrationBuilder.DropTable(
                name: "TblKols");

            migrationBuilder.DropTable(
                name: "TblMoiens");

            migrationBuilder.DropTable(
                name: "TblOrganizations");

            migrationBuilder.DropTable(
                name: "TblPaymentAcceptors");

            migrationBuilder.DropTable(
                name: "TblPaymentDetails");

            migrationBuilder.DropTable(
                name: "TblPays");

            migrationBuilder.DropTable(
                name: "TblPermissions");

            migrationBuilder.DropTable(
                name: "TblRangBudgets");

            migrationBuilder.DropTable(
                name: "TblRecognitions");

            migrationBuilder.DropTable(
                name: "TblRequestAcceptors");

            migrationBuilder.DropTable(
                name: "TblRequestBudgets");

            migrationBuilder.DropTable(
                name: "TblRequestSigns");

            migrationBuilder.DropTable(
                name: "TblRequestTables");

            migrationBuilder.DropTable(
                name: "TblResponsibilities");

            migrationBuilder.DropTable(
                name: "TblSalMds");

            migrationBuilder.DropTable(
                name: "TblSanadDetailMds");

            migrationBuilder.DropTable(
                name: "TblSanadDetails");

            migrationBuilder.DropTable(
                name: "TblSanadMds");

            migrationBuilder.DropTable(
                name: "TblSanadStates");

            migrationBuilder.DropTable(
                name: "TblSignDetails");

            migrationBuilder.DropTable(
                name: "TblSuppliersCalls");

            migrationBuilder.DropTable(
                name: "TblTafsilies");

            migrationBuilder.DropTable(
                name: "TblVasets");

            migrationBuilder.DropTable(
                name: "TblVasetsBanks");

            migrationBuilder.DropTable(
                name: "TblVasetTamins");

            migrationBuilder.DropTable(
                name: "TblVasetTarazSazmen");

            migrationBuilder.DropTable(
                name: "TblVehiclesDetails");

            migrationBuilder.DropTable(
                name: "TblVehiclesKindInsurances");

            migrationBuilder.DropTable(
                name: "TblVehiclestechnicalDiagnoses");

            migrationBuilder.DropTable(
                name: "TblVehiclesTransfers");

            migrationBuilder.DropTable(
                name: "TblEditStatuses");

            migrationBuilder.DropTable(
                name: "TblBudgetPerformanceAccepts");

            migrationBuilder.DropTable(
                name: "TblCommiteDetails");

            migrationBuilder.DropTable(
                name: "TblContracts");

            migrationBuilder.DropTable(
                name: "TblDepartmentAcceptors");

            migrationBuilder.DropTable(
                name: "TblEstateProjects");

            migrationBuilder.DropTable(
                name: "TblPayments");

            migrationBuilder.DropTable(
                name: "TblBudgetDetailProjectAreas");

            migrationBuilder.DropTable(
                name: "TblRequests");

            migrationBuilder.DropTable(
                name: "TblSanads");

            migrationBuilder.DropTable(
                name: "TblSigns");

            migrationBuilder.DropTable(
                name: "TblVehicles");

            migrationBuilder.DropTable(
                name: "TblCommites");

            migrationBuilder.DropTable(
                name: "TblDepartmen");

            migrationBuilder.DropTable(
                name: "TblBudgetDetailProjects");

            migrationBuilder.DropTable(
                name: "TblDoingMethods");

            migrationBuilder.DropTable(
                name: "TblSuppliers");

            migrationBuilder.DropTable(
                name: "TblSanadKinds");

            migrationBuilder.DropTable(
                name: "TblSanadStatuses");

            migrationBuilder.DropTable(
                name: "TblCommiteKinds");

            migrationBuilder.DropTable(
                name: "TblBudgetDetails");

            migrationBuilder.DropTable(
                name: "TblProgramOperationDetails");

            migrationBuilder.DropTable(
                name: "TblSuppliersCoKinds");

            migrationBuilder.DropTable(
                name: "TblBudgets");

            migrationBuilder.DropTable(
                name: "TblCodings");

            migrationBuilder.DropTable(
                name: "TblProgramOperations");

            migrationBuilder.DropTable(
                name: "TblProjects");

            migrationBuilder.DropTable(
                name: "TblYears");

            migrationBuilder.DropTable(
                name: "TblBudgetProcesses");

            migrationBuilder.DropTable(
                name: "TblCodingKinds");

            migrationBuilder.DropTable(
                name: "TblCodingNatures");

            migrationBuilder.DropTable(
                name: "TblCodingPbbs");

            migrationBuilder.DropTable(
                name: "TblCodingSubjects");

            migrationBuilder.DropTable(
                name: "TblProctors");

            migrationBuilder.DropTable(
                name: "TblAreas");

            migrationBuilder.DropTable(
                name: "TblPrograms");

            migrationBuilder.DropTable(
                name: "TblProjectScales");
        }
    }
}

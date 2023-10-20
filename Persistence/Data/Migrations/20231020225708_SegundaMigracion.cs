using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SueldoBase = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "forma_pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forma_pago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreInsumo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnit = table.Column<double>(type: "double", nullable: false),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Talla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talla", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_estado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoPersona = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_proteccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_proteccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDepartamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_pais_IdPaisFK",
                        column: x => x.IdPaisFK,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_tipo_estado_IdTipoEstadoFK",
                        column: x => x.IdTipoEstadoFK,
                        principalTable: "tipo_estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuarioFK = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_token_user_IdUsuarioFK",
                        column: x => x.IdUsuarioFK,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    IdUsuarioFK = table.Column<int>(type: "int", nullable: false),
                    IdRolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.IdUsuarioFK, x.IdRolFK });
                    table.ForeignKey(
                        name: "FK_userRol_rol_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_IdUsuarioFK",
                        column: x => x.IdUsuarioFK,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMunicipio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_municipio_Departamento_IdDepartamentoFK",
                        column: x => x.IdDepartamentoFK,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPrenda = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombrePrenda = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitCop = table.Column<double>(type: "double", nullable: false),
                    ValorUnitUsd = table.Column<double>(type: "double", nullable: false),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false),
                    IdTipoProteccionFK = table.Column<int>(type: "int", nullable: false),
                    IdGneroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prenda_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenda_Genero_IdGneroFK",
                        column: x => x.IdGneroFK,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenda_tipo_proteccion_IdTipoProteccionFK",
                        column: x => x.IdTipoProteccionFK,
                        principalTable: "tipo_proteccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoCliente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCliente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoPersonaFK = table.Column<int>(type: "int", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_tipo_persona_IdTipoPersonaFK",
                        column: x => x.IdTipoPersonaFK,
                        principalTable: "tipo_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreEmpleado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCargoFK = table.Column<int>(type: "int", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_cargo_IdCargoFK",
                        column: x => x.IdCargoFK,
                        principalTable: "cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NitEmpresa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RazonSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepresentanteLegal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NitProveedor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreProveedor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersonaFK = table.Column<int>(type: "int", nullable: false),
                    IdMunicipioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_municipio_IdMunicipioFk",
                        column: x => x.IdMunicipioFk,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedor_tipo_persona_IdTipoPersonaFK",
                        column: x => x.IdTipoPersonaFK,
                        principalTable: "tipo_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insumo_prenda",
                columns: table => new
                {
                    IdInsumoFK = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo_prenda", x => new { x.IdInsumoFK, x.IdPrendaFK });
                    table.ForeignKey(
                        name: "FK_insumo_prenda_Insumo_IdInsumoFK",
                        column: x => x.IdInsumoFK,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insumo_prenda_Prenda_IdPrendaFK",
                        column: x => x.IdPrendaFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoInventario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorVtaCop = table.Column<double>(type: "double", nullable: false),
                    ValorVtaUsd = table.Column<double>(type: "double", nullable: false),
                    IdPredaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventario_Prenda_IdPredaFK",
                        column: x => x.IdPredaFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaOrden = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Empleado_IdEmpleadoFk",
                        column: x => x.IdEmpleadoFk,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaVenta = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    IdFormaPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_forma_pago_IdFormaPago",
                        column: x => x.IdFormaPago,
                        principalTable: "forma_pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insumo_proveedor",
                columns: table => new
                {
                    IdInsumoFK = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insumo_proveedor", x => new { x.IdInsumoFK, x.IdProveedorFK });
                    table.ForeignKey(
                        name: "FK_insumo_proveedor_Insumo_IdInsumoFK",
                        column: x => x.IdInsumoFK,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insumo_proveedor_Proveedor_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventario_talla",
                columns: table => new
                {
                    IdInventarioFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFk = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario_talla", x => new { x.IdInventarioFK, x.IdTallaFk });
                    table.ForeignKey(
                        name: "FK_inventario_talla_Inventario_IdInventarioFK",
                        column: x => x.IdInventarioFK,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_talla_Talla_IdTallaFk",
                        column: x => x.IdTallaFk,
                        principalTable: "Talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CatidadProducir = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<int>(type: "int", nullable: false),
                    IdOrdenFK = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFK = table.Column<int>(type: "int", nullable: false),
                    IdColorFK = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_orden_Color_IdColorFK",
                        column: x => x.IdColorFK,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_Orden_IdOrdenFK",
                        column: x => x.IdOrdenFK,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_orden_Prenda_IdPrendaFK",
                        column: x => x.IdPrendaFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnit = table.Column<double>(type: "double", nullable: false),
                    IdVentaFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFk = table.Column<int>(type: "int", nullable: false),
                    IdInventarioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalle_venta_Inventario_IdInventarioFK",
                        column: x => x.IdInventarioFK,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_venta_Talla_IdTallaFk",
                        column: x => x.IdTallaFk,
                        principalTable: "Talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_venta_Venta_IdVentaFK",
                        column: x => x.IdVentaFK,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Rosa" },
                    { 2, "Magenta" },
                    { 3, "Naranja" },
                    { 4, "Rojo" },
                    { 5, "Azul" }
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" },
                    { 3, "Unisex" }
                });

            migrationBuilder.InsertData(
                table: "Insumo",
                columns: new[] { "Id", "NombreInsumo", "StockMax", "StockMin", "ValorUnit" },
                values: new object[,]
                {
                    { 1, "Tela", 100, 20, 10000.0 },
                    { 2, "Botones", 100, 20, 5000.0 },
                    { 3, "Aguja", 100, 20, 2000.0 },
                    { 4, "Pintura", 100, 20, 15000.0 }
                });

            migrationBuilder.InsertData(
                table: "Talla",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "L" },
                    { 3, "XL" },
                    { 4, "XLL" }
                });

            migrationBuilder.InsertData(
                table: "cargo",
                columns: new[] { "Id", "Descripcion", "SueldoBase" },
                values: new object[,]
                {
                    { 1, "Limpiador", 50000.0 },
                    { 2, "Estilista", 100000.0 },
                    { 3, "Cajera", 70000.0 }
                });

            migrationBuilder.InsertData(
                table: "forma_pago",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta" },
                    { 3, "En Especie" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "NombrePais" },
                values: new object[,]
                {
                    { 1, "Colombia" },
                    { 2, "Venezuela" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "rolName" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tipo_estado",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Finalizado" },
                    { 2, "En Produccion" },
                    { 3, "Vendido" }
                });

            migrationBuilder.InsertData(
                table: "tipo_persona",
                columns: new[] { "Id", "NombreTipoPersona" },
                values: new object[,]
                {
                    { 1, "Persona Natura" },
                    { 2, "Persona Juridica" }
                });

            migrationBuilder.InsertData(
                table: "tipo_proteccion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "No Proteje" },
                    { 2, "Anti Fuego" },
                    { 3, "Anti Balas" },
                    { 4, "Anti Arañasos" }
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "Id", "IdPaisFK", "NombreDepartamento" },
                values: new object[,]
                {
                    { 1, 1, "Santander" },
                    { 2, 1, "Cundinamarca" },
                    { 3, 2, "Carabobo" },
                    { 4, 2, "Caracas" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion", "IdTipoEstadoFK" },
                values: new object[,]
                {
                    { 1, "Finalizado", 1 },
                    { 2, "Descansando", 2 },
                    { 3, "No lo voy a hacer", 2 },
                    { 4, "Vendido", 3 }
                });

            migrationBuilder.InsertData(
                table: "Prenda",
                columns: new[] { "Id", "IdEstadoFK", "IdGneroFK", "IdPrenda", "IdTipoProteccionFK", "NombrePrenda", "ValorUnitCop", "ValorUnitUsd" },
                values: new object[,]
                {
                    { 1, 1, 1, "", 1, "Camiceta", 50000.0, 10.0 },
                    { 2, 1, 2, "", 2, "Pantalon", 100000.0, 20.0 },
                    { 3, 2, 1, "", 3, "Vestido", 120000.0, 25.0 },
                    { 4, 1, 2, "", 1, "Gorra", 30000.0, 7.0 },
                    { 5, 2, 1, "", 2, "Sudadera", 40000.0, 9.0 }
                });

            migrationBuilder.InsertData(
                table: "municipio",
                columns: new[] { "Id", "IdDepartamentoFK", "NombreMunicipio" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Giron" },
                    { 3, 1, "Floridablanca" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "CodigoCliente", "FechaRegistro", "IdMunicipioFk", "IdTipoPersonaFK", "NombreCliente" },
                values: new object[,]
                {
                    { 1, "1912", new DateOnly(2023, 12, 21), 1, 1, "Pedro David" },
                    { 2, "1923", new DateOnly(2023, 12, 23), 2, 1, "Jose Jose" },
                    { 3, "1920", new DateOnly(2023, 12, 25), 3, 1, "Chayan" },
                    { 4, "1921", new DateOnly(2023, 12, 26), 1, 1, "Luis Miguel" },
                    { 5, "1934", new DateOnly(2023, 12, 29), 1, 1, "Don Omar" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "Id", "FechaIngreso", "IdCargoFK", "IdEmpleado", "IdMunicipioFk", "NombreEmpleado" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 11, 21), 1, "", 1, "Ozuna" },
                    { 2, new DateOnly(2023, 11, 21), 1, "", 2, "Romeo Santos" },
                    { 3, new DateOnly(2023, 11, 21), 2, "", 3, "Karol G" },
                    { 4, new DateOnly(2023, 11, 21), 2, "", 1, "Luis Fonsi" },
                    { 5, new DateOnly(2023, 11, 21), 3, "", 2, "Drake" }
                });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "FechaCreacion", "IdMunicipioFk", "NitEmpresa", "RazonSocial", "RepresentanteLegal" },
                values: new object[,]
                {
                    { 1, new DateOnly(2003, 11, 21), 1, "10023123", "Sin Animo de Lucro", "Suits" },
                    { 2, new DateOnly(2013, 11, 21), 2, "1002023", "Ganar Plata", "Suits" },
                    { 3, new DateOnly(2002, 11, 21), 3, "1006969", "Sin Animo de Lucro", "Suits" },
                    { 4, new DateOnly(2005, 11, 21), 1, "1005544", "Ganar Plata", "Suits" }
                });

            migrationBuilder.InsertData(
                table: "Inventario",
                columns: new[] { "Id", "CodigoInventario", "IdPredaFK", "ValorVtaCop", "ValorVtaUsd" },
                values: new object[,]
                {
                    { 1, "12332", 1, 200000.0, 20.0 },
                    { 2, "1234", 2, 220000.0, 22.0 },
                    { 3, "4321", 3, 240000.0, 24.0 },
                    { 4, "54231", 4, 250000.0, 25.0 },
                    { 5, "1235", 5, 260000.0, 26.0 }
                });

            migrationBuilder.InsertData(
                table: "Proveedor",
                columns: new[] { "Id", "IdMunicipioFk", "IdTipoPersonaFK", "NitProveedor", "NombreProveedor" },
                values: new object[,]
                {
                    { 1, 1, 2, "1002312", "Ropa la 15" },
                    { 2, 2, 2, "1007766", "LA ropera" },
                    { 3, 3, 2, "1005432", "La ropita" },
                    { 4, 1, 2, "1001212", "Ropa Masx" },
                    { 5, 2, 2, "1006965", "Guchi" }
                });

            migrationBuilder.InsertData(
                table: "insumo_prenda",
                columns: new[] { "IdInsumoFK", "IdPrendaFK", "Cantidad" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 3, 0 },
                    { 2, 1, 0 },
                    { 2, 3, 0 },
                    { 2, 5, 0 },
                    { 3, 2, 0 },
                    { 3, 4, 0 },
                    { 4, 1, 0 },
                    { 4, 2, 0 },
                    { 4, 4, 0 },
                    { 4, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Orden",
                columns: new[] { "Id", "FechaOrden", "IdClienteFK", "IdEmpleadoFk", "IdEstadoFK" },
                values: new object[,]
                {
                    { 1, new DateOnly(2003, 11, 21), 1, 1, 3 },
                    { 2, new DateOnly(2003, 11, 25), 2, 1, 3 },
                    { 3, new DateOnly(2003, 11, 26), 3, 2, 3 },
                    { 4, new DateOnly(2003, 11, 27), 4, 3, 3 },
                    { 5, new DateOnly(2003, 11, 28), 5, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "Id", "FechaVenta", "IdClienteFK", "IdEmpleadoFK", "IdFormaPago" },
                values: new object[,]
                {
                    { 1, new DateOnly(2003, 11, 21), 1, 1, 1 },
                    { 2, new DateOnly(2003, 11, 25), 2, 2, 1 },
                    { 3, new DateOnly(2003, 11, 24), 3, 3, 2 },
                    { 4, new DateOnly(2003, 11, 26), 4, 1, 2 },
                    { 5, new DateOnly(2003, 11, 27), 1, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "insumo_proveedor",
                columns: new[] { "IdInsumoFK", "IdProveedorFK" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 2 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "inventario_talla",
                columns: new[] { "IdInventarioFK", "IdTallaFk", "Cantidad" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 1, 4, 0 },
                    { 2, 3, 0 },
                    { 2, 4, 0 },
                    { 3, 1, 0 },
                    { 3, 2, 0 },
                    { 4, 3, 0 },
                    { 4, 4, 0 },
                    { 5, 2, 0 },
                    { 5, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "detalle_orden",
                columns: new[] { "Id", "CantidadProducida", "CatidadProducir", "IdColorFK", "IdEstadoFK", "IdOrdenFK", "IdPrendaFK" },
                values: new object[,]
                {
                    { 1, 20, 100, 1, 1, 1, 1 },
                    { 2, 22, 80, 2, 2, 2, 2 },
                    { 3, 24, 70, 3, 1, 3, 3 },
                    { 4, 25, 50, 1, 2, 1, 1 },
                    { 5, 26, 30, 4, 1, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "detalle_venta",
                columns: new[] { "Id", "Cantidad", "IdInventarioFK", "IdTallaFk", "IdVentaFK", "ValorUnit" },
                values: new object[,]
                {
                    { 1, 20, 1, 1, 1, 10000.0 },
                    { 2, 22, 2, 2, 2, 20000.0 },
                    { 3, 24, 3, 3, 3, 30000.0 },
                    { 4, 25, 1, 1, 1, 10000.0 },
                    { 5, 26, 2, 2, 2, 40000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdMunicipioFk",
                table: "Cliente",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdTipoPersonaFK",
                table: "Cliente",
                column: "IdTipoPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFK",
                table: "Departamento",
                column: "IdPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdColorFK",
                table: "detalle_orden",
                column: "IdColorFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdEstadoFK",
                table: "detalle_orden",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdOrdenFK",
                table: "detalle_orden",
                column: "IdOrdenFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_orden_IdPrendaFK",
                table: "detalle_orden",
                column: "IdPrendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdInventarioFK",
                table: "detalle_venta",
                column: "IdInventarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdTallaFk",
                table: "detalle_venta",
                column: "IdTallaFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_venta_IdVentaFK",
                table: "detalle_venta",
                column: "IdVentaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargoFK",
                table: "Empleado",
                column: "IdCargoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdMunicipioFk",
                table: "Empleado",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_IdMunicipioFk",
                table: "Empresa",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_IdTipoEstadoFK",
                table: "Estado",
                column: "IdTipoEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_prenda_IdPrendaFK",
                table: "insumo_prenda",
                column: "IdPrendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_insumo_proveedor_IdProveedorFK",
                table: "insumo_proveedor",
                column: "IdProveedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdPredaFK",
                table: "Inventario",
                column: "IdPredaFK");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_talla_IdTallaFk",
                table: "inventario_talla",
                column: "IdTallaFk");

            migrationBuilder.CreateIndex(
                name: "IX_municipio_IdDepartamentoFK",
                table: "municipio",
                column: "IdDepartamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdClienteFK",
                table: "Orden",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdEmpleadoFk",
                table: "Orden",
                column: "IdEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdEstadoFK",
                table: "Orden",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdEstadoFK",
                table: "Prenda",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdGneroFK",
                table: "Prenda",
                column: "IdGneroFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdTipoProteccionFK",
                table: "Prenda",
                column: "IdTipoProteccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdMunicipioFk",
                table: "Proveedor",
                column: "IdMunicipioFk");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdTipoPersonaFK",
                table: "Proveedor",
                column: "IdTipoPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_IdUsuarioFK",
                table: "refresh_token",
                column: "IdUsuarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_IdRolFK",
                table: "userRol",
                column: "IdRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdClienteFK",
                table: "Venta",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdEmpleadoFK",
                table: "Venta",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdFormaPago",
                table: "Venta",
                column: "IdFormaPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_orden");

            migrationBuilder.DropTable(
                name: "detalle_venta");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "insumo_prenda");

            migrationBuilder.DropTable(
                name: "insumo_proveedor");

            migrationBuilder.DropTable(
                name: "inventario_talla");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Talla");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "forma_pago");

            migrationBuilder.DropTable(
                name: "Prenda");

            migrationBuilder.DropTable(
                name: "tipo_persona");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "tipo_proteccion");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "tipo_estado");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}

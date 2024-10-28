﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Server.Models.Consumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdReserva");

                    b.ToTable("Consumo");
                });

            modelBuilder.Entity("Server.Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("Server.Models.DetailConsumo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ConsumoId")
                        .HasColumnType("int");

                    b.Property<int?>("IdConsumo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceSingle")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumoId");

                    b.ToTable("DetailConsumo");
                });

            modelBuilder.Entity("Server.Models.DetailOrder", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("DateOrder")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("HeavenCoins")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrder")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceSingle")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("DetailOrders");
                });

            modelBuilder.Entity("Server.Models.DetailPurchase", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdMP")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdProveedor")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdPurchase")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Presentation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PriceSingle")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseId");

                    b.ToTable("DetailPurchases");
                });

            modelBuilder.Entity("Server.Models.DetailReserva", b =>
                {
                    b.Property<int>("idDetailReser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idDetailReser"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("horaFin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("horaInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEspacio")
                        .HasColumnType("int");

                    b.HasKey("idDetailReser");

                    b.ToTable("DetailReservas");
                });

            modelBuilder.Entity("Server.Models.Direcciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroExterior")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Server.Models.Espacio", b =>
                {
                    b.Property<int>("idEspacio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEspacio"));

                    b.Property<int>("canPersonas")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.HasKey("idEspacio");

                    b.ToTable("Espacios");
                });

            modelBuilder.Entity("Server.Models.Ingrediente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<decimal?>("Cantidad")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("EnMenu")
                        .HasColumnType("bit");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdMateriaPrima")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaPrimaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Server.Models.InventarioMP", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("Caducidad")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<float?>("Cantidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdCompra")
                        .HasColumnType("int");

                    b.Property<int?>("IdMateriaPrima")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaPrimaId")
                        .HasColumnType("int");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompra");

                    b.HasIndex("MateriaPrimaId");

                    b.ToTable("InventarioMPs");
                });

            modelBuilder.Entity("Server.Models.InventarioPostre", b =>
                {
                    b.Property<int?>("IdPostre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("IdPostre"));

                    b.Property<float?>("Cantidad")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("IdPostre");

                    b.HasIndex("ProductoId");

                    b.ToTable("InventarioPostres");
                });

            modelBuilder.Entity("Server.Models.MateriaPrima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MateriasPrimas");
                });

            modelBuilder.Entity("Server.Models.MateriaPrimaProveedor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Estatus")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaPrimaId")
                        .HasColumnType("int");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("MateriaPrimaProveedores");
                });

            modelBuilder.Entity("Server.Models.Order", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int?>("IdUser")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeliver")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PromCode")
                        .HasColumnType("int");

                    b.Property<float>("PromDesc")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Ticket")
                        .HasColumnType("bigint");

                    b.Property<float?>("Total")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<int>("TotalHeavenCoins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Server.Models.Producto", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CantidadXReceta")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Temperatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Server.Models.Promociones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BadgePromoId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Descuento")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("FechaFin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LimiteCanje")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Productos")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promociones");
                });

            modelBuilder.Entity("Server.Models.Proveedor", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DireccionEmpresa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Estatus")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NombreEncargado")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("TelefonoEmpresa")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Server.Models.Purchase", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdUser")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Total")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Server.Models.Reserva", b =>
                {
                    b.Property<int>("idReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idReserva"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idDetailReser")
                        .HasColumnType("int");

                    b.HasKey("idReserva");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("idDetailReser");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Server.Models.Usuario.Server.Models.Usuario.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttemptsToBlock")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("IsBlockedUntil")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastFailedLoginAttempt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Token")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.Models.Consumo", b =>
                {
                    b.HasOne("Server.Models.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("IdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("Server.Models.CreditCard", b =>
                {
                    b.HasOne("Server.Models.Usuario.Server.Models.Usuario.User", null)
                        .WithMany("CreditCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Models.DetailConsumo", b =>
                {
                    b.HasOne("Server.Models.Consumo", null)
                        .WithMany("DetailConsumo")
                        .HasForeignKey("ConsumoId");
                });

            modelBuilder.Entity("Server.Models.DetailOrder", b =>
                {
                    b.HasOne("Server.Models.Order", null)
                        .WithMany("DetailOrders")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Server.Models.DetailPurchase", b =>
                {
                    b.HasOne("Server.Models.Purchase", null)
                        .WithMany("DetailPurchases")
                        .HasForeignKey("PurchaseId");
                });

            modelBuilder.Entity("Server.Models.Direcciones", b =>
                {
                    b.HasOne("Server.Models.Usuario.Server.Models.Usuario.User", null)
                        .WithMany("Direcciones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.Models.Ingrediente", b =>
                {
                    b.HasOne("Server.Models.MateriaPrima", "MateriaPrima")
                        .WithMany("Ingredientes")
                        .HasForeignKey("MateriaPrimaId");

                    b.HasOne("Server.Models.Producto", "Producto")
                        .WithMany("Ingredientes")
                        .HasForeignKey("ProductoId");

                    b.Navigation("MateriaPrima");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Server.Models.InventarioMP", b =>
                {
                    b.HasOne("Server.Models.Purchase", "Compra")
                        .WithMany()
                        .HasForeignKey("IdCompra");

                    b.HasOne("Server.Models.MateriaPrima", "MateriaPrima")
                        .WithMany("InventarioMps")
                        .HasForeignKey("MateriaPrimaId");

                    b.Navigation("Compra");

                    b.Navigation("MateriaPrima");
                });

            modelBuilder.Entity("Server.Models.InventarioPostre", b =>
                {
                    b.HasOne("Server.Models.Producto", "Producto")
                        .WithMany("InventarioPostres")
                        .HasForeignKey("ProductoId");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Server.Models.MateriaPrimaProveedor", b =>
                {
                    b.HasOne("Server.Models.MateriaPrima", "MateriaPrima")
                        .WithMany("MateriaPrimaProveedores")
                        .HasForeignKey("MateriaPrimaId");

                    b.HasOne("Server.Models.Proveedor", "Proveedor")
                        .WithMany("MateriaPrimaProveedores")
                        .HasForeignKey("ProveedorId");

                    b.Navigation("MateriaPrima");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Server.Models.Proveedor", b =>
                {
                    b.HasOne("Server.Models.Usuario.Server.Models.Usuario.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Server.Models.Reserva", b =>
                {
                    b.HasOne("Server.Models.Usuario.Server.Models.Usuario.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.DetailReserva", "DetailReserva")
                        .WithMany()
                        .HasForeignKey("idDetailReser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailReserva");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Server.Models.Consumo", b =>
                {
                    b.Navigation("DetailConsumo");
                });

            modelBuilder.Entity("Server.Models.MateriaPrima", b =>
                {
                    b.Navigation("Ingredientes");

                    b.Navigation("InventarioMps");

                    b.Navigation("MateriaPrimaProveedores");
                });

            modelBuilder.Entity("Server.Models.Order", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("Server.Models.Producto", b =>
                {
                    b.Navigation("Ingredientes");

                    b.Navigation("InventarioPostres");
                });

            modelBuilder.Entity("Server.Models.Proveedor", b =>
                {
                    b.Navigation("MateriaPrimaProveedores");
                });

            modelBuilder.Entity("Server.Models.Purchase", b =>
                {
                    b.Navigation("DetailPurchases");
                });

            modelBuilder.Entity("Server.Models.Usuario.Server.Models.Usuario.User", b =>
                {
                    b.Navigation("CreditCards");

                    b.Navigation("Direcciones");
                });
#pragma warning restore 612, 618
        }
    }
}

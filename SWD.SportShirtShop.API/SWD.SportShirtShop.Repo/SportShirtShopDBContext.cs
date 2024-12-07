﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SWD.SportShirtShop.Repo.Entities;

public partial class SportShirtShopDBContext : DbContext
{
    public SportShirtShopDBContext()
    {
    }
    public SportShirtShopDBContext(DbContextOptions<SportShirtShopDBContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerInTournamentClub> PlayerInTournamentClubs { get; set; }

    public virtual DbSet<Shirt> Shirts { get; set; }

    public virtual DbSet<ShirtEdition> ShirtEditions { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TournamentClub> TournamentClubs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F92D9A3CA");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dob).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Club__3213E83F225A7821");

            entity.ToTable("Club");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("note");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3213E83F8BFDB817");

            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdShirt).HasColumnName("id_Shirt");
            entity.Property(e => e.Link).HasColumnName("link");

            entity.HasOne(d => d.IdShirtNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.IdShirt)
                .HasConstraintName("FK__Image__id_Shirt__44FF419A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83FD02FD764");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdAccount).HasColumnName("id_Account");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .HasColumnName("payment_status");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.ShipAddress)
                .HasMaxLength(200)
                .HasColumnName("ship_address");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalAmmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalAmmount");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdAccount)
                .HasConstraintName("FK__Orders__id_Accou__267ABA7A");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83F1D604263");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.IdOrders).HasColumnName("id_Orders");
            entity.Property(e => e.IdShirt).HasColumnName("id_Shirt");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SalePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("salePrice");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdOrdersNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrders)
                .HasConstraintName("FK__OrderDeta__id_Or__412EB0B6");

            entity.HasOne(d => d.IdShirtNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdShirt)
                .HasConstraintName("FK__OrderDeta__id_Sh__4222D4EF");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83FA031C50C");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.IdOrders).HasColumnName("id_Orders");
            entity.Property(e => e.Method).HasColumnName("method");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdOrdersNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.IdOrders)
                .HasConstraintName("FK__Payment__id_Orde__2E1BDC42");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Player__3213E83FB1D43C5B");

            entity.ToTable("Player");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.IdClub).HasColumnName("id_Club");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("note");

            entity.HasOne(d => d.IdClubNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.IdClub)
                .HasConstraintName("FK__Player__id_Club__2B3F6F97");
        });

        modelBuilder.Entity<PlayerInTournamentClub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerIn__3213E83F7ED1E794");

            entity.ToTable("PlayerInTournamentClub");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPlayer).HasColumnName("id_Player");
            entity.Property(e => e.IdTournamentClub).HasColumnName("id_TournamentClub");

            entity.HasOne(d => d.IdPlayerNavigation).WithMany(p => p.PlayerInTournamentClubs)
                .HasForeignKey(d => d.IdPlayer)
                .HasConstraintName("FK__PlayerInT__id_Pl__3A81B327");

            entity.HasOne(d => d.IdTournamentClubNavigation).WithMany(p => p.PlayerInTournamentClubs)
                .HasForeignKey(d => d.IdTournamentClub)
                .HasConstraintName("FK__PlayerInT__id_To__398D8EEE");
        });

        modelBuilder.Entity<Shirt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shirt__3213E83F1DC2467E");

            entity.ToTable("Shirt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdPlayerinTournamentClub).HasColumnName("id_PlayerinTournamentClub");
            entity.Property(e => e.IdShirtEdition).HasColumnName("id_shirtEdition");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QuantityStock).HasColumnName("quantity_stock");
            entity.Property(e => e.SalePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("salePrice");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.TotalSold).HasColumnName("totalSold");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.IdPlayerinTournamentClubNavigation).WithMany(p => p.Shirts)
                .HasForeignKey(d => d.IdPlayerinTournamentClub)
                .HasConstraintName("FK__Shirt__id_Player__3E52440B");

            entity.HasOne(d => d.IdShirtEditionNavigation).WithMany(p => p.Shirts)
                .HasForeignKey(d => d.IdShirtEdition)
                .HasConstraintName("FK__Shirt__id_shirtE__3D5E1FD2");
        });

        modelBuilder.Entity<ShirtEdition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShirtEdi__3213E83F077746A7");

            entity.ToTable("ShirtEdition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.IdTournament).HasColumnName("id_Tournament");
            entity.Property(e => e.Nameseason).HasColumnName("nameseason");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdTournamentNavigation).WithMany(p => p.ShirtEditions)
                .HasForeignKey(d => d.IdTournament)
                .HasConstraintName("FK__ShirtEdit__id_To__32E0915F");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tourname__3213E83F7510ACD0");

            entity.ToTable("Tournament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<TournamentClub>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tourname__3213E83FDED02FA7");

            entity.ToTable("TournamentClub");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateAccount).HasColumnName("createAccount");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.IdClub).HasColumnName("id_Club");
            entity.Property(e => e.IdTournament).HasColumnName("id_Tournament");

            entity.HasOne(d => d.IdClubNavigation).WithMany(p => p.TournamentClubs)
                .HasForeignKey(d => d.IdClub)
                .HasConstraintName("FK__Tournamen__id_Cl__36B12243");

            entity.HasOne(d => d.IdTournamentNavigation).WithMany(p => p.TournamentClubs)
                .HasForeignKey(d => d.IdTournament)
                .HasConstraintName("FK__Tournamen__id_To__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
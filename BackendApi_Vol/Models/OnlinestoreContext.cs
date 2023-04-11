using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendApi_Vol.Models
{
    public partial class OnlinestoreContext : DbContext
    {
        public OnlinestoreContext()
        {
        }

        public OnlinestoreContext(DbContextOptions<OnlinestoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courier> Couriers { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<OrderContent> OrderContents { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductPackaging> ProductPackagings { get; set; } = null!;
        public virtual DbSet<SiteUser> SiteUsers { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<UserCard> UserCards { get; set; } = null!;
        public virtual DbSet<UserOrder> UserOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>(entity =>
            {
                entity.HasKey(e => e.IdCourier)
                    .HasName("PK__Courier__3E05CEFE19329956");

                entity.ToTable("Courier");

                entity.Property(e => e.IdCourier).HasColumnName("id_courier");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NameCourier)
                    .HasMaxLength(50)
                    .HasColumnName("name_courier");

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.IdDelivery)
                    .HasName("PK__Delivery__D7513687E2B9990D");

                entity.ToTable("Delivery");

                entity.Property(e => e.IdDelivery).HasColumnName("id_delivery");

                entity.Property(e => e.DeliveryMethod)
                    .HasMaxLength(100)
                    .HasColumnName("delivery_method");

                entity.Property(e => e.IdCourier).HasColumnName("id_courier");

                entity.Property(e => e.IdTransport).HasColumnName("id_transport");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCourierNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.IdCourier)
                    .HasConstraintName("FK__Delivery__id_cou__06CD04F7");

                entity.HasOne(d => d.IdTransportNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.IdTransport)
                    .HasConstraintName("FK__Delivery__id_tra__07C12930");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.IdManufacturer)
                    .HasName("PK__Manufact__0F53B9C356E64E9E");

                entity.ToTable("Manufacturer");

                entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");

                entity.Property(e => e.Apartment).HasColumnName("apartment");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Entrance).HasColumnName("entrance");

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .HasColumnName("house");

                entity.Property(e => e.IndexUs).HasColumnName("index_us");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufName)
                    .HasMaxLength(50)
                    .HasColumnName("Manuf_name");

                entity.Property(e => e.NumFloor).HasColumnName("num_floor");

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderContent>(entity =>
            {
                entity.ToTable("Order_Contents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountProduct).HasColumnName("count_product");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Packaging)
                    .HasMaxLength(50)
                    .HasColumnName("packaging");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderContents)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Con__id_or__208CD6FA");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderContents)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Con__id_pr__2180FB33");

                entity.HasOne(d => d.PackagingNavigation)
                    .WithMany(p => p.OrderContents)
                    .HasForeignKey(d => d.Packaging)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Con__packa__22751F6C");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.IdPayment)
                    .HasName("PK__Payment__862FEFE083D0629A");

                entity.ToTable("Payment");

                entity.Property(e => e.IdPayment).HasColumnName("id_payment");

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.IdCard).HasColumnName("Id_card");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("payment_method");

                entity.HasOne(d => d.IdCardNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdCard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Id_card__7D439ABD");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__BA39E84F564333C8");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CountInBox).HasColumnName("Count_in_box");

                entity.Property(e => e.CountProductOnWarehouse).HasColumnName("Count_product_on_warehouse");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");

                entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");

                entity.Property(e => e.ImagePr).HasColumnName("image_pr");

                entity.Property(e => e.Information).HasColumnName("information");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductionDate)
                    .HasColumnType("date")
                    .HasColumnName("production_date");

                entity.Property(e => e.WeightPr)
                    .HasColumnType("decimal(10, 1)")
                    .HasColumnName("weight_pr");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Categor__1BC821DD");

                entity.HasOne(d => d.IdManufacturerNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdManufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__id_manu__1CBC4616");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Category)
                    .HasName("PK__Product___4BB73C334359DFAA");

                entity.ToTable("Product_Category");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Information).HasColumnName("information");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductPackaging>(entity =>
            {
                entity.HasKey(e => e.Packaging)
                    .HasName("PK__Product___9D09D5A93F97C0EE");

                entity.ToTable("Product_Packaging");

                entity.Property(e => e.Packaging)
                    .HasMaxLength(50)
                    .HasColumnName("packaging");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quality).HasColumnName("quality");
            });

            modelBuilder.Entity<SiteUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Site_Use__B607F2480EF92801");

                entity.ToTable("Site_User");

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_birth");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .HasColumnName("name_user");

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.IdTransport)
                    .HasName("PK__Transpor__A387EDD46BD49627");

                entity.ToTable("Transport");

                entity.Property(e => e.IdTransport).HasColumnName("id_transport");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberTr)
                    .HasMaxLength(50)
                    .HasColumnName("number_tr");

                entity.Property(e => e.TransportName)
                    .HasMaxLength(50)
                    .HasColumnName("transport_name");
            });

            modelBuilder.Entity<UserCard>(entity =>
            {
                entity.HasKey(e => e.IdCard)
                    .HasName("PK__User_Car__549380B9B15099AC");

                entity.ToTable("User_Card");

                entity.Property(e => e.IdCard).HasColumnName("Id_card");

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberCard).HasColumnName("number_card");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserCards)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Card__is_de__797309D9");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__User_Ord__DD5B8F3F09A590E8");

                entity.ToTable("User_Order");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.Apartment).HasColumnName("apartment");

                entity.Property(e => e.AssemblyPeriod).HasColumnName("assembly_period");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Entrance).HasColumnName("entrance");

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .HasColumnName("house");

                entity.Property(e => e.IdDelivery).HasColumnName("id_delivery");

                entity.Property(e => e.IdPayment).HasColumnName("id_payment");

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.Property(e => e.IndexUs).HasColumnName("index_us");

                entity.Property(e => e.Information).HasColumnName("information");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("is_delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumFloor).HasColumnName("num_floor");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.IdDeliveryNavigation)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.IdDelivery)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Orde__id_de__0E6E26BF");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.IdPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Orde__id_pa__0D7A0286");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Orde__Id_us__0C85DE4D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

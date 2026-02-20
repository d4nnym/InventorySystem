using InventorySystem.Infrastructure.Persistence.Scaffold;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Infrastructure.Persistence;

public partial class OracleDbContext : DbContext
{
    public OracleDbContext()
    {
    }

    public OracleDbContext(DbContextOptions<OracleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TBL_INV_SYS_ATTRIBUTE> TBL_INV_SYS_ATTRIBUTEs { get; set; }

    public virtual DbSet<TBL_INV_SYS_ATTRIBUTE_VALUE> TBL_INV_SYS_ATTRIBUTE_VALUEs { get; set; }

    public virtual DbSet<TBL_INV_SYS_BRAND> TBL_INV_SYS_BRANDs { get; set; }

    public virtual DbSet<TBL_INV_SYS_CATEGORy> TBL_INV_SYS_CATEGORIEs { get; set; }

    public virtual DbSet<TBL_INV_SYS_MODEL> TBL_INV_SYS_MODELs { get; set; }

    public virtual DbSet<TBL_INV_SYS_PRODUCT> TBL_INV_SYS_PRODUCTs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=INVENTORY_SYSTEM;Password=InventorySystem1234;Data Source=localhost:1521/FREEPDB1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("INVENTORY_SYSTEM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TBL_INV_SYS_ATTRIBUTE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014054");

            entity.ToTable("TBL_INV_SYS_ATTRIBUTES");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.ATRIBUTE_NAME)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TBL_INV_SYS_ATTRIBUTE_VALUE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014058");

            entity.ToTable("TBL_INV_SYS_ATTRIBUTE_VALUES");

            entity.HasIndex(e => e.VALUE, "SYS_C0014059").IsUnique();

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.VALUE)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.ATTRIBUTE).WithMany(p => p.TBL_INV_SYS_ATTRIBUTE_VALUEs)
                .HasForeignKey(d => d.ATTRIBUTE_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_INV_SYS_ATTRIBUTE_VALUES_ATTRIBUTE_ID_TBL_INV_SYS_ATTRIBUTES");
        });

        modelBuilder.Entity<TBL_INV_SYS_BRAND>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014038");

            entity.ToTable("TBL_INV_SYS_BRANDS");

            entity.HasIndex(e => e.BRAND_NAME, "SYS_C0014039").IsUnique();

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.BRAND_NAME)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TBL_INV_SYS_CATEGORy>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014034");

            entity.ToTable("TBL_INV_SYS_CATEGORIES");

            entity.HasIndex(e => e.CATEGORY_NAME, "SYS_C0014035").IsUnique();

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.CATEGORY_NAME)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TBL_INV_SYS_MODEL>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014044");

            entity.ToTable("TBL_INV_SYS_MODELS");

            entity.HasIndex(e => e.MODELS_NAME, "SYS_C0014045").IsUnique();

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.MODELS_NAME)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.BRAND).WithMany(p => p.TBL_INV_SYS_MODELs)
                .HasForeignKey(d => d.BRAND_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_INV_SYS_MODELS_BRAND_ID_TBL_INV_SYS_BRANDS");

            entity.HasOne(d => d.CATEGORY).WithMany(p => p.TBL_INV_SYS_MODELs)
                .HasForeignKey(d => d.CATEGORY_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_INV_SYS_MODELS_CATEGORY_ID_TBL_INV_SYS_CATEGORIES");
        });

        modelBuilder.Entity<TBL_INV_SYS_PRODUCT>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("SYS_C0014051");

            entity.ToTable("TBL_INV_SYS_PRODUCTS");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.DESCRIPTION).HasColumnType("CLOB");
            entity.Property(e => e.PRODUCT_NAME)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.SKU)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.MODEL).WithMany(p => p.TBL_INV_SYS_PRODUCTs)
                .HasForeignKey(d => d.MODEL_ID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TBL_INV_SYS_PRODUCTS_MODEL_ID_TBL_INV_SYS_MODELS");

            entity.HasMany(d => d.VALUEs).WithMany(p => p.PRODUCTs)
                .UsingEntity<Dictionary<string, object>>(
                    "TBL_INV_SYS_PRODUCT_ATTRIBUTE",
                    r => r.HasOne<TBL_INV_SYS_ATTRIBUTE_VALUE>().WithMany()
                        .HasForeignKey("VALUE_ID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TBL_INV_SYS_PRODUCT_ATTRIBUTES_VALUE_ID_TBL_INV_SYS_ATTRIBUTE_VALUES"),
                    l => l.HasOne<TBL_INV_SYS_PRODUCT>().WithMany()
                        .HasForeignKey("PRODUCT_ID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TBL_INV_SYS_PRODUCT_ATTRIBUTES_PRODUCT_ID_TBL_INV_SYS_PRODUCTS"),
                    j =>
                    {
                        j.HasKey("PRODUCT_ID", "VALUE_ID").HasName("SYS_C0014062");
                        j.ToTable("TBL_INV_SYS_PRODUCT_ATTRIBUTES");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

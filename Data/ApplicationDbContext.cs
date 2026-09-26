using Microsoft.EntityFrameworkCore;
using TqkLesson11_Db.Models;

namespace TqkLesson11_Db.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<HvtStudent> HvtStudents => Set<HvtStudent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<HvtStudent>(entity =>
        {
            entity.ToTable("HvtStudent");
            entity.HasKey(student => student.MaSV);
            entity.Property(student => student.MaSV).HasMaxLength(20);
            entity.Property(student => student.HoTen).HasMaxLength(100).IsRequired();
            entity.Property(student => student.GioiTinh).HasMaxLength(20);
            entity.Property(student => student.Email).HasMaxLength(254);
            entity.Property(student => student.SoDienThoai).HasMaxLength(20);
        });
    }
}

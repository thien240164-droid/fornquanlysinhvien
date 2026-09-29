using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VTBDU.CorePlatform.Domain.Entities.StudentManagement;

namespace VTBDU.CorePlatform.Infrastructure.Persistence.Configurations.StudentManagement;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // 1. Tên bảng
        builder.ToTable("Students");

        // 2. Khóa chính
        builder.HasKey(x => x.Id);

        // 3. Ràng buộc các thuộc tính quan trọng
        builder.Property(x => x.StudentCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.StudentCode)
            .IsUnique();

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        // các trường liên hệ & định danh
        builder.Property(x => x.IdentityNumber)
            .HasMaxLength(20);

        builder.HasIndex(x => x.IdentityNumber)
            .IsUnique()
            .HasFilter("[IdentityNumber] IS NOT NULL"); // Index Unique chỉ áp dụng cho giá trị không NULL

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder.Property(x => x.MobilePhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.HomePhoneNumber)
            .HasMaxLength(20);

        // các trường thông tin cá nhân & địa chỉ
        builder.Property(x => x.Gender).HasMaxLength(10);
        builder.Property(x => x.PlaceOfBirth).HasMaxLength(200);
        builder.Property(x => x.Hometown).HasMaxLength(200);
        builder.Property(x => x.Nationality).HasMaxLength(100);
        builder.Property(x => x.Ethnicity).HasMaxLength(100);
        builder.Property(x => x.Religion).HasMaxLength(100);
        builder.Property(x => x.PlaceOfOrigin).HasMaxLength(200);

        builder.Property(x => x.PermanentAddress).HasMaxLength(500);
        builder.Property(x => x.Ward).HasMaxLength(100);
        builder.Property(x => x.District).HasMaxLength(100);
        builder.Property(x => x.Province).HasMaxLength(100);

        builder.Property(x => x.MailingAddress).HasMaxLength(500);
        builder.Property(x => x.CurrentAddress).HasMaxLength(500);

        // các trường chính sách
        builder.Property(x => x.PolicyBeneficiary).HasMaxLength(200);
        builder.Property(x => x.AllowanceBeneficiary).HasMaxLength(200);
        builder.Property(x => x.TargetGroup).HasMaxLength(200);

        // 4. Mối quan hệ 1 - 1 với User (Khóa ngoại UserId nằm ở phía Student)
        // builder.HasOne(x => x.User)
        //     .WithOne(x => x.Student)
        //     .HasForeignKey<Student>(x => x.UserId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}
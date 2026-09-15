using System.ComponentModel.DataAnnotations;

namespace fornquanlysinhvien.Models;

public class Student
{
    [Display(Name = "ID")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên người dùng phải từ 3 đến 100 ký tự")]
    [Display(Name = "Tên người dùng")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string PasswordHash { get; set; } = default!;

    [StringLength(50)]
    [Display(Name = "Tên")]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Display(Name = "Họ")]
    public string? LastName { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [Display(Name = "Số điện thoại")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Mã sinh viên")]
    [StringLength(20)]
    public string? StudentId { get; set; }

    [Display(Name = "Lớp")]
    [StringLength(50)]
    public string? ClassName { get; set; }

    [Display(Name = "Ngành học")]
    [StringLength(100)]
    public string? Major { get; set; }

    [Display(Name = "Ngày tạo")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Display(Name = "Ngày cập nhật")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

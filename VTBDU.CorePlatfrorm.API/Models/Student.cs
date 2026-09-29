using System.ComponentModel.DataAnnotations;

namespace fornquanlysinhvien.Models
{
    public class Student
    {
        [Display(Name = "Mã ID")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public string PasswordHash { get; set; } = default!;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Các thuộc tính đang bị thiếu gây ra lỗi:
        public string? StudentId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ClassName { get; set; }
        public string? Major { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
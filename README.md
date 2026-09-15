# Quản Lý Sinh Viên - Student Management System

## Mô tả
Ứng dụng quản lý sinh viên được xây dựng bằng ASP.NET Core (.NET 10) với MVC Pattern. Hệ thống cho phép quản lý thông tin sinh viên bao gồm: tài khoản, thông tin cá nhân, thông tin học tập.

## Features
- ✅ Danh sách sinh viên
- ✅ Thêm sinh viên mới
- ✅ Chỉnh sửa thông tin sinh viên
- ✅ Xem chi tiết sinh viên
- ✅ Xóa sinh viên
- ✅ Validation dữ liệu
- ✅ Giao diện Bootstrap 5
- ✅ Responsive Design

## Công nghệ sử dụng
- **Framework**: ASP.NET Core 10
- **Mô hình**: MVC (Model-View-Controller)
- **Frontend**: Razor Views, Bootstrap 5
- **Ngôn ngữ**: C#
- **IDE**: Visual Studio Community 2026

## Cấu trúc dự án
```
fornquanlysinhvien/
├── Controllers/
│   ├── HomeController.cs
│   └── StudentController.cs
├── Models/
│   ├── ErrorViewModel.cs
│   └── Student.cs
├── Views/
│   ├── Home/
│   ├── Student/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── Shared/
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## Hướng dẫn cài đặt

### Yêu cầu
- .NET 10 SDK
- Visual Studio Insiders 2026 hoặc cao hơn
- Git

### Bước 1: Clone repository
```bash
git clone https://github.com/your-username/fornquanlysinhvien.git
cd fornquanlysinhvien
```

### Bước 2: Restore NuGet packages
```bash
dotnet restore
```

### Bước 3: Chạy ứng dụng
```bash
dotnet run
```

Ứng dụng sẽ chạy tại: `https://localhost:5001` hoặc `http://localhost:5000`

## Sử dụng

### Quản lý sinh viên
1. **Danh sách**: Truy cập `/Student/Index` để xem tất cả sinh viên
2. **Thêm mới**: Click "Thêm sinh viên mới" để thêm sinh viên
3. **Chỉnh sửa**: Click "Sửa" để cập nhật thông tin
4. **Xem chi tiết**: Click "Xem" để xem đầy đủ thông tin
5. **Xóa**: Click "Xóa" để xóa sinh viên

## Model - Student

### Thông tin tài khoản
- **Username** - Tên người dùng (bắt buộc, 3-100 ký tự)
- **PasswordHash** - Mật khẩu (bắt buộc, ≥6 ký tự)

### Thông tin cá nhân
- **FirstName** - Tên (tùy chọn)
- **LastName** - Họ (tùy chọn)
- **Email** - Email (tùy chọn, phải hợp lệ)
- **PhoneNumber** - Số điện thoại (tùy chọn)

### Thông tin học tập
- **StudentId** - Mã sinh viên
- **ClassName** - Lớp học
- **Major** - Ngành học

### Thông tin hệ thống
- **Id** - Định danh duy nhất (GUID)
- **CreatedAt** - Ngày tạo
- **UpdatedAt** - Ngày cập nhật

## Phát triển tiếp theo
- [ ] Tích hợp Database (SQL Server / PostgreSQL)
- [ ] Entity Framework Core
- [ ] Authentication & Authorization
- [ ] API REST
- [ ] Unit Tests
- [ ] Logging
- [ ] Search & Filter
- [ ] Pagination

## Tác giả
THIEN

## License
MIT

## Hỗ trợ
Nếu có bất kỳ vấn đề hoặc câu hỏi, vui lòng tạo Issue trên GitHub.

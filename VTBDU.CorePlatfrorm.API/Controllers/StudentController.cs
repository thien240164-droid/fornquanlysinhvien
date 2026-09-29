using Microsoft.AspNetCore.Mvc;
using fornquanlysinhvien.Models;

namespace fornquanlysinhvien.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách lưu tạm sinh viên trong bộ nhớ
        private static List<Student> _studentList = new List<Student>();

        // 1. Hiển thị danh sách sinh viên
        public IActionResult Index()
        {
            return View(_studentList);
        }

        // 2. Trang hiển thị Form nhập thông tin (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. Xử lý khi bấm nút "Lưu" trên Form (POST)
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = Guid.NewGuid(); // Tự động tạo ID mới
                _studentList.Add(student);   // Lưu vào danh sách
                return RedirectToAction("Index"); // Chuyển về trang danh sách
            }
            return View(student); // Nếu có lỗi nhập liệu thì ở lại trang form
        }
    }
}
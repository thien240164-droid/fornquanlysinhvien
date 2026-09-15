namespace fornquanlysinhvien
{
    public class User
    {
        public Guid Id { get; private set; } = default!;
        public string Username { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        // Constructor để tạo dữ liệu mới
        public User(string username, string passwordHash, string? firstName = null, string? lastName = null)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
        }

        // Cập nhật tên
        public void UpdateName(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
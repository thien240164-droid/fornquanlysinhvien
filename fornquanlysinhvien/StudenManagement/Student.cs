using System;
using System.Collections.Generic;
using System.Text;
namespace TBDUni. CorePlatform.Domain.Entities.Identities;

public class Student
{
    public Guid Id { get; private set; } = default!;
    public string StudentCode { get; private set; } = default!;      // Mã sinh viên
    public string FullName { get; private set; } = default!;          // Họ và tên
    public DateTime? DateOfBirth { get; private set; }                // Ngày sinh
    public string? Gender { get; private set; }                       // Giới tính
    public string? PlaceOfBirth { get; private set; }                 // Nơi sinh
    public string? HomeTown { get; private set; }                     // Quê quán
    public string? Nationality { get; private set; }                  // Quốc tịch
    public string? Ethnicity { get; private set; }                    // Dân tộc
    public string? Religion { get; private set; }                     // Tôn giáo
    public string? Background { get; private set; }                   // TP xuất thân
    public DateTime? YouthUnionJoinDate { get; private set; }         // Ngày vào Đoàn
    public DateTime? PartyJoinDate { get; private set; }              // Ngày vào Đảng
    public string? PermanentAddress { get; private set; }             // Nơi thường trú
    public string? Ward { get; private set; }                         // Xã/phường
    public string? District { get; private set; }                     // Quận/huyện
    public string? Province { get; private set; }                     // Tỉnh/TP
    public string? PolicyBeneficiaryGroup { get; private set; }       // Đối tượng CS
    public string? SubsidyBeneficiaryGroup { get; private set; }      // Đối tượng trợ cấp
    public string? AdmissionGroup { get; private set; }               // Nhóm ĐT
    public string? HomePhoneNumber { get; private set; }              // ĐT nhà riêng
    public string? PersonalPhoneNumber { get; private set; }          // ĐT cá nhân
    public string? Email { get; private set; }                        // Email
    public string? IdentityCardNumber { get; private set; }           // Số CMND
    public string? ContactAddress { get; private set; }               // Địa chỉ báo tin
    public string? CurrentAddress { get; private set; }               // Nơi ở hiện nay
}
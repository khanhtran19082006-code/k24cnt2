using System.ComponentModel.DataAnnotations;

namespace TqkLesson11_Db.Models;

public class HvtStudent
{
    [Key]
    [Required(ErrorMessage = "Vui lòng nhập mã sinh viên.")]
    [StringLength(20)]
    [Display(Name = "Mã sinh viên")]
    public string MaSV { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    [StringLength(100)]
    [Display(Name = "Họ và tên")]
    public string HoTen { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Giới tính")]
    public string? GioiTinh { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime? NgaySinh { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    [StringLength(254)]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    [StringLength(20)]
    [Display(Name = "Số điện thoại")]
    public string? SoDienThoai { get; set; }

    [Display(Name = "Đang học")]
    public bool DangHoc { get; set; } = true;
}

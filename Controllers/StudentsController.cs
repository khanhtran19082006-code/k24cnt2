using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TqkLesson11_Db.Data;
using TqkLesson11_Db.Models;

namespace TqkLesson11_Db.Controllers;

public class StudentsController(ApplicationDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var students = await context.HvtStudents.AsNoTracking()
            .OrderBy(student => student.MaSV)
            .ToListAsync();
        return View(students);
    }

    public async Task<IActionResult> Details(string? id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        var student = await context.HvtStudents.AsNoTracking()
            .FirstOrDefaultAsync(item => item.MaSV == id);
        return student is null ? NotFound() : View(student);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MaSV,HoTen,GioiTinh,NgaySinh,Email,SoDienThoai,DangHoc")] HvtStudent student)
    {
        if (await context.HvtStudents.AnyAsync(item => item.MaSV == student.MaSV))
            ModelState.AddModelError(nameof(student.MaSV), "Mã sinh viên này đã tồn tại.");

        if (!ModelState.IsValid) return View(student);

        context.Add(student);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string? id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        var student = await context.HvtStudents.FindAsync(id);
        return student is null ? NotFound() : View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("MaSV,HoTen,GioiTinh,NgaySinh,Email,SoDienThoai,DangHoc")] HvtStudent student)
    {
        if (id != student.MaSV) return NotFound();
        if (!ModelState.IsValid) return View(student);

        context.Update(student);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(string? id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        var student = await context.HvtStudents.AsNoTracking()
            .FirstOrDefaultAsync(item => item.MaSV == id);
        return student is null ? NotFound() : View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var student = await context.HvtStudents.FindAsync(id);
        if (student is not null)
        {
            context.HvtStudents.Remove(student);
            await context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

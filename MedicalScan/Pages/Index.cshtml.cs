
using MedicalScan.Helpers;
using MedicalScan.Models;
using MedicalScan.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly IDoctorService _doctorService;

    public IndexModel(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [BindProperty(SupportsGet = true)]
    public string SelectedSpecialty { get; set; }

    public SelectList SpecialtyList { get; set; }
    public List<Doctor> Doctors { get; set; }

    public async Task OnGetAsync()
    {
        SpecialtyList = new SelectList(await _doctorService.GetSpecialtiesAsync(), nameof(Specialty.SpecialtyId), nameof(Specialty.Name));
        Doctors = await _doctorService.GetDoctorsAsync(SelectedSpecialty);
    }

    public async Task<IActionResult> OnGetFilteredDoctorsAsync(string specialty)
    {
        var doctors = await _doctorService.GetDoctorsAsync(specialty);
        return Partial("_PartialDoctors", doctors);
    }
}

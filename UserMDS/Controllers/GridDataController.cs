using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMDS.Data;
using UserMDS.Models;

namespace UserMDS.Controllers
{
    public class GridDataController : Controller
    {

        private readonly UserMDSDbContext userMDSDbContext;
        public GridDataController(UserMDSDbContext userMDSDbContext)
        {
            this.userMDSDbContext = userMDSDbContext;   
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {

            return View(await userMDSDbContext.UKG_Production_Centers.ToListAsync());
        }
        public async Task<IActionResult> Index(string Table_Name)
        {

            if (Table_Name != null)
            {
                if (Table_Name == "UKG_Production_Centers")
                {
                    var result = new UserMaintenanceModel();
                    var userDbContext = await userMDSDbContext.UKG_Production_Centers.ToListAsync();
                    result.UKGProdCenters = userDbContext.ToList();
                    return View(result);
                }
            }
            return View();
            

        }
    }
}

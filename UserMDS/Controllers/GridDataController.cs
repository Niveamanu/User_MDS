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
            ViewData["parameterValue"] = Request.Query["Table_Name"];
            var dataSource = ViewData["parameterValue"].ToString();
            if (dataSource == "UKG_Production_Centers")
            {
                return View(await userMDSDbContext.UKG_Production_Centers.ToListAsync());
            }
            else if(dataSource=="Company_Employee_Benefits")
            {
                return View(await userMDSDbContext.Company_Employee_Benefits.ToListAsync());
            }
            else  if(dataSource == "Freight_Miles")
            {
                return View(await userMDSDbContext.Freight_Miles.ToListAsync());
            }
            else if( dataSource == "Revised_Customer_Ship_To_Details")
            {
                return View(await userMDSDbContext.Revised_Customer_Ship_To_Details.ToListAsync());
            }
            else
            {
                return View(await userMDSDbContext.Manual_KPI_Metrics_Value.ToListAsync());

            }

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
                else if (Table_Name == "Company_Employee_Benefits")
                {
                    var result = new UserMaintenanceModel();
                    var userDbContext = await userMDSDbContext.Company_Employee_Benefits.ToListAsync();
                    result.CompanyEmployeesBenefits = userDbContext.ToList();
                    return View(result);
                }
                else if (Table_Name == "Freight_Miles")
                {
                    var result = new UserMaintenanceModel();
                    var userDbContext = await userMDSDbContext.Freight_Miles.ToListAsync();
                    result.FreightMiles = userDbContext.ToList();
                    return View(result);
                }
                else if(Table_Name == "Revised_Customer_Ship_To_Details")
                {
                    var result = new UserMaintenanceModel();
                    var userDbContext = await userMDSDbContext.Revised_Customer_Ship_To_Details.ToListAsync();
                    result.revisedCustShipToDetails = userDbContext.ToList();
                    return View(result);
                }
                else
                {
                    var result = new UserMaintenanceModel();
                    var userDbContext = await userMDSDbContext.Manual_KPI_Metrics_Value.ToListAsync();
                    result.manualKPIMetricsValues = userDbContext.ToList();
                    return View(result);
                }
            }
            return View();
            

        }
    }
}

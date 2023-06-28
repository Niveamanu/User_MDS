﻿using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMDS.Data;
using UserMDS.Models;
using UserMDS.Models.DTO;
using UserMDS.Repositories; 

namespace UserMDS.Controllers
{
    public class UserMDSController : Controller
    {
        private readonly UserMDSRepository userMDSRepository;
        private readonly UserMDSDbContext userMDSDbContext;
        
        private readonly IMapper mapper;
       
        public UserMDSController(IUserMDSRepository userMDSRepository, UserMDSDbContext userMDSDbContext, IMapper mapper)
        {
            this.userMDSRepository = (UserMDSRepository?)userMDSRepository;
            this.userMDSDbContext = userMDSDbContext;
            this.mapper = mapper;
         
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index( IFormFile files, string button)
        {
          
            

            var ukgProdCenterInput = new List<UKGProdCenterModel>();
            var companyEmployeeBenefitsInput = new List<CompanyEmployeeBenefitsModel>();
            var dataSource = "";
            if (files != null)
            {
                if (files.Length > 0)
                {

                    //Getting FileName
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        // The formFile is the method parameter which type is IFormFile
                        // Saves the files to the local file system using a file name generated by the app.
                        await files.CopyToAsync(stream);
                    }

                    // For .net core, the next line requires the NuGet package, 
                    // System.Text.Encoding.CodePages
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            //// reader.IsFirstRowAsColumnNames
                            var conf = new ExcelDataSetConfiguration
                            {
                                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                                {
                                    UseHeaderRow = false
                                }
                            };
                            var dataSet = reader.AsDataSet(conf);
                            var dataTable = dataSet.Tables[0];
                            int columnCount = reader.FieldCount;
                            dataSource = dataTable.Rows[0][0].ToString();
                            //template check 
                            if (button == "UKG")
                            {
                                if(dataTable.Rows[0][0].ToString() != "UKG Production Center")
                                {
                                    ViewData["TemplateMismatch"] ="Please choose the proper template for UKG Production center";
                                    return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());

                                }
                            }
                            if (dataTable != null)
                            {
                                for (var i = 2; i < dataTable.Rows.Count; i++)
                                {
                                    if (dataTable.Rows[0][0].ToString() == "UKG Production Center")
                                    {
                                        try {
                                            ukgProdCenterInput.Add(new UKGProdCenterModel
                                            {
                                                Plant = dataTable.Rows[i][0].ToString(),
                                                Cost_Center = dataTable.Rows[i][1].ToString(),
                                                Shift = Convert.ToInt32(dataTable.Rows[i][2]),
                                                


                                            });
                                        }
                                        catch(Exception ex) {
                                            ViewData["ExceptionMessage"] = ex.Message;
                                            return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());

                                        }

                                    }
                                    else
                                    {
                                        try
                                        {
                                            string whp = dataTable.Rows[i][1]?.ToString();
                                            double? _whp = string.IsNullOrEmpty(whp) ? (double?)null : Convert.ToDouble(whp);
                                            string ip = dataTable.Rows[i][2]?.ToString();
                                            double? _ip = string.IsNullOrEmpty(ip) ? (double?)null : Convert.ToDouble(ip);
                                            string ptp = dataTable.Rows[i][3]?.ToString();
                                            double? _ptp = string.IsNullOrEmpty(ptp) ? (double?)null : Convert.ToDouble(ptp);
                                            string pp = dataTable.Rows[i][4]?.ToString();
                                            double? _pp = string.IsNullOrEmpty(pp) ? (double?)null : Convert.ToDouble(pp);
                                            string afp = dataTable.Rows[i][5]?.ToString();
                                            double? _afp = string.IsNullOrEmpty(afp) ? (double?)null : Convert.ToDouble(afp);
                                            string tbp = dataTable.Rows[i][6]?.ToString();
                                            double? _tbp = string.IsNullOrEmpty(tbp) ? (double?)null : Convert.ToDouble(tbp);
                                            companyEmployeeBenefitsInput.Add(new CompanyEmployeeBenefitsModel
                                            {
                                                plant_unique = dataTable.Rows[i][0].ToString(),
                                                work_home_perc = _whp,
                                                insurance_perc = _ip,
                                                pr_tax_perc = _ptp,
                                                pto_perc =  _pp,
                                                adj_factor_perc = _afp,
                                                tot_benefits_perc = _tbp,



                                            });
                                        }
                                        catch (Exception ex)
                                        {
                                            ViewData["ExceptionMessage"] = ex.Message;
                                            return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());

                                        }
                                    }

                                }
                            }


                        }
                    }
                    if (dataSource == "UKG Production Center")
                    {
                        if (ukgProdCenterInput != null && ukgProdCenterInput.Count > 0)
                        {
                            for (int i = 0; i < ukgProdCenterInput.Count; i++)
                            {
                                var ukgprodCenter = new AddUKGProdCenterDTO();
                                {
                                    ukgprodCenter.Plant = ukgProdCenterInput[i].Plant;
                                    ukgprodCenter.Cost_Center = ukgProdCenterInput[i].Cost_Center;
                                    ukgprodCenter.Shift = ukgProdCenterInput[i].Shift;
                                    ukgprodCenter.Modified_Date = DateTime.Now;
                                    


                                }
                                var ukgProdModelDomain = mapper.Map<UKGProdCenterModel>(ukgprodCenter);
                                try {
                                    var result = await userMDSRepository.CreateUKGProdCenterAsync(ukgProdModelDomain);
                                    ViewData["Success"] = "File uploaded successfully";
                                  
                                }
                                catch(Exception ex) {
                                    ViewData["ExceptionMessage"] = ex.Message;
                                    return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());
                                } 
                                
                            }
                            return Redirect("/GridData?Table_Name=UKG_Production_Centers");
                        }
                    }
                    else
                    {
                        if (companyEmployeeBenefitsInput != null && companyEmployeeBenefitsInput.Count > 0)
                        {
                            for (int i = 0; i < companyEmployeeBenefitsInput.Count; i++)
                            {
                                var companyEmployeeBenefits = new AddCompanyEmployeeBenefitsDTO();
                                {
                                    companyEmployeeBenefits.plant_unique = companyEmployeeBenefitsInput[i].plant_unique;
                                    companyEmployeeBenefits.work_home_perc = companyEmployeeBenefitsInput[i].work_home_perc;
                                    companyEmployeeBenefits.insurance_perc = companyEmployeeBenefitsInput[i].insurance_perc;
                                    companyEmployeeBenefits.pto_perc = companyEmployeeBenefitsInput[i].pto_perc;
                                    companyEmployeeBenefits.adj_factor_perc = companyEmployeeBenefitsInput[i].adj_factor_perc;
                                    companyEmployeeBenefits.pr_tax_perc = companyEmployeeBenefitsInput[i].pr_tax_perc;
                                    companyEmployeeBenefits.tot_benefits_perc = companyEmployeeBenefitsInput[i].tot_benefits_perc;


                                }
                                var companyEmployeeBenefitsDomain = mapper.Map<CompanyEmployeeBenefitsModel>(companyEmployeeBenefits);
                                try
                                {
                                    var result = await userMDSRepository.CreateCompanyEmployeeBenefitsAsync(companyEmployeeBenefitsDomain);
                                    
                                     
                                }
                                catch (Exception ex)
                                {
                                    ViewData["ExceptionMessage"] = ex.Message;
                                    return View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());
                                }
                            }
                           return  Redirect("/GridData?Table_Name=Company_Employee_Benefits");
                        }
                    }

                }

            }

            return 
                //Redirect("/GridData?Table_Name=UKG_Production_Centers");
            View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());
        }


    }
}

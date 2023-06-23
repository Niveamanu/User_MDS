using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMDS.Data;
using UserMDS.Models;
using UserMDS.Models.DTO;
using UserMDS.Repositories;

namespace SalesRfp.Controllers
{
    public class UserMDSController : Controller
    {
        private readonly UserMDSRepository userMDSRepository;
        private readonly UserMDSDbContext userMDSDbContext;

        private readonly IMapper mapper;
        public UserMDSController(IUserMDSRepository userMDSRepository,UserMDSDbContext userMDSDbContext,IMapper mapper)
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
        public async Task<IActionResult> Index(IFormFile files)
        {
            var input = new List<UKGProdCenterModel>();
            if (files != null)
            {
                if (files.Length > 0)
                {

                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);

                    // For .net core, the next line requires the NuGet package, 
                    // System.Text.Encoding.CodePages
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
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

                            if (dataTable != null)
                            {
                                for (var i = 2; i < dataTable.Rows.Count; i++)
                                {
                                    input.Add(new UKGProdCenterModel
                                    {
                                        Plant = dataTable.Rows[i][0].ToString(),
                                        Cost_Center = dataTable.Rows[i][1].ToString(),
                                        Shift = Convert.ToInt32( dataTable.Rows[i][2]),
                                         
                                         
                                    });
                                    
                                }
                            }

                            
                        }
                    }

                    if (input != null && input.Count > 0)
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            var ukgprodCenter = new AddUKGProdCenterDTO();
                            {
                                ukgprodCenter.Plant = input[i].Plant;
                                ukgprodCenter.Cost_Center = input[i].Cost_Center;
                                ukgprodCenter.Shift = input[i].Shift;   
                                ukgprodCenter.Modified_Date= DateTime.Now;


                            }
                            var ukgProdModelDomain = mapper.Map<UKGProdCenterModel>(ukgprodCenter);
                             var result = await userMDSRepository.CreateUKGProdCenterAsync(ukgProdModelDomain);
                        }
                    }

                }

            }

            return Redirect("/GridData?Table_Name=UKG_Production_Centers");
                //View(await userMDSDbContext.User_Maintenance_Master_Data.ToListAsync());
        }

       
    }
}

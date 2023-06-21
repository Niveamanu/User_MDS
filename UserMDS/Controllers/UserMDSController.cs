using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using SalesRfp.Models.Domain;
using SalesRfp.Models;
using UserMDS.Models;
using UserMDS.Repositories;

namespace SalesRfp.Controllers
{
    public class UserMDSController : Controller
    {
        private readonly UserMDSRepository userMDSRepository;  
        public UserMDSController(IUserMDSRepository userMDSRepository)
        {
            this.userMDSRepository = (UserMDSRepository?)userMDSRepository;
        }
        public IActionResult Index()
        {
            return View();
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
                                         
                                         
                                    });
                                    
                                }
                            }

                            
                        }
                    }

                    if (input != null && input.Count > 0)
                    {
                        for (int i = 0; i < input.Count; i++)
                        {
                            var ukgprodCenter = new AddUKGProdCenterModel();
                            {
                                ukgprodCenter.Plant = input[i].Plant;
                                ukgprodCenter.Cost_Center = input[i].Cost_Center;
                                
                                
                            }
                             var result = await userMDSRepository.CreateUKGProdCenterAsync(ukgprodCenter);
                        }
                    }

                }

            }

            return View(input);
        }
    }
}

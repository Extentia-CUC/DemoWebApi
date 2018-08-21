using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using WebDataModel;
using WebDataService.Controllers;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.Tracing;
using System.Web.Http.Controllers;

namespace WebService.Tests
{
    [TestFixture]
    public class TestNopvController
    {
        List<NOPVData> nopvList;
       [SetUp]
        public void Setup()
        {
            //_products = SetUpProducts();
            //_tokens = SetUpTokens();
            //_dbEntities = new Mock<WebApiDbEntities>().Object;
            //_tokenRepository = SetUpTokenRepository();
            //_productRepository = SetUpProductRepository();
            //var unitOfWork = new Mock<IUnitOfWork>();
            //unitOfWork.SetupGet(s => s.ProductRepository).Returns(_productRepository);
            //unitOfWork.SetupGet(s => s.TokenRepository).Returns(_tokenRepository);
            //_unitOfWork = unitOfWork.Object;
            //_productService = new ProductServices(_unitOfWork);
            //_tokenService = new TokenServices(_unitOfWork);
            //_client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            //var tokenEntity = _tokenService.GenerateToken(1);
            //_token = tokenEntity.AuthToken;
            //_client.DefaultRequestHeaders.Add("Token", _token);
            nopvList = new List<NOPVData>
            {
                new NOPVData
                {
                    BBL = "1005680015",
                    PrimaryZoning= "R5-2",
                    LotFrontage= 25,
                    LotDepth = (float)94.83,
                    LotSquareFootage = 2371,
                    LotType = "Inside",
                    Proximity = "2-Side Abutted",
                    BuildingFrontage = 25,
                    BuildingDepth = 78,
                    NumberOfBuildings = 1,
                    Style = "Row",
                    YearBuilt = 1900,
                    ExteriorCondition = "Low Average",
                    FinishedSquareFootage = 5696,
                    UnfinishedSquareFootage = 512,
                    CommercialUnits = 0,
                    CommercialSquareFootage = 0,
                    ResidentialUnits = 3,
                    GarageType = null,
                    GarageSquareFootage = 0,
                    BasementGrade = "Above Grade",
                    BasementSquareFootage = "1734",
                    BasementType = "Full",
                    ConstructionType = "Stone",
                    ExteriorWall = "Masonry",
                    NumberOfStories = 3,
                    LastUpdated = "39:26.0",
                    LotShape = "Regular"
                },
                 new NOPVData
                {
                    BBL = "1005680030",
                    PrimaryZoning= "R7-2",
                    LotFrontage= 28,
                    LotDepth = (float)98.83,
                    LotSquareFootage = 2571,
                    LotType = "Inside",
                    Proximity = "2-Side Abutted",
                    BuildingFrontage = 30,
                    BuildingDepth = 78,
                    NumberOfBuildings = 1,
                    Style = "Row",
                    YearBuilt = 1900,
                    ExteriorCondition = "Low Average",
                    FinishedSquareFootage = 5696,
                    UnfinishedSquareFootage = 512,
                    CommercialUnits = 0,
                    CommercialSquareFootage = 0,
                    ResidentialUnits = 3,
                    GarageType = null,
                    GarageSquareFootage = 0,
                    BasementGrade = "Above Grade",
                    BasementSquareFootage = "1734",
                    BasementType = "Full",
                    ConstructionType = "Stone",
                    ExteriorWall = "Masonry",
                    NumberOfStories = 3,
                    LastUpdated = "39:26.0",
                    LotShape = "Regular"
                },
                 new NOPVData
                {
                    BBL = "1005690029",
                    PrimaryZoning= "R7-2",
                    LotFrontage= 28,
                    LotDepth = (float)98.83,
                    LotSquareFootage = 3000,
                    LotType = "Inside",
                    Proximity = "2-Side Abutted",
                    BuildingFrontage = 30,
                    BuildingDepth = 78,
                    NumberOfBuildings = 1,
                    Style = "Row",
                    YearBuilt = 1950,
                    ExteriorCondition = "Low Average",
                    FinishedSquareFootage = 5696,
                    UnfinishedSquareFootage = 512,
                    CommercialUnits = 0,
                    CommercialSquareFootage = 0,
                    ResidentialUnits = 3,
                    GarageType = null,
                    GarageSquareFootage = 0,
                    BasementGrade = "Above Grade",
                    BasementSquareFootage = "1734",
                    BasementType = "Full",
                    ConstructionType = "Stone",
                    ExteriorWall = "Masonry",
                    NumberOfStories = 3,
                    LastUpdated = "39:26.0",
                    LotShape = "Regular"
                }
            };
        }

        [Test]
        public void TestGetAll()
        {
            var mockService = new Mock<INopvDataRepository>();
            mockService.Setup(repo => repo.GetAll()).Returns(nopvList.AsQueryable());
            var controller = new NopvDataController(mockService.Object);
            //Act
            IHttpActionResult actionResult = controller.Get(new WebDataService.Models.PaginationMetadata());
            // Assert
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<WebDataService.Models.ServiceResponse<NOPVData>>), actionResult);
            var contentResult = actionResult as OkNegotiatedContentResult<WebDataService.Models.ServiceResponse<NOPVData>>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Data.Count);

        }

        [Test]
        public void TestPatch()
        {
            var delta = new Delta<NOPVData>(typeof(NOPVData));
                        
            var mockService = new Mock<INopvDataRepository>();
            //mockService.Setup(repo => repo.UpdateDetails(
            //    It.IsAny<string>(), //Any value of BBL
            //    It.IsAny<Delta<NOPVData>>()) //Any value of Delata object
            //    ).Returns(nopvList.FirstOrDefault(d => d.BBL == "1005690029"));

            var controller = new NopvDataController(mockService.Object);
            //Act
            //IHttpActionResult actionResult = controller.Patch("1005690029", delta);
            //// Assert
            //Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<NOPVData>), actionResult);
            //var contentResult = actionResult as OkNegotiatedContentResult<NOPVData>;
            //// Assert the result  
            //Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(contentResult.Content.BBL, "1005690029");
        }


        [Test]
        public void TestGetById()
        {
            string bbl = "1005690029";
            // Mock Repository service
            var mockService = new Mock<INopvDataRepository>();
            mockService.Setup(repo => repo.GetDetails(
                It.IsAny<string>() //Any value of BBL
                )).Returns(nopvList.FirstOrDefault(d => d.BBL == bbl)); // Always return Nopv details for "1005690029".

            // Mock Logger
            var mockLogger = new Mock<ITraceWriter>();
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), mockLogger.Object);

            // Mock ApiController's Descriptor
            var mockControllerDecriptor = new HttpControllerDescriptor() { ControllerType = typeof(NopvDataController) };
            var controller = new NopvDataController(mockService.Object);
            controller.ControllerContext.ControllerDescriptor = mockControllerDecriptor;

            //Act
            IHttpActionResult actionResult = controller.Get(bbl);
            // Assert
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<NOPVData>), actionResult);
            var contentResult = actionResult as OkNegotiatedContentResult<NOPVData>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(contentResult.Content.BBL, bbl);
        }

        [Test]
        public void Test_GetByID_NotFound()
        {
            string bbl = "1005690029";
            
            var mockService = new Mock<INopvDataRepository>();
            mockService.Setup(repo => repo.GetDetails(
                It.IsAny<string>() //Any value of BBL
                )).Returns(()=> null);

            var mockLogger = new Mock<ITraceWriter>();
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), mockLogger.Object);

            var mockControllerDecriptor = new HttpControllerDescriptor() { ControllerType = typeof(NopvDataController) };
            var controller = new NopvDataController(mockService.Object);
            controller.ControllerContext.ControllerDescriptor = mockControllerDecriptor;
            //Act
            var result = controller.Get(bbl) as NegotiatedContentResult<string>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
        }

    }

}

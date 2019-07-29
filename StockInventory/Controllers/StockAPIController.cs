using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Web.Models;
using Stock.Web.Core.BAL;
using Stock.Web.Utility;

namespace Stock.Web.Controllers
{

    [Produces("application/json")]
    //[Route("api/StockAPI")]
    public class StockAPIController : Controller
    {
        private readonly IStockBll _stockBll;
        private ILog _logger;

        public StockAPIController(IStockBll stockBll, ILog logger)
        {
            _stockBll = stockBll;
            _logger = logger;
        }

        // GET: api/GetAllStocks
        [HttpGet]
        [Route("api/StockAPI/GetAllStocks")]
        public IEnumerable<StockModel> GetAllStudents()
        {
            List<StockModel> stocks = _stockBll.GetAllProductStocks().ToList();
            return stocks;
        }
    }
}
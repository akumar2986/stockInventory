using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Web.Core.BAL;
using Stock.Web.Models;

namespace Stock.Web.Controllers
{
    public class ProductStockController : Controller
    {
        private readonly IStockBll _stockBll;

        public ProductStockController(IStockBll stockBll)
        {
              _stockBll = stockBll;
        }


        // GET: productstocks
        public ActionResult Index()
        {
            return View(_stockBll.GetAllProductStocks().ToList());           
        }

        // GET: stocks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var pstocks = await _context.ProductStocks
            //    .SingleOrDefaultAsync(m => m.ProductStockID == id);

            var pstocks = _stockBll.GetStockData(id);

            if (pstocks == null)
            {
                return NotFound();
            }

            return View(pstocks);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchId,Name,Variety,Quantity")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                _stockBll.AddProductStock(stockModel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(stockModel);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var player = await _context.ProductStocks.SingleOrDefaultAsync(m => m.ProductStockID == id);
            var pstock = _stockBll.GetStockData(id);
            if (pstock == null)
            {
                return NotFound();
            }
            return View(pstock);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tag,EnrollmentDate")] StockModel productStock)
        {
            if (id != productStock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _stockBll.UpdateProductStock(productStock);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productStock.StockId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productStock);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pstock = _stockBll.GetStockData(id);

            //var player = await _context.ProductStocks
            //    .SingleOrDefaultAsync(m => m.ProductStockID == id);
            if (pstock == null)
            {
                return NotFound();
            }

            return View(pstock);
        }

        // POST: ProductStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _stockBll.DeleteProductStock(id);
            return RedirectToAction(nameof(Index));

            //var pstock = await _context.ProductStocks.SingleOrDefaultAsync(m => m.ProductStockID == id);
            //_context.ProductStocks.Remove(pstock);
            //await _context.SaveChangesAsync();

        }

        private bool ProductExists(int id)
        {
            var pstock = _stockBll.GetStockData(id);
            if (pstock != null)
                return true;
            else
                return false;
            //return _context.ProductStocks.Any(e => e.ProductStockID == id);
        }
    }
}

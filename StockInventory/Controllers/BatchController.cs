using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stock.Web.Core.BAL;
using Stock.Web.Models;
using Stock.Web.Utility;

namespace Stock.Web.Controllers
{
    [Authorize]
    public class BatchController : Controller
    {
        private readonly IBatchBll _batchBll;
        private ILog _logger;

        public BatchController(IBatchBll stockBll, ILog logger)
        {
              _batchBll = stockBll;
            _logger = logger;
        }


        // GET: batches
        public IActionResult Index()
        {
            _logger.Information("starting batch services");
            return View(_batchBll.GetAllBatchStocks().ToList());
        }

        // GET: batch/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var pstocks = await _context.ProductStocks
            //    .SingleOrDefaultAsync(m => m.ProductStockID == id);

            var batches = _batchBll.GetBatchData(id);

            if (batches == null)
            {
                return NotFound();
            }

            return View(batches);
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
        public IActionResult Create([Bind("BatchId,Name,Variety,Quantity")] BatchModel batchemodel)
        {
            if (ModelState.IsValid)
            {
                _batchBll.AddUpdateBatchStock(batchemodel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(batchemodel);
        }

        // GET: batch/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var player = await _context.ProductStocks.SingleOrDefaultAsync(m => m.ProductStockID == id);
            var batch = _batchBll.GetBatchData(id);
            if (batch == null)
            {
                return NotFound();
            }
            return View(batch);
        }

        // POST: batch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BatchModel productStock)
        {
            //[Bind("ID,Tag,EnrollmentDate")] 
            if (id != productStock.BatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _batchBll.AddUpdateBatchStock(productStock);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productStock.BatchId))
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

        // GET: batch/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = _batchBll.GetBatchData(id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             _batchBll.DeleteBatchStock(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {

            var batch = _batchBll.GetBatchData(id);
            if (batch != null)
                return true;
            else
                return false;
            //return _context.ProductStocks.Any(e => e.ProductStockID == id);
        }
    }
}

using IntegrityAndConcurrency.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IntegrityAndConcurrency.Controllers
{
    public class IntegrityConcurrencyAPIController : ApiController
    {
        private ConcurrencyDBEntities db = new ConcurrencyDBEntities();
        [HttpGet]
        public IQueryable<transaction> GetTransactions()
        {
            return db.transactions;
        }
        [HttpGet]
        public IHttpActionResult GetTransaction(int id)
        {
            var transaction = db.transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateTransaction(int id, transaction updatedTransaction)
        {
            if (id != updatedTransaction.TransactionId)
            {
                return BadRequest();
            }

            db.Entry(updatedTransaction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool TransactionExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}

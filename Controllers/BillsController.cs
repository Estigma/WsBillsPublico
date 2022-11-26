using Microsoft.AspNetCore.Mvc;
using System;
using WsBills.Models;
using WSBills.Interfaces;

namespace WsBills.Controllers
{
    public class BillsController : ControllerBase
    {
        private IBillService _service;

        public BillsController(IBillService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/bills")]
        public ActionResult<Bill> GetBills()
        {
            var bills = _service.GetBills();
            return Ok(bills);
        }

        [HttpGet]
        [Route("api/bills/{id}", Name = "GetBill")]
        public async Task<IActionResult> GetBill(int id)
        {
            var bill = _service.GetBill(id);

            if (bill == null)
            {
                return BadRequest($"Factura con Id = {id} no existe.");
            }

            return Ok(bill);
        }

        [HttpPost]
        [Route("api/bills")]
        public async Task<ActionResult<Bill>> AddBill([FromBody] Bill bill)
        {
            if(_service.GetBill(bill.Id) != null)
            {
                return NotFound();
            }

            _service.AddBill(bill.Name, bill.Description, bill.Amount, bill.DueDate);
            return CreatedAtRoute(nameof(GetBill), new { id = bill.Id}, bill);
        }

        [HttpPut]
        [Route("api/bills/{id}")]
        public async Task<ActionResult<Bill>> UpdateBill(int id, [FromBody] Bill bill)
        {
            _service.UpdateBill(id, bill.Name, bill.Description, bill.Amount, bill.DueDate);
            
            return CreatedAtRoute(nameof(GetBill), new { id = bill.Id }, bill);
        }

        [HttpDelete]
        [Route("api/bills/{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(int id)
        {
            _service.DeleteBill(id);
            
            return Ok(id);
        }
    }
}

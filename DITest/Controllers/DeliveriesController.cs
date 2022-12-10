using DITest.Data;
using DITest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DITest.Controllers
{
    [Route("deliveries/")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveryDbContext _deliveryContext;
        private readonly TimeslotDbContext _timeslotContext;

        public DeliveriesController(DeliveryDbContext deliverycontext, TimeslotDbContext timeslotContext)
        {
            _deliveryContext = deliverycontext;
            _timeslotContext = timeslotContext;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> BookDelivery(BookDelivery bd)
        {
            var a = bd;
            var ts = await _timeslotContext.Timeslot.FindAsync(bd.timeslotId);
            if (ts == null)
            {
                await _timeslotContext.AddAsync(new Timeslot());
                await _timeslotContext.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                if(ts.delivery_1 == null)
                {
                    var new_Delivery = new Delivery();
                    new_Delivery.user = bd.user;
                    ts.delivery_1 = new_Delivery;

                    await _deliveryContext.AddAsync(new_Delivery);
                    await _deliveryContext.SaveChangesAsync();

                    _timeslotContext.Entry(ts).State= EntityState.Modified;
                    await _timeslotContext.SaveChangesAsync();
                    return NoContent();
                }
            }
            return BadRequest();
        }

        [HttpPost("{id}/complete")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> MarkDeliveryAsCompleted(int id)
        {
            var delivery = await _deliveryContext.Delivery.FindAsync(id);
            if (delivery == null) return BadRequest();
            delivery.status = Status.Deliverd;
            _deliveryContext.Entry(delivery).State = EntityState.Modified;
            await _deliveryContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> CancelDelivery(int id)
        {
            var delivery = await _deliveryContext.Delivery.FindAsync(id);
            if (delivery == null) return BadRequest();
            delivery.status = Status.Canceled;
            _deliveryContext.Entry(delivery).State = EntityState.Modified;
            await _deliveryContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("/daily")]
        public async Task<IEnumerable<Delivery>> GetTodayDelivery()
        {
            var currentTime = DateTime.Now;
            var deliveriesToday = await _timeslotContext.Timeslot.Where(ts =>
            ts.startTime.Year == currentTime.Year &&
                 ts.startTime.Month == currentTime.Month &&
                 ts.startTime.Day == currentTime.Day)
                .Select(
                 ts => ts.id
                 ).ToListAsync();
            return await _deliveryContext.Delivery.Where(d => deliveriesToday.Contains(d.id)).ToListAsync();
        }

        [HttpGet("/weekly")]
        public async Task<IEnumerable<Delivery>> GetWeeklyDelivery()
        {
            var currentTime = DateTime.Now;
            var deliveriesToday = await _timeslotContext.Timeslot.Where(ts =>
            ts.startTime.Year == currentTime.Year &&
                 ts.startTime.Month == currentTime.Month)
                .Select(
                 ts => ts.id
                 ).ToListAsync();
            return await _deliveryContext.Delivery.Where(d => deliveriesToday.Contains(d.id)).ToListAsync();
        }
    }
}

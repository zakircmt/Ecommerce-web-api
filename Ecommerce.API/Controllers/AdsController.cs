using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Entities;
using Ecommerce.Web.Data;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecoundBanner>>> GetSecoundBanners()
        {
            return await _context.SecoundBanners.ToListAsync();
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecoundBanner>> GetSecoundBanner(int id)
        {
            var secoundBanner = await _context.SecoundBanners.FindAsync(id);

            if (secoundBanner == null)
            {
                return NotFound();
            }

            return secoundBanner;
        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecoundBanner(int id, SecoundBanner secoundBanner)
        {
            if (id != secoundBanner.ID)
            {
                return BadRequest();
            }

            _context.Entry(secoundBanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecoundBannerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SecoundBanner>> PostSecoundBanner(SecoundBanner secoundBanner)
        {
            _context.SecoundBanners.Add(secoundBanner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecoundBanner", new { id = secoundBanner.ID }, secoundBanner);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecoundBanner(int id)
        {
            var secoundBanner = await _context.SecoundBanners.FindAsync(id);
            if (secoundBanner == null)
            {
                return NotFound();
            }

            _context.SecoundBanners.Remove(secoundBanner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecoundBannerExists(int id)
        {
            return _context.SecoundBanners.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityCenterTracker.Model;
using AutoMapper;
using CommunityCenterTracker.DTOs;
using AutoMapper.QueryableExtensions;

namespace CommunityCenterTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundlesController : ControllerBase
    {
        private readonly CommunityCenterContext _context;

        private readonly IMapper _mapper;

        public BundlesController(IMapper mapper, CommunityCenterContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Bundles
        [HttpGet]
        public async Task<ActionResult<List<BundleDTO>>> GetBundles()
        {
          if (_context.Bundles == null)
          {
              return NotFound();
          }

            var bundles = await _context.Bundles
                .Include(bundle => bundle.Section)
                .ToListAsync();
            var bundleDTOs = _mapper.Map<List<BundleDTO>>(bundles);
            return bundleDTOs;
        }

        // PUT: api/Bundles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBundle(int id, Bundle bundle)
        {
            if (id != bundle.Id)
            {
                return BadRequest();
            }

            _context.Entry(bundle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BundleExists(id))
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

        // POST: api/Bundles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bundle>> PostBundle(Bundle bundle)
        {
          if (_context.Bundles == null)
          {
              return Problem("Entity set 'CommunityCenterContext.Bundles'  is null.");
          }
            _context.Bundles.Add(bundle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBundle", new { id = bundle.Id }, bundle);
        }

        // DELETE: api/Bundles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBundle(int id)
        {
            if (_context.Bundles == null)
            {
                return NotFound();
            }
            var bundle = await _context.Bundles.FindAsync(id);
            if (bundle == null)
            {
                return NotFound();
            }

            _context.Bundles.Remove(bundle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BundleExists(int id)
        {
            return (_context.Bundles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityCenterTracker.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommunityCenterTracker.DTOs;

namespace CommunityCenterTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BundleController : EntityController<Bundle, ReturnBundle_BundleDTO, CreateBundle_BundleDTO>
    {
        private readonly CommunityCenterContext _context;

        private readonly IMapper _mapper;

        public BundleController(IMapper mapper, CommunityCenterContext context) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<Bundle>> Get(int id)
        {
            if (_context.Bundles == null)
            {
                return NotFound();
            }

            var bundles = await _context.Bundles
                .Include(bundle => bundle.Section)
                .Include(bundle => bundle.Fishes)
                .Include(bundle => bundle.Crops)
                .Where(bundle => bundle.Id.Equals(id))
                .FirstOrDefaultAsync();
            //var bundleDTOs = _mapper.Map<List<ReturnBundle_BundleDTO>>(bundles);
            return Ok(bundles);
        }

        private bool BundleExists(int id)
        {
            return (_context.Bundles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommunityCenterTracker.DTOs;
using CommunityCenterTracker.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<EntityType, OutputModelDTO, InputModelDTO> : ControllerBase
        where EntityType : class
        where OutputModelDTO: class
        where InputModelDTO : class
    {
        private readonly CommunityCenterContext _context;
        private readonly IMapper _mapper;
        protected DbSet<EntityType> _entitySet { get; }

        public EntityController(CommunityCenterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _entitySet = context.Set<EntityType>();
        }

        [HttpGet]
        public virtual async Task<ActionResult<OutputModelDTO>> Get()
        {
            if (_context == null)
            {   
                return NotFound();
            }
            var entity = await _entitySet.ToListAsync();
            var dtoParsedEntity = _mapper.Map<List<OutputModelDTO>>(entity);
            
            return Ok(dtoParsedEntity);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<EntityType>> Get(int id)
        {
            if (_entitySet == null)
            {
                return NotFound();
            }
            var entity = await _entitySet.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var dtoParsedEntity = _mapper.Map<OutputModelDTO>(entity);

            return Ok(dtoParsedEntity);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public virtual async Task<ActionResult<InputModelDTO>> Post(InputModelDTO inputModelDTO)
        {
            var dtoParsedEntity = _mapper.Map<EntityType>(inputModelDTO);
            _entitySet.Add(dtoParsedEntity);
            await _context.SaveChangesAsync();

            var returnDTO = _mapper.Map<OutputModelDTO>(dtoParsedEntity);

            return Ok(returnDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_entitySet == null)
            {
                return NotFound();
            }
            var crop = await _entitySet.FindAsync(id);
            if (crop == null)
            {
                return NotFound();
            }

            _entitySet.Remove(crop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        // [HttpPut("{id}")]	// id does not need to be in URL since it will be on the object
        public async Task<IActionResult> Update([FromBody()] EntityType existingEntity)
        {
            _entitySet.Attach(existingEntity);
            _context.Entry(existingEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(existingEntity);
        }
    }
}

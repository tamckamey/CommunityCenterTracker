using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommunityCenterTracker.Model;
using CommunityCenterTracker.DTOs;
using AutoMapper;

namespace CommunityCenterTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : EntityController<Crop, ReturnCrop_CropDTO, CreateCrop_CropDTO>
    {
        private readonly CommunityCenterContext _context;
        private readonly IMapper _mapper;

        public CropController(IMapper mapper, CommunityCenterContext context) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;

        }
    }
}

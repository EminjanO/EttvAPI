using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EttvAPI.Data.Models;
using EttvAPI.Help.Extensions;
using EttvAPI.Models;
using EttvAPI.Services;
using EttvAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EttvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelProgramController : ControllerBase
    {

        private readonly ChannelProgramService _channelProgramService;
        private readonly IMapper _mapper;

        public ChannelProgramController(IChannelProgramService channelProgramService, IMapper mapper)
        {
            _channelProgramService = channelProgramService as ChannelProgramService;
            _mapper = mapper;
        }

        // GET: api/ChannelProgram
        [HttpGet]
        public ActionResult Get()
        {
            var models = new List<ChannelProgramModel>();
            var results = _channelProgramService.List();

            foreach (var result in results)
            {
                models.Add(_mapper.Map<ChannelProgram, ChannelProgramModel>(result));
            }

            return Ok(models);
        }

        // GET: api/ChannelProgram/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _channelProgramService.List().Where(x => x.Id == id).SingleOrDefault();
            var channelProgramM = _mapper.Map<ChannelProgram, ChannelProgramModel>(result);

            return Ok(channelProgramM);
        }

        // POST: api/ChannelProgram
        [HttpPost]
        public ActionResult Post([FromBody] ChannelProgramModel model)
        {
           if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var channelProgram = _mapper.Map<ChannelProgramModel, ChannelProgram>(model);
            var result = _channelProgramService.Save(channelProgram);

            if (!result.Success)
                return BadRequest(result.Message);

            var channelProgramModel = _mapper.Map<ChannelProgram, ChannelProgramModel>(result.ChannelProgram);
            return Ok(channelProgramModel);
        }

        // PUT: api/ChannelProgram/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ChannelProgramModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var channelProgram = _mapper.Map<ChannelProgramModel, ChannelProgram>(model);
            var result = _channelProgramService.Update(id, channelProgram);

            if (!result.Success)
                return BadRequest(result.Message);

            var channelProgramModel = _mapper.Map<ChannelProgram, ChannelProgramModel>(result.ChannelProgram);
            return Ok(channelProgramModel);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _channelProgramService.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var channelProgramModel = _mapper.Map<ChannelProgram, ChannelProgramModel>(result.ChannelProgram);
            return Ok(channelProgramModel);
        }
    }
}

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
    public class VideoContentController : ControllerBase
    {
        private readonly VideoContentService _videoContentService;
        private readonly IMapper _mapper;

        public VideoContentController(IVideoContentService videoContentService, IMapper mapper)
        {
            _videoContentService = videoContentService as VideoContentService;
            _mapper = mapper;
        }

        // GET api/VideoContent
        [HttpGet]
        public ActionResult Index()
        {
            var models = new List<VideoContentModel>();
            var results = _videoContentService.List();

            foreach (var result in results)
            {
                var videoContentM = _mapper.Map<VideoContent, VideoContentModel>(result);
                models.Add(videoContentM);
            }

            return Ok(models);
        }

        // GET api/VideoContent/M7lc1UVf-VE
        [HttpGet("{id}")]
        public ActionResult Index(string id)
        {
            var result = _videoContentService.List().Where(x=>x.VideoId == id).SingleOrDefault();
            var videoContentM = _mapper.Map<VideoContent, VideoContentModel>(result);
            return Ok(videoContentM);
        }

        // POST api/VideoContent
        [HttpPost]
        public ActionResult Post([FromBody] VideoContentModel model) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videocontent = _mapper.Map<VideoContentModel, VideoContent>(model);
            var result = _videoContentService.Save(videocontent);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoContentModel = _mapper.Map<VideoContent, VideoContentModel>(result.VideoContent);
            return Ok(videoContentModel);
        }

        // PUT api/VideoContent/M7lc1UVf-VE
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] VideoContentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videoContent = _mapper.Map<VideoContentModel, VideoContent>(model);
            var result = _videoContentService.Update(id,videoContent);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoContentModel = _mapper.Map<VideoContent, VideoContentModel>(result.VideoContent);
            return Ok(videoContentModel);
        }

        // DELETE api/VideoContent/M7lc1UVf-VE
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var result = _videoContentService.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoContentModel = _mapper.Map<VideoContent, VideoContentModel>(result.VideoContent);
            return Ok(videoContentModel);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using EttvAPI.Models;
using AutoMapper;
using EttvAPI.Data.Models;
using EttvAPI.Help.Extensions;
using Microsoft.AspNetCore.Mvc;
using EttvAPI.Services;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginService _loginService;
        public readonly AppUserService _appUserService;
        private readonly IMapper _mapper;

        public UserController(ILoginService loginService, IAppUserService appUserService, IMapper mapper)
        {
            _loginService = loginService as LoginService;
            _appUserService = appUserService as AppUserService;
            _mapper = mapper;
        }
        // Get: api/User
        [HttpGet]
        [Route("AllUser")]
        public ActionResult Get()
        {
            var models = new List<AppUserModel>();
            var results = _appUserService.List();

            foreach (var result in results)
            {
                models.Add(_mapper.Map<AppUser, AppUserModel>(result));
            }

            return Ok(models);
        }

        // Post: api/User
        [HttpPost]
        [Route("Register")]
        public ActionResult Post([FromBody] AppUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            bool EmailExist = _appUserService.List().Any(a => a.Email == model.Email);
            if (EmailExist) return BadRequest("Email Exist");
            
            var appUser = _mapper.Map<AppUserModel, AppUser>(model);
            var result = _appUserService.Save(appUser);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var appUserModel = _mapper.Map<AppUser, AppUserModel>(result.AppUser);
            return Ok(appUserModel);
        }

        // Post: api/User
        [HttpPost]
        [Route("Login")]
        public  ActionResult Post([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = _loginService.UserLogin(model);

            if (result == null)
                return BadRequest("Email / Password is not correct");

            var appUserModel = _mapper.Map<AppUser, AppUserModel>(result);
            return Ok(appUserModel);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AppUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var appUser = _mapper.Map<AppUserModel, AppUser>(model);
            var result = _appUserService.Update(id, appUser);

            if (!result.Success)
                return BadRequest(result.Message);

            var appUserModel = _mapper.Map<AppUser, AppUserModel>(result.AppUser);
            return Ok(appUserModel);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _appUserService.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var appUserModel = _mapper.Map<AppUser, AppUserModel>(result.AppUser);
            return Ok(appUserModel);
        }
    }
}
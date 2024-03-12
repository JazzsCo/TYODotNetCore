using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using TYODotNetCore.BirdWebApi.Models;

namespace TYODotNetCore.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly IBirdApi refitApi = RestService.For<IBirdApi>("https://burma-project-ideas.vercel.app");

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BirdModel> lst = await refitApi.GetBirds();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            BirdModel item = await refitApi.GetBird(id);
            return Ok(item);
        }
    }
}

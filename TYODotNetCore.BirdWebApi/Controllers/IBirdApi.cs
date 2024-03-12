using Refit;
using TYODotNetCore.BirdWebApi.Models;

namespace TYODotNetCore.BirdWebApi.Controllers
{
    public interface IBirdApi
    {
        [Get("/birds")]
        Task<List<BirdModel>> GetBirds();

        [Get("/birds/{id}")]
        Task<BirdModel> GetBird(int id);
    }
}

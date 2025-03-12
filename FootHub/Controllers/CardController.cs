using FootHub.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly FootHubDBContext dbContext;
        public CardController(FootHubDBContext dBContext)
        {
            this.dbContext = dbContext;
        }

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BrouwerWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BrouwerWebApp.Controllers {
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase {
        private readonly IBrouwerRepository repository;
        public BrouwerController(IBrouwerRepository repository) =>
        this.repository = repository;
        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id) {
            var brouwer = await repository.FindByIdAsync(id);
            return brouwer == null ? base.NotFound() : base.Ok(brouwer);
        }
    }
}
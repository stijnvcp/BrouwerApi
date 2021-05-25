using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrouwerService.Controllers
{
    [Route("brouwers")]
    [ApiController]
    public class BrouwerController : ControllerBase {
        private readonly IBrouwerRepository repository;
        public BrouwerController(IBrouwerRepository repository) => this.repository = repository;

        [HttpGet]
        public ActionResult FindAll() => base.Ok(repository.FindAll());

        [HttpGet("{id}")]
        public ActionResult FindById(int id) {
            var brouwer = repository.FindById(id);
            return brouwer == null ? base.NotFound() : base.Ok(brouwer);
        }

        [HttpGet("naam")]
        public ActionResult FindByBeginNaam(string begin) =>
            base.Ok(repository.FindByBeginNaam(begin));

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var brouwer = repository.FindById(id);
            if (brouwer == null) {
                return base.NotFound();
            }
            repository.Delete(brouwer);
            return base.Ok();
        }

        [HttpPost]
        public ActionResult Post(Brouwer brouwer) {
            if (this.ModelState.IsValid) {
                repository.Insert(brouwer);
                return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
            }
            return base.BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Brouwer brouwer) {
                if (this.ModelState.IsValid) {
                    try {
                        brouwer.Id = id;
                        repository.Update(brouwer);
                        return base.Ok();
                    }
                    catch (DbUpdateConcurrencyException) {
                        return base.NotFound();
                    }
                    catch {
                        return base.Problem();
                    }
                }
                return base.BadRequest();
        }
    }
}

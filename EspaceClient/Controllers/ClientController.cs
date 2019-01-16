using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EspaceClient.Context;
using EspaceClient.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EspaceClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext clientContext;

        public ClientController(ClientContext clientContext)
        {
            this.clientContext = clientContext;
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(clientContext.Clients.ToList());
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            try
            {
                clientContext.Add(client);
                clientContext.SaveChanges();
                return Created("/"+ client.Id, client);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Put([FromBody] Client client)
        {
            try
            {
                clientContext.Attach(client);
                //  clientContext.Entry(client).Property("Name").IsModified = true;
                //  clientContext.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                clientContext.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        public IActionResult Delete([FromBody] Client client)
        {
            try
            {
                clientContext.Attach(client);
                clientContext.Clients.Remove(client);
                clientContext.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
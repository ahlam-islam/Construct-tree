using Microsoft.AspNetCore.Mvc;
using TreeAPI.Model;
using TreeAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeServices nodeOptions;

        public NodesController(INodeServices nodeOptions)
        {
            this.nodeOptions = nodeOptions;
        }
        // GET: api/<NodesController>
        [HttpGet]
        public ActionResult<List<Node>> Get()
        {
            return nodeOptions.GetNodes();
        }

        [HttpGet("{id}")]

        public ActionResult<Node> Get(string id)
        {
            var node = nodeOptions.GetNode(id);
            if(node == null)
            {
                return NotFound();
            }
            return node;
        }
        // POST api/<NodesController>
        [HttpPost]
        public ActionResult<Node> Post([FromBody] Node node)
        {
            nodeOptions.AddNode(node);
            return Ok(node);

        }

        // PUT api/<NodesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Node node)
        {
            var existingNode = nodeOptions.GetNode(id);
            if(existingNode == null)
            {
                return NotFound();
            }

            nodeOptions.UpdateNode(id, node);
            return NoContent();

                
        }

        // DELETE api/<NodesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingNode = nodeOptions.GetNode(id);
            if(existingNode == null)
            {
                return NotFound();
            }

            nodeOptions.DeleteNode(existingNode.Id);
            return Ok();
        }
    }
}

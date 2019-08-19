using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Model;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogAPI.Controllers
{
    [Route("api/blog")]
    public class BlogController : Controller
    {
       

        private readonly PostContext _context;

        public BlogController(PostContext context)
        {
            _context = context;

        }

        // GET: api/blog
        [HttpGet]
        public ActionResult<List<PostEntity>> Get()
        {
            var listOfentities = _context.Posts.ToList();           
            

            return listOfentities;
        }
        

        // POST api/blog
        [HttpPost]
        public ActionResult<PostEntity> Post([FromBody]Post post)
        {          
           
            var postEntity = new PostEntity { _id = post.id, _content = post.content, _title = post.title };
            _context.Posts.Add(postEntity);
             _context.SaveChanges();
            return CreatedAtAction("Post", new { postEntity._id }, postEntity);

        }


        // DELETE blog/api/8cbf31b5-5911-4255-a929-534be5f1546c
        [HttpDelete("{id}")]
        public  IActionResult Delete(Guid id)
        {
            var removePost =  _context.Posts.Find(id);
            

            if (removePost == null)
            {
                return NotFound();
            }            

            _context.Posts.Remove(removePost);
            _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

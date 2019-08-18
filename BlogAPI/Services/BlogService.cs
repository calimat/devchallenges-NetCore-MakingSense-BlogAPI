using System;
using System.Collections.Generic;
using System.Linq;
using BlogAPI.Model;

namespace BlogAPI.Services
{
    public class BlogService
    {
        private readonly List<Post> _posts;

        public BlogService(List<Post> posts)
        {
            _posts = posts;
        }

        public List<Post> GetAll()
        {
            return _posts;
        }

        public Post Create(string title, string content)
        {
            var newPost = new Post(title, content);
            _posts.Add(newPost);
            return new Post(title, content);
        }

        public void Delete(Guid id)
        {
            var post = _posts.SingleOrDefault(x => x.id == id);           
            _posts.Remove(post);
        }
    }
}

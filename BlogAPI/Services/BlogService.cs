using System;
using System.Collections.Generic;
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
    }
}

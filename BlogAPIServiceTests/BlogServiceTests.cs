using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class BlogService
    {
        public List<Post> Get()
        {
            return new List<Post>();
        }
    }

    public class Post
    {

    }

    public class BlogServiceTests
    {
        [Test]
        public void BlogService_ShouldNotBeNull()
        {
            var sut =  new BlogService();
            Assert.IsNotNull(sut);
        }

       
        [Test]
        public void BlogService_ShouldReturnAListOfPosts()
        {
            var sut = new BlogService();
            var result = sut.Get();
            Assert.IsInstanceOf<List<Post>>(result);
        }
    }
}
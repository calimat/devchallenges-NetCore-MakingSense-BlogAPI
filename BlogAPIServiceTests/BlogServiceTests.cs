using System;
using System.Collections.Generic;
using BlogAPI.Model;
using BlogAPI.Services;
using Moq;
using NUnit.Framework;

namespace Tests
{
  
    public class BlogServiceTests
    {
        public Post mockPost { get; set; }
        public List<Post> listOfPostMock { get; set; }
        public BlogService sut { get; set; }

        [SetUp]
        public void Setup()
        {
            mockPost = new Post();
            listOfPostMock = new List<Post>();
            sut = new BlogService(listOfPostMock);

        }

        [Test]
        public void BlogService_ShouldReturnAListOfPosts()
        {
            
            var result = sut.GetAll();
            Assert.IsInstanceOf<List<Post>>(result);
            
        }

        [Test]
        public void BlogService_ListOfPostHasOneReturnsOne()
        {
            listOfPostMock.Add(mockPost);
            var result = sut.GetAll();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void BlogService_ListOfPostHasTwoReturnsTwo()
        {
            listOfPostMock.Add(mockPost);
            listOfPostMock.Add(mockPost);
            var result = sut.GetAll();
            Assert.AreEqual(2, result.Count);
        }

    }
}
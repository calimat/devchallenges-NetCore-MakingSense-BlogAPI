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
        public Guid id { get; set; }

        [SetUp]
        public void Setup()
        {
            
            mockPost = new Post("TestPost", "TestPostContent");
            listOfPostMock = new List<Post>();
            sut = new BlogService(listOfPostMock);
            id = Guid.NewGuid();

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

        [Test]
        public void BlogServiceCreatesPost_ReturnsNotNullPost()
        {
            var post = sut.Create("TitleForPost", "Content");
            Assert.IsNotNull(post);
            
        }

        [Test]
        public void BlogServiceCreatesPost_ReturnsTitleAndContentCreated()
        {
            var resultPost = sut.Create("Title for Created Post", "Content");
            Assert.AreEqual(resultPost.title, "Title for Created Post");
            Assert.AreEqual(resultPost.content, "Content");
        }

        [Test]
        public void BlogServiceCreatesOnePost_IncrementsTheListByOne()
        {
            var resultPost = sut.Create("Title for Created Post", "Content");
            Assert.AreEqual(sut.GetAll().Count, 1); 
        }

        [Test]
        public void BlogServiceCreatesTwoPosts_IncrementsTheListByTwo()
        {
            var resultPost = sut.Create("Title for Created Post", "Content");
            var secondPost = sut.Create("Title for Created Post", "Content");
            Assert.AreEqual(sut.GetAll().Count, 2);
        }

        [Test]
        public void BlogServiceDeletesPost_FromTwoPostModel_ShouldReturnOne()
        {
            listOfPostMock.Add(mockPost);
            listOfPostMock.Add(new Post("Second Post", "Second Content"));

            sut.Delete(mockPost.id);

            Assert.AreEqual(listOfPostMock.Count, 1);
        }
    }
}
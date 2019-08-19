using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Model
{
    public class Post
    {
        [Key]
        private Guid _id { get; set; }

        private string _title { get; set; }

        private string _content { get; set; }

        

        public string title
        {
            get
            {
                return _title;
            }
        }

        public string content
        {
            get
            {
                return _content;
            }
        }

        
        public Guid id
        {
            get
            {
                return _id;
            }
        }

       
        public Post(String title, String content)
        {
           
            _id = Guid.NewGuid();
            _title = title;
            _content = content;

        }
    }

    public class PostEntity
    {
        [Key]
        public Guid _id { get; set; }

        public string _title { get; set; }

        public string _content { get; set; }
    }
}

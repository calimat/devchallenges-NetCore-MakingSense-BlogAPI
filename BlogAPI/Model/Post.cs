using System;
namespace BlogAPI.Model
{
    public class Post
    {
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

        public Post(string title, string content)
        {
            _id = Guid.NewGuid();
            _title = title;
            _content = content;

        }
    }
}

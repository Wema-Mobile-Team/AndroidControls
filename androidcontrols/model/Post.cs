using System;
using SQLite;

namespace androidcontrols.model
{
    public class Post
    {

        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string title { get; set; }

        public string body { get; set; }

        public Post()
        {
        }
    }
}

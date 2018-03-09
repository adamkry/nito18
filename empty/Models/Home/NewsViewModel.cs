using System.Collections.Generic;

namespace empty.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<string> Images { get; set; } = new List<string>();
    }
}
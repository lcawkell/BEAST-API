using System.Collections.Generic;

namespace BEAST_API.Models {
    public class Application {
        public long id { get; set; }
        public string title { get; set; }
        public List<Beast> beasts { get; set; }
    }
}
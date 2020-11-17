using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public List<Question> Questions { get; set; }
    }
}

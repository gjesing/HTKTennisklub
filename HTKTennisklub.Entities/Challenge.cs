using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public Member Member1 { get; set; }
        public Member Member2 { get; set; }
        public Member Winner { get; set; }
    }
}

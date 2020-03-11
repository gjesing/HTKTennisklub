using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.Entities
{
    public class Rank
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int Points { get; set; }
        public int RankNumber { get; set; }
    }
}

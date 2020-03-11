using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.Entities
{
    public class CourtClosing
    {
        public int Id { get; set; }
        public Court Court { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPermanent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TvMaze.Domain.Models
{
    public class ImportRun
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public int StartPageNum { get; set; }

        public int EndPageNum { get; set; }
    }
}

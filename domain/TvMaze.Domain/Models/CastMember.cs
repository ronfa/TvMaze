using System;

namespace TvMaze.Domain.Models
{
    public class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
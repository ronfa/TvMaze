using System.Collections.Generic;

namespace TvMaze.Domain.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CastMember> CastMembers { get; set; } = new List<CastMember>();
    }
}
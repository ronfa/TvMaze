using System.Collections.Generic;

namespace TvMaze.Domain.Resources
{
    public class ShowResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CastMemberResource> CastMembers { get; set; } = new List<CastMemberResource>();
    }
}
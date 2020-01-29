using System;

namespace TvMaze.Domain.Resources
{
    public class CastMemberResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public int ShowId { get; set; }
        public ShowResource Show { get; set; }

    }
}

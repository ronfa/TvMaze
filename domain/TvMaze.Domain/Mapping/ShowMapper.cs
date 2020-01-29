using TvMaze.Domain.Models;
using TvMaze.Domain.Resources;
using System.Linq;

namespace TvMaze.Domain.Mapping
{
    public static class ShowMapper
    {
        public static ShowResource ToShowResource(this Show show)
        {
            if (show == null)
            {
                return null;
            }

            return new ShowResource
            {
                Id = show.Id,
                Name = show.Name,
                CastMembers = show.CastMembers.OrderByDescending(c => c.Birthday).Select(ToCastMemberResource).ToList()
            };
        }

        public static CastMemberResource ToCastMemberResource(this CastMember castMember)
        {
            if (castMember == null)
            {
                return null;
            }

            return new CastMemberResource
            {
                 Id = castMember.Id,
                 Name = castMember.Name,
                 ShowId = castMember.ShowId,
                 Birthday = castMember.Birthday.ToString("dd/MM/yyyy")
            };
        }
    }
}

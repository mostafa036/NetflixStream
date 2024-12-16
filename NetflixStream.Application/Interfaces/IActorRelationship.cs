using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.Interfaces
{
    public interface IActorRelationship<ActorRelationship>
    {
        ICollection<ActorRelationship> ActorRelationships { get; }
    }
}

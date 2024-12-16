using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Application.DTOs.Subscriptiones
{
    public record SubscriptionResponseDto(string Username, string SubscriptionPlanName);

}

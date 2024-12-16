using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixStream.Domain.UserIdentity
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string PostalCode { get; private set; } = string.Empty;
        public string AddressType { get; private set; } = string.Empty;
        public string IsPrimary { get; private set; } = string.Empty;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

    }

}

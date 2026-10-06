using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Domain.Entities.Identity
{
    public class Jwt
    {
        public string key { get; set; } 
        public string issuer { get; set; }

        public string Audience { get; set; }

        public double DurationInDays { get; set; }

    }
}

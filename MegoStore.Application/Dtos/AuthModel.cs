using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegoStore.Application.Dtos
{
    public class AuthModel
    {
        public string message { get; set; }
        public bool IsAuthentcated { get; set; }

        public string username { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public string Token { get; set; }

        public DateTime Expireon { get; set; }


    }
}

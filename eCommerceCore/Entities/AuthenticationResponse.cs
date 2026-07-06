using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Entities
{
    public record AuthenticationResponse
    {
        public int Id { get; init; }
        public string? Email { get; init; }
        public string? Name { get; init; }
        public char? Gender { get; init; }
        public string? Token { get; init; }
        public bool? Success { get; init; }
    }
}

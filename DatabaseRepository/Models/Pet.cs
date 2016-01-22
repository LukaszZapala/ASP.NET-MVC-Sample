using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRepository.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PetType { get; set; }
        public int OwnerId { get; set; }
        public virtual Person Owner { get; set; }
    }
}

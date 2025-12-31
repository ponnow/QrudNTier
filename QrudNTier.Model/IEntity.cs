using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrudNTier.Model
{
    //Usnig Generic Type T for Id, CreatedBy, UpdatedBy to allow flexibility in data types
    internal interface IEntity<T>
    {
        T Id { get; set; }
        T CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        T UpdatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
    }

    public class Entity : IEntity<int>
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class  Entity2 : IEntity<string>
    {
        public string Id { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
    }
}

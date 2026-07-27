using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model {
    public enum CategoryState
    {
        Listed,
        Deleted
    }
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryState State { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model {
    public class Category {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(int id, string name)
        {
            setId(id);
            setName(name);
        }

        public void setName(string name) {
            Name = name;
        }

        public void setId(int id) {
            Id = id;
        }
    }
}

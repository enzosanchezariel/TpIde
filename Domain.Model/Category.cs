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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CategoryState State { get; private set; }

        public Category(int id, string name, CategoryState state)
        {
            setId(id);
            setName(name);
            setState(state);
        }

        public void setState(CategoryState state) {
            State = state;
        }

        public void setName(string name) {
            Name = name;
        }

        public void setId(int id) {
            Id = id;
        }
    }
}

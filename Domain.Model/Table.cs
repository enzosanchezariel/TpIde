using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model {
    public class Table {
        public int Id { get; set; }
        public int Number { get; set; }

        public Table(int id, int number)
        {
            setId(id);
            setNumber(number);
        }

        private void setNumber(int number) {
            Number = number;
        }

        private void setId(int id) {
            Id = id;
        }
    }
}

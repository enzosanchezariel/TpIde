using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model {
    public enum ProductState
    {
        Hidden,
        OutOfStock,
        Listed
    }
    public class Product {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProductState State { get; private set; }
        public Category Category { get; private set; }
        public List<Price> Prices { get; private set; } = new List<Price>();
        public Price Price
        {
            get {
                return Prices.First();
            }
            set {
                Prices.Insert(0, value);
            }
        }

        public Product(int id, string name, string description, ProductState state, Category category, Price price)
        {
            setId(id);
            setName(name);
            setDescription(description);
            setState(state);
            setCategory(category);
            setPrice(price);
        }

        public void setPrices(List<Price> prices) {
            Prices = prices;
        }

        public void setPrice(Price price) {
            Price = price;
        }

        public void setCategory(Category category) {
            Category = category;
        }

        public void setState(ProductState state) {
            State = state;
        }

        public void setDescription(string description) {
            Description = description;
        }

        public void setName(string name) {
            Name = name;
        }

        public void setId(int id) {
            Id = id;
        }
    }
}

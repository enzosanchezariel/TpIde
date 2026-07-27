namespace Domain.Model
{
    public enum OrderState
    {
        InProgress,
        Cancelled,
        Delivered,
        Paid
    }
    public class Order
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public OrderState State { get; private set; }
        public User Client { get; private set; }
        public List<Table> Tables { get; private set; }
        public List<Product> Products { get; private set; }

        public Order(int id, DateTime dateTime, OrderState state, User client, List<Table> tables, List<Product> products)
        {
            setId(id);
            setDateTime(dateTime);
            setOrderState(state);
            setClient(client);
            setTables(tables);
            setProducts(products);
        }

        private void setProducts(List<Product> products)
        {
            Products = products;
        }

        private void setTables(List<Table> tables)
        {
            Tables = tables;
        }

        private void setClient(User client)
        {
            Client = client;
        }

        private void setOrderState(OrderState state)
        {
            State = state;
        }

        private void setDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        private void setId(int id)
        {
            Id = id;
        }
    }
}

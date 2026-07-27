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
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public OrderState State { get; set; }
        public User Client { get; set; }
        public List<Table> Table { get; set; }
        public List<Product> Products { get; set; }

    }
}

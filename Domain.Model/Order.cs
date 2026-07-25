namespace Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        // INPROGRESS, CANCELLED, DELIVERED, PAID
        public string State { get; set; }
        public User Client { get; set; }
        public List<Table> Table { get; set; }
        public List<Product> Products { get; set; }

    }
}

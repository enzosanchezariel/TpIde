namespace Domain.Model {
    public class Price {
        public decimal Value { get; private set; }
        public DateTime DateTime { get; private set; }

        public Price(decimal value, DateTime dateTime)
        {
            setValue(value);
            setDateTime(dateTime);
        }

        private void setDateTime(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        private void setValue(decimal value)
        {
            Value = value;
        }
    }
}
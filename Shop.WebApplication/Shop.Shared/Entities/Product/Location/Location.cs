namespace Shop.Shared.Entities
{
    public class Location //пока не используется, но будет заменой поля Location у продукта, но надо перепроектировать базу данных и немного переделать код
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Apartment { get; set; }
    }
}

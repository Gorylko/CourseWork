namespace Shop.Shared.Entities
{
    public class Location //пока не используется, но будет заменой поля Location у продукта, но надо перепроектировать базу данных и немного переделать код
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; } //string т.к. может быть 10a и тд.

        public string Apartment { get; set; }
    }
}

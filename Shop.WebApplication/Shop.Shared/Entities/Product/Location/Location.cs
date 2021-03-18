namespace Shop.Shared.Entities
{
    public class Location //пока не используется, но будет заменой поля Location у продукта, но надо перепроектировать базу данных и немного переделать код
    {
        public int Id { get; set; }

        public Country Country { get; set; }

        public City City { get; set; }

        public Address Address { get; set; }
    }
}

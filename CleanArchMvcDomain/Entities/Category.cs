using CleanArchMvcDomain.Validation;
using CleanArchMvcDomain.Validation.;

namespace CleanArchMvcDomain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }


        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(Id < 0, "Invalid Id value");
            Id = id;
            ValidationDomain(name);
        }

        public void Update(string name)
        {
            ValidationDomain(name);
        }
        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracters");

            Name = name;
        }
    }
}

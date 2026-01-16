namespace User.API.Model
{
    public class User
    {
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Guid Id => Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }


        public User()
        {

        }
    }
}

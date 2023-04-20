namespace Simplon.Data.Entity
{
    public class Dog
    {
        public int? Id {get;set;}
        public string? Name {get;set;}
        public string? Breed {get;set;}
        public DateTime? BirthDate {get;set;}

        
        public Dog(string? name, string? breed, DateTime? birthDate, int? id = null)
        {
            Id = id;
            Name = name;
            Breed = breed;
            BirthDate = birthDate;
        }

    }
}


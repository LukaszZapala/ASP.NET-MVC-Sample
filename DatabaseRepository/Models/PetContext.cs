using System.Data.Entity;

namespace DatabaseRepository.Models
{
    public class PetContext : DbContext
    {
        public PetContext() : base("Default") { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pet>()                  // Budujemy sobie model na podstawie klasy Pet
                .HasRequired(x => x.Owner)              // który będzie wymagał wypełniania pola Owner.
                .WithMany(y => y.Pets)                  // Łączymy związkiem jeden do wielu z tabelą Person
                .HasForeignKey(z => z.OwnerId)          // z kluczem obcym OwnerId
                .WillCascadeOnDelete();                 // oraz włączamy kaskadowe usuwanie.
        }
    }
}

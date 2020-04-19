using ContactInformationCore.WebAPI;

namespace ContactInformationCore.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void SeedData(DatabaseContaxt context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Contacts.AddRange(
                new Model.Contact() { First_Name = "Kennie",Last_Name = "Guilloton",Email = "kguilloton0@utexas.edu", Phone_Number =  "2456325456", Status = Model.Status.Activate},
                new Model.Contact() { First_Name = "Elfreda", Last_Name = "Hallett", Email = "ehallett1@fema.gov", Phone_Number = "2525252525", Status = Model.Status.Activate },
                new Model.Contact() { First_Name = "Merill", Last_Name = "Gutteridge", Email = "mgutteridge2@paypal.com", Phone_Number = "8545625632", Status = Model.Status.Activate }
            );
            context.SaveChanges();
        }
    }
}

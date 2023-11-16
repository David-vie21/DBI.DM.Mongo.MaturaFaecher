using System.Reflection.Metadata;
using DBI.MongoRepoGeneric.Tests;
namespace DBI.MongoRepoGeneric.Tests
{
   
    public class DBIMongo
    {
        [Fact]
        public async Task AddClass1Async()
        {
            MongoDbSettings mongoDbSettings = new MongoDbSettings();
            //user:pw@host
            mongoDbSettings.ConnectionString = "mongodb://root:1234@localhost:27017";
            mongoDbSettings.DatabaseName = "mongodb";

            MongoRepository<Class> _classRepository = new MongoRepository<Class>(mongoDbSettings);
            //_classRepository.DeleteManyAsync(c => c.Name.Equals("2021/22 5BHIF"));
            //Class1

            Class class1 = new Class();
            class1.Name = "2021/22 5BHIF";


            Pruefung p1 = new Pruefung();
            p1.Schueler = "Max Mustermann";

            Fach f1 = new Fach();
            f1.Diplomarbeit = new Diplomarbeit() { Lehrer = "GT" };
            f1.AngMath = new AngMath();
            f1.Deutsch = new Deutsch();
            f1.Englisch = new Englisch();
            f1.Fachtheorie = new Fachtheorie() { muedlich = false, fach = "POS1" };
            f1.Schwerpunktfach = new Schwerpunktfach() { muedlich = true, Fach = "DBI", Lehrer = "HIK" };
            f1.Wahlpunktfach = new Wahlpunktfach();

            p1.Fach = f1;

            Pruefung[] pa = new Pruefung[2];
            pa[0] = p1;
            //class1.Pruefung = pa1;

            //_classRepository.InsertOneAsync(class1);

            //Prüf2


            Pruefung p2 = new Pruefung();
            p2.Schueler = "David Ankenbrand";

            Fach f2 = new Fach();
            f2.Diplomarbeit = new Diplomarbeit() { Lehrer = "OM" };
            f2.AngMath = new AngMath();
            f2.Deutsch = new Deutsch();
            f2.Englisch = new Englisch();
            f2.Fachtheorie = new Fachtheorie() { Lehrer = "SRM", muedlich = false, fach = "POS1", Note = 5 };
            f2.Schwerpunktfach = new Schwerpunktfach() { muedlich = true, Fach = "SYP1", Lehrer = "HY" };
            f2.Wahlpunktfach = new Wahlpunktfach() { Fach = "NVS1", Lehrer = "CO", muedlich = true };

            p2.Fach = f2;

            pa[1] = p2;
            class1.Pruefung = pa;

            await _classRepository.InsertOneAsync(class1);




            var test = await _classRepository.FindOneAsync(c => c.Name.Equals("2021/22 5BHIF"));

            //Assert.NotNull(people);
            Assert.NotNull(test);
        }

        [Fact]
        public async void Quers()
        {
            MongoDbSettings mongoDbSettings = new MongoDbSettings();
            //user:pw@host
            mongoDbSettings.ConnectionString = "mongodb://root:1234@localhost:27017";
            mongoDbSettings.DatabaseName = "mongodb";

            MongoRepository<Class> _classRepository = new MongoRepository<Class>(mongoDbSettings);

            var result = await _classRepository.FindOneAsync(c => c.Name.Equals("2021/22 5BHIF"));

            Assert.NotNull(result);

            Assert.True(result.Pruefung[0].Schueler.Equals("Max Mustermann"));
            Assert.True(result.Pruefung[1].Schueler.Equals("David Ankenbrand"));

           
            Assert.True(result.Pruefung[0].Fach.Diplomarbeit.Lehrer.Equals("GT"));
            Assert.True(result.Pruefung[1].Fach.Diplomarbeit.Lehrer.Equals("OM"));


            var result2 = await _classRepository.FindOneAsync(c => c.Pruefung[1].Fach.Diplomarbeit.Lehrer.Equals("OM"));

            Assert.NotNull(result2);

            Assert.True(result2.Pruefung[0].Schueler.Equals("Max Mustermann"));
            Assert.True(result2.Pruefung[1].Schueler.Equals("David Ankenbrand"));


            Assert.True(result2.Pruefung[0].Fach.Diplomarbeit.Lehrer.Equals("GT"));
            Assert.True(result2.Pruefung[1].Fach.Diplomarbeit.Lehrer.Equals("OM"));

            var result3 = await _classRepository.FindOneAsync(c => c.Pruefung[1].Fach.Diplomarbeit.Lehrer.Equals("SRM"));
            Assert.Null(result3);
        }
    }

    
}

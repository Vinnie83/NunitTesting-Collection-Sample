using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {

        [Test]

        public void Test_Collection_EmptyConstructor()
        {
            var coll = new Collection<int>();


            Assert.AreEqual(coll.ToString(), "[]");

            Assert.AreEqual(coll.Count, 0);
            Assert.AreEqual(coll.Capacity, 16);

        }

        [Test]

        public void Test_Collection_ConstructorSingleItem()
        {

            var coll = new Collection<int>(5);

            Assert.AreEqual(coll.ToString(), "[5]");

        }

        [Test]

        public void Test_Collection_ConstructorMultipleItems()
        {

            var coll = new Collection<int>(5, 6);

            Assert.AreEqual(coll.ToString(), "[5, 6]");

        }

        [Test]

        public void Test_Collection_CountAndCapacity()
        {

            var coll = new Collection<int>(5, 6);

            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));

        }

        [Test]

        public void Test_Collection_Add()
        {

            var coll = new Collection<string>("Ivan", "Peter");
            coll.Add("Gosho");

            Assert.AreEqual(coll.ToString(), "[Ivan, Peter, Gosho]");
        }

        [Test]

        public void Test_Collection_GetByIndex()
        {

            var collection = new Collection<int>(5, 6, 7);
            var item = collection[1];

            Assert.That(item.ToString(), Is.EqualTo("6"));
        }

        [Test]

        public void Test_Collection_SetByIndex()
        {

            var collection = new Collection<int>(5, 6, 7);
            collection[1] = 666;

            Assert.That(collection.ToString(), Is.EqualTo("[5, 666, 7]"));
        }

        [Test]

        public void Test_GetByInvalidIndex()
        {

            var coll = new Collection<string>("Ivan", "Peter");

            Assert.That(() => { var item = coll[2]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }


        [Test]

        public void Test_Collection_AddRange()
        {

            var items = new Collection<string>("Ivan", "Peter");
            items.AddRange("Georgi", "Raya", "Ivo");
            Assert.That(items.ToString(), Is.EqualTo("[Ivan, Peter, Georgi, Raya, Ivo]"));
            Assert.That(items.Capacity, Is.GreaterThanOrEqualTo(items.Count));
        }


        [Test]
        public void Test_Collection_InsertAt()
        {
            var names = new Collection<string>("Ivan", "Peter");
            names.InsertAt(0, "Raya");
            Assert.That(names.ToString(), Is.EqualTo("[Raya, Ivan, Peter]"));
            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(names.Count));
        }

        [Test]
        public void Test_Collection_Exchange()
        {
            var names = new Collection<string>("Ivan", "Peter", "Raya", "Ivo");
            names.Exchange(2, 3);
            Assert.That(names.ToString(), Is.EqualTo("[Ivan, Peter, Ivo, Raya]"));
        }

        [Test]
        public void Test_Collection_Remove()
        {
            var names = new Collection<string>("Ivan", "Peter", "Georgi");
            names.RemoveAt(1);
            Assert.That(names.ToString(), Is.EqualTo("[Ivan, Georgi]"));
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var names = new Collection<string>("Peter", "Maria", "Steve", "Mia");
            names.Clear();
            Assert.That(names.Count, Is.EqualTo(0));
            Assert.That(names.ToString(), Is.EqualTo("[]"));
        }

        [Test]

        public void Test_EnsureCapacity()
        {

            var coll = new Collection<int>(17);

            int initialCapacity = coll.Capacity;

            for (int i = 0; i < 17; i++ )
                coll.Add(i);
                 
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));
            Assert.That(coll.Capacity, Is.EqualTo(32));


        }


    }
}
using NUnit.Framework;

namespace DVSClient.Address.Layout.Elements.Tests
{
    [TestFixture]
    public class AddressElementTests
    {
        [Test]
        public void AddressElementLibrary_GetElement()
        {
            var addressElement = AddressElementLibrary.GetAddressElementFromElementName(Dataset.AuAddressGnaf, "buildingNumberFirst");
            Assert.That(addressElement, Is.EqualTo(Aug.BuildingNumberFirst));
        }

        [Test]
        public void AddressElementLibrary_ElementNotInDataset()
        {
            var addressElement = AddressElementLibrary.GetAddressElementFromElementName(Dataset.AuAddressGnaf, "whatever");
            Assert.That(addressElement, Is.Null);
        }

        [Test]
        public void AddressElementLibrary_DatasetNotInMap_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => AddressElementLibrary.GetAddressElementFromElementName(Dataset.AdAddressEd, "whatever"));
            Assert.That(ex?.Message == "No AddressElements class found for dataset: ad-address-ed");
        }
    }
}
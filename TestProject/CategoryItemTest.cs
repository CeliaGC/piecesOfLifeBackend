using Entities.Entities;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject
{
    [TestClass]
    public class CategoryItemTests
    {
        [TestMethod]
        [Fact]
        public void Constructor_SetsDefaultValues()
        {
            var category = new CategoryItem();

            Assert.True(category.IsActive);
            Assert.True(category.IsPublic);
            Assert.Equal(DateTime.Now.Date, category.InsertDate.Date);
        }
    }
}

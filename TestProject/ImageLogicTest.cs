using Data;
using Entities.Entities;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject
{
    [TestClass]
    public class ImageLogicTests
    {
        private Mock<DbSet<CategoryItem>> _mockSet;
        private Mock<ServiceContext> _mockContext;
        private ImageLogic _logic;  // Suponiendo que tu servicio se llama ImageService

        public ImageLogicTests()
        {
            var data = new List<CategoryItem>
            {
                new CategoryItem { IdCategory = 1, CategoryName = "Test" }
            }.AsQueryable();
    
            _mockSet = new Mock<DbSet<CategoryItem>>();
            _mockSet.As<IQueryable<CategoryItem>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<CategoryItem>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<CategoryItem>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<CategoryItem>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    
            _mockContext = new Mock<ServiceContext>();
            _mockContext.Setup(c => c.Set<CategoryItem>()).Returns(_mockSet.Object);
    
            _logic = new ImageLogic(_mockContext.Object);  // Suponiendo que tu servicio se llama ImageService
        }

        [TestMethod]
        [Fact]
        public void UpdateImage_UpdatesCategoryItemId()
        {
            var imageItem = new ImageItem { Category = "Test" };
    
            _logic.UpdateImage(imageItem);
    
            Assert.Equal(1, imageItem.CategoryItemId);
        }
    }
}


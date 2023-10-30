using Data;
using Entities.Entities;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject
{
    [TestClass]
    public class ImageLogicTests
    {
    private Mock<DbSet<CategoryItem>> _mockCategorySet;
    private Mock<DbSet<ImageItem>> _mockImageSet;
    private Mock<ServiceContext> _mockContext;
    private ImageLogic _logic;

        public ImageLogicTests()
        {
            var categoryData = new List<CategoryItem>
        {
            new CategoryItem { IdCategory = 1, CategoryName = "Nature" }
        }.AsQueryable();

            _mockCategorySet = new Mock<DbSet<CategoryItem>>();
            _mockCategorySet.As<IQueryable<CategoryItem>>().Setup(m => m.Provider).Returns(categoryData.Provider);
            _mockCategorySet.As<IQueryable<CategoryItem>>().Setup(m => m.Expression).Returns(categoryData.Expression);
            _mockCategorySet.As<IQueryable<CategoryItem>>().Setup(m => m.ElementType).Returns(categoryData.ElementType);
            _mockCategorySet.As<IQueryable<CategoryItem>>().Setup(m => m.GetEnumerator()).Returns(categoryData.GetEnumerator());

            // Configuración para ImageItem
            var imageData = new List<ImageItem>().AsQueryable(); 
            _mockImageSet = new Mock<DbSet<ImageItem>>();
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.Provider).Returns(imageData.Provider);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.Expression).Returns(imageData.Expression);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.ElementType).Returns(imageData.ElementType);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.GetEnumerator()).Returns(imageData.GetEnumerator());


            // Configurar el ServiceContext mockeado
            _mockContext = new Mock<ServiceContext>();
            _mockContext.Setup(c => c.Set<CategoryItem>()).Returns(_mockCategorySet.Object);
            _mockContext.Setup(c => c.Images).Returns(_mockImageSet.Object);
            _mockContext.Setup(c => c.Set<ImageItem>()).Returns(_mockImageSet.Object);
   

            _logic = new ImageLogic(_mockContext.Object);
        }
        [TestMethod]
        [Fact]
        public void UpdateImage_UpdatesImageName()
        {
            var originalName = "OriginalName";
            var imageItem = new ImageItem { ImageName = originalName, Category = "Nature", ImageSource = "url"};
            var newName = "UpdatedName";
            imageItem.ImageName = newName;
            _logic.UpdateImage(imageItem);

            Assert.NotEqual(originalName, imageItem.ImageName);
            Assert.Equal(newName, imageItem.ImageName);  
        }

        [TestMethod]
        [Fact]
        public void DeleteImage_RemovesImage()
        {
           
            var imageIdToDelete = 123;
            var mockImageItem = new ImageItem { Id = imageIdToDelete, ImageName = "TestImage", Category = "Nature", ImageSource = "url" };

            _mockImageSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(mockImageItem);

            _logic.DeleteImage(imageIdToDelete);

            _mockImageSet.Verify(m => m.Remove(mockImageItem), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());

         
        }

    }
}


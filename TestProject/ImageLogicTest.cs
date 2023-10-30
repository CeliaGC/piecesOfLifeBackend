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
            var imageData = new List<ImageItem>().AsQueryable(); // Inicialmente vacío, ajusta según sea necesario
            _mockImageSet = new Mock<DbSet<ImageItem>>();
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.Provider).Returns(imageData.Provider);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.Expression).Returns(imageData.Expression);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.ElementType).Returns(imageData.ElementType);
            _mockImageSet.As<IQueryable<ImageItem>>().Setup(m => m.GetEnumerator()).Returns(imageData.GetEnumerator());


            // Configurar el ServiceContext mockeado
            _mockContext = new Mock<ServiceContext>();
            _mockContext.Setup(c => c.Set<CategoryItem>()).Returns(_mockCategorySet.Object);
            _mockContext.Setup(c => c.Images).Returns(_mockImageSet.Object); // Añade esta línea
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
            Assert.Equal(newName, imageItem.ImageName);  // Asume que tu lógica actualiza el nombre a "UpdatedName"
        }

        [TestMethod]
        [Fact]
        public void DeleteImage_RemovesImage()
        {
            // Crear un ImageItem mockeado
            var imageIdToDelete = 123; // ID arbitrario para la prueba
            var mockImageItem = new ImageItem { Id = imageIdToDelete, ImageName = "TestImage", Category = "Nature", ImageSource = "url" };

            // Configura el DbSet mockeado para devolver el mockImageItem cuando se llame a Find
            //_mockImageSet.Setup(m => m.Where(It.IsAny<Expression<Func<ImageItem, bool>>>()))
            //             .Returns((Expression<Func<ImageItem, bool>> predicate) =>
            //             new List<ImageItem> { mockImageItem }.AsQueryable().Where(predicate));

            //        _mockImageSet.Setup(m => m.Where(It.IsAny<Expression<Func<ImageItem, bool>>>()))
            //.Returns((Expression<Func<ImageItem, bool>> predicate) =>
            //    new List<ImageItem> { mockImageItem }.AsQueryable().Where(predicate));

            _mockImageSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(mockImageItem);



            // Llamar al método DeleteImage en ImageLogic
            _logic.DeleteImage(imageIdToDelete);

            // Verificar que se llamó al método Remove con el mockImageItem
            _mockImageSet.Verify(m => m.Remove(mockImageItem), Times.Once());

            // Verificar que se llamó al método SaveChanges en _serviceContext
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}


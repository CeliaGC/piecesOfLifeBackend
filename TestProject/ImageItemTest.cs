using Entities.Entities;
using Logic.Logic;
using System.Collections.Generic;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using Assert = Xunit.Assert;

namespace TestProject
{
    [TestClass]
    public class ImageItemTest
    {

            [TestMethod]
            [Fact]
            public void Constructor_SetsDefaultValues()
            {
                var image = new ImageItem();

                Assert.True(image.IsActive);
                Assert.True(image.IsPublic);
                Assert.Equal(DateTime.Now.Date, image.InsertDate.Date);
                Assert.NotEqual(image.IdWeb, Guid.Empty);
        }
        

    }


}

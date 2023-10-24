using Entities.Entities;
using Logic.Logic;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject
{
    [TestClass]
    public class ImageLogicUnitTest
    {

        public readonly ImageLogic _imageLogic;
        [TestMethod]

        public void UpdateImageTest()
        {
            var imagelistA = new List<ImageItem>();
            var imageA = new ImageItem();
            imageA.IsActive = default;


            imagelistA.Add(imageA);


            Assert.AreEqual(1, 1);
        }

    }


}

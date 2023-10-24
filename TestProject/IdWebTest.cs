using Entities.Entities;
using Logic.Logic;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject
{
    [TestClass]
    public class ImageIdWebTest
    {

        public readonly ImageLogic _imageLogic;
        [TestMethod]

        public void InsertImagetItemTest()
        {
            
            var imageToAdd = new ImageItem();
            var imagelistA = new List<ImageItem>();

           
            imageToAdd.IdWeb = Guid.NewGuid();
            imagelistA.Add(imageToAdd);


            Assert.AreNotEqual(imageToAdd.IdWeb, Guid.Empty);
        }



    }








}

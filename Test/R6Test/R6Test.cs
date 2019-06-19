using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R6;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;

namespace R6Test
{
    [TestClass]
    public class R6Test
    {

        [TestMethod]
        public void HiddingTest()
        {
            // arrange
            BorderWindow Test = new BorderWindow();
            Grid[] WallsFloor = new Grid[70];
            Grid Wall1 = new Grid();
            Wall1.Opacity = 100;
            WallsFloor[50] = Wall1;
            int i = 50;
            double wall = 100;

            // act
            Test.Hidding(i);

            // assert
            double wall2 = WallsFloor[50].Opacity;
            Assert.AreEqual(wall2, wall, "nie schowano");
        }
    }
}

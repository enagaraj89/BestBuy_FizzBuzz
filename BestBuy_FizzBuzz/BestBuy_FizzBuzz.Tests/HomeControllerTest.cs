using BestBuy_FizzBuzz.Controllers;
using BestBuy_FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BestBuy_FizzBuzz.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
       [TestMethod]
        public void Index_ReturnsAViewResult()
        {
            var serviceProvider = new ServiceCollection()
        .AddLogging()
        .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);
            var result = home.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);
            Exception expectedException = null;
            try
            {
                FizzBuzzModel model = null;
                var result = home.Index(model);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void IndexPost_ReturnsInvalidItemResult_WhenInputIsInvalid()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);

            FizzBuzzModel model = new FizzBuzzModel { InputValues = "Aa" };
            var result = home.Index(model);

            ViewResult viewResult = result as ViewResult;
            FizzBuzzModel resultModel = viewResult.ViewData.Model as FizzBuzzModel;
            Assert.AreEqual("Invalid Item", resultModel.Output.FirstOrDefault());
        }

        [TestMethod]
        public void IndexPost_ReturnsFizzAsResult_WhenInputIsDividedByThree()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);

            FizzBuzzModel model = new FizzBuzzModel { InputValues = "3" };
            var result = home.Index(model);

            ViewResult viewResult = result as ViewResult;
            FizzBuzzModel resultModel = viewResult.ViewData.Model as FizzBuzzModel;
            Assert.AreEqual("Fizz", resultModel.Output.FirstOrDefault());
        }

        [TestMethod]
        public void IndexPost_ReturnsBuzzAsResult_WhenInputIsDividedByFive()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var expectedValue = "Buzz";
            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);

            FizzBuzzModel model = new FizzBuzzModel { InputValues = "10" };
            var result = home.Index(model);

            ViewResult viewResult = result as ViewResult;
            FizzBuzzModel resultModel = viewResult.ViewData.Model as FizzBuzzModel;
            Assert.AreEqual(expectedValue, resultModel.Output.FirstOrDefault());
        }


        [TestMethod]
        public void IndexPost_ReturnsFizzBuzzAsResult_WhenInputIsDividedByThreeAndFive()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var expectedValue = "FizzBuzz";
            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);

            FizzBuzzModel model = new FizzBuzzModel { InputValues = "30" };
            var result = home.Index(model);

            ViewResult viewResult = result as ViewResult;
            FizzBuzzModel resultModel = viewResult.ViewData.Model as FizzBuzzModel;
            Assert.AreEqual(expectedValue, resultModel.Output.FirstOrDefault());
        }

        [TestMethod]
        public void IndexPost_ReturnsAResult_WhenInputIsListOfValues()
        {
            var serviceProvider = new ServiceCollection()
       .AddLogging()
       .BuildServiceProvider();

            var expectedValue = 3;
            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<HomeController>();
            HomeController home = new HomeController(logger);

            FizzBuzzModel model = new FizzBuzzModel { InputValues = "3,5,30" };
            var result = home.Index(model);

            ViewResult viewResult = result as ViewResult;
            FizzBuzzModel resultModel = viewResult.ViewData.Model as FizzBuzzModel;
            Assert.AreEqual(expectedValue, resultModel.Output.Count);
        }
    }
}

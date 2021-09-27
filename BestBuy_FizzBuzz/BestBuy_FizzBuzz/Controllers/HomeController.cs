namespace BestBuy_FizzBuzz.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using BestBuy_FizzBuzz.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// HomeController.
        /// </summary>
        /// <param name="logger">logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Index Get action.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Index post action.
        /// </summary>
        /// <param name="model">FizzBuzzModel.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Index(FizzBuzzModel model)
        {
            if (model == null)
            {
                this.logger.LogError("Input model is null.");
                throw new ArgumentNullException($"{nameof(model)} is null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.logger.LogInformation("Input received for evaluating Fizz Buzz: " + model.InputValues);
            List<string> listStrInputValues = new List<string>();

            List<string> listStrOutputValues = new List<string>();

            if (model.InputValues.Contains(","))
            {
                listStrInputValues = model.InputValues.Split(',').Select(s => s.Trim()).ToList();
            }
            else
            {
                listStrInputValues.Add(model.InputValues.Trim());
            }

            foreach (var input in listStrInputValues)
            {
                if (int.TryParse(input, out int numberInput))
                {
                    if (numberInput % 3 == 0 && numberInput % 5 == 0)
                    {
                        listStrOutputValues.Add("FizzBuzz");
                    }
                    else if (numberInput % 3 == 0 && numberInput % 5 != 0)
                    {
                        listStrOutputValues.Add("Fizz");
                    }
                    else if (numberInput % 3 != 0 && numberInput % 5 == 0)
                    {
                        listStrOutputValues.Add("Buzz");
                    }
                    else
                    {
                        listStrOutputValues.Add("Divided " + numberInput + " by 3");
                        listStrOutputValues.Add("Divided " + numberInput + " by 5");
                    }
                }
                else
                {
                    listStrOutputValues.Add("Invalid Item");
                }
            }

            return this.View(new FizzBuzzModel
            {
                Output = listStrOutputValues,
            });
        }

        /// <summary>
        /// Error action.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

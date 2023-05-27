using facial_expression.WEB.Models;
using Facial_expression_WEB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace facial_expression.WEB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static int count = 0;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public IActionResult procesarImagen()
    {
        return View();
    }

    [HttpPost]
    public IActionResult procesarImagen(Image model)
    {
        if (model.ImageFile != null && model.ImageFile.Length > 0)
        {
            // Aquí puedes realizar las operaciones necesarias con la imagen, como guardarla en disco, procesarla, etc.
            // model.ImageFile contiene la imagen enviada

            // Ejemplo: Guardar la imagen en una ubicación específica
            var imagePath = $"images/{model.ImageFile.Name}.jpg";
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }

            //Load sample data
            var imageBytes = System.IO.File.ReadAllBytes(@$"images/{model.ImageFile.Name}.jpg");
            MLModel.ModelInput sampleData = new MLModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = MLModel.Predict(sampleData);

            Console.WriteLine("Respuesta:" + result.PredictedLabel);

            bool saved = false;
            while (!saved)
            {
                if (System.IO.File.Exists($"images/{result.PredictedLabel + count}.jpg"))
                {
                    count++;
                }
                else
                {
                    System.IO.File.Move($"images/{model.ImageFile.Name}.jpg", $"images/{result.PredictedLabel + count}.jpg");
                    count++;
                    saved = true;
                }
            }

            // Ejemplo: Redirigir a una vista de éxito
            return RedirectToAction("Index");
        }

        // Si no se envió una imagen válida, puedes redirigir a una vista de error o mostrar un mensaje de validación en el formulario.
        ModelState.AddModelError("ImageFile", "Por favor, seleccione una imagen.");

        // Vuelve a mostrar el formulario de carga de imágenes con el mensaje de error
        return View("Index", model);
    }
}
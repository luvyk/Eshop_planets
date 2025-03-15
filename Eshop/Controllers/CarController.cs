using Microsoft.AspNetCore.Mvc;
using WebMVC.Attributes;
using WebMVC.Database;
using WebMVC.Entities;
using WebMVC.Models.Car;

namespace WebMVC.Controllers
{
    public class CarController : SecuredController
    {
        private DatabaseContext _context;

        public CarController(DatabaseContext context)
        {
            _context = context;
        }

        [RequireLogin]
        public IActionResult List()
        {
            List<Car> cars = _context.Cars.ToList();

            List<CarViewModel> carViewModels = cars.Select(c => 
                new CarViewModel(c.ID, c.Brand, c.Model, c.Year,c.Price)
            ).ToList();

            return View(carViewModels);
        }

        [RequireRole("admin")]
        public IActionResult Add()
        {
            return View(new CarViewModel());
        }

        [RequireRole("admin")]
        [HttpPost]
        public IActionResult Add(CarViewModel carViewModel)
        {
            /*if (string.IsNullOrEmpty(carViewModel.Brand) || !char.IsUpper(carViewModel.Brand[0]))
            {
                ModelState.AddModelError("Brand", "Brand must start with a capital letter!"); //ruční nastavení chybového stavu
            }*/

            if (!ModelState.IsValid)
            {
                /*TempData["Message"] = $"Car cannot be added."; //jednoduchá, ale uživatelsky nepříznivá validace
                TempData["MessageType"] = "danger";

                return RedirectToAction("List");*/

                return View(carViewModel);
            }

            Car car = new Car(
                carViewModel.ID,
                carViewModel.Brand,
                carViewModel.Model,
                carViewModel.Year,
                carViewModel.Price
            );

            _context.Cars.Add(car);
            _context.SaveChanges();

            TempData["Message"] = $"Car {car.Brand} {car.Model} has been successfully added.";
            TempData["MessageType"] = "success";

            return RedirectToAction("List");
        }

        [RequireRole("admin")]
        public IActionResult Edit(int id)
        {
            Car? car = _context.Cars.SingleOrDefault(c => c.ID == id);

            if (car == null)
            {
                TempData["Message"] = "Car with the specified ID was not found!";
                TempData["MessageType"] = "danger";
                return RedirectToAction("List");
            }

            CarViewModel carViewModel = new CarViewModel(
                car.ID,
                car.Brand,
                car.Model,
                car.Year,
                car.Price
            );

            return View(carViewModel);
        }

        [RequireRole("admin")]
        [HttpPost]
        public IActionResult Edit(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carViewModel);
            }

            Car? car = _context.Cars.SingleOrDefault(c => c.ID == carViewModel.ID);

            if (car == null)
            {
                TempData["Message"] = "Car with the specified ID was not found!";
                TempData["MessageType"] = "danger";
                return RedirectToAction("List");
            }

            car.Brand = carViewModel.Brand;
            car.Model = carViewModel.Model;
            car.Year = carViewModel.Year;
            car.Price = carViewModel.Price;

            _context.Cars.Update(car);
            _context.SaveChanges();

            TempData["Message"] = $"Car {car.Brand} {car.Model} has been successfully edited.";
            TempData["MessageType"] = "success";

            return RedirectToAction("List");
        }

        [RequireRole("admin")]
        public IActionResult DeleteAction(int id)
        {
            Car? car = _context.Cars.SingleOrDefault(c => c.ID == id);

            /*if(car == null)
                return NotFound("Car with the specified ID was not found."); //možnost 1 - vrácení standardní odpovědi 404

            _context.Cars.Remove(car);
            _context.SaveChanges();*/

            if (car == null)
            {
                TempData["Message"] = "Car with the specified ID was not found!"; //možnost 2 - nastavení obsahu na následující stránce
                TempData["MessageType"] = "danger";
                return RedirectToAction("List");
            }

            _context.Cars.Remove(car);
            _context.SaveChanges();

            TempData["Message"] = "Car has been successfully deleted.";
            TempData["MessageType"] = "success";

            return RedirectToAction("List"); //přesměrování na stránku List
        }
    }
}

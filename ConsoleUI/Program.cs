//using Business.Concrete;
//using DataAccess.Concrete.EntityFramework;
//using Entities.Concrete;

//CarGetWithDetailTest();

//static void CarGetAllTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    foreach (var car in carManager.GetAll())
//    {
//        Console.WriteLine(car.Description);
//    }
//}


//static void CarGetByBrandId(int brandId)
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    foreach (var car in carManager.GetAll(x => x.BrandId == brandId))
//    {
//        Console.WriteLine(car.Description);
//    }
//}

//static void CarCreateTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    carManager.Create(new Car
//    {
//        BrandId = 1,
//        ColorId = 2,
//        DailyPrice = 250,
//        Description = "TOGG",
//        ModelYear = 2023
//    });

//}

//static void CarGetWithDetailTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());

//    foreach (var p in carManager.GetWithDetails())
//    {
//        Console.WriteLine(p.CarName + " - " + p.BrandName + " - " + p.ColorName);
//    }
//}
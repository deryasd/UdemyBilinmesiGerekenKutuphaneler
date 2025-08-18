// See https://aka.ms/new-console-template for more information
using Solid.App.DIPGoodAndBad;
using Solid.App.LSPGood;
using Solid.App.OCPGood2;

Console.WriteLine("Hello, World!");

//SalaryCalculater salaryCalculater = new SalaryCalculater();

//Bad Way
//Console.WriteLine($"Low Salary :{ salaryCalculater.Calculate(1000, SalaryCalculater.SalaryType.Low)}");
//Console.WriteLine($"Middle Salary :{ salaryCalculater.Calculate(1000, SalaryCalculater.SalaryType.Middlee)}");
//Console.WriteLine($"High Salary :{ salaryCalculater.Calculate(1000, SalaryCalculater.SalaryType.High)}");

//Good Way
//Console.WriteLine($"Low Salary :{salaryCalculater.Calculate(1000, new LowSalaryCalculate())}");
//Console.WriteLine($"Middle Salary :{salaryCalculater.Calculate(1000,new MiddleSalaryCalculate())}");
//Console.WriteLine($"High Salary :{salaryCalculater.Calculate(1000, new HighSalaryCalculate())}");

//Good Way 2
//Console.WriteLine($"Low Salary :{salaryCalculater.Calculate(1000, new LowSalaryCalculate().Calculate)}");
//Console.WriteLine($"Middle Salary :{salaryCalculater.Calculate(1000, new MiddleSalaryCalculate().Calculate)}");
//Console.WriteLine($"High Salary :{salaryCalculater.Calculate(1000, new HighSalaryCalculate().Calculate)}");
//Console.WriteLine($"Manager Salary :{salaryCalculater.Calculate(1000, new ManagerSalaryCalculate().Calculate)}");

//Console.WriteLine($"Custom Salary :{salaryCalculater.Calculate(1000, x =>
//{
//    return x*10;
//})}");

// -----

//BasePhone phone = new IPhone();

//phone.Call();
//phone.TakePhoto();

//phone = new Nokia3310();
//phone.Call();
//phone.TakePhoto();

//BasePhone phone = new IPhone();
//phone.Call();
//((ITakePhoto)phone).TakePhoto();

//phone = new Nokia3310();
//phone.Call();

var productService = new ProductService(new ProductRepositoryFromOracle());

productService.GetAll().ForEach(x =>  Console.WriteLine(x));
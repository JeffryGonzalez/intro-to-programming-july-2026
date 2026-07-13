using ExtraStuff;
using System.Runtime.CompilerServices;



if (true)
{
    var myLifeStory = new string('x', 10000);
    DateOnly jeffsBirthday = new DateOnly(1986, 4, 20);
}

//var lotsOfNumbers = Enumerable.Range(1, 100);
var lotsOfNumbers = Enumerable.Range(1, 50).Where(n => n % 2 == 0);


var total = lotsOfNumbers.Sum();

//foreach(var n in lotsOfNumbers.Skip(3).Take(4))
//{
//    Console.WriteLine("at " +n);
//    await Task.Delay(500);
//}





//int[] favoriteNumbers = [2, 10, 22, 108, 33];

//var evenFavorites = favoriteNumbers.Where(n => n % 2 == 0);

//favoriteNumbers[0] = 5;
//favoriteNumbers[4] = 80;

//foreach(var n in evenFavorites)
//{
//    Console.WriteLine(n);
//}

//Console.WriteLine("Hello, World!");


//var c1 = new Customer();

//c1.FirstName = "Robert";
//c1.LastName = "Smith";
//Console.WriteLine(c1.FullName);

//Console.WriteLine(c1.ToString());

//Console.WriteLine("Department: " + c1.Department);

//c1.SetDepartment("QA");
//Console.WriteLine("Department: " + c1.Department);

////c1.PhoneNumber = "555-1212";
//if (c1.PhoneNumber is not null)
//{
//    Console.WriteLine(c1.PhoneNumber.PadLeft(10));
//} else
//{
//    Console.WriteLine("No phone number provided!");
//}

//var phone = c1.PhoneNumber ?? "No Phone Number Provided";

//c1.PhoneNumber?.PadLeft(30);

//var sue = await Customer.LoadByIdAsync("x0039");

//var earl = await  Customer.LoadByIdAsync("a999");


//foreach(var purchase in c1.GetPurchaseHistory())
//{
   
//    Console.WriteLine($"Bought {purchase.Sku} for {purchase.Cost:c}");

//}

//var cat1 = new Pet
//{
//    Name = "Spike",
//    Age = 3,
//    Breed = "Balinese"
//};


//var cat2 = new Pet
//{
//    Name = "Spike",
//    Age = 3,
//    Breed = "Balinese"
//};

//if(cat1 == cat2)
//{
//    Console.WriteLine("They are the same");
//} else
//{
//    Console.WriteLine("They are different");
//}

//Console.WriteLine(cat1.ToString());


//var birthdaySpike = cat1 with { Age = 4 };

//Console.WriteLine(cat1);
//Console.WriteLine(birthdaySpike);

//var myName = "Jeff";
//myName.ToUpper();

//Console.WriteLine(myName);

//Console.WriteLine(myName.ToUpper());


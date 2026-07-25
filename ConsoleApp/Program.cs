using Domain;
using System.Drawing;

Flower rose = new Flower("rose", Color.Red, 1.25m);
Flower tulip = new Flower("tulip", Color.Red, 1.00m);
Flower daffodil = new Flower("daffodil", Color.Yellow, 1.50m);
Flower tulip1 = new Flower("tulip", Color.Yellow, 1.00m);

Bouquet valentineBouquet = new Bouquet("Valentine's bouquet");
valentineBouquet.AddFlower(rose, 10);
valentineBouquet.AddFlower(rose, 5);
valentineBouquet.AddFlower(daffodil, 7);
valentineBouquet.AddFlower(tulip1, 3);
valentineBouquet.AddFlower(tulip, 5);

Customer alice = new Customer("Alice");
alice.AddBouquet(valentineBouquet, DateTime.Now);
Console.WriteLine(alice);

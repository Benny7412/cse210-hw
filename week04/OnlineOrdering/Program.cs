using System;

class Program
{
    static void Main(string[] args)
    {
        Address usAddress = new Address("123 Street St", "Dallas", "TX", "USA");
        Address globalAddress = new Address("1234 Street Blvd", "Frankfurt", "Germany");

        Customer usCustomer = new Customer("Benjamin", usAddress);
        Customer globalCustomer = new Customer("Klaus", globalAddress);

        //products
        Product hamburger = new Product("hamburger", "FD01", 10.99f);
        Product taco = new Product("taco", "FD02", 3.99f);
        Product keyboard = new Product("keyboard", "TE01", 32.99f);
        Product mouse = new Product("mouse", "TE02", 59.99f);
        Product monitor = new Product("monitor", "TE03", 129.99f);
        Product bigCar = new Product("big car", "VE01", 12399.98f);

        Order order1 = new Order(usCustomer);
                
        order1.AddProduct(keyboard);
        order1.AddProduct(mouse, 3);
        order1.AddProduct(monitor);

        Order order2 = new Order(globalCustomer);

        order2.AddProduct(taco, 3);
        order2.AddProduct(hamburger, 500);
        order2.AddProduct(bigCar);


        Console.WriteLine("==== US ORDER ====");
        order1.GetPackingLabel();
        order1.GetShippingLabel();
        order1.SummarizeOrder();
        
        Console.WriteLine("==== INTERNATIONAL ORDER ====");
        order2.GetPackingLabel();
        order2.GetShippingLabel();
        order2.SummarizeOrder();
    }
}
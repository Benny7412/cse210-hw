using System;

class Order {
    private List<Product> _products;
    private Customer _customer;
    
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) 
    {
        _products.Add(product);
    }
    
    public void AddProduct(Product product, int quantity)
    {
        Product newProduct = new Product(product.Name, product.ProductId, product.UnitPrice, quantity);
        _products.Add(newProduct);
    }

    public float CalculateOrderTotal()
    {
        float productTotal = 0;
        foreach(Product product in _products) 
        {
            productTotal += product.CalculateCost();
        }

        float shippingCost = _customer.IsInUSA() ? 5:35;

        return productTotal + shippingCost;
    }

    public void GetPackingLabel() {
        Console.WriteLine("===== PACKING LABEL ======");
        foreach(Product product in _products) 
        {
            Console.WriteLine($"Product name: {product.Name}\nProduct ID: {product.ProductId}");
        }
        Console.WriteLine("==========================\n");
    }
    
    public void GetShippingLabel() {
        Console.WriteLine($"===== SHIPPING LABEL =====\nCustomer: {_customer.Name}\n{_customer.Address.GetFormattedAddress()}\n==========================\n");
    }
    
    public void SummarizeOrder() {
        Console.WriteLine("===== ORDER SUMMARY =====");
        foreach (Product product in _products) {
            Console.WriteLine($"{product.Name} | ID: {product.ProductId}");
            Console.WriteLine($"Amount: {product.Quantity} | Cost: ${product.UnitPrice:F2} | ${product.CalculateCost():F2}");
        } 
        float shippingCost = _customer.IsInUSA() ? 5:35;
        Console.WriteLine($"Shipping Cost: ${shippingCost:F2}\nTotal Order Price: ${CalculateOrderTotal():F2}\n=======================\n\n");
    }
}
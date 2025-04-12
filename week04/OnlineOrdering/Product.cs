using System;

class Product {
    private string _name;
    private string _productId;
    private float _unitPrice;
    private int _quantity;



    public Product(string name, string productId, float unitPrice, int quantity)
    {
        _name = name;
        _productId = productId;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }
    
    public Product(string name, string productId, float unitPrice)
    {
        _name = name;
        _productId = productId;
        _unitPrice = unitPrice;
        _quantity = 1;
    }
    

    public string Name {

        get { return _name; }
    }

    public string ProductId
    {
        get { return _productId; }
    }
    public float UnitPrice 
    {
        get { return _unitPrice; }
    }
    public int Quantity 
    {
        get { return _quantity; }
    }
    public float CalculateCost() 
    {
        return UnitPrice * _quantity;
    }

}
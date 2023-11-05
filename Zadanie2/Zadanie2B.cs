namespace Zadanie2;

public class Zadanie2B
{
    public class Product
    {
        private string _name;
        private int _price;
    
        public Product(string Name,int Price)
        {
            _name = Name;
            _price = Price;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPrice()
        {
            return _price;
        }
    }

    public class Provider
    {
        private List<Product> _products;

        public Provider()
        {
            _products = new List<Product>();
        }

        public List<Product> GatProduct()
        {
            Console.WriteLine("-----------------------");
            return _products;
        }
        
        public void AddProduct(Product product)
        {
            
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }
    }

}
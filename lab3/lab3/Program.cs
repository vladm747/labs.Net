using System;

namespace lab3
{

    public interface IAbstractFactory
    {
        IAbstractProduct CreateProduct();

        IAbstractSortOfGetting GetProduct();
    }


    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProduct CreateProduct()
        {
            return new Book();
        }

        public IAbstractSortOfGetting GetProduct()
        {
            return new GetBook();
        }
    }


    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProduct CreateProduct()
        {
            return new Magazine();
        }

        public IAbstractSortOfGetting GetProduct()
        {
            return new GetMagazine();
        }
    }

    public interface IAbstractProduct
    {
        string UsefulFunctionA();

    }

    class Book : IAbstractProduct
    {
        public string UsefulFunctionA()
        {
            return "Now you have got a BOOK";
        }

    }

    class Magazine : IAbstractProduct
    {
        public string UsefulFunctionA()
        {
            return "You have got a MAGAZINE";
        }
    }

    public interface IAbstractSortOfGetting
    {

        string ToBuyFromShop(IAbstractProduct product);


        string ToBorrowFromLib(IAbstractProduct product);
    }


    class GetBook : IAbstractSortOfGetting
    {
        public string ToBuyFromShop(IAbstractProduct product)
        {
            var result = product.UsefulFunctionA();

            return $"You went to the shop, {result}";
        }

        public string ToBorrowFromLib(IAbstractProduct product)
        {
            var result = product.UsefulFunctionA();

            return $"You went to the lib, {result}";
        }
    }

    class GetMagazine : IAbstractSortOfGetting
    {
        public string ToBuyFromShop(IAbstractProduct product)
        {
            var result = product.UsefulFunctionA();

            return $"You went to the shop, {result}";
        }

        public string ToBorrowFromLib(IAbstractProduct product)
        {
            var result = product.UsefulFunctionA();

            return $"You went to the lib, {result}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProduct();
            var productB = factory.GetProduct();

            Console.WriteLine(productA.UsefulFunctionA());
            Console.WriteLine(productB.ToBorrowFromLib(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}

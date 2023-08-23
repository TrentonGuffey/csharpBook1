
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()



{
    new Product()
    {
        Name = "Trumpet",
        Price = 150.99M,
        ProductTypeId = 1
    },
     new Product()
    {
        Name = "Trombone",
        Price = 246.99M,
        ProductTypeId = 1
    },
     new Product()
    {
        Name = "Tuba",
        Price = 1250.99M,
        ProductTypeId = 1
    },
     new Product()
    {
        Name = "Ozymandias",
        Price = 12350.99M,
        ProductTypeId = 2
    },
     new Product()
    {
        Name = "Leaves of Grass",
        Price = 15650.99M,
        ProductTypeId = 2
    },
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass"
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poem"
    }
};
//put your greeting here
string greeting = "Welcome to Brass & Poem. ";
Console.WriteLine(greeting);

//implement your loop here

string choice = null;
while (choice != "0")
{
    DisplayMenu();
    switch (choice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;

        case "2":
            DeleteProduct(products, productTypes);
            break;

        case "3":
            AddProduct(products, productTypes);
            break;

        case "4":
            UpdateProduct(products, productTypes);
            break;

        case "5":
            Console.WriteLine("Have a great day!");
            Environment.Exit(0);
            break;
    }
};

void DisplayMenu()
{
     Console.WriteLine(@"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
");
    choice = Console.ReadLine();

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} Price : {product.Price}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
     Console.WriteLine("Enter the name of the product to delete:");
    string productName = Console.ReadLine();

    Product productToDelete = products.Find(product => product.Name == productName);
    if (productToDelete != null)
    {
        products.Remove(productToDelete);
        Console.WriteLine($"Product '{productName}' has been deleted.");
    }
    else
    {
        Console.WriteLine($"Product '{productName}' not found.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the name of the new product:");
    string productName = Console.ReadLine();

    Console.WriteLine("Enter the price of the new product:");
    decimal productPrice;
    if (decimal.TryParse(Console.ReadLine(), out productPrice))
    {
        Console.WriteLine("Enter the product type (1 for Brass, 2 for Poem):");
        int productTypeId;
        if (int.TryParse(Console.ReadLine(), out productTypeId))
        {
            ProductType selectedType = productTypes.Find(type => type.Id == productTypeId);
            if (selectedType != null)
            {
                Product newProduct = new Product
                {
                    Name = productName,
                    Price = productPrice,
                    ProductTypeId = productTypeId
                };

                products.Add(newProduct);
                Console.WriteLine("New product added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid product type.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for product type.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input for product price.");
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
     Console.WriteLine("Enter the name of the product to update:");
    string productName = Console.ReadLine();

    Product productToUpdate = products.Find(product => product.Name == productName);
    if (productToUpdate != null)
    {
        Console.WriteLine("Enter the new price for the product:");
        decimal newPrice;
        if (decimal.TryParse(Console.ReadLine(), out newPrice))
        {
            productToUpdate.Price = newPrice;
            Console.WriteLine($"Product '{productName}' updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid input for product price.");
        }
    }
    else
    {
        Console.WriteLine($"Product '{productName}' not found.");
    }
}

// don't move or change this!
public partial class Program { }
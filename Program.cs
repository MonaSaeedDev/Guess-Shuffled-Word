using InventoryManagement;

class Program
{
    static void Main(string[] args)
    {
        Item laptop = new Item("Laptop", 45, 200);
        //Item laptop = new Item("Phone", -9, -19);
        //Item laptop = new Item("Phone", -9, 19);
        //Item laptop = new Item("+", 9, 19);
        laptop.DisplayItemDetails();

        Item stopwatch = new Item("Stopwatch", 10, 200);
        //Item stopwatch = new Item(null, -9, -19);
        stopwatch.DisplayItemDetails();

        Item phone = new Item("Phone", 60, 120);
        //Item phone = new Item("", -9, 19);
        //Item phone = new Item(" ", +9, 19);
        //Item phone = new Item("7476", 10, 500);
        phone.DisplayItemDetails();

        //Item cocaCola = new Item("coca-cola", 9, 19);
        //cocaCola.DisplayItemDetails();
        //Item InvalidItem = new Item("-", 9, 19);
        //InvalidItem.DisplayItemDetails();
    }
}








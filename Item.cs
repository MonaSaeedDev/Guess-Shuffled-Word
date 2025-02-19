
namespace InventoryManagement
{
     class Item
{
        private static int _itemId = 0;
        private string? _name;
        private int _quantity;
        private decimal _pricePerUnit;
        private string? _availabilityStatus;
        private string? _paymentType;
        private char _currency;
        public Item(string? name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            PricePerUnit = price;
            GenerateItemId();
        }
        public static int ItemId {get => _itemId;}
        public int Quantity { 
            get => _quantity;
            set => _quantity = value >= 0 ? value : default;
        }
        public string? Name {
            get => _name;
            set
            {
                var chars = new[] {'@', '#', '$', '%', '^', '=', '!', '&', '*', '(', ')', '-',
                    '_', '+', '`','~', '}', '{', '[', '\\', '|', '.', '/', ';', ':', '?', '<', '>', '\''};
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value)
                    && !int.TryParse(value, out _) && !value.All(c => chars.Contains(c)))
                {
                    _name = value;
                    return;
                }
                _name = "Invalid product";
            }
        }
        public decimal PricePerUnit {
            get => _pricePerUnit; 
            set => _pricePerUnit = value >= 0 ? value : default;
        }
        private void ProductValidation()
        {
            if (Name == "Invalid product")
            {
                _quantity = int.MinValue;
                _pricePerUnit = decimal.MinValue;
                _availabilityStatus = string.Empty;
                _paymentType = string.Empty;
                _currency = char.MinValue;
                return;
            }
            _currency = '$';
        }
        private void AvailabilityStatus() => _availabilityStatus = Quantity == default ? "(Unavailable)" : "(Available)";
        private void PaymentType() => _paymentType = _pricePerUnit == default ? "(Free)" : "(Paid)";
        private static void GenerateItemId() => _itemId++;
        public void DisplayItemDetails()
        {
            AvailabilityStatus();
            PaymentType();
            ProductValidation();
            Console.WriteLine($"\n{"", 3}{"Item ID",-13} {"Name",-16} {"Quantity",-17} {"Price Per Unit",-15}");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"",3}{ItemId,-13} {Name,-16} {Quantity,0} {_availabilityStatus} {_currency,5}{PricePerUnit:F2} {_paymentType}\n\n");

        }
    }
}

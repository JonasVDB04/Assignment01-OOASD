namespace Domain;
using System.Drawing;

public class Flower(string name, Color color, decimal price)
{
    public string Name { get;} = name;
    public Color Color { get;} = color;
    public decimal Price { get;} = price;

    public override string ToString()
    {
        return $"{Name} ({Color.Name})";
    }
    
}

public class Bouquet(string name)
{
    public string Name { get; } = name;
    private Dictionary<Flower, int> Flowers { get; } = new Dictionary<Flower, int>();
    
    public void AddFlower(Flower flower, int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        if (Flowers.ContainsKey(flower))
        {
            Flowers[flower] += amount;
        }
        else
        {
            Flowers.Add(flower, amount);
        }
    }

    public decimal ComputePriceBouquet()
    {
        decimal amount = 10;
        foreach (KeyValuePair<Flower, int> flower in Flowers)
        {
            amount += flower.Key.Price * flower.Value;
        }

        return amount;
    }

    public override string ToString()
    {
        string result = $"{Name}\n====\n";
        IEnumerable<IGrouping<string, KeyValuePair<Flower, int>>> colorGroups = Flowers.GroupBy(f => f.Key.Color.Name);
        foreach (IGrouping<string, KeyValuePair<Flower, int>> colorGroup in colorGroups)
        {
            result += $"{colorGroup.Key}\n";
            foreach (KeyValuePair<Flower, int> flower in colorGroup)
            {
                result += $"  {flower.Value} x {flower.Key}\n";
            }
        }
        result += $"----\nPrice: {ComputePriceBouquet():F2} euro";
        return result;
    }
}

public class Customer(string name)
{
    public string Name { get; } = name;
    private Dictionary<Bouquet, DateTime> _bouquets = new Dictionary<Bouquet, DateTime>();

    public void AddBouquet(Bouquet bouquet, DateTime purchaseDate)
    {
        if (_bouquets.ContainsKey(bouquet))
        {
            _bouquets[bouquet] = purchaseDate;
        }
        else
        {
            _bouquets.Add(bouquet, purchaseDate);
        }
    }

    public override string ToString()
    {
        string result = $"{Name}\n";
        IEnumerable<KeyValuePair<Bouquet, DateTime>> orderedBouquets = _bouquets.OrderBy(b => b.Value);
        foreach (KeyValuePair<Bouquet, DateTime> bouquet in orderedBouquets)
        {
            result += $"{bouquet.Value:yyyy-MM-dd} {bouquet.Key.Name}\n";
        }
        return result.TrimEnd();
    }
}


namespace ConsoleGame;

public class TestField {
    public void TestGetMultiplier() {
        Pokedex pokedex = new Pokedex();
        CreatePokemon Venusaur = pokedex.GetPokemon("Venusaur");
        
        Console.Write("Enter type: "); string text = Console.ReadLine();
        double multiplier = 0;
        
        if (Venusaur.weakness.SuperEffective?.Contains(text) == true) {
            multiplier = 2.0;
        }else if (Venusaur.weakness.Effective?.Contains(text) == true) {
            multiplier = 1.5;
        }else if (Venusaur.weakness.Resistant?.Contains(text) == true) {
            multiplier = 0.6;
        }else if (Venusaur.weakness.SuperResistant?.Contains(text) == true) {
            multiplier = 0.3;
        }else {
            multiplier = 1.0;
        }
        
        Console.WriteLine($"Multiplier: {multiplier}");
    }
}

namespace ConsoleGame;

public class Pokedex {
    
    public Dictionary<string, CreatePokemon> PokemonDatabase { get; set; }
    
    public CreatePokemon? GetPokemon(string name) {
        if (PokemonDatabase.TryGetValue(name, out CreatePokemon? pokemon)) {
            return pokemon;
        }
        
        return null; 
    }
    
    public List<string> GetPokemonNamesByType(string searchType) {
        List<string> matchingNames = new List<string>();

        foreach (var pokemon in PokemonDatabase.Values) {
            if (pokemon.pokemonType.PrimaryType.Equals(searchType, StringComparison.OrdinalIgnoreCase) ||
                pokemon.pokemonType.SecondaryType?.Equals(searchType, StringComparison.OrdinalIgnoreCase) == true) {
            
                matchingNames.Add(pokemon.pokemonName.name);
            }
        }

        return matchingNames;
    }

    public Pokedex() {
        PokemonDatabase = new Dictionary<string, CreatePokemon>(StringComparer.OrdinalIgnoreCase) {
            { 
                "Venusaur", 
                new CreatePokemon(
                    new PokemonName("Venusaur"),
                    new PokemonType("Grass", "Poison"),
                    new Weakness(
                        effective:["Fire", "Flying", "Ice", "Psychic"],
                        resistant:["Electric", "Fighting", "Fairy", "Water"]),
                    new Stats(152, 153, 270),
                    new Moveset(new Move("Energy Ball", "Grass", 90),
                        new Move("Sludge Bomb", "Poison", 90),
                        new Move("Earth Power", "Ground", 90),
                        new Move("Giga Drain", "Grass", 75)))
            },
            { 
                "Charizard",
                new CreatePokemon(
                    new PokemonName("Charizard"),
                    new PokemonType("Fire", "Flying"),
                    new Weakness(
                        superEffective:["Rock"],
                        effective:["Electric", "Water"],
                        resistant:["Fire", "Fighting", "Steel", "Fairy"],
                        superResistant:["Bug", "Grass", "Ground"]),
                    new Stats(155, 144, 266),
                    new Moveset(new Move("Flamethrower", "Fire", 90),
                        new Move("Air Slash", "Flying", 75),
                        new Move("Dragon Claw", "Dragon", 80),
                        new Move("Earthquake", "Ground", 100)))
            },
            {
               "Blastoise",
               new CreatePokemon(
                   new PokemonName("Blastoise"),
                   new PokemonType("Water"),
                   new Weakness(
                       effective:["Grass", "Electric"], 
                       resistant:["Fire", "Water", "Ice", "Steel"]),
                   new Stats(153, 184, 268),
                   new Moveset(new Move("Surf", "Water", 90),
                       new Move("Ice Beam", "Ice", 90),
                       new Move("Flash Cannon", "Steel", 80),
                       new Move("Dark Pulse", "Dark", 80)))
            },
            {
                "Pidgeot",
                new CreatePokemon(
                    new PokemonName("Pidgeot"),
                    new PokemonType("Normal", "Flying"),
                    new Weakness(
                        effective:["Rock", "Electric", "Ice"],
                        resistant:["Bug", "Grass"],
                        superResistant:["Ground", "Ghost"]),
                    new Stats(148, 139, 276),
                    new Moveset(new Move("Hurricane", "Flying", 110),
                        new Move("Brave Bird", "Flying", 120),
                        new Move("U-turn", "Bug", 70),
                        new Move("Heat Wave", "Fire", 95)))
            },
            {
                "Pikachu", 
                new CreatePokemon(
                    new PokemonName("Pikachu"),
                    new PokemonType("Electric"),
                    new Weakness(
                        effective:["Ground"],
                        resistant:["Flying", "Steel", "Electric"]),
                    new Stats(103, 76, 180),
                    new Moveset(new Move("Thunderbolt", "Electric", 90),
                        new Move("Iron Tail", "Steel", 100),
                        new Move("Quick Attack", "Normal", 40),
                        new Move("Volt Tackle", "Electric", 120)))
            }
        };
    }
}
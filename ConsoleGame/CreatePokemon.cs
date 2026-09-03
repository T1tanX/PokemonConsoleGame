namespace ConsoleGame;

public class Weakness {
    public string[]? SuperEffective { get; set; }
    public string[]? Effective { get; set; }
    public string[]? Resistant { get; set; }
    public string[]? SuperResistant { get; set; }
    
    public Weakness(string[]? superEffective = null, string[]? effective = null, 
        string[]? resistant = null, string[]? superResistant = null) {
        
        SuperEffective = superEffective;
        Effective = effective;
        Resistant = resistant;
        SuperResistant = superResistant;
    }
}
public class Move {
    public string name { get; set; }
    public string type { get; set; }
    public int power { get; set; }

    public Move(string name, string type, int power) {
        this.name = name;
        this.type = type;
        this.power = power;
    }
}

public class Moveset {
    public List<Move> Moves { get; set; }

    public Moveset(params Move[] moves) {
        Moves = new List<Move>(moves);
    }
}

public class Stats {
    public int attack { get; set; }
    public int defense { get; set; }
    public int hp { get; set; }

    public Stats(int attack, int defense, int hp) {
        this.attack = attack;
        this.defense = defense;
        this.hp = hp;
    }
}

public class PokemonType {
    public string PrimaryType { get; set; }
    public string? SecondaryType { get; set; }
    
    public PokemonType(string type1, string? type2 = null) {
        PrimaryType = type1;
        SecondaryType = type2;
    }
}

public class PokemonName {
    public string name { get; set; }

    public PokemonName(string name) {
        this.name = name;
    }
}

public class CreatePokemon {
    public PokemonName pokemonName { get; set; }
    public PokemonType pokemonType { get; set; }
    public Weakness weakness { get; set; }
    public Stats stats { get; set; }
    public Moveset moveset { get; set; }
    

    public CreatePokemon(PokemonName a, PokemonType b, Weakness c, Stats d, Moveset e) {
        pokemonName = a;
        pokemonType = b;
        weakness = c;
        stats = d;
        moveset = e;
    }
}
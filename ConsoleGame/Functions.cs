namespace ConsoleGame;

public class Functions {
    
    public CreatePokemon ChoosePokemon() {
        Pokedex pokedex = new Pokedex();
        string[] TempNameStorage2;
        
        string pokemonName;
        
        while (true) {
            List<string> TempNameStorage = new List<string>();
            
            Console.WriteLine("Choosing Pokemon:\n" +
                              "1 >Filter by type [enter '1'].\n" +
                              "2 >See all pokemon [enter '2'].");
            String num = Console.ReadLine();
            
                //Option 1 ________________________________________________________________
            if (num == "1") {
                Console.Write("\nEnter pokemon type: ");
                string inputType = Console.ReadLine();
                List<string> results = pokedex.GetPokemonNamesByType(inputType);
                
                Console.WriteLine("\n_____________________________________________________________________" +
                                  "_____________________________________________________________________>");
                if (results.Count > 0) {
                    foreach (string name in results) {
                        CreatePokemon p = pokedex.GetPokemon(name);
                        
                        Console.WriteLine();
                        Console.WriteLine($"\n> {p.pokemonName.name} ({p.pokemonType.PrimaryType} {p.pokemonType.SecondaryType}) - [HP: {p.stats.hp}] - [ATK: {p.stats.attack}] - [DEF: {p.stats.defense}]");
                        Console.Write("  Moves: "); 
                        for (int m = 0; m < p.moveset.Moves.Count; m++) {
                            Console.Write($"[{p.moveset.Moves[m].name} ({p.moveset.Moves[m].type}) - {p.moveset.Moves[m].power}P] ");
                        }
                        TempNameStorage.Add(name);
                    }
                    Console.WriteLine("\n_____________________________________________________________________" +
                                      "_____________________________________________________________________>");
                    Console.Write("Choose your pokemon (enter name): ");
                    pokemonName = Console.ReadLine();
                    TempNameStorage2 = TempNameStorage.ToArray();
                    
                    for (int i = 0; i < TempNameStorage2.Length; i++) {
                        if (TempNameStorage2[i].ToLower() == pokemonName.ToLower()) {
                            CreatePokemon p = pokedex.GetPokemon(TempNameStorage2[i]);
                            Console.WriteLine($"> You choose {pokemonName} - HP: {p.stats.hp}\n");
                            return pokedex.GetPokemon(TempNameStorage2[i]);
                        }
                    }
                    Console.WriteLine("Pokemon not found, please try again.");
                } else {
                    Console.WriteLine($"No Pokémon found with type'{inputType}', please try again.");
                }
                
                
                //Option 2 ________________________________________________________________    
            }else if (num == "2") {
                Console.WriteLine("\n_____________________________________________________________________" +
                                  "_____________________________________________________________________>");
                foreach (string name in pokedex.PokemonDatabase.Keys) {
                    CreatePokemon p = pokedex.GetPokemon(name);
                    
                    Console.WriteLine();
                    Console.WriteLine($"\n> {p.pokemonName.name} ({p.pokemonType.PrimaryType} {p.pokemonType.SecondaryType}) - [HP: {p.stats.hp}] - [ATK: {p.stats.attack}] - [DEF: {p.stats.defense}]");
                    Console.Write("  Moves: "); 
                    for (int m = 0; m < p.moveset.Moves.Count; m++) {
                        Console.Write($"[{p.moveset.Moves[m].name} ({p.moveset.Moves[m].type}) - {p.moveset.Moves[m].power}P] ");
                    }
                    TempNameStorage.Add(name);
                }
                Console.WriteLine("\n_____________________________________________________________________" +
                                  "_____________________________________________________________________>");
                Console.Write("Choose your pokemon (enter name): ");
                pokemonName = Console.ReadLine();
                TempNameStorage2 = TempNameStorage.ToArray();
                
                for (int i = 0; i < TempNameStorage2.Length; i++) {
                    if (TempNameStorage2[i].ToLower() == pokemonName.ToLower()) {
                        CreatePokemon p = pokedex.GetPokemon(TempNameStorage2[i]);
                        Console.WriteLine($"> You choose {pokemonName} - HP: {p.stats.hp}\n");
                        return pokedex.GetPokemon(TempNameStorage2[i]);
                    }
                }
                Console.WriteLine("Pokemon not found, please try again.");
            }
        }
    }
    
//____________________________________________________________________________________________________    
    public int ChooseMoves(CreatePokemon attacker) {
        int index = 0;
        
        Console.WriteLine("Your turn, choose a move: ");
        for (int i = 0; i < attacker.moveset.Moves.Count; i++) {
            Console.WriteLine($"{i+1} > [{attacker.moveset.Moves[i].name} - " +
                              $"{attacker.moveset.Moves[i].type} - " +
                              $"{attacker.moveset.Moves[i].power}P]");
        }
        
        while (true) {
            Console.Write("Enter number > "); string input = Console.ReadLine();

            if (int.TryParse(input, out index) && index >= 1 && index <= attacker.moveset.Moves.Count) {
                return index - 1;
            }
            Console.WriteLine("Invalid input, try again.");
        } 
    }
    
//____________________________________________________________________________________________________    
    //Example: double multiplier = GetMultiplier(Venusaur, Charizard, 3 (from "ChooseMoves")); 
    public double GetMultiplier(CreatePokemon defender, CreatePokemon attacker, int moveIndex) {
        double multiplier = 0;
        
        if (defender.weakness.SuperEffective?.Contains(attacker.moveset.Moves[moveIndex].type) == true) {
            multiplier = 2.0;
        }else if (defender.weakness.Effective?.Contains(attacker.moveset.Moves[moveIndex].type) == true) {
            multiplier = 1.5;
        }else if (defender.weakness.Resistant?.Contains(attacker.moveset.Moves[moveIndex].type) == true) {
            multiplier = 0.6;
        }else if (defender.weakness.SuperResistant?.Contains(attacker.moveset.Moves[moveIndex].type) == true) {
            multiplier = 0.3;
        }else {
            multiplier = 1.0;
        }
        
        return multiplier;
    }
    
//____________________________________________________________________________________________________
    public double GetStabb(CreatePokemon attacker, int moveIndex) {
        string moveType = attacker.moveset.Moves[moveIndex].type;
        
        if (attacker.pokemonType.PrimaryType == moveType || attacker.pokemonType.SecondaryType == moveType) {
            return 1.2;
        }
        return 1.0;
    } 
    
//____________________________________________________________________________________________________
    public int GetDamage(CreatePokemon defender, CreatePokemon attacker, int moveIndex, double multiplier,
        double stabb) {
        
        int movePower = attacker.moveset.Moves[moveIndex].power;
        int attackerAtkStat = attacker.stats.attack;
        int defenderDefStat = defender.stats.defense;

        double damage = movePower * ((double)attackerAtkStat / defenderDefStat) * stabb * multiplier;
        int roundedDamage = (int)Math.Ceiling(damage);

        return roundedDamage;
    }
    
//____________________________________________________________________________________________________
    public string GetConfirmEffectiveness(double multiplier) {
        string confirmEffectiveness = multiplier switch {
            2.0 => "It is super effective!\n",
            1.5 => "It is effective!\n",
            1.0 => "",
            0.6 => "It is not effective.\n",
            0.3 => "It is not very effective.\n"
        };
        
        return confirmEffectiveness;
    }

//____________________________________________________________________________________________________    
    public string getFaintedChecker(int defenderHP, CreatePokemon defender, CreatePokemon attacker, int damage) {
        int HP = defenderHP;

        if (HP <= 0) {
            return $"{defender.pokemonName.name} has 0/{defender.stats.hp}HP," +
                   $"\n{defender.pokemonName.name} fainted!" +
                   $"\n{attacker.pokemonName.name} wins!";
        }

        return "";
    }
}
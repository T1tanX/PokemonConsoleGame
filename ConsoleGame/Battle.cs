namespace ConsoleGame;

public class Battle {
    public void oneVSone() {
        Functions functions = new Functions();
        
        Console.WriteLine("-Player 1");
        CreatePokemon player1 = functions.ChoosePokemon();
        int OriginalHPplayer1 = player1.stats.hp;
        int HPplayer1 = player1.stats.hp; 
        Thread.Sleep(3000);
        
        Console.WriteLine("\n-Player 2");
        CreatePokemon player2 = functions.ChoosePokemon();
        int OriginalHPplayer2 = player2.stats.hp;
        int HPplayer2 = player2.stats.hp;
        Thread.Sleep(3000);

        Console.WriteLine($"{player1.pokemonName.name} - {HPplayer1}/{OriginalHPplayer1}HP");
        while (true) {
            int moveIndex;
            double multiplier;
            double stabb;
            int damage;
            
            Console.Write($"> [Player 1 - {player1.pokemonName.name}] ");
            moveIndex = functions.ChooseMoves(player1);
            multiplier = functions.GetMultiplier(player2, player1, moveIndex);
            stabb = functions.GetStabb(player1, moveIndex);
            damage = functions.GetDamage(player2, player1, moveIndex, multiplier, stabb);
            HPplayer2 -= damage;
            Thread.Sleep(2000);
            Console.WriteLine($"\n{player1.pokemonName.name} used {player1.moveset.Moves[moveIndex].name}!");
            Thread.Sleep(2000);
            Console.WriteLine($"{functions.GetConfirmEffectiveness(multiplier)}");
            Thread.Sleep(2000);
            if (!functions.getFaintedChecker(HPplayer2,player2, player1, damage).Equals("")) {
                Console.WriteLine(functions.getFaintedChecker(HPplayer2,player2, player1, damage));
                break;
            }
            Console.WriteLine($"{player2.pokemonName.name} - {HPplayer2}/{OriginalHPplayer2}HP");
            
            Console.Write($"> [Player 2 - {player2.pokemonName.name}] ");
            moveIndex = functions.ChooseMoves(player2);
            multiplier = functions.GetMultiplier(player1, player2, moveIndex);
            stabb = functions.GetStabb(player2, moveIndex);
            damage = functions.GetDamage(player1, player2, moveIndex, multiplier, stabb);
            HPplayer1 -= damage;
            Thread.Sleep(2000);
            Console.WriteLine($"\n{player2.pokemonName.name} used {player2.moveset.Moves[moveIndex].name}!");
            Thread.Sleep(2000);
            Console.WriteLine($"{functions.GetConfirmEffectiveness(multiplier)}");
            Thread.Sleep(2000);
            if (!functions.getFaintedChecker(HPplayer1,player1, player2, damage).Equals("")) {
                Console.WriteLine(functions.getFaintedChecker(HPplayer1,player1, player2, damage));
                break;
            }
            Console.WriteLine($"{player1.pokemonName.name} - {HPplayer1}/{OriginalHPplayer1}HP");
        }
        
    } 
        
}
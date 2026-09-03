namespace ConsoleGame;

class Program {
    static void Main(string[] args) {
        Pokedex pokedex = new Pokedex();
        TestField testField = new TestField();
        Functions functions = new Functions();
        Battle battle = new Battle();

        string confirm;
        while (true) {
            battle.oneVSone();
            
            Console.Write("Restart y/n: ");
            confirm = Console.ReadLine();
            
            if (confirm.Equals("y")) {
            }
            else {
                break;
            }
        }
    }
}


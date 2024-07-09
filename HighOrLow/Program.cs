class Program {
    static void Main(string[] args){

        int targetNumber;
        int guessNumber;
        int roundCount = 0;
        string guessString;
        
        Random rnd = new Random();
        targetNumber = rnd.Next(1, 100);

        do {
            roundCount++;
            Console.Write("Please enter a guess between 1 and 100: ");
            guessString = Console.ReadLine();

            guessNumber = int.Parse(guessString);
        
            if(guessNumber == targetNumber){
                Console.WriteLine("Nice job!");
            }else if(guessNumber > targetNumber){
                Console.WriteLine("Too high!");
            }else {
                Console.WriteLine("Too low!");
            }

        } while (guessNumber != targetNumber);
        Console.WriteLine($"Finish with {roundCount} attempts!");

    }
}

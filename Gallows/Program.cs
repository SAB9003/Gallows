// See https://aka.ms/new-console-template for more information
string[] words = 
    {"apple", "banana", "orange",
    "library", "function","volleyball"};
Random random = new Random();
int index_words_rand = random.Next(words.Length);
string riddled_word = words[index_words_rand];
char[] letters = new char[riddled_word.Length];
for (int i = 0; i < letters.Length; i++)
{
    letters[i] = '_';
}
int remaining_letters = riddled_word.Length;
int guesses = 10;
Console.WriteLine("Congratulations! Try to guess the encrypted word!");
Console.WriteLine($"Number of letters in the word: {remaining_letters}");
Console.WriteLine($"Number of possible incorrect attempts: {guesses}");
//Це зроблено для краси
//foreach (char c in letters)
//{
//    Console.Write($"{c} ");
//}
//Console.WriteLine();
while (new string(letters) != riddled_word && guesses > 0)
{
    Console.Write("Enter your letter: ");
    char guess =  Console.ReadKey().KeyChar;
    Console.WriteLine();
    guess = char.ToLower(guess);
    bool is_guess_correct = false;
    List<int> positions_letter = new List<int>();
    for (int i = 0; i < riddled_word.Length; i++)
    {
        if (riddled_word[i] == guess && letters[i] == '_')
        {
            letters[i] = guess;
            positions_letter.Add(i+1);
            is_guess_correct = true;
        }
    }
    if (is_guess_correct)
    {
        Console.WriteLine($"Such a letter is in the word! Letter position: " +
            $"{string.Join(",", positions_letter)}");
    }
    else {
        guesses--;
        Console.WriteLine($"There is no such letter! Remaining attempts: {guesses}");
    }
    //Це зроблено для краси
    //foreach (char c in letters)
    //{
    //    Console.Write($"{c} ");
    //}
    //Console.WriteLine();
}
if (new string(letters) == riddled_word)
{
    Console.WriteLine($"Congratulations, you guessed the word: {riddled_word}");
}
else
{
    guesses--;
    Console.WriteLine($"Unfortunately, you did not guess the word: {riddled_word}");
}
Console.WriteLine("Thanks for playing.");
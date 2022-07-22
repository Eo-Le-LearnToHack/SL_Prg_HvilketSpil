using System.Text;

while (true)
{
    Console.Clear();
    string[] spil = new string[5]; //Brugernes spilleønske gemmes heri.
    int ranNum = RandomNumber(0, 5, 10); //Generer tilfældigt tal mellem 0-4. Tilfældighed loopes 10x før resultatet bliver returneret.

    for (int i = 0; i < spil.Length; i++)
    {
        string instruktion = $"Person nr. {i + 1}, indtast det spil du ønsker at spille\t:";
        string fejlBesked = $"Person nr. {i + 1}, indtast det spil du ønsker at spille\t:";
        spil[i] = DitSpil(instruktion, fejlBesked); //Mindst 2 karakterer og må ikke være tom.
    }

    Console.Write($"\nComputeren vælger et tilfældigt spil.\nVent venligst");
    MovingTekst($"........", 500); //Simuler at computeren tænker med 500 ms' ventetid.
    Console.WriteLine($"\n\nI aften skal I spille:\t\t{spil[ranNum].ToUpper()}");
    Console.ReadLine();
}



///////////////////////////////////////////////////
//HERUNDER FINDES METODERNE
string DitSpil(string instruction, string erroMessage)
{
    string? userInput = null;
    char[] charsToTrim = { '*', ' ', '\'', '*', '?', '@', '#', '"','%' }; //Disse karakterer bliver trimmet væk ved brug af Trim() funktionen.
    do
    {
        Console.Write(instruction);
        userInput = Console.ReadLine();
        string temp = userInput.Trim(charsToTrim);
        if ( String.IsNullOrEmpty(temp) || String.IsNullOrWhiteSpace(temp) || userInput.Length <= 2)
        {
            Console.WriteLine(erroMessage);
            userInput = null;
        }
    } while (userInput==null);
    return userInput;
}


int RandomNumber(int min, int max, int loop)
{
    Random random = new Random();
    int result = 0;
    for (int i = 0; i < loop; i++)
    {result = random.Next(min, max); }
    return result;
}


void MovingTekst(string text, int sleepingTime)
{
    StringBuilder sb = new();
    for (int i = 0; i < text.Length; i++)
    {
        Thread.Sleep(sleepingTime);
        Console.Write(text.Substring(i, 1));
    }
}

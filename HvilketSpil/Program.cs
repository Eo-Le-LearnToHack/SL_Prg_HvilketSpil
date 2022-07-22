using System.Text;

    Console.Clear();
    string[] spil = new string[5]; //Brugernes spilleønske gemmes heri.
    int[] spilRandom = new int[5]; //Computerens forslag af spillerækkefølgen gemmes heri. NB! Default værdi er 0 i int array.

    for (int i = 0; i < spil.Length; i++)
    {
        string instruktion = $"Person nr. {i + 1}, indtast det spil du ønsker at spille\t:";
        string fejlBesked = $"UGYLDIG INDTASTNING. PRØV IGEN\t\t\t\t:";
        spil[i] = DitSpil(instruktion, fejlBesked); //Mindst 2 karakterer og må ikke være tom.
    }

while (true)
{
    Console.Clear();
    for (int i = 0; i < spilRandom.Length; i++)
    { spilRandom[i] = 0; } //NULSTILLE ARRAYET hvis der skal foretages ny beregning

    for (int i = 0; i < spilRandom.Length; i++)
    {
        int minInt = 1;
        int maxInt = 6;
        int loop = 10;
        int ranNum = RandomNumber(minInt, maxInt, loop); //Generer tilfældigt tal mellem 1-5. Tilfældighed loopes 10x før resultatet bliver returneret.
        while (spilRandom.Contains(ranNum)) //Hvis tallet allerede findes i array spilRandom, genereres der et nyt tal.
        { ranNum = RandomNumber(minInt, maxInt, loop); }
        spilRandom[i] = ranNum; //Ellers tilføjes tallet til arrayet spilRandom
    }

    for (int i = 0; i < spilRandom.Length; i++)
    { spilRandom[i] = spilRandom[i] - 1; } //Reducere værdien i array med -1, for at konvertere til indeks nr.

    Console.Write($"Computeren foreslår, at du prøver spillene i følgende rækkefølge.\nVent mens computeren tænker.");
    MovingTekst($"........", 500); //Simuler at computeren tænker med 500 ms' ventetid.

    Console.WriteLine($"\n\nI aften skal I spille:");
    for (int i = 0; i < spil.Length; i++)
    {
        MovingTekst($"{i + 1}:\t{spil[spilRandom[i]].ToUpper()}\n", 100);
        /*Console.WriteLine($"{i+1}:\t{spil[spilRandom[i]].ToUpper()}"); */}

    Console.WriteLine();
    Console.WriteLine("Tryk på en vilkårlig tast for at foretage en ny beregning.");
    Console.ReadLine();
}


///////////////////////////////////////////////////
//HERUNDER FINDES METODERNE
string DitSpil(string instruction, string erroMessage)
{
    string? userInput = null;
    char[] charsToTrim = { '*', ' ', '\'', '*', '?', '@', '#', '"','%' }; //Disse karakterer bliver trimmet væk ved brug af Trim() funktionen.
    Console.Write(instruction);
    do
    {
        userInput = Console.ReadLine();
        string temp = userInput.Trim(charsToTrim);
        if ( String.IsNullOrEmpty(temp) || String.IsNullOrWhiteSpace(temp) || userInput.Length <= 2)
        {
            Console.Write(erroMessage);
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

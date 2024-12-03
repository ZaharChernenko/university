void PrintElements<T>(IEnumerable<T> items)
{
    foreach (T item in items)
    {
        Console.Write(item);
        Console.Write(' ');
    }
    Console.Write('\n');
}

void arr20() {
    int[] arr = new int[20];
    Random rand = new Random();

   for (int i = 0; i != arr.Length; ++i)  {
        arr[i] = rand.Next(10, 100);
   }
    Console.WriteLine("Начальный состав массива:");
    PrintElements(arr);
    Console.WriteLine($"Среднее арифметическое: {arr.Average()}");
    for (int i = 0; i != arr.Length; ++i) {
        arr[i] = arr[i] < arr.Average() ? 0 : 1;
    }
    Console.WriteLine("Конечный состав массива:");
    PrintElements(arr);
}


void arrMed() {
    int[] arr = new int[4];

    if (arr.Length == 0) {
        Console.WriteLine("Массив должен быть непуст:");
    }

    Random rand = new Random();

   for (int i = 0; i != arr.Length; ++i)  {
        arr[i] = rand.Next(1, 10);
   }
    Console.WriteLine("Начальный состав массива:");
    PrintElements(arr);
    Array.Sort(arr);

    Console.WriteLine("Отсортированный состав массива:");
    PrintElements(arr);
    int med = arr.Length % 2 == 1 ? arr[arr.Length / 2] : (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2;

    Console.WriteLine($"Медиана: {med}");
    for (int i = 0; i != arr.Length; ++i) {
        arr[i] = arr[i] < med ? 0 : 1;
    }
    Console.WriteLine("Конечный состав массива:");
    PrintElements(arr);
}

// arr20();


void action(List<int> player_arr, List<int> pc_arr) {
    int player_var = -1;

    while (!(0 <= player_var && player_var <= 10)) {
        Console.WriteLine("Введите число от 0 до 10 включительно");
        try {
            player_var = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException) {
            Console.WriteLine("Ввод должен быть числом");
        }
    }

    Random rand = new Random();
    int pc_var = rand.Next(0, 11);

    Console.WriteLine($"Число компьютера: {pc_var}");

    if (player_var == pc_var)
        return;
    if (player_var % 2 == pc_var % 2) {
        if (player_var > pc_var)
            player_arr.Add(player_var / 2);
        else
            pc_arr.Add(pc_var / 2);
        return;
    }
    if (Math.Abs(player_arr.Count > 0 ? player_arr.Average() : 0 - player_var) <  Math.Abs(pc_arr.Count > 0 ? pc_arr.Average() : 0 - pc_var)) {
        player_arr.Add((int) Math.Ceiling((player_var + pc_var) / 2.0));
        return;
    }
    pc_arr.Add((int) Math.Ceiling((player_var + pc_var) / 2.0));
}


void Game() {
    List<int> player_arr = new List<int>(), pc_arr = new List<int>();
while (true) {
    if (player_arr.Sum() >= 30) {
        Console.WriteLine("Победил игрок");
        break;
    }
    else if (pc_arr.Sum() >= 30) {
        Console.WriteLine("Победил компьютер");
        break;
    }
    action(player_arr, pc_arr);
    PrintElements(player_arr);
    PrintElements(pc_arr);
}
PrintElements(player_arr);
PrintElements(pc_arr);
}

arrMed();

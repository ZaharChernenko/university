using System;

namespace lab4
{

    class Game
    {

        public Game()
        {
            bool result = false;
            while (!result)
            {
                Console.WriteLine("Введите нижнюю границу:");
                result = Int32.TryParse(Console.ReadLine(), out lower_bound);
            }

            result = false;
            while (!result)
            {
                Console.WriteLine("Введите верхнюю границу:");
                result = Int32.TryParse(Console.ReadLine(), out upper_bound) && lower_bound < upper_bound;
            }

            result = false;
            while (!result)
            {
                Console.WriteLine("Введите количество попыток:");
                result = UInt32.TryParse(Console.ReadLine(), out step);
            }

            gen_number = new Random().Next(lower_bound, upper_bound + 1);
        }

        public bool Step()
        {
            if (cur_step == step)
            {
                Console.WriteLine($"Вы проиграли. Загаданное число: {gen_number}");
                return true;
            }

            bool result = false;
            Int32 number = 0;
            while (!result)
            {
                Console.WriteLine("Отгадайте число:");
                result = Int32.TryParse(Console.ReadLine(), out number);
            }
            ++cur_step;

            if (number == gen_number)
            {
                Console.WriteLine($"Вы отгадали! Всего попыток: {cur_step}");
                return true;
            }

            Console.WriteLine(gen_number > number ? "Загаданное число больше" : "Загаданное число меньше");

            return false;
        }

        protected Int32 lower_bound, upper_bound, gen_number;
        protected UInt32 step, cur_step = 0;

    }

    class Program
    {
        static int Main()
        {
            string action = "1";
            while (true)
            {
                Console.WriteLine("Введите 0, чтобы начать новую игру или 1 чтобы выйти из приложения:");
                action = Console.ReadLine();

                switch (action)
                {
                    case "0":
                        Game game = new Game();
                        while (!game.Step())
                        {
                            continue;
                        }
                        break;
                    case "1":
                        goto finish;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }

        finish:
            return 0;
        }
    }
}
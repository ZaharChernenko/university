using System;

namespace lab4
{
    class Game
    {
        public Game()
        {
            bool result = false;
            Int32 lower_bound = 0, upper_bound = 0;

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

        protected Int32 Step()
        {
            bool result = false;
            Int32 number = 0;
            while (!result)
            {
                Console.WriteLine("Отгадайте число:");
                result = Int32.TryParse(Console.ReadLine(), out number);
            }
            ++cur_step;
            return number;
        }

        public void Run()
        {
            bool is_found = false;
            Int32 number;

            while (cur_step < step)
            {
                number = Step();
                if (number == gen_number)
                {
                    is_found = true;
                    break;
                }
                if (cur_step != step)
                    Console.WriteLine(gen_number > number ? "Загаданное число больше" : "Загаданное число меньше");
            }
            Console.WriteLine(is_found ? $"Вы отгадали! Всего попыток: {cur_step}" : $"Вы проиграли. Загаданное число: {gen_number}");
        }

        protected Int32 gen_number;
        protected UInt32 step, cur_step = 0;
    }

    class Program
    {
        static int Main()
        {
            string action;
            bool is_finished = false;
            while (!is_finished)
            {
                Console.WriteLine("Введите 0, чтобы начать новую игру, 1 чтобы выйти из приложения, 2 чтобы очистить консоль:");
                action = Console.ReadLine();

                switch (action)
                {
                    case "0":
                        Game game = new Game();
                        game.Run();
                        break;
                    case "1":
                        is_finished = true;
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }

            return 0;
        }
    }
}
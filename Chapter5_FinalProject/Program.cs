namespace Chapter5_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var user = GetDataFromUser();
            DisplayData(user);



            // static (string name, string lastName, int age, bool pet, int petCount, string[] petNames, int favcolorsCount, string[] favcolor) GetDataFromUser()
            static (string name, string lastName, int age, string[] petNames, string[] favcolor) GetDataFromUser()
            {
                int petCount;
                int favColorsCount;
                string hasPet="ZX";
                (string name, string lastName, int age,string[] petNames, string[] favcolor) user;
                Console.WriteLine("Введите Ваше имя");
                user.name = Console.ReadLine();

                Console.WriteLine("Введите Вашу фамилию");
                user.lastName = Console.ReadLine();

                Console.WriteLine("Введите ваш возраст:");
                var forCheck = (Console.ReadLine());
                user.age = CheckData(forCheck);

                while (hasPet != "Да" ^ hasPet == "Нет")  
                {
                    Console.WriteLine("Есть ли у вас домашнее животное? Да или Нет");
                    hasPet = Console.ReadLine();
                }
                if (hasPet == "Да")
                {
                    Console.WriteLine("Введите количество животных");
                    forCheck = (Console.ReadLine());
                    petCount = CheckData(forCheck);
                }
                else
                { petCount = 0; }
                user.petNames = CreatePetArr(petCount);

                Console.WriteLine("введите количество любимых цветов");
                favColorsCount = CheckData(Console.ReadLine());

                user.favcolor = GetFavColors(favColorsCount);

                
                return user;

            }
            static int CheckData(string data)
            {
                bool res = int.TryParse(data, out var parsed);
                if (res)
                    {
                    if (parsed > 0)
                        return parsed;
                    else
                    {
                        while (parsed <= 0)
                        {
                            Console.WriteLine("Вы ввели некорректные данные, повторите ввод");
                            parsed = CheckData(Console.ReadLine());
                        }
                    }
                            
                    }
                if (res==false)
                {
                    Console.WriteLine("Вы ввели некорректные данные, повторите ввод");
                    parsed = CheckData(Console.ReadLine());
                }

                return parsed;  
            }

            static string[] CreatePetArr(int num)
            {
                string[] arr = new string[num];
                for (int i=0; i<arr.Length;i++)
                {
                    Console.WriteLine("Введите кличку животного номер {0}", i + 1);
                    arr[i] = Console.ReadLine();
                }
                return arr;
            }
            static string[] GetFavColors(int num)
            {
                string[] arr = new string[num];
                for (int i=0;i<arr.Length;i++)
                {
                    Console.WriteLine("Введите любимый цвет номер {0}", i + 1);
                    arr[i] = Console.ReadLine();
                }
                return arr;
            }
            static void DisplayData((string name, string lastName, int age, string[] petNames, string[] favcolor) user)
            {
                Console.WriteLine("Ваше имя:");
                Console.WriteLine(user.name);
                //Console.WriteLine();
                Console.WriteLine("Ваша фамилия:");
                Console.WriteLine(user.lastName);
                Console.WriteLine("Ваш возраст:");
                Console.WriteLine(user.age);
                //Console.WriteLine();

                if (user.petNames.Length > 0)
                {
                    for(int i = 0;i<user.petNames.Length;i++)
                    {
                        Console.WriteLine("Вашего питомца номре {0} зовут: {1}", i + 1, user.petNames[i]);
                    }
                    
                }
                else Console.WriteLine("У вас нет домашних животных");


                if (user.favcolor.Length > 0)
                {
                    Console.WriteLine("Ваши любимые цвета");
                    for (int i = 0; i < user.favcolor.Length; i++)
                    {
                        Console.Write(user.favcolor[i] + "\t");
                    }

                }
                else Console.WriteLine("У вас нет любимых цыетов");

            }
        }
    }
}
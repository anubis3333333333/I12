string[] names = {"ноутбук","скиж плата","книга дугина","веселая наука книга","злая мудрость книга","король в желтом книга"};
int[] prices = {1000,2000,3000,50000,200000,100};

int choice;
do{
    Console.WriteLine();
    Console.WriteLine("Каталог товаров");
    Console.WriteLine("1 - показать список");
    Console.WriteLine("2 - найти товар");
    Console.WriteLine("3 - статистика цен");
    Console.WriteLine("4 - скидка");
    Console.WriteLine("5 – товары дешевле заданной цены");
    Console.WriteLine("6 – поиск по первой букве");
    Console.WriteLine("7 – отсортировать по цене");
    Console.WriteLine("0 - выход");
    Console.WriteLine("ваш выбор :");

    if (!int.TryParse(Console.ReadLine(), out choice)){
        choice = -1;
    }    

    switch (choice){
        case 1: PrintCatalog(names, prices);  break;
        case 2:
            Console.Write("Введите текст для поиска: ");
            string query = Console.ReadLine();
            Find(names, query);
            break;
        case 3:
            Console.WriteLine($"Минимальная цена: {MinPrice(prices)}");
            Console.WriteLine($"Максимальная цена: {MaxPrice(prices)}");
            Console.WriteLine($"Средняя цена: {AveragePrice(prices):F0}");

            int maxIndex = IndexOfMax(prices);
            Console.WriteLine($"Самый дорогой товар: {names[maxIndex]}");
            break;
        case 4:
            int percent;
            do{
                Console.Write("Введите процент скидки (от 1 до 50): ");
            } 
            while (!int.TryParse(Console.ReadLine(), out percent) || percent < 1 || percent > 50);
            for (int i = 0; i < prices.Length; i++){
                if (prices[i] > 10000){
                    prices[i] = prices[i] * (100 - percent) / 100;
                }
            }
            Console.WriteLine("Цены со скидкой:");
            PrintCatalog(names, prices);
            break;
        case 5:
            int maxPrice;
            Console.Write("Введите максимальную цену: ");
            while (!int.TryParse(Console.ReadLine(), out maxPrice) || maxPrice < 0){
                Console.Write("Некорректный ввод. Введите цену еще раз: ");
            }
            ShowCheaperThan(names, prices, maxPrice);
            break;
        case 6:
            Console.Write("Введите первую букву для поиска: ");
            string letterInput = Console.ReadLine();
            if (letterInput.Length > 0){
                FindByFirstLetter(names, letterInput[0]);
            }
            else{
                Console.WriteLine("Вы ничего не ввели.");
            }
            break;
        case 7:
            SortByPrice(names, prices);
            Console.WriteLine("Каталог успешно отсортирован по возрастанию цены!");
            PrintCatalog(names, prices); 
            break;
        case 0: Console.WriteLine(""); break;
        default: Console.WriteLine("Нет такого"); break;

    }
}
while (choice != 0);

static void PrintCatalog(string[] names, int[] prices){
    for (int i = 0; i < names.Length; i++){
        Console.WriteLine($"{i + 1}. {names[i]} — {prices[i]}");
    }
}



static void Find(string[] names, string query){
    bool found = false;
    string lowerQuery = query.ToLower();

    for (int i = 0; i < names.Length; i++){
        if (names[i].ToLower().Contains(lowerQuery)){
            Console.WriteLine($"{names[i]}");
            found = true;
        }
    }

    if (!found){
        Console.WriteLine("Ничего не найдено");
    }
}


static int MinPrice(int[] prices){
    int min = prices[0];
    foreach (int price in prices){
        if (price < min) min = price;
    }
    return min;
}

static int MaxPrice(int[] prices){
    int max = prices[0];
    foreach (int price in prices){
        if (price > max) max = price;
    }
    return max;
}

static double AveragePrice(int[] prices){
    double sum = 0;
    foreach (int price in prices){
        sum += price;
    }
    return sum / prices.Length;
}

static int IndexOfMax(int[] prices){
    int maxIndex = 0;
    for (int i = 1; i < prices.Length; i++){
        if (prices[i] > prices[maxIndex]){
            maxIndex = i;
        }
    }
    return maxIndex;
}

static void ShowCheaperThan(string[] names, int[] prices, int maxPrice){
    int count = 0;
    for (int i = 0; i < names.Length; i++){
        if (prices[i] < maxPrice){
            Console.WriteLine($"{names[i]} — {prices[i]}");
            count++;
        }
    }
    Console.WriteLine($"Всего товаров дешевле {maxPrice}: {count}");
}

static void FindByFirstLetter(string[] names, char letter){
    bool found = false;
    char lowerLetter = char.ToLower(letter);
    foreach (string name in names){
        if (name.Length > 0 && char.ToLower(name[0]) == lowerLetter){
            Console.WriteLine(name);
            found = true;
        }
    }

    if (!found){
        Console.WriteLine("Ничего не найдено");
    }
}

static void SortByPrice(string[] names, int[] prices){
    for (int i = 0; i < prices.Length - 1; i++){
        for (int j = 0; j < prices.Length - 1 - i; j++){
            if (prices[j] > prices[j + 1]){
                int tempPrice = prices[j];
                prices[j] = prices[j + 1];
                prices[j + 1] = tempPrice;
                string tempName = names[j];
                names[j] = names[j + 1];
                names[j + 1] = tempName;
            }
        }
    }
}
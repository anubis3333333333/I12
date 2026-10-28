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


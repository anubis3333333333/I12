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
        case 2: Console.WriteLine(""); break;
        case 3: Console.WriteLine(""); break;
        case 4: Console.WriteLine(""); break;
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
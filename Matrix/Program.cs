Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;
System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
customCulture.NumberFormat.NumberDecimalSeparator = ".";
System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

int N = 0;
int M = 0;
Random rand = new Random();
bool ok;
do
{
    Console.Write("Введіть число N = ");
    ok = int.TryParse(Console.ReadLine(), out N);
    if (!ok) Console.WriteLine("Число введено неправельно , повторить спробу!\n");
} while (!ok);

do
{
    Console.Write("Введіть число N = ");
    ok = int.TryParse(Console.ReadLine(), out M);
    if (!ok) Console.WriteLine("Число введено неправельно , повторить спробу!\n");
} while (!ok);

int[,] arr = new int[N, M];
int plus = 0, max = 0,count = 0;
int res = 0, first1 = 1 , first2 = 0, countRows = 0, countCols = 0 ;
int colSum = 0;
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i,j] = rand.Next(-15, 15);
        if(arr[i,j] > 0) plus++;
        if (arr[i,j] > max) max = arr[i,j];
        if (arr[i, j] == max) count++;
        if (count > 1) res = max;
        if (arr[i, j] == 0) first1 = 0;
        if (arr[i, j] == 0) first2 = 1;
        if (arr[i, j] >= 0)
            colSum += arr[i, j];
        else
        {
            colSum = 0;
            break;
        }
    }
    countRows += first1; first1 = 1;
    countCols += first2; first2 = 0;
}
for (int i = 0; i < arr.GetLength(0); i++) { 
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write($"{arr[i,j]}\t");
    }        
    Console.WriteLine();
}
int rowIndex = 0, countEqual = 0, countMaxEqual = 1;
for (int i = 0; i < arr.GetLength(0); i++)
    for (int j = 0; j < arr.GetLength(1) - 1; j++)
    {
        if (arr[i, j] == arr[i, j + 1])
            countEqual++;
        if (countMaxEqual < countEqual)
        {
            countMaxEqual = countEqual;
            rowIndex = i + 1;
        }
        else
            countEqual = 1;
    }
int rowMult = 0;
for (int i = 0; i < arr.GetLength(0); i++)
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        if (arr[i, j] >= 0)
            rowMult *= arr[i, j];
    }
Console.WriteLine($"\n Kількість додатних елементів: {plus}");
Console.WriteLine($"\n Mаксимальне із чисел, що зустрічається в заданій матриці більше одного разу: {res}");
Console.WriteLine($"\n Kількість рядків, які не містять жодного нульового елемента: {countRows}");
Console.WriteLine($"\n Kількість стовпців, які містять хоча б один нульовий елемент: {countCols}");
Console.WriteLine($"\n Номер рядка, в якому знаходиться найдовша серія однакових елементів: {rowIndex}");
Console.WriteLine($"\n Добуток елементів в тих рядках, які не містять від’ємних елементів: {rowMult}");

int[] upperSum = new int[arr.GetLength(0) + arr.GetLength(1)];
int[] lowwerSum = new int[arr.GetLength(0) + arr.GetLength(1)];
int coordRow, coordCol;
for (int j = 1; j < arr.GetLength(0); j++)
{
    int sum = 0;
    coordRow = 0;
    coordCol = j;
    for (int k = 0; k < arr.GetLength(1) - j; k++)
    {
        sum += arr[coordRow, coordCol];
        coordCol++;
        coordRow++;
    }
    upperSum[j - 1] = sum;
}

for (int i = 1; i < arr.GetLength(0); i++)
{
    int sum = 0;
    coordRow = i;
    coordCol = 0;
    for (int k = 0; k < arr.GetLength(1) - i; k++)
    {
        sum += arr[coordRow, coordCol];
        coordCol++;
        coordRow++;
    }
    lowwerSum[i - 1] = sum;
}

Console.WriteLine($"\n максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці: {Math.Max(upperSum.Max(), lowwerSum.Max())}");
Console.WriteLine($"\n суму елементів в тих стовпцях, які не містять від’ємних елементів: {colSum}");
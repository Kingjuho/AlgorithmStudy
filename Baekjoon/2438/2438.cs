/*******
 2438. 별 찍기 - 1

 * namespace, class 다 빼고 제출해도 정상작동
 ********/

int a = int.Parse(Console.ReadLine());
for (int i = 1; i <= a; i++) Console.WriteLine(new string('*', i));
/*******
 1002. 터렛

 * 기하학 문제
 * 두 점 사이의 거리 d를 구한 후, r을 반지름 취급하여 합, 차와 비교
 * 루트 계산을 피하기 위해 제곱값으로 판단(정확한 거리를 찾는 문제가 아님)
 * d > r1 + r2              = 0, 서로 탐지 거리 밖에 있음
 * d = r1 + r2              = 1, 서로 정확히 탐지 거리 경계에 걸쳐있음
 * r1 - r2 < d < r1 + r2    = 2, 탐지 거리가 겹쳐짐
 * d == r1 - r2             = 1, 작은 원이 안에 들어와서 큰 원 벽에 붙어있음
 * d < r1 - r2              = 0, 작은 원이 안에 들어와서 떠있음
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

int T = int.Parse(sr.ReadLine());
for (int i = 0; i < T; i++)
{
    double[] tmp = Array.ConvertAll(sr.ReadLine().Split(' '), double.Parse);
    var (x1, y1, r1, x2, y2, r2) = (tmp[0], tmp[1], tmp[2], tmp[3], tmp[4], tmp[5]);

    var d2 = Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
    var sumR = Math.Pow(r1 + r2, 2);
    var diffR = Math.Pow(r1 - r2, 2);

    if (d2 == 0 && r1 == r2)
        Console.WriteLine("-1");
    else if (d2 > sumR || d2 < diffR)
        Console.WriteLine("0");
    else if (d2 == sumR || d2 == diffR)
        Console.WriteLine("1");
    else
        Console.WriteLine("2");
}
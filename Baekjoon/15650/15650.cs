/*******
 15650. N과 M (2)

 * N과 M (1)의 응용 문제. 순열이 아닌 조합 구현
 * 상태 변화도를 그려보며 재귀함수의 프로세스를 익히기 좋음
 
 * 상태 변화도(입력: 4, 4)
    * 01. [1, ?, ?, ?] -> Combination(0)
    * 02. [1, 2, ?, ?] -> Combination(1)
    * 03. [1, 2, 3, ?] -> Combination(2)
    * 04. [1, 2, 3, 4] -> Combination(3)
    * 05. [1, 2, 3, 4] -> Conbination(4) - 출력
    * 06. [1, 2, 4, ?] -> Combination(2)
    * 07. [1, 2, ?, ?] -> Combination(1)
    * 08. [1, 3, ?, ?] -> Combination(1)
    * 09. [1, 3, 4, ?] -> Combination(2)
    * 10. [1, 4, ?, ?] -> Combination(1)
    * 11. [1, ?, ?, ?] -> Combination(0)
    * 12. [2, ?, ?, ?] -> Combination(0)
    * 13. [2, 3, ?, ?] -> Combination(1)
    * 이후 Depth 4까지 도달하지 못하여 그대로 종료
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] nm = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var (n, m) = (nm[0], nm[1]);

int[] numList = new int[n];

void Combination(int depth, int start)
{
    // 깊이가 m에 도달했으면 numList 출력
    if (depth == m)
    {
        for (int i = 0; i < m; i++)
            sw.Write(numList[i] + " ");
        sw.WriteLine();
        return;
    }

    for (int i = start; i <= n; i++)
    {
        // numList에 추가
        numList[depth] = i;

        // 재귀 호출
        Combination(depth + 1, i + 1);
    }
}

Combination(0, 1);

sw.Flush();
sr.Close();
sw.Close();
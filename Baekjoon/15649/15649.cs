/*******
 15649. N과 M (1)

 * 가장 기본적인 백트래킹 문제
 * 재귀함수의 깊이가 m에 도달했을 때, numList에 담긴 수들을 공백으로 구분하여 출력
 * 상태 변화도를 그려보며 재귀함수의 프로세스를 익히기 좋음

 * 상태 변화도(입력: 4, 4)
    * 01. [1, ?, ?, ?] -> permutation(0) - used[1] true
    * 02. [1, 2, ?, ?] -> permutation(1) - used[2] true
    * 03. [1, 2, 3, ?] -> permutation(2) - used[3] true
    * 04. [1, 2, 3, 4] -> permutation(3) - used[4] true
    * 05. [1, 2, 3, 4] -> permutation(4) - 출력
    * 05. [1, 2, 3, ?] -> permutation(3) - used[4] false(used[4] false = for문 종료)
    * 06. [1, 2, 4, ?] -> permutation(3) - used[3] false, used[4] true
    * 07. [1, 2, 4, 3] -> permutation(3) - used[3] true
    * 08. [1, 2, 4, 3] -> permutation(4) - 출력
    * 09. [1, 2, 4, ?] -> permutation(3) - used[3] false
    * 10. [1, 2, ?, ?] -> permutation(2) - used[4] false
    * 11. [1, 3, ?, ?] -> permutation(1) - used[2] false, used[3] true
    * 12. [1, 3, 2, ?] -> permutation(2) - used[2] true
    * ...
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] nm = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var (n, m) = (nm[0], nm[1]);

int[] numList = new int[n + 1];
bool[] used = new bool[n + 1];

void permutation(int depth)
{
    // 깊이가 m에 도달했으면 numList 출력
    if (depth == m)
    {
        for (int i = 0; i < m; i++)
            sw.Write(numList[i] + " ");
        sw.WriteLine();
        return;
    }

    for (int i = 1; i <= n; i++)
    {
        // 이미 사용됐으면 continue
        if (used[i]) continue;

        // 사용 안됐으면 numList에 추가하고 used 표시
        numList[depth] = i;
        used[i] = true;
        
        // 재귀 호출
        permutation(depth + 1);
        
        // 사용 완료 후 used 표시 해제
        used[i] = false;
    }
}

permutation(0);

sw.Flush();
sr.Close();
sw.Close();
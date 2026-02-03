/*******
 14226. 이모티콘

 * 의외로 BFS로 간단히 풀 수 있는 응용 문제
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

// 왼쪽: screen, 오른쪽: clipboard
Queue<(int, int)> q = new Queue<(int, int)>();

// time[screen, clipboard] = 시간
int[,] time = new int[2000, 2000];
for (int i = 0; i < 2000; i++)
    for (int j = 0; j < 2000; j++)
        time[i, j] = -1;

int n = int.Parse(sr.ReadLine());

// 초기 상태: 화면에 이모티콘 1개, 클립보드 비어있음
q.Enqueue((1, 0));
time[1, 0] = 0;

while (q.Count > 0)
{
    var (s, c) = q.Dequeue();

    // 목표 도달 시 종료
    if (s == n)
    {
        sw.WriteLine(time[s, c]);
        break;
    }

    // 화면에 있는 이모티콘을 모두 복사
    if (time[s, s] == -1)
    {
        time[s, s] = time[s, c] + 1;
        q.Enqueue((s, s));
    }

    // 클립보드에 있는 이모티콘 붙여넣기
    if (c > 0 && s + c < 2000 && time[s + c, c] == -1)
    {
        time[s + c, c] = time[s, c] + 1;
        q.Enqueue((s + c, c));
    }

    // 화면에 있는 이모티콘 하나 삭제
    if (s - 1 >= 0 && time[s - 1, c] == -1)
    {
        time[s - 1, c] = time[s, c] + 1;
        q.Enqueue((s - 1, c));
    }
}

sw.Flush();
sr.Close();
sw.Close();
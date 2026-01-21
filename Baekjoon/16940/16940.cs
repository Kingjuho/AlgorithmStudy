/*******
 16940. BFS 스페셜 저지

 * 입력된 결과를 저장해 커스텀 정렬의 우선순위로 사용
 ********/

bool[] visited;
List<int>[] graph;

// 빠른 입력
StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
// 빠른 출력
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] BFS(int start, int len)
{
    int[] result = new int[len];

    // 큐 사용
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    visited[start] = true;

    result[0] = start;
    int cursor = 1;

    while (q.Count > 0)
    {
        int cur = q.Dequeue();
        foreach (var i in graph[cur])
        {
            if (visited[i]) continue;

            q.Enqueue(i);
            visited[i] = true;

            result[cursor] = i;
            cursor++;
        }
    }

    return result;
}

int n = int.Parse(sr.ReadLine());
visited = new bool[n + 1];
graph = new List<int>[n + 1];
for (int i = 0; i <= n; i++) graph[i] = new List<int>();

for (int i = 0; i < n - 1; i++)
{
    int[] tmp = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    graph[tmp[0]].Add(tmp[1]);
    graph[tmp[1]].Add(tmp[0]);
}

int[] isCorrect = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int[] priority = new int[n + 1];
for (int i = 0; i < n; i++) priority[isCorrect[i]] = i;
for (int i = 1; i <= n; i++) graph[i].Sort((a, b) => priority[a].CompareTo(priority[b]));

sw.WriteLine(BFS(1, n).SequenceEqual(isCorrect) ? 1 : 0);

// 마지막에 반드시 비워야 함
sw.Flush();
sr.Close();
sw.Close();
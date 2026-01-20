/*******
 1260. DFS와 BFS

 * BFS, DFS 복습
 ********/

bool[] visited;
List<int>[] graph;

// 빠른 입력
StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
// 빠른 출력
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

void BFS(int start)
{
    // 큐 사용
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    visited[start] = true;

    while (q.Count > 0)
    {
        int cur = q.Dequeue();
        sw.Write(cur + " ");

        foreach (var i in graph[cur])
        {
            if (visited[i]) continue;

            q.Enqueue(i);
            visited[i] = true;
        }
    }
}

void DFS(int start)
{
    visited[start] = true;
    sw.Write(start + " ");

    foreach (var i in graph[start])
    {
        if (visited[i]) continue;
        DFS(i);
    }
}

// 공백 기준으로 문자열을 쪼갠 후 Int로 전환
int[] nmv = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

int n, m, v;
(n, m, v) = (nmv[0], nmv[1], nmv[2]);

visited = new bool[n + 1];
graph = new List<int>[n + 1];
for (int i = 0; i <= n; i++) graph[i] = new List<int>();

for (int i = 0; i < m; i++)
{
    int[] tmp = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    graph[tmp[0]].Add(tmp[1]);
    graph[tmp[1]].Add(tmp[0]);
}

for (int i = 1; i <= n; i++) graph[i].Sort();

DFS(v);

visited = new bool[n + 1];
sw.WriteLine();

BFS(v);

// 마지막에 반드시 비워야 함
sw.Flush();
sr.Close();
sw.Close();

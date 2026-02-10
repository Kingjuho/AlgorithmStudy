/*******
 1238. 파티

 * 다익스트라 알고리즘 응용 문제
 * X에서 모든 노드로 가는 거리 = 입력값 그대로 그래프를 그린 후 X를 출발지점으로 두고 다익스트라
 * 모든 노드에서 X로 오는 거리 = 입력값 반대로 그래프를 그린 후 X를 출발지점으로 두고 다익스트라
 * 이 간선 뒤집기 테크닉은 매우 유용한 테크닉이므로 반드시 기억해둬야 함
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] NMX = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var (N, M, X) = (NMX[0], NMX[1], NMX[2]);

int[] back = new int[N + 1];
int[] go = new int[N + 1];
List<List<(int, int)>> backGraph = new List<List<(int, int)>>();
List<List<(int, int)>> goGraph = new List<List<(int, int)>>();

Array.Fill(back, Int32.MaxValue);
Array.Fill(go, Int32.MaxValue);
for (int i = 0; i <= N; i++)
{
    backGraph.Add(new List<(int, int)>());
    goGraph.Add(new List<(int, int)>());
}

for (int i = 0; i < M; i++)
{
    int[] uvw = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var (u, v, w) = (uvw[0], uvw[1], uvw[2]);

    backGraph[u].Add((v, w));
    goGraph[v].Add((u, w));
}

void Dijkstra(int start, List<List<(int, int)>> graph, int[] dist)
{
    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    dist[start] = 0;
    pq.Enqueue(start, 0);

    while (pq.Count > 0)
    {
        pq.TryDequeue(out int u, out int curDist);

        if (curDist > dist[u]) continue;

        foreach (var edge in graph[u])
        {
            var (v, w) = edge;
            int nextDist = w + curDist;

            if (nextDist < dist[v])
            {
                dist[v] = nextDist;
                pq.Enqueue(v, nextDist);
            }
        }
    }
}

Dijkstra(X, backGraph, back);
Dijkstra(X, goGraph, go);

int maxValue = 0;
for (int i = 1; i <= N; i++)
    maxValue = (maxValue < go[i] + back[i]) ? go[i] + back[i] : maxValue;
sw.WriteLine(maxValue);

sw.Flush();
sr.Close();
sw.Close();
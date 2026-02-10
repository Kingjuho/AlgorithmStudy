/*******
 1753. 최단경로

 * 다익스트라 알고리즘 기초 문제
 * A* 학습 전 반드시 이해하고 넘어가야 함
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] VE = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var (V, E) = (VE[0], VE[1]);
int K = int.Parse(sr.ReadLine());

// 우선순위 큐
PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
// 거리(값: 비용)
int[] dist = new int[V + 1];
// 그래프. 비용도 넣어야 하기 때문에 튜플 사용
List<List<(int, int)>> graph = new List<List<(int, int)>>();

// 초기화
for (int i = 0; i <= V; i++)
    graph.Add(new List<(int, int)>());
for (int i = 1; i <= V; i++)
    dist[i] = Int32.MaxValue;

for (int i = 0; i < E; i++)
{
    int[] uvw = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var (u, v, w) = (uvw[0], uvw[1], uvw[2]);

    // u -> v, 비용 w
    graph[u].Add((v, w));
}

// 시작점 삽입
pq.Enqueue(K, 0);
dist[K] = 0;

// 다익스트라
while (pq.Count > 0)
{
    // 가장 가까운 정점 디큐(자동으로 curDist가 가장 작은 값이 디큐됨)
    pq.TryDequeue(out int u, out int curDist);

    // 이미 저장된 비용보다 더 큰 경로는 무시
    if (curDist > dist[u]) continue;

    // 인접 정점 탐색
    foreach (var edge in graph[u])
    {
        var (v, w) = edge;
        int nextDist = w + curDist;

        // 더 짧은 경로 발견 시 비용 갱신 및 우선순위 큐 삽입
        if (nextDist < dist[v])
        {
            dist[v] = nextDist;
            pq.Enqueue(v, nextDist);
        }
    }
}

for (int i = 1; i <= V; i++)
    sw.WriteLine((dist[i] == Int32.MaxValue) ? "INF" : dist[i]);


sw.Flush();
sr.Close();
sw.Close();

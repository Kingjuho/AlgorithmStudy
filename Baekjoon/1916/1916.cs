/*******
 1916. 최소비용 구하기

 * 다익스트라 알고리즘 기초 문제
 * A* 학습 전 반드시 이해하고 넘어가야 함
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int N = int.Parse(sr.ReadLine());
int M = int.Parse(sr.ReadLine());

PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
int[] dist = new int[N + 1];
List<List<(int, int)>> graph = new List<List<(int, int)>>();

for (int i = 0; i <= N; i++)
{
    graph.Add(new List<(int, int)>());
    dist[i] = Int32.MaxValue;
}

for (int i = 0; i < M; i++)
{
    int[] uvw = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
    var (u, v, w) = (uvw[0], uvw[1], uvw[2]);

    graph[u].Add((v, w));
}

int[] tmp = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
var (start, end) = (tmp[0], tmp[1]);
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

sw.WriteLine(dist[end]);


sw.Flush();
sr.Close();
sw.Close();
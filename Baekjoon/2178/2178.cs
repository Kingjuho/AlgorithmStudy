/*******
 2178. 미로 탐색

 * 2차원 배열 내에서의 BFS, visited 대신 distance 사용법 복습
 * 배열 선언 대신 튜플을 활용할 시 메모리 소모가 더 적으며 활용도 편함
 ********/

int[,] dist;
int[,] maze;
Queue<(int, int)> q = new Queue<(int, int)>();

(int, int)[] dir = { (1, 0), (-1, 0), (0, 1), (0, -1) };

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

int[] nm = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
int n, m;
(n, m) = (nm[0], nm[1]);

dist = new int[n, m];
maze = new int[n, m];

for (int i = 0; i < n; i++)
{
    string tmp = sr.ReadLine();
    for (int j = 0; j < m; j++)
    {
        dist[i, j] = -1;
        maze[i, j] = tmp[j] - '0';
    }
}

q.Enqueue((n - 1, m - 1));
dist[n - 1, m - 1] = 0;

while (q.Count > 0)
{
    var (cx, cy) = q.Dequeue();
    for (int i = 0; i < 4; i++)
    {
        var (dx, dy) = dir[i];
        var (nx, ny) = (cx + dx, cy + dy);

        if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;
        if (dist[nx, ny] >= 0 || maze[nx, ny] != 1) continue;

        dist[nx, ny] = dist[cx, cy] + 1;
        q.Enqueue((nx, ny));
    }
}

sw.WriteLine(dist[0, 0] + 1);

sw.Flush();
sr.Close();
sw.Close();
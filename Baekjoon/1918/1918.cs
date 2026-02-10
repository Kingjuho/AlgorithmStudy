/*******
 1918. 후위 표기식

 * 스택 사용법 응용편
 * 명확한 조건을 코드로 변환하는 법 학습에도 좋음
 ********/

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

Stack<char> stack = new Stack<char>();

var priority = new Dictionary<char, int>();
priority.Add('+', 1);
priority.Add('-', 1);
priority.Add('*', 2);
priority.Add('/', 2);

string input = sr.ReadLine();
string ans = "";

foreach (char chr in input)
{
    // 현재 읽은 것이 피연산자
    if (65 <= (int)chr && (int)chr <= 90) ans += chr;
    // 현재 읽은 것이 괄호
    else if (chr == '(') stack.Push(chr);
    else if (chr == ')')
    {
        while (stack.Count > 0 && stack.Peek() != '(')
            ans += stack.Pop();
        stack.Pop();
    }
    // 현재 읽은 것이 연산자
    else
    {
        // 스택이 있으며, head가 (가 아니며, head의 우선순위가 현재 연산자와 같거나 높을 경우
        while (stack.Count > 0 && stack.Peek() != '(' && priority[chr] <= priority[stack.Peek()])
            ans += stack.Pop();
        stack.Push(chr);
    }
}

while (stack.Count > 0) ans += stack.Pop();

sw.WriteLine(ans);

sw.Flush();
sr.Close();
sw.Close();

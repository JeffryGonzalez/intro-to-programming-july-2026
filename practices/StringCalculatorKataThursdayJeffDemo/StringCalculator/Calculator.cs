
public class Calculator
{
    public int Add(string numbers)
    {

        return numbers == "" ? 0 :
             numbers.Split(',', '\n')
             .Sum(int.Parse);

    }
}

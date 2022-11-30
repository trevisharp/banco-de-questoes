App.Run();

public class Controller
{
    public long GetNext(long current, int move)
    {
        switch (move)
        {
            case 1:
                current = current >> 1;
                break;
            case 2:
                current = current >> 8;
                break;
            case 3:
                current = current << 1;
                break;
            case 4:
                current = current << 8;
                break;
        }
        return current;
    }
}
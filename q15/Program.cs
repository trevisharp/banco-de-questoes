using System.Linq;
using System.Collections.Generic;

App.Run();

public class Controller
{
    public void Solve(IEnumerable<Piece> pieces)
    {
        var first = pieces.FirstOrDefault(p => p.IsLeftTopPiece());
        first.SetPosition(0, 0);

        for (int j = 0; true; j++)
        {
            var crr = first;
            for (int i = 1; i < 32; i++)
            {
                foreach (var p in pieces)
                {
                    if (crr.ConnectRight(p))
                    {
                        p.SetPosition(i, j);
                        crr = p;
                        break;
                    }
                }
            }

            if (j == 17)
                break;

            foreach (var p in pieces)
            {
                if (first.ConnectBottom(p))
                {
                    p.SetPosition(0, j + 1);
                    first = p;
                    break;
                }
            }
        }
    }
}
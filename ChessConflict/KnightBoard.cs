namespace ChessConflict;

public class KnightBoard
{
    private List<Knight> _knights;

    public KnightBoard(IEnumerable<string> positions)
    {
        _knights = positions.Select(p => new Knight(p)).ToList();
    }

    public Dictionary<Knight, List<Knight>> GetConflicts()
    {
        var result = new Dictionary<Knight, List<Knight>>();

        foreach (var knight in _knights)
        {
            var conflicts = new List<Knight>();
            foreach (var other in _knights)
            {
                if (knight != other && knight.CanAttack(other))
                {
                    conflicts.Add(other);
                }
            }
            result[knight] = conflicts;
        }

        return result;
    }
}
namespace ChessConflict;

public class Knight
{
    public string Position { get; private set; }
    public int Row { get; private set; }
    public int Column { get; private set; }

    public Knight(string position)
    {
        Position = position.ToUpper().Trim();
        (Row, Column) = ConvertPosition(Position);
    }

    private (int, int) ConvertPosition(string pos)
    {
        if (pos.Length != 2)
            throw new Exception($"La posición {pos} no es válida.");

        char colChar = pos[0];
        char rowChar = pos[1];

        if (colChar < 'A' || colChar > 'H')
            throw new Exception($"La columna {colChar} no es válida. Debe ser A-H.");

        if (!char.IsDigit(rowChar))
            throw new Exception($"La fila {rowChar} no es válida. Debe ser 1-8.");

        int column = colChar - 'A' + 1; 
        int row = int.Parse(rowChar.ToString());

        if (row < 1 || row > 8)
            throw new Exception($"La fila {row} no es válida. Debe ser 1-8.");

        return (row, column);
    }

    public bool CanAttack(Knight other)
    {
        int dr = Math.Abs(Row - other.Row);
        int dc = Math.Abs(Column - other.Column);

        return (dr == 2 && dc == 1) || (dr == 1 && dc == 2);
    }

    public string GetRowColFormat()
    {
        char colChar = (char)('A' + Column - 1);
        return $"{Row}{colChar}";
    }
}

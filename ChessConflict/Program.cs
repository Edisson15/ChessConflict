using ChessConflict;

Console.WriteLine("=== Caballos en Conflicto ===");
Console.WriteLine("Ingrese la ubicación de los caballos separadas por coma (ejemplo: B7,C5,E2,H7,G5,F6)");
Console.WriteLine("Escriba 'exit' para salir.\n");

int testNumber = 1;

while (true)
{
    Console.Write($"Prueba {testNumber} - Ingrese ubicación de los caballos: ");
    string input = Console.ReadLine();

    if (input == null) continue;
    if (input.Trim().ToLower() == "exit") break;

    try
    {
        var positions = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(p => p.Trim()).ToList();

        var board = new KnightBoard(positions);
        var conflicts = board.GetConflicts();

        foreach (var kvp in conflicts)
        {
            var knight = kvp.Key;
            var conflictList = kvp.Value;

            Console.Write($"Analizando Caballo en {knight.GetRowColFormat()} =>");

            if (conflictList.Count == 0)
            {
                Console.WriteLine();
            }
            else
            {
                foreach (var c in conflictList)
                {
                    Console.Write($" Conflicto con {c.GetRowColFormat()}");
                }
                Console.WriteLine();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    testNumber++;
}

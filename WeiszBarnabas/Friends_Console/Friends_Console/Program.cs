

using Friends_Console;

List<Episode> NNevek = Solution.getNameContainedTitles();
Console.WriteLine($"6.feladat: Összesen {NNevek.Count} db epizód van, mely tartalmazza valamely női főszereplő nevét");
Console.WriteLine("Címek:");
foreach (var item in NNevek)
{
    Console.WriteLine($"\t{item.name}");
}

Console.WriteLine("7. feladat:");
Console.WriteLine($"\t{Solution.getBetweenDayEpisodes()}");


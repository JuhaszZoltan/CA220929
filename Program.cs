using CA220929;
using System.Text;

List<Mission> missions = new();
using StreamReader sr = new(@"..\..\..\src\kuldetesek.csv", Encoding.UTF8);
while (!sr.EndOfStream) missions.Add(new Mission(sr.ReadLine()));

ParhozamosanKezeltListakkal(missions);
Console.WriteLine("--------------");
AsszociativDinamikusVektorral(missions);
Console.WriteLine("--------------");
NyelvbeIntegraltLekerdezessel(missions);

static void ParhozamosanKezeltListakkal(List<Mission> missions)
{
    List<string> names = new();
    List<int> sumOfhours = new();

    for (int i = 0; i < missions.Count; i++)
    {
        if (!Contains(missions[i].ShuttleName))
        {
            names.Add(missions[i].ShuttleName);
            sumOfhours.Add(missions[i].TotalSpaceHours);
        }
        else
        {
            int index = IndexOf(missions[i].ShuttleName);
            sumOfhours[index] += missions[i].TotalSpaceHours;
        }
    }

    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"{names[i]} - {sumOfhours[i] / 24F}");
    }

    bool Contains(string shuttleName)
    {
        int i = 0;
        while (i < names.Count && names[i] != shuttleName)
        {
            i++;
        }
        if (i < names.Count) return true;
        else return false;
    }

    int IndexOf(string shuttleName)
    {
        int i = 0;
        while (names[i] != shuttleName)
        {
            i++;
        }
        return i;
    }
}
static void AsszociativDinamikusVektorral(List<Mission> missions)
{
    Dictionary<string, int> dictionary = new();

    foreach (var m in missions)
    {
        if (!dictionary.ContainsKey(m.ShuttleName))
            dictionary[m.ShuttleName] = m.TotalSpaceHours;
        else
            dictionary[m.ShuttleName] += m.TotalSpaceHours;
    }

    foreach (var kvp in dictionary)
    {
        Console.WriteLine($"{kvp.Key} - {kvp.Value / 24F}");
    }
}
static void NyelvbeIntegraltLekerdezessel(List<Mission> missions)
{
    var res = missions.GroupBy(m => m.ShuttleName);
    foreach (var item in res)
    {
        Console.WriteLine($"{item.Key} - {item.Sum(m => m.TotalSpaceHours) / 24F}");
    }
}
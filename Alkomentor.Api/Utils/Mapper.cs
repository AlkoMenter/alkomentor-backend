using System.Text.Json;

namespace Alkomentor.Api;
public static class Mapper
{
    public static To? Map<TFrom, To>(TFrom from)
        where To: class
        where TFrom: class
    {
        var json = JsonSerializer.Serialize(from);

        return JsonSerializer.Deserialize<To>(json);
    }
}

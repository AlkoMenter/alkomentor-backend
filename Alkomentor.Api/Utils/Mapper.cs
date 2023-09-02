using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alkomentor.Api.Utils;
public static class Mapper
{
    public static To? Map<TFrom, To>(TFrom from)
        where To: class
        where TFrom: class
    {
        var json = JsonSerializer.Serialize(from, new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        return JsonSerializer.Deserialize<To>(json);
    }
}

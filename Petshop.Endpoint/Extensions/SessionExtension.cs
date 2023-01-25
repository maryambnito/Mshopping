﻿using Newtonsoft.Json;

namespace Petshop.Endpoint.Extensions;

public static class SessionExtension
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));

    }
    public static T GetJson<T>(this ISession session, string key)
    {
        var jsonObject = session.GetString(key);
        if (string.IsNullOrEmpty(jsonObject))
            return default(T);
        return JsonConvert.DeserializeObject<T>(jsonObject);
    }
}

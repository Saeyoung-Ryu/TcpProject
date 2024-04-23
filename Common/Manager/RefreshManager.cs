using System.Reflection;

namespace Common;

public class RefreshManager
{
    private static List<string> typesToRefresh;
    
    public static async Task InitializeAsync()
    {
        try
        {
            // 미리 Refresh할 클래스를 추가
            typesToRefresh = new List<string>();
				
            // 모든 Refreshable 클래스를 찾아서 추가
            AppendAllRefreshables(typesToRefresh);

            await RefreshAllAsync(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    
    public static void AppendAllRefreshables(List<string> typesToRefresh)
    {
        var types = Assembly.GetEntryAssembly().GetTypes();
        foreach (var t in types)
        {
            if (!typesToRefresh.Contains(t.ToString()))
            {
                var typeInfo = t.GetTypeInfo();
                if (typeInfo.GetCustomAttributes(typeof(RefreshableAttribute), true).Count() > 0)
                    typesToRefresh.Add(t.ToString());
            }
        }
    }
    
    public static List<string> GetAllRefreshables()
    {
        return typesToRefresh;
    }
    
    private static async Task RefreshAllAsync(bool enforced)
    {
        foreach (var i in typesToRefresh)
            await RefreshSingleAsync(i, enforced);
    }
    
    public static async Task RefreshSingleAsync(string typeName, bool enforced)
    {
        try
        {
            var type = Type.GetType(typeName);
            if (type == null) return;

            MethodInfo methodInfo = type.GetMethod("RefreshAsync");
            if (methodInfo == null) return;

            ParameterInfo[] parameters = methodInfo.GetParameters();
            if (parameters.Length == 0)
                await (Task)methodInfo.Invoke(null, null);
            else
                await (Task)methodInfo.Invoke(null, new object[] { enforced });
            
        }
        catch (Exception ex)
        {
            Console.WriteLine();
        }
    }

}
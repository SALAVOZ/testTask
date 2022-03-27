using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestTask.Helpers
{
    public static class ListHelpers
    {
        public static bool Compare(this IHtmlHelper html, int item_1, int item_2)
        {
            return item_1 == item_2;
        }
    
    }
}

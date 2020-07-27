namespace RestaurantManagement.Models.Common
{
    public class PagingParams
    {
        public int StartIndex { get; set; } = 1;

        public int EndIndex { get; set; } = int.MaxValue;
    }
}

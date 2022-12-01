namespace Duo
{
    /// <summary>
    /// Information of dataset paging
    /// </summary>
    public class PagingInfo
    {
        public int total_objects { get; set; }
        public ushort? next_offset { get; set; }
        public int prev_offset { get; set; }
    }
}

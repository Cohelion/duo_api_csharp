namespace Duo
{
    /// <summary>
    /// Information of dataset paging
    /// </summary>
    public class PagingInfo
    {
        /// <summary/>
        public int total_objects { get; set; }

        /// <summary/>
        public ushort? next_offset { get; set; }

        /// <summary/>
        public int prev_offset { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Duo
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DataEnvelope<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DuoApiResponseStatus Stat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public T Response { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Upon error, basic error information
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Upon error, detailed error information
        /// </summary>
        public string? Message_detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PagingInfo? Metadata { get; set; }
    }
}

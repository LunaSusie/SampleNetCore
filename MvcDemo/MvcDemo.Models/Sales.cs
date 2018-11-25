namespace MvcDemo.Models
{
    public class Sales
    {
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        /// <summary>
        /// 卖出了多少票
        /// </summary>
        public int AudienceCount { get; set; }
    }
}
using System;

namespace MvcDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int CinemaId { get; set; }
        /// <summary>
        /// 主演
        /// </summary>
        public string Starring { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}
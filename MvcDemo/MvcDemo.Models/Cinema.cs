namespace MvcDemo.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        /// <summary>
        /// 容纳多少观众
        /// </summary>
        public int Capacity { get; set; }
    }
}
using System.Collections.Generic;

namespace OptionsBindConfig
{
    public class Class
    {
        public int ClassNO { get; set; }
        public string ClassDesc { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
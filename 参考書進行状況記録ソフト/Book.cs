namespace 参考書進行状況記録ソフト
{
    public class Book
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Book(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }

        public override string ToString()
        {
            return $"名前：{this.Name}　パス；{this.Path}";
        }
    }
}
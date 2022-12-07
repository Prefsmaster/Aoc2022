namespace Aoc202207
{
    internal class DirItem
    {
        public DirItem? Parent { get; set; }
        public List<DirItem> Items { get; set; } = new();
        public string Name { get; set; }
        private readonly long _size;
        public bool IsDir => _size == -1; 
        public DirItem(DirItem? parent, string name, long size = -1)
        {
            Parent = parent;
            Name = name;
            _size = size; 
        }
        public long Size => IsDir ? Items.Select(it => it.Size).Sum() : _size; 

        public List<DirItem> FilterDirectories(Func<DirItem, bool> filter)
        {
            var filtered = new List<DirItem>();
            FilterItems(filter, this, filtered);
            return filtered;
        }
        private static void FilterItems(Func<DirItem, bool> filter, DirItem item, List<DirItem> candidates)
        {
            foreach (var subItem in item.Items.Where(i => i.IsDir))
            {
                if (filter(subItem)) candidates.Add(subItem);
                FilterItems(filter, subItem, candidates);
            }
        }
    }
}

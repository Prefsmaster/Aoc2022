namespace Aoc202207
{
    internal class DirItem
    {
        public DirItem? Parent;
        public List<DirItem> Items = new();
        public string Name { get; set; }
        private  long _size;
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
        private void FilterItems(Func<DirItem, bool> filter, DirItem item, List<DirItem> candidates)
        {
            foreach (var subitem in item.Items.Where(i => i.IsDir))
            {
                if (filter(subitem)) candidates.Add(subitem);
                FilterItems(filter, subitem, candidates);
            }
        }

        // attempt to use SelectMany, but does not work (yet) :-(
        //var candidates1 = dirTree.Items.SelectMany(it=>it.Items).Where(it=> it.IsDir && it.Size<=100000).Sum(dir => dir.Size);

    }
}

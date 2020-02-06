using System;
using System.Collections.Generic;
using System.Linq;

namespace ThemeApp.Models
{
    public class OptionCollection<T>
    {
        public IEnumerable<Option<T>> Items { get; }

        public OptionCollection(IEnumerable<Option<T>> items)
        {
            Items = items ?? throw new ArgumentNullException($"{nameof(OptionCollection<T>)} requires an initialized collection.");
        }

        public void Select(T value)
        {
            UnselectAll();

            var items = GetItemsMatching(value);
            foreach (var item in items)
            {
                item.IsSelected = true;
            }
        }

        private void UnselectAll()
        {
            foreach (var item in Items)
            {
                item.IsSelected = false;
            }
        }

        private IEnumerable<Option<T>> GetItemsMatching(T value) => Items.Where(o => o.Value.Equals(value));
    }
}

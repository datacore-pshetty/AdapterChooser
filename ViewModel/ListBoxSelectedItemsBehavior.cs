using System.Collections;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace AdapterChooser.ViewModel
{
    public class ListBoxSelectedItemsBehavior
    {
        // Prevent circular updates
        private static bool _isUpdating = false;

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(IList),
                typeof(ListBoxSelectedItemsBehavior),
                new PropertyMetadata(null, OnSelectedItemsChanged));

        public static void SetSelectedItems(DependencyObject element, IList value)
        {
            element.SetValue(SelectedItemsProperty, value);
        }

        public static IList GetSelectedItems(DependencyObject element)
        {
            return (IList)element.GetValue(SelectedItemsProperty);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ListBox listBox)
            {
                // Remove old event handlers
                listBox.SelectionChanged -= ListBox_SelectionChanged;

                var newCollection = e.NewValue as INotifyCollectionChanged;

                if (newCollection != null)
                {
                    // Initial sync from collection to ListBox
                    SyncListBoxFromCollection(listBox, e.NewValue as IList);
                }

                // Add new event handler
                listBox.SelectionChanged += ListBox_SelectionChanged;
            }
        }

        private static void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isUpdating) return;

            if (sender is ListBox listBox)
            {
                var selectedItems = GetSelectedItems(listBox);
                if (selectedItems == null) return;

                _isUpdating = true;
                try
                {

                    //Make changes in one of the Bridge and then change to Prox-2
                    //When the host is changed back from Prox-2 to Prox-1 the listBox.SelectedItems will be empty, but the selectedItems will have the old selected values.
                    //In case the If condition is not there, the selectedItems will be cleared and no items will be added since listBox.SelectedItems is empty.
                    if (listBox.SelectedItems.Count != 0)
                    {
                        // Clear and repopulate the bound collection
                        selectedItems.Clear();
                        foreach (var item in listBox.SelectedItems)
                        {
                            selectedItems.Add(item);
                        }
                    }
                }
                finally
                {
                    _isUpdating = false;
                }
            }
        }

        private static void SyncListBoxFromCollection(ListBox listBox, IList collection)
        {
            if (listBox == null || collection == null || _isUpdating) return;

            _isUpdating = true;
            try
            {
                listBox.SelectedItems.Clear();
                foreach (var item in collection)
                {
                    if (listBox.Items.Contains(item))
                    {
                        listBox.SelectedItems.Add(item);
                    }
                }
            }
            finally
            {
                _isUpdating = false;
            }
        }
    }
}

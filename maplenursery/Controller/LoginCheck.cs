using JustTest1.DataModel;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace JustTest1.Controller
{
    public class LoginCheck
    {




        //private async Task RefreshTodoItems()
        //{
        //    MobileServiceInvalidOperationException exception = null;
        //    try
        //    {
        //        // This code refreshes the entries in the list view by querying the TodoItems table.
        //        // The query excludes completed TodoItems
        //        items = await userTable
        //            .Where(todoItem => todoItem.Name != null)
        //            .ToCollectionAsync();
        //    }
        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        exception = e;
        //    }

        //    if (exception != null)
        //    {
        //        await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
        //    }
        //    else
        //    {
        //        ListItems.ItemsSource = items;
        //        this.ButtonSave.IsEnabled = true;
        //    }
        //}
        //private async Task UpdateCheckedTodoItem(User item)
        //{
        //    // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
        //    // responds, the item is removed from the list 
        //    await userTable.UpdateAsync(item);
        //    items.Remove(item);
        //    ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);

        //    //await SyncAsync(); // offline sync
        //}

        //private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        //{
        //    ButtonRefresh.IsEnabled = false;

        //    //await SyncAsync(); // offline sync
        //    await RefreshTodoItems();

        //    ButtonRefresh.IsEnabled = true;
        //}

        //private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        //{
        //    var todoItem = new User { Name = TextInput.Text, Password = TextInput.Text };
        //    await InsertTodoItem(todoItem);
        //}


        //private async void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cb = (CheckBox)sender;
        //    User item = cb.DataContext as User;
        //    await UpdateCheckedTodoItem(item);
        //}


        #region Offline sync

        //private async Task InitLocalStoreAsync()
        //{
        //    if (!App.MobileService.SyncContext.IsInitialized)
        //    {
        //        var store = new MobileServiceSQLiteStore("localstore.db");
        //        store.DefineTable<TodoItem>();
        //        await App.MobileService.SyncContext.InitializeAsync(store);
        //    }
        //
        //    await SyncAsync();
        //}

        //private async Task SyncAsync()
        //{
        //    await App.MobileService.SyncContext.PushAsync();
        //    await userTable.PullAsync("todoItems", userTable.CreateQuery());
        //}

        #endregion 
    }
}

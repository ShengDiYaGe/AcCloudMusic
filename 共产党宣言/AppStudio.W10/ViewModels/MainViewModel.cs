using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using AppStudio.DataProviders;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Sections;


namespace AppStudio.ViewModels
{
    public class MainViewModel : PageViewModel
    {
        public MainViewModel(int visibleItems) : base()
        {
            PageTitle = "共产党宣言";
            Section1 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new Section1Config(), visibleItems);
            Section2 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new Section2Config(), visibleItems);
            Section3 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new Section3Config(), visibleItems);
            Section4 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new Section4Config(), visibleItems);
            Section5 = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new Section5Config(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Section1 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Section2 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Section3 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Section4 { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> Section5 { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

		public override void UpdateCommonProperties(SplitViewDisplayMode splitViewDisplayMode)
        {
            base.UpdateCommonProperties(splitViewDisplayMode);
            if (splitViewDisplayMode == SplitViewDisplayMode.Overlay)
            {
                AppBarRow = 3;
                AppBarColumn = 0;
                AppBarColumnSpan = 2;
            }
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return Section1;
            yield return Section2;
            yield return Section3;
            yield return Section4;
            yield return Section5;
        }
    }
}

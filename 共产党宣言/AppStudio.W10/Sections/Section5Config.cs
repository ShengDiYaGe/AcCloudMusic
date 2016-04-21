using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.Uwp.Navigation;
using AppStudio.Config;
using AppStudio.ViewModels;

namespace AppStudio.Sections
{
    public class Section5Config : SectionConfigBase<LocalStorageDataConfig, HtmlSchema>
    {
        public override DataProviderBase<LocalStorageDataConfig, HtmlSchema> DataProvider
        {
            get
            {
                return new HtmlDataProvider();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Section5.htm"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("Section5ListPage");
            }
        }

        public override ListPageConfig<HtmlSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<HtmlSchema>
                {
                    Title = "第四章",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Content = item.Content;
                    },
                    NavigationInfo = (item) =>
                    {
                        return null;
                    }
                };
            }
        }

        public override DetailPageConfig<HtmlSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "第四章"; }
        }
    }
}

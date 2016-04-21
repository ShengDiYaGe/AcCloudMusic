using AppStudio.Uwp;
using Windows.ApplicationModel;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel : PageViewModel
    {
        public string Publisher
        {
            get
            {
                return "西方媒体";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "《共产党宣言》全文卡尔·马克思　 费里德里希·恩格斯";
            }
        }
		
        public string AppName
        {
            get
            {
                return "共产党宣言";
            }
        }
    }
}


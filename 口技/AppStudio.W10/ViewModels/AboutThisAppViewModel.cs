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
                return "一篇经典文言文";
            }
        }
		
        public string AppName
        {
            get
            {
                return "口技";
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace AppStudio.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();
		    var resourceLoader = new ResourceLoader();
            Nodes.Add(new ItemNavigationNode
            {
                Title = @"共产党宣言",
                Label = "Home",
                FontIcon = "\ue10f",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "序言",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("Section1ListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "第一章",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("Section2ListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "第二章",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("Section3ListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "第三章",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("Section4ListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "第四章",
                FontIcon = "\ue185",
                NavigationInfo = NavigationInfo.FromPage("Section5ListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPaneAbout"),
                FontIcon = "\ue11b",
                NavigationInfo = NavigationInfo.FromPage("AboutPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPanePrivacy"),
                FontIcon = "\ue1f7",
                NavigationInfo = new NavigationInfo()
                {
                    NavigationType = NavigationType.DeepLink,
                    TargetUri = new Uri("http://appstudio.windows.com/home/appprivacyterms", UriKind.Absolute)
                }
            });
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}

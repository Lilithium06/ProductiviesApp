using ProductiviesApp.Views;

namespace ProductiviesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(QuestListPage), typeof(QuestListPage));
            Routing.RegisterRoute(nameof(SkillsListPage), typeof(SkillsListPage));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductiviesApp.ViewModels;

namespace ProductiviesApp.Views;

public partial class QuestListPage : ContentPage
{
    public QuestListPage(QuestListViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}
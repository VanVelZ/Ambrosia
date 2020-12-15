using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ambrosia.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : TabbedPage
    {
        public History()
        {
            InitializeComponent();
            Children.Add(new MealHistory());
            Children.Add(new WorkoutHistory());
            Title = "History";
        }
    }
}

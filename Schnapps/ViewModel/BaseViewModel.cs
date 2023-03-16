using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schnapps.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        #region Properties
        [ObservableProperty]
        private bool isBusy;
        [ObservableProperty]
        private string title;
        #endregion
    }
}

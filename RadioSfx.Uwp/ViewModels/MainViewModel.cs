using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioSfx.Uwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public bool IsTrial { get; set; }

        public string Title => IsTrial ? "Trial Mode" : "Radio SFX Manager";


    }
}

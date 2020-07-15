using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioSfx.Uwp.Models
{
    public class Preset : ViewModelBase
    {
        public string Name { get; set; }

        public List<Sfx> Effects { get; set; }
    }
}

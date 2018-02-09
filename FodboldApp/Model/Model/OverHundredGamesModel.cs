﻿using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class OverHundredGamesModel : RealmObject
    {
        public string Name { get; set; }
        public string Period { get; set; }
        public string Games { get; set; }
        public int Index { get; set; }
    }
}

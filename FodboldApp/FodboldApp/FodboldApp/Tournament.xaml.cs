﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tournament : ContentPage
	{
		public Tournament ()
		{
			InitializeComponent ();
		}
	}
}
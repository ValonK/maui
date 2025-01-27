﻿using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;

namespace Microsoft.Maui.Handlers
{
	public partial class MenuBarItemHandler : ElementHandler<IMenuBarItem, UIMenu>, IMenuBarItemHandler
	{
		protected override UIMenu CreatePlatformElement()
		{
			IUIMenuBuilder? uIMenuBuilder = null;

			if (VirtualView.Parent?.Handler?.PlatformView is IUIMenuBuilder builder)
			{
				uIMenuBuilder = builder;
			}

			return
				VirtualView
					.ToPlatformMenu(
						VirtualView.Text,
						null,
						MauiContext!,
						uIMenuBuilder);
		}

		public void Add(IMenuElement view)
		{
			Rebuild();
		}

		public void Remove(IMenuElement view)
		{
			Rebuild();
		}

		public void Clear()
		{
			Rebuild();
		}

		public void Insert(int index, IMenuElement view)
		{
			Rebuild();
		}

		void Rebuild()
		{
			MenuBarHandler.Rebuild();
		}
	}
}

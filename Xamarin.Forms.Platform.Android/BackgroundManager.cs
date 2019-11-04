﻿using System;
using System.ComponentModel;
using Android.Content;
using Android.Util;
using Android.Views;
using Xamarin.Forms.Internals;
using AView = Android.Views.View;
using AApp = Android.App.Application;
using Android.Runtime;

namespace Xamarin.Forms.Platform.Android
{
	internal static class BackgroundManager
	{
		static BackgroundDrawable _backgroundDrawable;

		public static void Init(IVisualElementRenderer renderer)
		{
			_ = renderer ?? throw new ArgumentNullException($"{nameof(BackgroundManager)}.{nameof(Init)} {nameof(renderer)} cannot be null");

			renderer.ElementPropertyChanged += OnElementPropertyChanged;
			renderer.ElementChanged += OnElementChanged;
		}

		public static void Dispose(IVisualElementRenderer renderer)
		{
			_ = renderer ?? throw new ArgumentNullException($"{nameof(BackgroundManager)}.{nameof(Init)} {nameof(renderer)} cannot be null");

			if (_backgroundDrawable != null)
			{
				_backgroundDrawable.Dispose();
				_backgroundDrawable = null;
			}

			renderer.ElementPropertyChanged -= OnElementPropertyChanged;
			renderer.ElementChanged -= OnElementChanged;
		}

		static void UpdateBackgroundColor(AView Control, VisualElement Element, Color? color = null)
		{
			if (Element == null || Control == null)
				return;

			var finalColor = color ?? Element.BackgroundColor;
			if (finalColor.IsDefault)
				Control.SetBackground(null);
			else
				Control.SetBackgroundColor(finalColor.ToAndroid());
		}

		static void UpdateBackground(AView Control, VisualElement Element)
		{
			if (Element == null || Control == null)
				return;

			var background = Element.Background;
			if (background != null)
			{
				_backgroundDrawable = new BackgroundDrawable(Element);
				Control.SetBackground(_backgroundDrawable);
			}
		}

		static double GetDensity()
		{
			float density = 0;
			using (var displayMetrics = new DisplayMetrics())
			{
				var windowService = AApp.Context.GetSystemService(Context.WindowService)
					?.JavaCast<IWindowManager>();

				using (var display = windowService?.DefaultDisplay)
				{
					if (display == null)
						return density;

					display.GetRealMetrics(displayMetrics);
					density = displayMetrics.Density;
					return density;
				}
			}
		}

		static void OnElementChanged(object sender, VisualElementChangedEventArgs e)
		{
			Performance.Start(out string reference);
			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;
			}

			if (e.NewElement != null)
			{
				var renderer = (sender as IVisualElementRenderer);
				e.NewElement.PropertyChanged += OnElementPropertyChanged;
				UpdateBackgroundColor(renderer?.View, renderer?.Element);
				UpdateBackground(renderer?.View, renderer?.Element);
			}

			Performance.Stop(reference);
		}


		static void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
			{
				var renderer = (sender as IVisualElementRenderer);
				UpdateBackgroundColor(renderer?.View, renderer?.Element);
			}
			else if (e.PropertyName == VisualElement.BackgroundProperty.PropertyName)
			{
				var renderer = (sender as IVisualElementRenderer);
				UpdateBackground(renderer?.View, renderer?.Element);
			}
		}
	}
}
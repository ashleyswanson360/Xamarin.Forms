﻿using Xamarin.Forms;
using AWebView = Android.Webkit.WebView;

namespace Xamarin.Platform
{
	public static class WebViewExtensions
	{
		public static void UpdateSource(this AWebView nativeWebView, IWebView webView)
		{
			nativeWebView.UpdateSource(webView, null);
		}

		public static void UpdateSource(this AWebView nativeWebView, IWebView webView, IWebViewDelegate? webViewDelegate)
		{
			if (webViewDelegate != null)
				webView.Source.Load(webViewDelegate);
		}
	}
}
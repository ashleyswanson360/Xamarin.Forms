﻿using WebKit;
using Xamarin.Forms;

namespace Xamarin.Platform
{
	public static class WebViewExtensions
	{
		public static void UpdateSource(this WKWebView nativeWebView, IWebView webView)
		{
			nativeWebView.UpdateSource(webView, null);
		}

		public static void UpdateSource(this WKWebView nativeWebView, IWebView webView, IWebViewDelegate? webViewDelegate)
		{
			if (webViewDelegate != null)
				webView.Source.Load(webViewDelegate);
		}
	}
}
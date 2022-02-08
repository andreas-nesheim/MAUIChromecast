using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using SharpCaster.Controllers;
using SharpCaster.Models;
using SharpCaster.Services;

namespace MAUIChromecast
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}

		private async void OnCounterClicked(object sender, EventArgs e)
		{

			//var video = await MediaPicker.PickVideoAsync();
			//if (video is null) return;

			//var path = video.Path;

			var chromecast = await PromptAndGetSelectedChromecastDevice();
			if (chromecast is null) return;
			//await ConnectAndStreamToChromecast(chromecast, path);
		}

		private async Task<Chromecast> PromptAndGetSelectedChromecastDevice()
		{
			var chromecasts = await ChromecastService.Current.StartLocatingDevices();

			var chromecastName = await DisplayActionSheet("Velg Chromecast", "Avbryt", null, chromecasts.Select(x => x.FriendlyName).ToArray());

			return chromecasts.FirstOrDefault(x => x.FriendlyName == chromecastName);
		}

		//private static async Task ConnectAndStreamToChromecast(Chromecast chromecast, string mediaUrl)
		//{
		//	SharpCasterDemoController _controller = null;
		//	ChromecastService.Current.ChromeCastClient.ConnectedChanged += async delegate { if (_controller == null) _controller = await ChromecastService.Current.ChromeCastClient.LaunchSharpCaster(); };
		//	ChromecastService.Current.ChromeCastClient.ApplicationStarted +=
		//	async delegate
		//	{
		//		while (_controller == null)
		//		{
		//			await Task.Delay(500);
		//		}

		//		await _controller.LoadMedia(mediaUrl, "video/mp4", null, "BUFFERED");
		//	};

		//	await ChromecastService.Current.ConnectToChromecast(chromecast);
		//}
	}
}

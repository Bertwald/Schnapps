using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Schnapps.Model;
using Schnapps.Services;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Schnapps.ViewModel {
    public partial class VideoViewModel : BaseViewModel {
        #region Fields
        private readonly YoutubeClient youtube = new();
        private readonly List<string> urls = new List<string>() { "https://www.youtube.com/watch?v=sISumy3TmIQ",
                                              "https://www.youtube.com/watch?v=hCGMcVfjiBo",
                                              "https://www.youtube.com/watch?v=b0IuTL3Z-kk",
                                              "https://www.youtube.com/watch?v=BW1te_miu5I"};
        #endregion
        #region Properties
        [ObservableProperty]
        private ObservableCollection<string> videosList = new();
        #endregion
        #region Constructors
        public VideoViewModel() {
            Title = "Educational Resources Videos";
            SetStreams();
        }
        #endregion
        #region Methods
        public async void SetStreams() {
            // How I prefer it
            await Task.Run(() => { urls.Select(x => GetStreamAsync(x)).ToList()
                                  .ForEach(async x => VideosList.Add(await x));
            });

            // The Regular way
            //var Url1 = await GetStreamAsync("https://www.youtube.com/watch?v=sISumy3TmIQ");
            //VideosList.Add(Url1);
            //var Url2 = await GetStreamAsync("https://www.youtube.com/watch?v=hCGMcVfjiBo");
            //VideosList.Add(Url2);
            //var Url3 = await GetStreamAsync("https://www.youtube.com/watch?v=b0IuTL3Z-kk");
            //VideosList.Add(Url3);
            //var Url4 = await GetStreamAsync("https://www.youtube.com/watch?v=BW1te_miu5I");
            //VideosList.Add(Url4);
        }
        public async Task<string> GetStreamAsync(string url) =>
                          (await youtube.Videos.Streams.GetManifestAsync(url))
                          .GetMuxedStreams()
                          .GetWithHighestVideoQuality()?
                          .Url;
    }
    #endregion
}

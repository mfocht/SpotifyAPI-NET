using System;
using System.Net;

namespace SpotifyAPI.Local
{
    internal class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }

        public ExtendedWebClient()
        {
            Timeout = 2000;
            Headers.Add("Origin", "https://embed.spotify.com");
            Headers.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:5Zp4SWOpbuOdnsxLqwgutt");
            Headers.Add("User-Agent", "spotifyapinet/0.0");
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest webRequest = base.GetWebRequest(address) as HttpWebRequest;
            if (webRequest != null)
                webRequest.Timeout = Timeout;
            webRequest.KeepAlive = false;
            return webRequest;
        }
    }
}
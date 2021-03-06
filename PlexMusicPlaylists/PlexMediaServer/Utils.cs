﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;


namespace PlexMusicPlaylists.PlexMediaServer
{
  public class Utils
  {
    private const string HEADER_ENTRY_PLEX_CLIENT = "X-Plex-Client-Identifier";
    private const string PLEX_CLIENT_IDENTIFIER = "MusicPlaylist-Configurator";
    public const string DUMMY = "dummy";

    public static string textFromURL(string _url)
    {
      var client = new WebClient();
      try
      {
        client.Headers.Add(HEADER_ENTRY_PLEX_CLIENT, PLEX_CLIENT_IDENTIFIER);
        return client.DownloadString(_url);
      }
      catch 
      {        
        return "";
      }
    }

    public static XElement elementFromURL(string _url)
    {
      try
      {
        return XElement.Parse(Utils.textFromURL(_url), LoadOptions.None);
      }
      catch
      {
        return new XElement(DUMMY, new XAttribute("url", _url));
      }
    }
  }
}

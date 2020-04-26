using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace DemoLibrary
{
    public class ComicProcessor
    {
        public static Dictionary<int, ComicModel> LoadedComics { get; set; } 
            = new Dictionary<int, ComicModel>();
        
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            if (CheckDictionary(comicNumber))
                return LoadedComics[comicNumber];
            else
            {
                string url = "";
                if (comicNumber != 0)
                {
                    url = $"http://xkcd.com/{ comicNumber }/info.0.json";
                }
                else
                {
                    url = $"http://xkcd.com/info.0.json";
                }

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                        LoadedComics.Add(comic.Num, comic);
                        return comic;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }   
        }

        public static bool CheckDictionary(int num)
        {
            if (num == 0)
                return false;
            else
                return LoadedComics.ContainsKey(num);
        }
    }
}

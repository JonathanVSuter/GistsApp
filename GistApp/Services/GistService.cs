using GistApp.ExtractModels;
using GistApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GistApp.Services
{
    public class GistService : BaseClientService<PostGistItem>
    {
        public GistService(string uri) : base(uri){}
    }
}

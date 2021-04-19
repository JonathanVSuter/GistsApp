using GistApp.DBModels;
using GistApp.ExtractModels;
using GistApp.Helpers;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace GistApp.LocalDataContext
{
    public class GistLocalDB : BaseLocalDBOperations<PostGistItem>
    {
        public GistLocalDB()
        {           
        }
       
    }
}

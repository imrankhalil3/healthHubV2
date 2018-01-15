using System.Collections.Generic;
using SehatClone.Models;

namespace SehatClone.ViewModel
{
    public class HomeIndexVm
    {
        public List<Article> Articles { get; set; }

        public HomeIndexVm()
        {
            Articles = new List<Article>();
        }
    }
}
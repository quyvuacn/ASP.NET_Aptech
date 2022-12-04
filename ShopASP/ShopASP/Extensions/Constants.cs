using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using System.Collections;
using System.Collections.Generic;

namespace ShopASP.Extensions
{
    public class USER_LEVEL : BaseExtensions
	{
		public int PENDING = 0;
        public int ADMIN = 1;
        public int CLIENT = 2;
	}
    public class NOTIFICATION : BaseExtensions
	{
		public string SUCCESS = "success";
        public string ERROR = "error";
        public string WARNING = "warning";
        public string INFO = "info";
        public string TEXT = "text";
        public string LOG = "log";
        public string DEFAULT = "default";
	}

    public class BaseExtensions
    {
		public Dictionary<string, dynamic> ToDictionary()
		{
			var json = JsonConvert.SerializeObject(this);
			var dictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
			return dictionary;
		}
	}


}

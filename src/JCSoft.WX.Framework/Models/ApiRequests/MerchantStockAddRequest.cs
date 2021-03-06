﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantStockAddRequest : ApiRequest<DefaultResponse>
    {
        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        [JsonProperty("sku_info")]
        /// <summary>
        /// sku 信息 ,格式 "id1:vid1;id2:vid2" ,如商品为统 如商品为统 一规格， 则此处赋值为空字符串即可
        /// </summary>
        public string SkuInfo { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/stock/add?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true;  }
        }

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

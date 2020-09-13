namespace ECommerce_Shop_Online_MVC_Model.Interfaces
{
    public interface IHasSeoMetaData
    {
        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }
    }
}
namespace App_Mongodb_mar17.Models
{
    public class ProductStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; }=null!;
        public string ProductCollectionName { get; set; }=null!;
    }
}


namespace Crmspecialcustomer.HostFrameworks.Pagination
{
    public class PaginationViewModel<Model>
    {
        public List<Model> Models { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        
    }
}

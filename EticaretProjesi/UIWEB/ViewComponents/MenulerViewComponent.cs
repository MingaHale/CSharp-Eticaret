using Bussiness.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace UIWEB.ViewComponents
{
    public class MenulerViewComponent : ViewComponent
    {
        private readonly IUnitOfWorks works;
    
        public MenulerViewComponent(IUnitOfWorks works)
        {
            this.works = works;
        }
        public IViewComponentResult Invoke()
        {
            return View(works.CategoriesService.GetAll());
        }

    }
}

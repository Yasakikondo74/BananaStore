using BananaStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BananaWebView.Controllers
{
    public class BoxOfBanana : Controller
    {
        private readonly IBanana bananas;
        private readonly IBox boxes;
        public BoxOfBanana(IBanana bananas, IBox boxes)
        {
            this.bananas = bananas;
            this.boxes = boxes;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await boxes.List_v2());
        }
    }
}

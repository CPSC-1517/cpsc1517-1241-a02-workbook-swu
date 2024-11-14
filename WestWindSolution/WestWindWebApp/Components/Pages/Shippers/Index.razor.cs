using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Components.Pages.Shippers
{
    public partial class Index
    {
        [Inject]
        private ShipperService CurrentShipperService { get; set; }

        private List<Shipper> shippers = [];
        private string feedback;

        protected override void OnInitialized()
        {
            try
            {
                shippers = CurrentShipperService.GetShippers();
            }
            catch (Exception ex)
            {
                feedback = ex.Message;
            }
            
        }
    }
}

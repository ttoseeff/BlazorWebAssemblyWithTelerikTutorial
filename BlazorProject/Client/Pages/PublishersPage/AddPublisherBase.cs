using BlazorProject.Client.Services;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Threading.Tasks;
using Telerik.Blazor.Components;

namespace BlazorProject.Client.Pages.PublishersPage
{
    public class AddPublisherBase : ComponentBase
    {
        [Inject]
        public IPublisherService PublisherService { get; set; }
        [Inject]
        public ICityService cityService { get; set; }

        public Publishers Publisher { get; set; } = new Publishers();
        protected List<Publishers> ListofPublishers { get; set; }
        protected List<Publishers> PublishersByPage { get; set; } = new List<Publishers>();
        protected List<City> ListofCities { get; set; } = new List<City>();
        protected List<int> PageSizeOptions { get; set; } = new List<int>() { 2, 3, 4, 5, 6, 10 };
        protected int PageSizeOption { get; set; } = 3;
        protected bool Paging { get; set; } = true;
        public int CurrentListPageNumber { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //await LoadAllPublisher();
            await LoadAllCities();
        }

        protected async Task LoadAllPublisher()
        {
            ListofPublishers = (await PublisherService.GetPublishers()).ToList();
        }

        protected async Task LoadAllCities()
        {
            ListofCities = (await cityService.GetCities()).ToList();
        }

        protected async Task CreatePublisher()
        {
            await PublisherService.AddPublisher(Publisher);
            Publisher = new Publishers();
            await LoadAllPublisher();
        }

        protected void ClearPublisher()
        {
            Publisher = new Publishers();
        }
        protected void PageChangedEvent(int PageNumber)
        {
            CurrentListPageNumber = PageNumber;
        }
        protected async Task AddPublisher(ListViewCommandEventArgs args)
        {
            var publisher = args.Item as Publishers;
            await PublisherService.AddPublisher(publisher);
            //await LoadAllPublisher();
        }
        protected async Task DeletePublisher(ListViewCommandEventArgs listViewCommandEventArgs)
        {
            var publisher = listViewCommandEventArgs.Item as Publishers;
            await PublisherService.DeletePublisher(publisher.Id);
            //await LoadAllPublisher();
        }

        protected async Task UpdatePublisher(ListViewCommandEventArgs args)
        {
            var publisher = args.Item as Publishers;
            var resp = await PublisherService.UpdatePublisher(publisher);
            //await LoadAllPublisher();
        }

        protected async Task EditHandler(ListViewCommandEventArgs args)
        {
            var publisher = args.Item as Publishers;
        }
        protected async Task CancelHandler(ListViewCommandEventArgs args)
        {
            var publisher = args.Item as Publishers;
        }

        protected async Task GetPublishersByPage(ListViewReadEventArgs args)
        {
            int pageNumber = args.Request.Page;
            int pageSize = args.Request.PageSize;
            PublishersByPage = await PublisherService.GetPublishersByPage(pageNumber, pageSize);
            args.Data = PublishersByPage;
            args.Total = (await PublisherService.GetPublishers()).Count();
        }
    }
}

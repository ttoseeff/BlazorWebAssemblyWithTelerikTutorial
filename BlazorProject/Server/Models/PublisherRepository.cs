using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.SvgIcons;

namespace BlazorProject.Server.Models
{
    public class PublisherRepository : IPublisherRepository
    {
        public AppDbContext Context { get; }
        public PublisherRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Publishers> CreatePublisher(Publishers publisher)
        {
            await Context.Publishers.AddAsync(publisher);
            await Context.SaveChangesAsync();
            return publisher;
        }

        public async Task<List<Publishers>> GetAllPublishers()
        {
            return await Context.Publishers
                .Include(x=> x.City)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task DeletePublisher(int Id)
        {
            var publisher = await Context.Publishers.FirstOrDefaultAsync(x => x.Id == Id);
            Context.Remove(publisher);
            await Context.SaveChangesAsync();
        }

        public async Task<Publishers> UpdatePublisher(Publishers publisher)
        {
            var publisherEntity = await Context.Publishers.FirstOrDefaultAsync(x => x.Id == publisher.Id);
            publisherEntity.CityId = publisher.CityId;
            publisherEntity.Name = publisher.Name;
            Context.Entry(publisherEntity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return publisherEntity;
        }

    }
}

using AutoMapper;
using BlazorProject.Client.Models;
using BlazorProject.Client.Services;
using BlazorProject.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;

namespace BlazorProject.Client.Pages.BooksPage
{
    public class BooksBase : ComponentBase
    {
        [Inject]
        public IBooksService _BooksService { get; set; }
        [Inject]
        public IAuthorsService _AuthorsService { get; set; }
        [Inject]
        public IBookTypesService _BookTypesService { get; set; }
        [Inject]
        public IMapper _Mapper { get; set; }
        public string PageTitle { get; set; } = "Books";
        public List<BooksDto> ListOfBooks { get; set; }
        public List<Author> ListOfAuthors { get; set; }
        public List<BookType> ListOfBookTypes { get; set; }
        protected int CurrentPage { get; set; } = 1;

        public TelerikGrid<BooksDto> BookGridRef { get; set; }

        protected string Title { get; set; } 
        protected string AutherName { get; set; }

        public BooksDto CurrentlyEditedItem { get; set; }
        protected IEnumerable<BooksDto> SelectedBooks { get; set; } = Enumerable.Empty<BooksDto>();

        public List<BooksDto> BooksByPage { get; set; }  = new List<BooksDto>();

        protected async override Task OnInitializedAsync()
        {
            //ListOfBooks = await GetAllBooks();
            ListOfAuthors  = await GetAllAuthors();
            ListOfBookTypes = await GetAllBookTypes();
        }

        protected async Task SortByColumn(string Member, ListSortDirection listSortDirection)
        {
            // set the sort Descripter
            SortDescriptor sortDescriptor = new SortDescriptor()
            {
                Member = Member,
                SortDirection = listSortDirection
            };

            // add sort descripter in an array of sort descriptors
            List<SortDescriptor> sortDescriptors = new List<SortDescriptor>() { sortDescriptor };

            // set sort descriptors in the grid state

            GridState<BooksDto> gridState = new GridState<BooksDto>()
            {
                SortDescriptors = sortDescriptors
            };

            await BookGridRef.SetStateAsync(gridState);
        }

        protected async Task FilterByTitleAndAutherName()
        {
            
            CompositeFilterDescriptor AuthorFilter = new CompositeFilterDescriptor()
            {
                FilterDescriptors = new FilterDescriptorCollection()
                        {
                            new FilterDescriptor() { Member = "Author.Name", Operator = FilterOperator.Contains, Value = AutherName, MemberType = typeof(string)}
                        }
            };

            CompositeFilterDescriptor titleFilter = new CompositeFilterDescriptor()
            {
                FilterDescriptors = new FilterDescriptorCollection()
                        {
                            new FilterDescriptor() { Member = "Title", Operator = FilterOperator.Contains, Value = Title, MemberType = typeof(string)}
                        }
            };

            List<IFilterDescriptor> filters = new List<IFilterDescriptor>() { titleFilter, AuthorFilter };

            GridState<BooksDto> gridState = new GridState<BooksDto>();
            gridState.FilterDescriptors = filters;

            await BookGridRef.SetStateAsync(gridState);
        }

        private async Task<List<BooksDto>> GetAllBooks()
        {
            List<Book> books = await _BooksService.GetAllBooks();
            ListOfBooks =  _Mapper.Map<List<BooksDto>>(books);
            return ListOfBooks;
        }

        private async Task<List<Author>> GetAllAuthors()
        {
            return await _AuthorsService.GetAllAuthors();
        }
        private async Task<List<BookType>> GetAllBookTypes()
        {
            return await _BookTypesService.GetAllBookTypes();
        }

        protected void OnStateInitHandler(GridStateEventArgs<BooksDto> args)
        {
            SortDescriptor sortDescriptor = new SortDescriptor()
            {
                Member = "Title",
                SortDirection = ListSortDirection.Ascending,
            };

            // add sort descripter in an array of sort descriptors
            List<SortDescriptor> sortDescriptors = new List<SortDescriptor>() { sortDescriptor };

            // set sort descriptors in the grid state

            GridState<BooksDto> gridState = new GridState<BooksDto>()
            {
                SortDescriptors = sortDescriptors
            };


            CompositeFilterDescriptor AuthorFilter = new CompositeFilterDescriptor()
            {
                FilterDescriptors = new FilterDescriptorCollection()
                        {
                            new FilterDescriptor() { Member = "Author.Name", Operator = FilterOperator.Contains, Value = AutherName, MemberType = typeof(string)}
                        }
            };

            CompositeFilterDescriptor titleFilter = new CompositeFilterDescriptor()
            {
                FilterDescriptors = new FilterDescriptorCollection()
                        {
                            new FilterDescriptor() { Member = "Title", Operator = FilterOperator.Contains, Value = Title, MemberType = typeof(string)}
                        }
            };

            List<IFilterDescriptor> filters = new List<IFilterDescriptor>() { titleFilter, AuthorFilter };

            gridState.FilterDescriptors = filters;

            // grouping 
            GroupDescriptor groupDescriptor = new GroupDescriptor()
            {
                Member = "BookType.Type",
                MemberType = typeof(string),
            };
            // add group descripter in an array of sort descriptors
            List<GroupDescriptor> groupDescriptors = new List<GroupDescriptor>() { groupDescriptor };
            // set group descriptors in the grid state
            //gridState.GroupDescriptors = groupDescriptors;


            args.GridState = gridState;

        }

        protected async Task DeleteBook(GridCommandEventArgs args)
        {
            var bookDto = args.Item as BooksDto;
            var book = _Mapper.Map<Book> (bookDto);
            await _BooksService.DeleteBook(book.Id);
            //ListOfBooks = await GetAllBooks();
        }

        protected async Task UpdateBook(GridCommandEventArgs args)
        {
            var bookDto = args.Item as BooksDto;
            var book = _Mapper.Map<Book>(bookDto);
            await _BooksService.UpdateBook(book);
            //ListOfBooks = await GetAllBooks();
        }
        protected async Task CreateBook(GridCommandEventArgs args)
        {
            var bookDto = args.Item as BooksDto;
            var book = _Mapper.Map<Book>(bookDto);
            await _BooksService.CreateBook(book);
            //ListOfBooks = await GetAllBooks();
        }

        protected void BeforeAddingBook(GridCommandEventArgs args)
        {
            args.Item = new Book()
            {
               Author = new Author(),
               BookType = new BookType()
            };
            args.IsCancelled = false;

        }

        protected void SelectedItemsChangedHanlder(IEnumerable<BooksDto> books)
        {
            SelectedBooks = books;
        }

        public async Task ReadEventHandler(GridReadEventArgs args)
        {
            int pageIndex = args.Request.Page;
            int pageSize = args.Request.PageSize;
            var books = await GetAllBooks(); // await _BooksService.GetBooksByPage(pageIndex, pageSize);
            BooksByPage = _Mapper.Map<List<BooksDto>>(books);
            var result = BooksByPage.ToDataSourceResult(args.Request);
            args.Data = result.Data;
            args.Total = (await GetAllBooks()).Count();
        }
    }
}

﻿using System.Linq;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Search
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;

        public SearchPresenter(ISearchView view, IProductService service, IViewModelFactory factory) : base(view)
        {
            this.service = service;
            this.factory = factory;

            this.View.MySearch += View_MySearch;
        }

        private void View_MySearch(object sender, SearchEventArgs e)
        {
            this.View.Model.Products = this.service.GetProducts()
                   .Select(p => this.factory.CreateProductDetailsViewModel(p.ProductId,
                       p.Name,
                   p.Category.Name,
                   p.Price,
                   p.Volume,
                   p.Maker,
                   p.ImageMimeType,
                   p.ImageBuffer));
        }
    }
}
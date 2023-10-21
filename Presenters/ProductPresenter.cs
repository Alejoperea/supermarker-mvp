using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket_mvp.Views;
using Supermarket_mvp.Models;


namespace Supermarket_mvp.Presenters
{
    internal class ProductPresenter
    {
        private IProductView view;
        private IProductRepository repository;
        private BindingSource productBindingSource;
        private IEnumerable<ProductsModel> productList;

        public ProductPresenter(IProductView view, IProductRepository repository)
        {
            this.view = view;
            this.repository = repository;


            this.view.SearchEvent += SearchProduct;
            this.view.AddNewEvent += AddNewProduct;
            this.view.EditEvent += LoadSelectProductToEdit;
            this.view.DeleteEvent += DeleteSelectedProduct;
            this.view.SaveEvent += SaveProduct;
            this.view.CancelEvent += CancelAction;

            this.view.SetProductListBildingSource(productBindingSource); // posible error aca

            loadAllProductList();

            this.view.Show();
        }

        private void loadAllProductList()
        {
            productList = repository.GetAll();
            productBindingSource.DataSource = productList;
        }

        private void SearchProduct(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                productList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                productList = repository.GetAll();
            }
            productBindingSource.DataSource = productList;
        }

        private void AddNewProduct(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectProductToEdit(object? sender, EventArgs e)
        {
            // se obtiene el objeto del datagridview que se encuntran selecionado 
            var productModel = (ProductsModel)productBindingSource.Current;

            //se cambia el contenido de las cajas de texto por el objeto recuperado 
            // del datagrie
            view.ProductsId = productModel.Id.ToString();
            view.ProductsName = productModel.Name;
            view.ProductsObservation = productModel.Observation;

            // se establece el modo como edificion 
            view.IsEdit = true;
        }

        private void DeleteSelectedProduct(object? sender, EventArgs e)
        {
            try
            // se recupera el objeto de la fila seleccionada del datagri
            {
                var productModel = (ProductsModel)productBindingSource.Current;
                // se invoca el metodo delete del repositorio pasandole el Id del Pay Mode
                repository.Delete(productModel.Id);
                view.IsSuccessful = true;
                view.Message = "Product deleted successfully";
                loadAllProductList();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not deleted product";
            }
        }

        private void SaveProduct(object? sender, EventArgs e)
        {
            // se crea un objeto de la clase paymode y se asigan los datos 
            // de las cajas de texto de la vista 
            var productModel = new ProductsModel();
            productModel.Id = Convert.ToInt32(view.ProductsId);
            productModel.Name = view.ProductsName;
            productModel.Observation = view.ProductsObservation;

            try
            {
                new Common.ModelDataValidation().Validate(productModel);
                if (view.IsEdit)
                {
                    repository.Edit(productModel);
                    view.Message = "Product edited successfuly";
                }
                else
                {
                    repository.Add(productModel);
                    view.Message = "PayMode added successfuly";
                }
                view.IsSuccessful = true;
                loadAllProductList();
                CleanViewFields();
            }
            catch (Exception ex)
            {

                // si ocurre una excepcion se configura IsSuccesfull en false 
                // y la propiedad Message de la vista se asigna de la exception
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.ProductsId = "0";
            view.ProductsName = "";
            view.ProductsObservation = "";
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }
    }
}

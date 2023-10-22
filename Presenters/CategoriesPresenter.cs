using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket_mvp.Views;
using Supermarket_mvp.Models;

namespace Supermarket_mvp.Presenters
{
    internal class CategoriesPresenter
    {
        private ICategoriesView view;
        private ICategoriesRepository repository;
        private BindingSource categoriesBindingSource;
        private IEnumerable<CategoriesModel> categoriesList;

        public CategoriesPresenter(ICategoriesView view, ICategoriesRepository repository)
        {
            this.categoriesBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchCategories;
            this.view.AddNewEvent += AddNewCategories;
            this.view.EditEvent += LoadSelectCategoriesToEdit;
            this.view.DeleteEvent += DeleteSelectedCategories;
            this.view.SaveEvent += SaveCategories;
            this.view.CancelEvent += CancelAction;

            this.view.SetCategoriesListBildingSource(categoriesBindingSource);

            loadAllCategoriesList();

            this.view.Show();
        }

        private void loadAllCategoriesList()
        {
            categoriesList = repository.GetAll();
            categoriesBindingSource.DataSource = categoriesList;
        }

        private void SearchCategories(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                categoriesList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                categoriesList = repository.GetAll();
            }
            categoriesBindingSource.DataSource = categoriesList;
        }

        private void AddNewCategories(object? sender, EventArgs e)
        {
            view.IsEdit = false;
            //MessageBox.Show("Hizo Clic en el boton nuevo");
        }

        private void LoadSelectCategoriesToEdit(object? sender, EventArgs e)
        {
            // se obtiene el objeto del datagridview que se encuntran selecionado 
            var categoriesMode = (CategoriesModel)categoriesBindingSource.Current;

            //se cambia el contenido de las cajas de texto por el objeto recuperado 
            // del datagrie
            view.CategoriesId = categoriesMode.Id.ToString();
            view.CategoriesName = categoriesMode.Name;
            view.CategoriesName = categoriesMode.Observation;

            // se establece el modo como edificion 
            view.IsEdit = true;
        }

        private void DeleteSelectedCategories(object? sender, EventArgs e)
        {
            try
            // se recupera el objeto de la fila seleccionada del datagri
            {
                var categoriesMode = (CategoriesModel)categoriesBindingSource.Current;
                // se invoca el metodo delete del repositorio pasandole el Id del Pay Mode
                repository.Delete(categoriesMode.Id);
                view.IsSuccessful = true;
                view.Message = "Categories deleted successfully";
                loadAllCategoriesList();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not deleted categories";
            }
        }

        private void SaveCategories(object? sender, EventArgs e)
        {
            // se crea un objeto de la clase paymode y se asigan los datos 
            // de las cajas de texto de la vista 
            var categoriesMode = new CategoriesModel();
            categoriesMode.Id = Convert.ToInt32(view.CategoriesId);
            categoriesMode.Name = view.CategoriesName;
            categoriesMode.Observation = view.CategoriesObservation;

            try
            {
                new Common.ModelDataValidation().Validate(categoriesMode);
                if (view.IsEdit)
                {
                    repository.Edit(categoriesMode);
                    view.Message = "Categories edited successfuly";
                }
                else
                {
                    repository.Add(categoriesMode);
                    view.Message = "Categories added successfuly";
                }
                view.IsSuccessful = true;
                loadAllCategoriesList();
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
            view.CategoriesId = "0";
            view.CategoriesName = "";
            view.CategoriesObservation = "";
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }
    }
}

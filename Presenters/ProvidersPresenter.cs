using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket_mvp.Views;
using Supermarket_mvp.Models;

namespace Supermarket_mvp.Presenters
{
    internal class ProvidersPresenter
    {
        private IProvidersView view;
        private IProvidersRepository repository;
        private BindingSource providersBindingSource;
        private IEnumerable<ProvidersModel> providersModeList;

        public ProvidersPresenter(IProvidersView view, IProvidersRepository repository)
        {
            this.providersBindingSource = new BindingSource();

            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchProviders;
            this.view.AddNewEvent += AddNewProviders;
            this.view.EditEvent += LoadSelectProvidersToEdit;
            this.view.DeleteEvent += DeleteSelectedProviders;
            this.view.SaveEvent += SaveProviders;
            this.view.CancelEvent += CancelAction;

            this.view.SetProvidersListBildingSource(providersBindingSource);

            loadAllProvidersList();

            this.view.Show();
        }

        private void loadAllProvidersList()
        {
            providersModeList = repository.GetAll();
            providersBindingSource.DataSource = providersModeList;
        }

        private void SearchProviders(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                providersModeList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                providersModeList = repository.GetAll();
            }
            providersBindingSource.DataSource = providersModeList;
        }

        private void AddNewProviders(object? sender, EventArgs e)
        {
            view.IsEdit = false;
            //MessageBox.Show("Hizo Clic en el boton nuevo");
        }

        private void LoadSelectProvidersToEdit(object? sender, EventArgs e)
        {
            // se obtiene el objeto del datagridview que se encuntran selecionado 
            var providersMode = (ProvidersModel)providersBindingSource.Current;

            //se cambia el contenido de las cajas de texto por el objeto recuperado 
            // del datagrie
            view.ProvidersId = providersMode.Id.ToString();
            view.ProvidersName = providersMode.Name;
            view.ProvidersObservation = providersMode.Observation;

            // se establece el modo como edificion 
            view.IsEdit = true;
        }

        private void DeleteSelectedProviders(object? sender, EventArgs e)
        {
            try
            // se recupera el objeto de la fila seleccionada del datagri
            {
                var providersMode = (ProvidersModel)providersBindingSource.Current;
                // se invoca el metodo delete del repositorio pasandole el Id del Providers
                repository.Delete(providersMode.Id);
                view.IsSuccessful = true;
                view.Message = "Providers deleted successfully";
                loadAllProvidersList();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not deleted providers";
            }
        }

        private void SaveProviders(object? sender, EventArgs e)
        {
            // se crea un objeto de la clase paymode y se asigan los datos 
            // de las cajas de texto de la vista 
            var providersMode = new ProvidersModel();
            providersMode.Id = Convert.ToInt32(view.ProvidersId);
            providersMode.Name = view.ProvidersName;
            providersMode.Observation = view.ProvidersObservation;

            try
            {
                new Common.ModelDataValidation().Validate(providersMode);
                if (view.IsEdit)
                {
                    repository.Edit(providersMode);
                    view.Message = "Providers edited successfuly";
                }
                else
                {
                    repository.Add(providersMode);
                    view.Message = "Providers added successfuly";
                }
                view.IsSuccessful = true;
                loadAllProvidersList();
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
            view.ProvidersId = "0";
            view.ProvidersName = "";
            view.ProvidersObservation = "";
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }
    }
}

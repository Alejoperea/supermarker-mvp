using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket_mvp.Views;
using Supermarket_mvp.Models;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace Supermarket_mvp.Presenters
{
    internal class PayModePresenter
    {
        private IPayModeView view;
        private IPayModeRepository repository;
        private BindingSource payModeBindingSource;
        private IEnumerable<PayModeModel> payModeList;

        public PayModePresenter(IPayModeView view, IPayModeRepository repository)
        {
            this.payModeBindingSource = new BindingSource();
           
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchPayMode;
            this.view.AddNewEvent += AddNewPayMode;
            this.view.EditEvent += LoadSelectPayModeToEdit;
            this.view.DeleteEvent += DeleteSelectedPayMode;
            this.view.SaveEvent += SavePayMode;
            this.view.CancelEvent += CancelAction;

            this.view.SetPayModeListBildingSource(payModeBindingSource);

            loadAllPayModeList();

            this.view.Show();
        }

        private void loadAllPayModeList()
        {
            payModeList = repository.GetAll();
            payModeBindingSource.DataSource = payModeList;
        }

        private void SearchPayMode(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue== false)
            {
                payModeList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                payModeList = repository.GetAll();
            }
            payModeBindingSource.DataSource = payModeList;
        }

        private void AddNewPayMode(object? sender, EventArgs e)
        {
             view.IsEdit = false;
            // MessageBox.Show("Hizo Clic en el boton nuevo");
        }

        private void LoadSelectPayModeToEdit(object? sender, EventArgs e)
        {
            // se obtiene el objeto del datagridview que se encuntran selecionado 
            var payMode = (PayModeModel)payModeBindingSource.Current;

            //se cambia el contenido de las cajas de texto por el objeto recuperado 
            // del datagrie
            view.PayModeId = payMode.Id.ToString();
            view.PayModeName = payMode.Name;
            view.PayModeObservation = payMode.Observation;

            // se establece el modo como edificion 
            view.IsEdit = true;
        }

        private void DeleteSelectedPayMode(object? sender, EventArgs e)
        {
            try
                // se recupera el objeto de la fila seleccionada del datagri
            {
                var payMode = (PayModeModel)payModeBindingSource.Current;
                // se invoca el metodo delete del repositorio pasandole el Id del Pay Mode
                repository.Delete(payMode.Id);
                view.IsSuccessful = true;
                view.Message = "Pay Mode deleted successfully";
                loadAllPayModeList();
            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not deleted pay mode";
            }
        }

        private void SavePayMode(object? sender, EventArgs e)
        {
            // se crea un objeto de la clase paymode y se asigan los datos 
            // de las cajas de texto de la vista 
            var payMode = new PayModeModel();
            payMode.Id = Convert.ToInt32(view.PayModeId);
            payMode.Name = view.PayModeName;
            payMode.Observation = view.PayModeObservation;

            try
            {
                new Common.ModelDataValidation().Validate(payMode);
                if (view.IsEdit)
                {
                    repository.Edit(payMode);
                    view.Message = "PayMode edited successfuly";
                }
                else
                {
                    repository.Add(payMode);
                    view.Message = "PayMode added successfuly";
                }
                view.IsSuccessful = true;
                loadAllPayModeList();
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
            view.PayModeId = "0";
            view.PayModeName = "";
            view.PayModeObservation = "";
        }
        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }
    }

        
}

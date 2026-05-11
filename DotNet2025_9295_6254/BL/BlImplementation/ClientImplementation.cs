using BlApi;
using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlImplementation
{
    internal class ClientImplementation : IClient
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        int Icrud<Client>.Create(Client client)
        {
            try
            {
                return _dal.Customer.Create(client.convert());
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Failed to create client with ID {client.Id}: Client already exists.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to create client with ID {client.Id}: {ex.Message}", ex);
            }
        }

   
        void Icrud<Client>.Delete(int id)
        {
            try
            {
                _dal.Customer.Delete(id);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Failed to delete client with ID {id}: Client does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to delete client with ID {id}: {ex.Message}", ex);
            }
        }


        bool IClient.Exists(int id)
        {
            try
            {
                var customer = _dal.Customer.Read(id);
                return customer != null;
            }
            catch (DO.DalDoesNotExistException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to check if client with ID {id} exists: {ex.Message}", ex);
            }
        }


        Client? Icrud<Client>.Get(int id)
        {
            try
            {
                var dalCustomer = _dal.Customer.Read(id);
                return dalCustomer?.convert();
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Failed to get client with ID {id}: Client does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to get client with ID {id}: {ex.Message}", ex);
            }
        }

    

        Client Icrud<Client>.Get(Func<Client, bool> filter)
        {
           return GetAll(filter).FirstOrDefault() ?? throw new BO.BlDoesNotExistException("No client found matching the provided filter.");
        }

     

        IEnumerable<Client> GetAll(Func<Client, bool> filter = null)
        {
            try
            {
                var dalCustomers = _dal.Customer.ReadAll();
                if (filter == null)
                    return dalCustomers.Select(c=>c.convert());
                var boClients = dalCustomers.Select(c => c.convert());
                return boClients.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to get clients with filter: {ex.Message}", ex);
            }
        }

        IEnumerable<Client> Icrud<Client>.GetAll(Func<Client, bool> filter)
        {
            return GetAll(filter);
        }

        void Icrud<Client>.Update(Client client)
        {
            try
            {
                _dal.Customer.Update(client.convert());
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Failed to update client with ID {client.Id}: Client does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to update client with ID {client.Id}: {ex.Message}", ex);
            }
        }
    }
}

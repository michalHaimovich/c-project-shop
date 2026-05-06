using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;

namespace BlImplementation
{
    internal class ClientImplementation : IClient
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        void IClient.Create(Client client)
        {
            try
            {
                _dal.Customer.Create(client.convert());
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

        void IClient.Delete(int id)
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

        Client? IClient.Get(int id)
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

        IEnumerable<Client> IClient.GetAll()
        {
            try
            {
                var dalCustomers = _dal.Customer.ReadAll();
                return dalCustomers.Select(c => c.convert()).ToList();
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to get all clients: {ex.Message}", ex);
            }
        }

        IEnumerable<Client> IClient.GetAll(Func<Client, bool> filter)
        {
            try
            {
                var dalCustomers = _dal.Customer.ReadAll();
                var boClients = dalCustomers.Select(c => c.convert());
                return boClients.Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to get clients with filter: {ex.Message}", ex);
            }
        }

        Client? IClient.Read(Func<Client, bool> filter)
        {
            try
            {
                var allClients = _dal.Customer.ReadAll();
                var boClients = allClients.Select(c => c.convert());
                return boClients.FirstOrDefault(filter);
            }
            catch (Exception ex)
            {
                throw new BO.BlInvalidInputException($"Failed to read client with filter: {ex.Message}", ex);
            }
        }

        void IClient.Update(Client client)
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

using System;
using System.Linq;
using System.ServiceModel;
using Ninject;
using Ninject.Extensions.Interception;
using IInterceptor = Ninject.Extensions.Interception.IInterceptor;
using System.Transactions;
using OnlineBookStore.Common.Services;

namespace OnlineBookStore.ServiceHost.Infrastructure
{
    public class ServiceInterceptor : IInterceptor
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("OnlineBookStoreLogger");
        private void SetupRequestContext(IInvocation invocation)
        {
            //var item = invocation.Request.Arguments.ToArray().FirstOrDefault();
            //var request = item as DataManipulationRequest;

            //if (request != null)
            //{
            //    var requestContext = invocation.Request.Context.Kernel.Get<RequestContext>();
            //    requestContext.Init(request);
            //}

        }
        public void Intercept(IInvocation invocation)
        {
            try
            {

                // HACK: Usunięto domyślne transakcje dla wszystkich metod.
                // Proszę używać jawnie transakcji oznaczając metodę atrybutem [OperationBehavior(TransactionScopeRequired = true)]
                // Używamy transakcji na wszystkich metodach 
                // - insert/update/delete
                // - select - tylko gdy wykonujemy wiele zapytań do bazy np. metoda GetEvents. Transakcje zapewnia spójność danych

                if (log.IsInfoEnabled)
                    log.InfoFormat("Calling {0}.{1}", invocation.Request.Target.GetType(), invocation.Request.Method.Name);

                SetupRequestContext(invocation);

                using (
                        var scope = new TransactionScope(TransactionScopeOption.Required,
                            new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }))
                {
                    invocation.Proceed();
                    scope.Complete();
                    log.Debug("TransactionScope Completed");
                }

            }
            catch (FaultException<ValidationFault> ex)
            {
                if (log.IsInfoEnabled)
                    log.Info(string.Join(". ", ex.Detail.ExceptionMessages), ex);
                throw;
            }
            catch (FaultException<ProcessFault> ex)
            {
                log.Error(string.Join(". ", ex.Detail.ExceptionMessages), ex);
                throw;
            }
            catch (FaultException<ResponseFault> ex)
            {
                log.Error(string.Join(". ", ex.Detail.ExceptionMessages), ex);
                throw;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);

                if (ex is FaultException || ex is CommunicationException || ex is TimeoutException)
                {
                    throw;
                }
                else
                {
                    throw new FaultException(ex.Message);
                }
            }
        }
    }
}
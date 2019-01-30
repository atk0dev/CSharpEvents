using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopSample
{
    class Worker
    {
        private IService _service;

        public Worker()
        {
            this._service = new Service();
        }

        public void DoSomething1()
        {
            try
            {
                // perform an action
                _service.Do();
            }
            catch (Exception ex)
            {
                // log exception
                Log(ex);
                _service.Abort();
            }
            finally
            {
                // clean up resources 
                _service.Close();
            }
        }

        public void DoSomething2()
        {
            this.Invoke(s => s.Do());   
        }

        public string DoSomething3()
        {
            return this.InvokeAndReturn(s => s.DoAndReturn());
        }

        private void Log(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        private void Invoke(Action<IService> action)
        {
            try
            {
                // perform an action
                action(this._service);
            }
            catch (Exception ex)
            {
                this.Log(ex);
                this._service.Abort();
            }
            finally
            {
                this._service.Close();
            }
        }

        private string InvokeAndReturn(Func<IService, string> func)
        {
            try
            {
                // perform an action
                return func(this._service);
            }
            catch (Exception ex)
            {
                this.Log(ex);
                this._service.Abort();
                return string.Empty;
            }
            finally
            {
                this._service.Close();
            }
        }
    }
}

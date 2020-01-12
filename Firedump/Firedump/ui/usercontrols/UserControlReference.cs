using Firedump.models.events;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.usercontrols
{
    public  class UserControlReference : UserControl
    {
        // Composition
        private readonly IParentRef parent;

        // this default constructor exists only for the visual studio incapability 
        // and bugs causing missing and error forms render in editor
        public UserControlReference() : base()
        {
        }

        // IoT
        public UserControlReference(IParentRef parentRef) : this()
        {
            this.parent = parentRef;
        }

        internal bool isConnected()
        {
            return parent.GetConnection() != null && parent.GetConnection().State == System.Data.ConnectionState.Open;
        }

        /**
         * Global method, will show warn dialog,(not connected...)
         */
        internal bool checkConnection()
        {
            return this.isConnected() && !string.IsNullOrEmpty(parent.GetConnection().Database);
        }

        internal void changeDatabase(string database)
        {
            if(this.isConnected())
            {
                parent.GetConnection().ChangeDatabase(database);
                this.OnConnectionChanged(this,new ConChangedEventArgs(parent.GetConnection()));
            }
        }

        internal DbConnection GetSqlConnection()
        {
            return parent.GetConnection();
        }

        internal sqlservers GetServer()
        {
            return parent.GetServer();
        }

        internal virtual void dataReceived(ITriplet<UserControlReference, UserControlReference, object> triplet)
        {
        }

        //Event handlers
        public event EventHandler Disconnected;
        internal virtual void OnDisconnected(object t, EventArgs e)
        {
            Disconnected?.Invoke(t, e);
        }
        internal virtual void onConnected() {
        }

        internal virtual void onDisconnect()
        {
        }


        public event EventHandler<ConChangedEventArgs> ConnectionChanged;
        internal virtual void OnConnectionChanged(object t, ConChangedEventArgs e)
        {
            ConnectionChanged?.Invoke(t, e);
        }


        public event EventHandler<object> Send;
        internal virtual void OnSend(object sender,object e)
        {
            Send?.Invoke(sender, e);
        }

    }
}

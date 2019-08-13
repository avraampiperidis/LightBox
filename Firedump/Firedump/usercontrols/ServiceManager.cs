using System;
using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;

namespace Firedump.usercontrols
{
    public partial class ServiceManager : UserControl
    {
        public ServiceManager()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="active">is the service running now or not</param>
        public void setPictureIcon(bool isActive)
        {
            pbStatus.Image = isActive ? Properties.Resources.greencircle : Properties.Resources.redcircle;
        }

        public void setStatusText(string info)
        {
            lStatus.Text = info;
        }

        /// <summary>
        /// See ServiceControllerStatus for enum info
        /// </summary>
        /// <returns>serviceController.Status enum, null if service is not installed</returns>
        public ServiceController GetServiceStatus()
        {
            return ServiceController.GetServices()
               .FirstOrDefault(s => s.ServiceName == Consts.SERVICE_NAME);
        }

        
        private bool isServiceInstalled()
        {
            return ServiceController.GetServices()
                .FirstOrDefault(s => s.ServiceName == Consts.SERVICE_NAME) != null;  
        }


        //--->Click events for buttons
        private void install_service_click(object sender, EventArgs e)
        {
            //check to see if the service is already installed
            ServiceController sc = GetServiceStatus();
            if (sc != null)
            {
                MessageBox.Show("Service is already installed");
                return;
            }

            //if use choose no from admin request access Win32Exception is raysed
            try {
                //install and start the service
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "serviceinstall.bat",
                        UseShellExecute = true,
                        Verb = "runas",
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                proc.WaitForExit();
            }catch(Exception ex)
            {
            }

            //after that , check to see if the service installed successfully and if its running
            sc = GetServiceStatus();
            if (sc == null)
            {
                Console.WriteLine("INSTALL:NULL");
                setPictureIcon(false);
                setStatusText("Error something went wrong installing the service");
            }
            else
            {
                Console.WriteLine("INSTALL:"+sc.Status);
                switch (sc.Status)
                {                  
                    case ServiceControllerStatus.Running:
                        setPictureIcon(true);
                        setStatusText("firedump Service Installed and Running");
                        break;
                    default:
                        {
                            setPictureIcon(false);
                            setStatusText("Error something went wrong installing the service");
                            break;
                        }

                }

            }
        }

        private void uninstall_service_click(object sender, EventArgs e)
        {
            //check to see if the service is installed
            ServiceController sc = GetServiceStatus();
            if (sc == null)
            {
                setPictureIcon(false);
                setStatusText("Service is not installed");
                return;
            }

            try
            {
                //Uninstall  the service
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "serviceuninstall.bat",
                        UseShellExecute = true,
                        Verb = "runas",
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                proc.WaitForExit();

            }
            catch (Exception ex)
            {
            }
            
            //after that , check to see if the service started successfully 
            sc = GetServiceStatus();
            if (sc == null)
            {
                setPictureIcon(false);
                setStatusText("Service Removed");
            }
            else
            {
                //error uninstalling
            }
        }

        private void start_service_click(object sender, EventArgs e)
        {
            //check to see if the service is already running
            ServiceController sc = GetServiceStatus();
            if(sc == null)
            {
                setStatusText("Service is not installed");
                setPictureIcon(false);
                return;
            }

            if (sc != null)
            {
                if (sc.Status == ServiceControllerStatus.Running) {
                    setStatusText("Service is already running");
                    return;
                }
                else if (sc.Status == ServiceControllerStatus.StartPending) {
                    setStatusText("Service is starting");
                    return;
                }
                else if (sc.Status == ServiceControllerStatus.StopPending) {
                    setStatusText("Service is stoping");
                    return;
                }
                else if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    return;
                }
                    
            }

            if(sc.Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    //Start  the service
                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "servicestart.bat",
                            UseShellExecute = true,
                            Verb = "runas",
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (Exception ex) { }

                //after that , check to see if the service started successfully 
                sc = GetServiceStatus();
                if (sc == null)
                {
                    setStatusText("Error, cant start the service");
                    setPictureIcon(false);
                }
                else
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        setStatusText("Service started");
                        setPictureIcon(true);
                    }

                }
            }
           
        }


        private void stop_service_click(object sender, EventArgs e)
        {
            //check to see if the service is already stoped
            ServiceController sc = GetServiceStatus();
            if(sc == null)
            {
                setStatusText("Service is not installed");
                setPictureIcon(false);
                return;
            }

            if (sc != null)
            {
                if (sc.Status == ServiceControllerStatus.StopPending)
                {
                    setStatusText("Service is stoping");
                    return;
                }
                else if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    setStatusText("Service is not running");
                    return;
                }

            }

            if (sc.Status == ServiceControllerStatus.Running)
            {
                try
                {
                    //Stop  the service
                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "servicestop.bat",
                            UseShellExecute = true,
                            Verb = "runas",
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (Exception ex) { }

                //after that , check to see if the service started successfully 
                sc = GetServiceStatus();
                if (sc == null)
                    setStatusText("Error, cant stop the service");
                else
                {
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        setStatusText("Service Stoped");
                        setPictureIcon(false);
                    }
                        
                }
            } 
        }
    }
}

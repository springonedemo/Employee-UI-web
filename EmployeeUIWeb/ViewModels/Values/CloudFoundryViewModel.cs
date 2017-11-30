using Steeltoe.Extensions.Configuration.CloudFoundry;


namespace CloudFoundry.ViewModels.Values
{
    public class CloudFoundryViewModel
    {
        public CloudFoundryViewModel(CloudFoundryApplicationOptions appOptions, CloudFoundryServicesOptions servOptions)
        {
            CloudFoundryServices = servOptions;
            CloudFoundryApplication = appOptions;
        }
        public CloudFoundryServicesOptions CloudFoundryServices { get;}
        public CloudFoundryApplicationOptions CloudFoundryApplication { get;}
    }
}

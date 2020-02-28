using System.Web;


namespace AMSWeb.Models
{
    public class UserSession
        {
            private static UserSession instance = null;
            private static readonly object padlock = new object();

            UserSession()
            {
            }

            public static UserSession Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (padlock)
                        {
                            if (instance == null)
                            {
                                instance = new UserSession();
                            }
                        }
                    }
                    return instance;
                }
            }
            public bool getname()
            {
                if (HttpContext.Current.Session["userName"] == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

    }

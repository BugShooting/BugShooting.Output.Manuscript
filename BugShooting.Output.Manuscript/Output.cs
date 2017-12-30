using BS.Plugin.V3.Output;

namespace BugShooting.Output.Manuscript
{

  public class Output: IOutput 
  {
    
    string name;
    string url;
    int lastCaseID;

    public Output(string name, 
                  string url, 
                  int lastCaseID)
    {
      this.name = name;
      this.url = url;
      this.lastCaseID = lastCaseID;
    }
    
    public string Name
    {
      get { return name; }
    }

    public string Information
    {
      get { return url; }
    }

    public string Url
    {
      get { return url; }
    }
       
    public int LastCaseID
    {
      get { return lastCaseID; }
    }

  }
}

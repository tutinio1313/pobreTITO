namespace pobreTITO_Models 
{
    public class Response
    {
        public bool StateExecution {get; set;}
        public List<string> Messages {get; set;} = new List<string>();   
    }    
}
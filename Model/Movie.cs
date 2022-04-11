using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MicaMatherialGhibli.Model
{
    public class Movie : ObservableObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string image { get; set; }
        public string original_title_romanised { get; set; }
        public string description { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string running_time { get; set; }
        public string rt_score { get; set; }
    }
}
